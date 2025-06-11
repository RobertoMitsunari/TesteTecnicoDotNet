using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TesteTecnicoDotNet.Business.Atributos;
using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
	public class SolicitacaoDeCreditoRequest
	{
		[Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
		[Cpf(ErrorMessage = "CPF inválido.")]
		public required string CpfCliente { get; set; }

		[Required(ErrorMessage = "O valor do crédito é obrigatório.")]
		[Range(100, 1000000, ErrorMessage = "O valor do crédito deve estar entre R$ 100 e R$ 1.000.000.")]
		public decimal ValorDoCredito { get; set; }

		[Required(ErrorMessage = "O tipo do crédito é obrigatório.")]
		[ValidarTipoCredito(typeof(TipoCredito), ErrorMessage = "Tipo de crédito inválido.")]
		public TipoCredito TipoDoCredito { get; set; }

		[Required(ErrorMessage = "A quantidade de parcelas é obrigatória.")]
		[Range(5, 72, ErrorMessage = "A quantidade de parcelas deve estar entre 5 e 72.")]
		public int QuantidadeParcelas { get; set; }

		[Required(ErrorMessage = "A data do primeiro vencimento é obrigatória.")]
		[DataFutura(ErrorMessage = "A data do primeiro vencimento deve ser futura.")]
		[DateInRange(15, 40, ErrorMessage = "A data do primeiro vencimento deve estar entre 15 e 40 dias a partir de hoje.")]
		public DateTime DataPrimeiroVencimento { get; set; }
	}
}
