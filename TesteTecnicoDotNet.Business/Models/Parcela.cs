using System.Text.Json.Serialization;

namespace TesteTecnicoDotNet.Business.Models
{
	public class Parcela : Entity
	{
		public Guid FinanciamentoId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public required Financiamento Financiamento { get; set; }

		public int NumeroParcela { get; set; }
		public decimal ValorParcela { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime? DataPagamento { get; set; }
	}
}
