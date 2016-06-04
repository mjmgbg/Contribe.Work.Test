using System;
using System.Collections.Generic;

namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IOrder
	{
		int OrderId { get; set; }
		DateTime OrderDate { get; set; }
		int CustomerId { get; set; }
		string Comment { get; set; }
		decimal TotalPrice { get; set; }
		Customer Customer { get; set; }
		ICollection<OrderDetail> OrderDetails { get; set; }
	}
}