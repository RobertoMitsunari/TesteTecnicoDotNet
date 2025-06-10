using Microsoft.AspNetCore.Mvc;
using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Interfaces;

namespace TesteTecnicoDotNet.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CreditoController : Controller
	{
		private readonly ICreditoService _creditoService;

		public CreditoController(ICreditoService creditoService)
		{
			_creditoService = creditoService;
		}

		[HttpPost]
		public async Task<IActionResult> SolicitacaoDeCreditoAsync(SolicitacaoDeCreditoRequest request)
		{
			var result = await _creditoService.CriarSolicitacaoDeCredito(request);
			return Ok(result);
		}
	}
}
