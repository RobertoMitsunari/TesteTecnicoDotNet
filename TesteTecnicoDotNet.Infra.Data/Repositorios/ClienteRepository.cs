using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;
using TesteTecnicoDotNet.Infra.Data.Context;

namespace TesteTecnicoDotNet.Infra.Data.Repositorios
{
	public class ClienteRepository : Repository<Cliente>, IClienteRepository
	{
		public ClienteRepository(CreditoDbContext context) : base(context)
		{
		}

		public async Task<Cliente?> ObterPorCpfAsync(string cpf)
			=> await _dbSet.FirstOrDefaultAsync(c => c.Cpf == cpf);
	}
}
