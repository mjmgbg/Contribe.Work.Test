namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IAddress
	{
		int AddressId { get; set; }
		string Street { get; set; }
		string ZipCode { get; set; }
		string City { get; set; }
	}

}
