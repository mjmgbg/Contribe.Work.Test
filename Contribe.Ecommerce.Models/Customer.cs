using Contribe.Ecommerce.Models.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contribe.Ecommerce.Models
{


	public class Customer : ICustomer
	{
		public int CustomerId { get; set; }
		[DisplayName("Epost")]
		[Required(ErrorMessage = "Epost måste anges")]
		[EmailAddress]
		public string Email { get; set; }
		[DisplayName("Mobilnummer")]
		[Required(ErrorMessage = "Mobilnummer måste anges")]
		public string CellPhoneNumber { get; set; }
		[DisplayName("Förnamn")]
		[Required(ErrorMessage = "Förnamn måste anges")]
		public string FirstName { get; set; }
		[DisplayName("Efternamn")]
		[Required(ErrorMessage = "Efternamn måste anges")]
		public string LastName { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }


	}
}

