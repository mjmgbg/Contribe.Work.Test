using Contribe.Ecommerce.Models;
using System.ComponentModel;

namespace Contribe.Ecommerce.Web.ViewModels
{
	public class ContactViewModel
	{
		public Address Address { get; set; }
		public Customer Contact { get; set; }
		public string ReturnUrl { get; set; }
		[DisplayName("Eventuell kommentar")]
		public string Comment { get; set; }
		public string ErrorMessage { get; set; }
	}
}
