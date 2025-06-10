using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;
using TesteTecnicoDotNet.Infra.Data.Context;

namespace TesteTecnicoDotNet.Infra.Data.Repositorios
{
	public class ParcelaRepository : Repository<Parcela>, IParcelaRepository
	{
		public ParcelaRepository(CreditoDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Parcela>> ObterPorFinanciamentoIdAsync(Guid financiamentoId)
		{
			return await _dbSet
			.Where(p => p.FinanciamentoId == financiamentoId)
			.ToListAsync();
		}
	}
}
