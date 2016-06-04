namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface ICustomer
	{
		int CustomerId { get; set; }
		string Email { get; set; }
		string CellPhoneNumber { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		int AddressId { get; set; }
		Address Address { get; set; }
	}
}