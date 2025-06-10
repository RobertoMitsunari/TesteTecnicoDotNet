using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;
using TesteTecnicoDotNet.Infra.Data.Context;

namespace TesteTecnicoDotNet.Infra.Data.Repositorios
{
	public class FinanciamentoRepository : Repository<Financiamento>, IFinanciamentoRepository
	{
		public FinanciamentoRepository(CreditoDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Financiamento>> ObterPorCpfClienteAsync(string cpf)
		{
			return await _dbSet
				.Include(f => f.Cliente)
				.Where(f => f.Cliente.Cpf == cpf)
				.ToListAsync();
		}
	}
}
