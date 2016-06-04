using Contribe.Ecommerce.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Contribe.Ecommerce.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly EcommerceContext context;
		internal readonly DbSet<TEntity> dbSet;

		public RepositoryBase(EcommerceContext context)
		{
			if (context == null)
				throw new ArgumentNullException();

			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual TEntity GetById(object id)
		{
			return dbSet.Find(id);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return dbSet;
		}
		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}
		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(TEntity entity)
		{
			if (context.Entry(entity).State == EntityState.Detached)
				dbSet.Attach(entity);

			dbSet.Remove(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entity = dbSet.Find(id);
			Delete(entity);
		}

		public virtual void Dispose()
		{
			context.Dispose();
		}
	}
}

