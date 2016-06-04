using System.Collections.Generic;
using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Web.ViewModels
{
	public class StartPageViewModel
	{
		public IEnumerable<IBook> BookList { get; set; }
		public bool NoSearchResultFound { get; set; }
		public string SearchTerm { get; set; }

		public StartPageViewModel()
		{
			BookList = new List<IBook>();
		}
	}
}
