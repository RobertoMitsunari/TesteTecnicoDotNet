using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Infra.Data.Context;

namespace TesteTecnicoDotNet.Api.Configurations
{
	public static class DbContextConfiguration
	{
		public static IServiceCollection AddDbSession(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<CreditoDbContext>(options =>
				options.UseSqlServer(connectionString));

			return services;
		}
	}
}
