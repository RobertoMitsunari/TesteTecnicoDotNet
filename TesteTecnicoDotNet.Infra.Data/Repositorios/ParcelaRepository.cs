using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
