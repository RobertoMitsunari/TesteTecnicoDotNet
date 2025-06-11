using System.ComponentModel.DataAnnotations;
using TesteTecnicoDotNet.Business.Atributos;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class ParcelaRequest
    {
		[Required(ErrorMessage = "O FinanciamentoId é obrigatório.")]
		public Guid FinanciamentoId { get; set; }

		[Required(ErrorMessage = "O número da parcela é obrigatório.")]
		[Range(1, int.MaxValue, ErrorMessage = "O número da parcela deve ser maior que 0.")]
		public int NumeroParcela { get; set; }

		[Required(ErrorMessage = "O valor da parcela é obrigatório.")]
		[Range(0.01, 1000000, ErrorMessage = "O valor da parcela deve ser maior que 0.")]
		public decimal ValorParcela { get; set; }

		[Required(ErrorMessage = "A data de vencimento é obrigatória.")]
		[DataFutura(ErrorMessage = "A data de vencimento deve ser no futuro.")]
		public DateTime DataVencimento { get; set; }

		public DateTime? DataPagamento { get; set; }
	}
}
