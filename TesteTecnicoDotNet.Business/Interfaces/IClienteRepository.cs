using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Business.Interfaces
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		Task<Cliente?> ObterPorCpfAsync(string cpf);
	}
}
