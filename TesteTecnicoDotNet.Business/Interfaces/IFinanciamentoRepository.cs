using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Business.Interfaces
{
	public interface IFinanciamentoRepository : IRepository<Financiamento>
	{
		Task<IEnumerable<Financiamento>> ObterPorCpfClienteAsync(string cpf);
	}
}
