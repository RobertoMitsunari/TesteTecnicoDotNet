using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Business.Interfaces
{
	public interface IParcelaRepository : IRepository<Parcela>
	{
		public Task<IEnumerable<Parcela>> ObterPorFinanciamentoIdAsync(Guid financiamentoId);
	}
}
