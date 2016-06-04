using Contribe.Ecommerce.Data.Repositories;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Data
{


	public class UnitOfWork : IUnitOfWork
	{
		private readonly EcommerceContext _context;
		public IRepositoryBase<Book> Books { get; private set; }
		public IRepositoryBase<Customer> Customers { get; private set; }
		public IAddressRepository<Address> Addresses { get; private set; }
		public IRepositoryBase<Order> Orders { get; private set; }
		public IRepositoryBase<OrderDetail> OrderDetails { get; private set; }



		public UnitOfWork(EcommerceContext context)
		{
			_context = context;
			Books = new RepositoryBase<Book>(_context);
			Customers = new RepositoryBase<Customer>(_context);
			Addresses = new AddressRepository(_context);
			Orders = new RepositoryBase<Order>(_context);
			OrderDetails = new RepositoryBase<OrderDetail>(_context);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
