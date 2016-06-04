

namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IAddressRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		TEntity GetByAddressAndZipCodeId(string street, string city);
	}


}
