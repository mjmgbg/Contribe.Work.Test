using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Contribe.Ecommerce.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private List<IShoppingCartItem> items;

		public int TotalQuantity { get; set; }
		public List<IShoppingCartItem> Items
		{
			get { return items; }
			set { items = value; }
		}

		public ShoppingCartService(List<IShoppingCartItem> items)
		{
			this.items = items;
		}
		public IShoppingCartService Create()
		{
			return new ShoppingCartService(new List<IShoppingCartItem>());
		}
		public void AddItem(IBook book, int quantity)
		{
			IShoppingCartItem item = items.SingleOrDefault(b => b.Book.BookId == book.BookId);
			if (item == null)
			{
				items.Add(new ShoppingCartItem
				{
					Book = book,
					Quantity = quantity
				});
				GetTotalCount();
				items[0].IsNotInStock = CheckStockQuantity(quantity, items[0]);
				if (items[0].IsNotInStock)
				{
					items[0].Quantity = items[0].Book.InStock;
					GetTotalCount();
				}
			}
			else
			{
				item.Quantity += quantity;
				GetTotalCount();
				item.IsNotInStock = CheckStockQuantity(quantity, item);
				if (item.IsNotInStock)
				{
					item.Quantity = item.Book.InStock;
					GetTotalCount();
				}
			}
		}

		public void Remove(int id)
		{
			items.RemoveAll(b => b.Book.BookId == id);
			GetTotalCount();

		}

		public decimal GetCartTotal()
		{
			return items.Sum(b => b.Book.Price * b.Quantity);
		}

		public void Clear()
		{
			items.Clear();
			TotalQuantity = 0;
		}
		public IShoppingCartService CreateCopy()
		{
			var service = new ShoppingCartService(new List<IShoppingCartItem>());
			foreach (var item in items)
			{
				service.Items.Add(item);
			}

			return service;
		}

		public void Edit(int id, int quantity)
		{
			IShoppingCartItem item = items.SingleOrDefault(b => b.Book.BookId == id);
			if (item == null) return;
			item.Quantity = quantity;
			GetTotalCount();
			item.IsNotInStock = CheckStockQuantity(quantity, item);

			if (!item.IsNotInStock) return;
			item.Quantity = item.Book.InStock;
			GetTotalCount();
		}

		public void GetTotalCount()
		{
			TotalQuantity = 0;
			foreach (var item in Items)
			{
				TotalQuantity += item.Quantity;
			}
		}

		public bool CheckStockQuantity(int quantity, IShoppingCartItem item)
		{
			var bookInCart = GetTotalBookInCart(item.Book.BookId);
			quantity += bookInCart;

			return item.Book.InStock < quantity;
		}
		public int GetTotalBookInCart(int id)
		{
			var quantity = 0;
			foreach (var item in Items.Where(item => item.Book.BookId == id))
			{
				quantity = item.Quantity;
			}
			return quantity;

		}
	}
}