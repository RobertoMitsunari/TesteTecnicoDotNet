using Microsoft.AspNetCore.Mvc;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientesController : Controller
	{
		private readonly IClienteRepository _clienteRepo;

		public ClientesController(IClienteRepository clienteRepo)
		{
			_clienteRepo = clienteRepo;
		}

		[HttpGet("id/{id}")]
		public async Task<IActionResult> GetClienteById(Guid id)
		{
			var cliente = await _clienteRepo.ObterPorIdAsync(id);
			if (cliente == null)
				return NotFound();

			return Ok(cliente);
		}

		[HttpGet("cpf/{cpf}")]
		public async Task<IActionResult> GetClienteByCpf(string cpf)
		{
			var cliente = await _clienteRepo.ObterPorCpfAsync(cpf);
			if (cliente == null)
				return NotFound();

			return Ok(cliente);
		}

		[HttpPost]
		public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
		{
			await _clienteRepo.AddAsync(cliente);
			await _clienteRepo.SaveChangesAsync();
			return CreatedAtAction(nameof(PostCliente), new { id = cliente.Id }, cliente);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutCliente(Guid id, [FromBody] Cliente cliente)
		{
			if (id != cliente.Id)
				return BadRequest("O ID da URL não corresponde ao ID do cliente.");

			var existente = await _clienteRepo.ObterPorIdAsync(id);
			if (existente == null)
				return NotFound();

			_clienteRepo.Update(cliente);
			await _clienteRepo.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCliente(Guid id)
		{
			var cliente = await _clienteRepo.ObterPorIdAsync(id);
			if (cliente == null)
				return NotFound();

			_clienteRepo.Remove(cliente);
			await _clienteRepo.SaveChangesAsync();

			return NoContent();
		}
	}
}
