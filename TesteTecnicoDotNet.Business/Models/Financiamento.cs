using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Models
{
	public class Financiamento : Entity
	{
		public Guid ClienteId { get; set; }
		public required Cliente Cliente { get; set; }

		public TipoCredito TipoCredito { get; set; }
		public decimal ValorInicialFinanciamento { get; set; }
		public decimal ValorTotal { get; set; }
		public DateTime DataUltimoVencimento { get; set; }
		public IList<Parcela>? Parcelas { get; set; }
	}
}
