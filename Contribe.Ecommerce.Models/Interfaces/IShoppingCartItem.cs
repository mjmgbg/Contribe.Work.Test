namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IShoppingCartItem
	{
		IBook Book { get; set; }
		int Quantity { get; set; }
		bool IsNotInStock { get; set; }
	}
}
