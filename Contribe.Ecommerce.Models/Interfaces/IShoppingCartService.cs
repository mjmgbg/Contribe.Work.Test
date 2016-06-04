using System.Collections.Generic;

namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IShoppingCartService
	{
		int TotalQuantity { get; set; }
		List<IShoppingCartItem> Items { get; set; }
		void AddItem(IBook book, int quantity);
		void Remove(int id);
		decimal GetCartTotal();
		void Clear();
		void Edit(int id, int quantity);
		void GetTotalCount();
		bool CheckStockQuantity(int quantity, IShoppingCartItem item);
		int GetTotalBookInCart(int id);
		IShoppingCartService Create();
		IShoppingCartService CreateCopy();
	}
}