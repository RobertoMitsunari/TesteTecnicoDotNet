using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;
using TesteTecnicoDotNet.Infra.Data.Context;

namespace TesteTecnicoDotNet.Infra.Data.Repositorios
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly CreditoDbContext _context;
		protected readonly DbSet<T> _dbSet;

		public Repository(CreditoDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public virtual async Task<T?> ObterPorIdAsync(Guid id)
			=> await _dbSet.FindAsync(id);

		public virtual async Task<IEnumerable<T>> ObterTodosAsync()
			=> await _dbSet.ToListAsync();

		public virtual async Task AddAsync(T entity)
			=> await _dbSet.AddAsync(entity);

		public virtual void Update(T entity)
			=> _dbSet.Update(entity);

		public virtual void Remove(T entity)
			=> _dbSet.Remove(entity);

		public async Task SaveChangesAsync()
			=> await _context.SaveChangesAsync();
	}
}
