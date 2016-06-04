namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IOrderDetail
	{
		int OrderDetailId { get; set; }
		int OrderId { get; set; }
		int QuantityOrdered { get; set; }
		int BookId { get; set; }
		Book Book { get; set; }
	}
}
