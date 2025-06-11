using Microsoft.AspNetCore.Mvc;
using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Dtos.Response;
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
			if (!ModelState.IsValid)
			{
				var erros = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();

				string todosErros = string.Join(" | ", erros);
				return BadRequest(SolicitacaoDeCreditoResponse.Reprovado(todosErros));
			}

			request.CpfCliente = request.CpfCliente!.Replace(".", "").Replace("-", "").Trim();
			var result = await _creditoService.CriarSolicitacaoDeCredito(request);
			return Ok(result);
		}
	}
}
