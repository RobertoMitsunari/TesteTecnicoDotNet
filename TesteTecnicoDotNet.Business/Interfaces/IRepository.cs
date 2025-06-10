using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Business.Interfaces
{
	public interface IRepository<T> where T : Entity
	{
		Task<T?> ObterPorIdAsync(Guid id);
		Task<IEnumerable<T>> ObterTodosAsync();
		Task AddAsync(T entity);
		void Update(T entity);
		void Remove(T entity);
		Task SaveChangesAsync();
	}
}
