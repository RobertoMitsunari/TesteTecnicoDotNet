using Microsoft.AspNetCore.Mvc;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FinanciamentoController : Controller
	{
		private readonly IFinanciamentoRepository _repository;

		public FinanciamentoController(IFinanciamentoRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Financiamento>>> GetAll()
		{
			var financiamentos = await _repository.ObterTodosAsync();
			return Ok(financiamentos);
		}

		[HttpGet("id/{id}")]
		public async Task<ActionResult<Financiamento>> GetById(Guid id)
		{
			var financiamento = await _repository.ObterPorIdAsync(id);
			if (financiamento == null) return NotFound();

			return Ok(financiamento);
		}

		[HttpGet("cpf/{cpf}")]
		public async Task<ActionResult<Financiamento>> GetByCpf(string cpf)
		{
			var financiamento = await _repository.ObterPorCpfClienteAsync(cpf);
			if (financiamento == null) return NotFound();

			return Ok(financiamento);
		}

		[HttpPost]
		public async Task<ActionResult<Financiamento>> Create([FromBody] Financiamento financiamento)
		{
			await _repository.AddAsync(financiamento);
			await _repository.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = financiamento.Id }, financiamento);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Financiamento financiamento)
		{
			if (id != financiamento.Id)
				return BadRequest("ID da URL não corresponde ao ID do objeto.");

			var existente = await _repository.ObterPorIdAsync(id);
			if (existente == null) return NotFound();

			_repository.Update(financiamento);
			await _repository.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var financiamento = await _repository.ObterPorIdAsync(id);
			if (financiamento == null) return NotFound();

			_repository.Remove(financiamento);
			await _repository.SaveChangesAsync();

			return NoContent();
		}
	}
}
