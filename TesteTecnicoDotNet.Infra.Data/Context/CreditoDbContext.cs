using Microsoft.EntityFrameworkCore;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Infra.Data.Context
{
	public class CreditoDbContext : DbContext
	{
		public CreditoDbContext(DbContextOptions<CreditoDbContext> options) : base(options)
		{
		}

		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Financiamento> Financiamento { get; set; }
		public DbSet<Parcela> Parcela { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Cliente -> Financiamento (1:N)
			modelBuilder.Entity<Financiamento>()
				.HasOne(f => f.Cliente)
				.WithMany()
				.HasForeignKey("ClienteId")
				.IsRequired();

			// Financiamento -> Parcelas (1:N)
			modelBuilder.Entity<Parcela>()
				.HasOne(p => p.Financiamento)
				.WithMany(f => f.Parcelas)
				.HasForeignKey("FinanciamentoId")
				.IsRequired();
		}
	}
}
