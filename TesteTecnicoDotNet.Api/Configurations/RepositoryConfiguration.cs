using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Infra.Data.Repositorios;

namespace TesteTecnicoDotNet.Api.Configurations
{
	public static class RepositoryConfiguration
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<IFinanciamentoRepository, FinanciamentoRepository>();
			services.AddScoped<IParcelaRepository, ParcelaRepository>();

			return services;
		}
	}
}
