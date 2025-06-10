using TesteTecnicoDotNet.Business.Enums;

namespace TesteTecnicoDotNet.Business.Extensions
{
	public static class TipoCreditoExtensions
	{
		public static decimal ObterTaxaDeJuros(this TipoCredito tipo)
		{
			return tipo switch
			{
				TipoCredito.Direto => 0.02m,
				TipoCredito.Consignado => 0.01m,
				TipoCredito.PessoaJuridica => 0.05m,
				TipoCredito.PessoaFisica => 0.03m,
				TipoCredito.Imobiliario => 0.09m,
				_ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de crédito desconhecido")
			};
		}
	}
}
