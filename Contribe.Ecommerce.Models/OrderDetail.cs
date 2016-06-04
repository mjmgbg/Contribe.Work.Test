using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Models
{


	public class OrderDetail : IOrderDetail
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int QuantityOrdered { get; set; }
		public int BookId { get; set; }
		public Book Book { get; set; }

	}


}
