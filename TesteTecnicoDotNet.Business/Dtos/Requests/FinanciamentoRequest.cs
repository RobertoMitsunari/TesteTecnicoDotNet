using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class FinanciamentoRequest
    {
		public Guid ClienteId { get; set; }
		public TipoCredito TipoCredito { get; set; }
		public decimal ValorInicialFinanciamento { get; set; }
		public decimal ValorTotal { get; set; }
		public DateTime DataUltimoVencimento { get; set; }
	}
}
