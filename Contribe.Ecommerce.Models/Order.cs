using Contribe.Ecommerce.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Contribe.Ecommerce.Models
{


	public class Order : IOrder
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public int CustomerId { get; set; }
		public string Comment { get; set; }
		public decimal TotalPrice { get; set; }
		public Customer Customer { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
