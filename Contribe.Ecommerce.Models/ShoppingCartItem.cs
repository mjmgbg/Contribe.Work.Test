using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Models
{
	public class ShoppingCartItem : IShoppingCartItem
	{
		public IBook Book { get; set; }
		public int Quantity { get; set; }
		public bool IsNotInStock { get; set; }
	}
}
