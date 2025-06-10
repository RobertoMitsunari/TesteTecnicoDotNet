using System.ComponentModel.DataAnnotations;
using TesteTecnicoDotNet.Business.Atributos;
using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class FinanciamentoRequest
    {
		[Required(ErrorMessage = "O ClienteId é obrigatório.")]
		public Guid ClienteId { get; set; }

		[Required(ErrorMessage = "O Tipo de Crédito é obrigatório.")]
		public TipoCredito TipoCredito { get; set; }

		[Required(ErrorMessage = "O valor inicial do financiamento é obrigatório.")]
		[Range(1000, 1000000, ErrorMessage = "O valor inicial deve estar entre R$ 1.000 e R$ 1.000.000.")]
		public decimal ValorInicialFinanciamento { get; set; }

		[Required(ErrorMessage = "O valor total do financiamento é obrigatório.")]
		[Range(1000, 1000000, ErrorMessage = "O valor total deve estar entre R$ 1.000 e R$ 1.000.000.")]
		public decimal ValorTotal { get; set; }

		[Required(ErrorMessage = "A data do último vencimento é obrigatória.")]
		[DataType(DataType.Date, ErrorMessage = "Data inválida.")]
		[FutureDate(ErrorMessage = "A data de vencimento deve ser no futuro.")]
		public DateTime DataUltimoVencimento { get; set; }
	}
}
