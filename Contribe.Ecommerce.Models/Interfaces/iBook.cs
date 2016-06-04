namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IBook
	{
		int BookId { get; set; }
		string Author { get; set; }
		string Title { get; set; }
		decimal Price { get; set; }
		int InStock { get; set; }
	}
}
