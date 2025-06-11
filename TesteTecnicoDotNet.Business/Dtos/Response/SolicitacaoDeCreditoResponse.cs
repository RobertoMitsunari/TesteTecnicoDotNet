using System.Text.Json.Serialization;

namespace TesteTecnicoDotNet.Business.Dtos.Response
{
	public class SolicitacaoDeCreditoResponse
	{
		public string StatusCredito => string.IsNullOrWhiteSpace(Erro) ? "Aprovado" : "Reprovado";
		public decimal ValorTotalComJuros { get; set; }
		public decimal ValorDosJuros { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Erro { get; set; }

		public void Falha(string erro)
		{
			Erro = erro;
		}

		public static SolicitacaoDeCreditoResponse Reprovado(string erro)
		{
			return new SolicitacaoDeCreditoResponse()
			{
				Erro = erro
			};
		}
	}
}
