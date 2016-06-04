using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Web.ViewModels
{
	public class CreateOrderViewModel
	{
		public IShoppingCartService Cart { get; set; }
		public ContactViewModel OrderInfo { get; set; }
	}
}
