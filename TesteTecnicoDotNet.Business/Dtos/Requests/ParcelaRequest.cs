namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class ParcelaRequest
    {
		public Guid FinanciamentoId { get; set; }
		public int NumeroParcela { get; set; }
		public decimal ValorParcela { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime? DataPagamento { get; set; }
	}
}
