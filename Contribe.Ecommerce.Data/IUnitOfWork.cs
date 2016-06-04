using Contribe.Ecommerce.Models;
using Contribe.Ecommerce.Models.Interfaces;

namespace Contribe.Ecommerce.Data
{
	public interface IUnitOfWork
	{
		IRepositoryBase<Book> Books { get; }
		IRepositoryBase<Customer> Customers { get; }
		IAddressRepository<Address> Addresses { get; }
		IRepositoryBase<Order> Orders { get; }
		IRepositoryBase<OrderDetail> OrderDetails { get; }
		void Save();
	}
}