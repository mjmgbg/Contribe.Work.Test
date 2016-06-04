using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Models
{
	public class Book : IBook
	{
		public int BookId { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public int InStock { get; set; }
		public bool IsInDb { get; set; }
		public override bool Equals(object obj)
		{
			if (obj == null) { return false; }
			if (!(obj is Book)) { return false; }
			return Author == ((Book)obj).Author
				   && Title == ((Book)obj).Title;
		}

		public override int GetHashCode()
		{
			return Author.GetHashCode() ^ Title.GetHashCode();
		}
	}
}
