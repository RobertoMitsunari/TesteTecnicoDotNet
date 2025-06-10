using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ParcelaController : Controller
	{
		private readonly IParcelaRepository _repository;
		private readonly IMapper _mapper;

		public ParcelaController(IParcelaRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Parcela>>> GetAll()
		{
			var parcelas = await _repository.ObterTodosAsync();
			return Ok(parcelas);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Parcela>> GetById(Guid id)
		{
			var parcela = await _repository.ObterPorIdAsync(id);
			if (parcela == null) return NotFound();

			return Ok(parcela);
		}

		[HttpGet("financiamento/{financiamentoId}")]
		public async Task<ActionResult<IEnumerable<Parcela>>> GetByFinanciamentoId(Guid financiamentoId)
		{
			var parcelas = await _repository.ObterPorFinanciamentoIdAsync(financiamentoId);
			return Ok(parcelas);
		}

		[HttpPost]
		public async Task<ActionResult<Parcela>> Create([FromBody] ParcelaRequest parcelaRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var parcela = _mapper.Map<Parcela>(parcelaRequest);
			await _repository.AddAsync(parcela);
			await _repository.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = parcela.Id }, parcela);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] ParcelaRequest parcelaRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var parcela = _mapper.Map<Parcela>(parcelaRequest);

			if (id != parcela.Id)
				return BadRequest("ID da URL não corresponde ao ID da parcela.");

			var existente = await _repository.ObterPorIdAsync(id);
			if (existente == null) return NotFound();

			_repository.Update(parcela);
			await _repository.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var parcela = await _repository.ObterPorIdAsync(id);
			if (parcela == null) return NotFound();

			_repository.Remove(parcela);
			await _repository.SaveChangesAsync();

			return NoContent();
		}
	}
}
