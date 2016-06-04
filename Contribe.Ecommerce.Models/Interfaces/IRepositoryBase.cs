using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contribe.Ecommerce.Models.Interfaces
{
	public interface IRepositoryBase<TEntity>
	   where TEntity : class
	{

		void Delete(object id);
		void Delete(TEntity entity);
		void Dispose();
		IEnumerable<TEntity> GetAll();
		Task<IEnumerable<TEntity>> GetAllAsync();
		TEntity GetById(object id);
		void Insert(TEntity entity);
		void Update(TEntity entity);
	}
}


