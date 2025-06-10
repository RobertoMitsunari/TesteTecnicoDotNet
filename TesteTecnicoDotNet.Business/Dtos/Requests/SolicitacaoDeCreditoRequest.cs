using System.Runtime.Serialization;
using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
	public class SolicitacaoDeCreditoRequest
	{
		public required string CpfCliente { get; set; }
		public decimal ValorDoCredito { get; set; }
		public TipoCredito TipoDoCredito { get; set; }
		public int QuantidadeParcelas { get; set; }
		public DateTime DataPrimeiroVencimento { get; set; }
	}
}
