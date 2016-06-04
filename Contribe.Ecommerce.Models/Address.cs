using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Models
{
	public class Address : IAddress
	{
		public int AddressId { get; set; }

		public string Street { get; set; }

		public string ZipCode { get; set; }
		public string City { get; set; }

	}
}