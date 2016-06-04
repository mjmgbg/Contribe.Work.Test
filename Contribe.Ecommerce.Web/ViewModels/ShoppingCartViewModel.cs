using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Web.ViewModels
{
	public class ShoppingCartViewModel
	{
		public IShoppingCartService Cart { get; set; }
		public string ReturnUrl { get; set; }
	}
}