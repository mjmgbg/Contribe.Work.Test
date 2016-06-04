using Contribe.Ecommerce.Data;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;
using System;

namespace Contribe.Ecommerce.Services
{
	public class OrderService
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public bool ProcessOrder(IAddress address, ICustomer customer, IShoppingCartService cart, string comment)
		{
			var dbAddress = GetAddressByStreetOrAddToDb(address);
			var dbCustomer = GetCustomerByIdOrAddToDb(customer, dbAddress.AddressId);
			dbCustomer.AddressId = dbAddress.AddressId;
			try
			{
				var order = SaveOrder(cart, comment, dbCustomer);
				return order != null && SaveOrderDetails(cart, order);
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool SaveOrderDetails(IShoppingCartService cart, IOrder order)
		{
			try
			{
				foreach (var item in cart.Items)
				{
					if (item.Quantity > item.Book.InStock) { return false; }
					var orderDetail = new OrderDetail
					{
						OrderId = order.OrderId,
						Book = _unitOfWork.Books.GetById(item.Book.BookId),
						QuantityOrdered = item.Quantity,
					};
					_unitOfWork.OrderDetails.Insert(orderDetail);
					var bookBought = _unitOfWork.Books.GetById(item.Book.BookId);
					bookBought.InStock -= item.Quantity;
				}
				_unitOfWork.Save();

				return true;
			}
			catch (Exception)
			{

				return false;
			}

		}

		private IOrder SaveOrder(IShoppingCartService cart, string comment, ICustomer customer)
		{
			try
			{
				var order = new Order
				{
					Customer = customer as Customer,
					CustomerId = customer.CustomerId,
					TotalPrice = cart.GetCartTotal(),
					OrderDate = DateTime.Now,
					Comment = comment,
				};
				_unitOfWork.Orders.Insert(order);
				_unitOfWork.Save();
				return order;
			}
			catch (Exception)
			{

				return null;
			}


		}

		private IAddress GetAddressByStreetOrAddToDb(IAddress address)
		{
			var dbAddress = _unitOfWork.Addresses.GetByAddressAndZipCodeId(address.Street, address.City);
			return dbAddress ?? AddAddressToDb(address);
		}

		private IAddress AddAddressToDb(IAddress address)
		{
			var dbAddress = new Address
			{
				City = address.City,
				Street = address.Street,
				ZipCode = address.ZipCode,

			};
			_unitOfWork.Addresses.Insert(dbAddress);
			_unitOfWork.Save();
			return dbAddress;
		}
		private ICustomer GetCustomerByIdOrAddToDb(ICustomer customer, int addressId)
		{
			var dbCustomer = _unitOfWork.Customers.GetById(customer.CustomerId);
			return dbCustomer ?? AddCustomerToDB(customer, addressId);
		}

		private ICustomer AddCustomerToDB(ICustomer customer, int addressId)
		{
			var dbCustomer = new Customer
			{
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				CellPhoneNumber = customer.CellPhoneNumber,
				Email = customer.Email,
				AddressId = addressId
			};
			_unitOfWork.Customers.Insert(dbCustomer);
			_unitOfWork.Save();
			return dbCustomer;
		}
	}
}