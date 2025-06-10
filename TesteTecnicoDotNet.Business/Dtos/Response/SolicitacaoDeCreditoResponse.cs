using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Dtos.Response
{
	public class SolicitacaoDeCreditoResponse
	{
		public string StatusCredito { get; set; }
		public decimal ValorTotalComJuros { get; set; }
		public decimal ValorDosJuros { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Erro { get; set; }

		public void Falha(string erro)
		{
			StatusCredito = "Reprovado";
			Erro = erro;
		}
	}
}
