using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Services;
using TesteTecnicoDotNet.Infra.Data.Repositorios;

namespace TesteTecnicoDotNet.Api.Configurations
{
	public static class ServiceConfiguration
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICreditoService, CreditoService>();
			return services;
		}
	}
}
