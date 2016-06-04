using System.Collections.Generic;

namespace Contribe.Ecommerce.Models
{
	public class JsonRootObject
	{
		public List<Book> Books { get; set; }

		public JsonRootObject()
		{
			Books = new List<Book>();
		}
	}

}
