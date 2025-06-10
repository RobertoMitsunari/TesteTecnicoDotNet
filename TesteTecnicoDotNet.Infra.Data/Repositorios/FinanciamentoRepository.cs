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
	}
}
