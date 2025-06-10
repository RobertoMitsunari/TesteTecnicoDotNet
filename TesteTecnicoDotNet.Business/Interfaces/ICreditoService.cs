using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Dtos.Response;

namespace TesteTecnicoDotNet.Business.Interfaces
{
	public interface ICreditoService
	{
		public Task<SolicitacaoDeCreditoResponse> CriarSolicitacaoDeCredito(SolicitacaoDeCreditoRequest request);
	}
}
