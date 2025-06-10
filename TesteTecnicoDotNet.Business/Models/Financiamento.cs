using System.Text.Json.Serialization;
using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Models
{
	public class Financiamento : Entity
	{
		public Guid ClienteId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public required Cliente Cliente { get; set; }

		public TipoCredito TipoCredito { get; set; }
		public decimal ValorInicialFinanciamento { get; set; }
		public decimal ValorTotal { get; set; }
		public DateTime DataUltimoVencimento { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IList<Parcela>? Parcelas { get; set; }
	}
}
