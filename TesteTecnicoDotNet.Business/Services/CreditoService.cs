using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Dtos.Response;
using TesteTecnicoDotNet.Business.Enums;
using TesteTecnicoDotNet.Business.Extensions;
using TesteTecnicoDotNet.Business.Interfaces;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Business.Services
{
	public class CreditoService : ICreditoService
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly IFinanciamentoRepository _financiamentoRepository;

		public CreditoService(IClienteRepository clienteRepository, IFinanciamentoRepository financiamentoRepository)
		{
			_clienteRepository = clienteRepository;
			_financiamentoRepository = financiamentoRepository;
		}

		public async Task<SolicitacaoDeCreditoResponse> CriarSolicitacaoDeCredito(SolicitacaoDeCreditoRequest request)
		{
			var response = new SolicitacaoDeCreditoResponse();

			if (!ValidarDados(request, response))
			{
				return response;
			}

			await GerarSolicitacaoAsync(request, response);

			return response;
		}

		private bool ValidarDados(SolicitacaoDeCreditoRequest request, SolicitacaoDeCreditoResponse response)
		{
			var erros = new List<string>();

			if (request.TipoDoCredito == TipoCredito.PessoaJuridica && request.ValorDoCredito < 15000)
				erros.Add("Para crédito de pessoa jurídica, o valor mínimo é de R$ 15.000,00.");

			if (erros.Any())
			{
				response.Erro = (string.Join(" ", erros));
				return false;
			}

			return true;
		}

		private async Task GerarSolicitacaoAsync(SolicitacaoDeCreditoRequest request, SolicitacaoDeCreditoResponse response)
		{
			var cliente = await _clienteRepository.ObterPorCpfAsync(request.CpfCliente);

			if(cliente is null)
			{
				response.Erro = $"Não foi possivel encontrar cliente com o cpf: {request.CpfCliente}";
				return;
			}

			var financiamento = new Financiamento
			{
				Cliente = cliente,
				ClienteId = cliente.Id,
				TipoCredito = request.TipoDoCredito,
				ValorInicialFinanciamento = request.ValorDoCredito,
				DataUltimoVencimento = request.DataPrimeiroVencimento.AddMonths(request.QuantidadeParcelas - 1),
			};

			financiamento.Parcelas = CriarParcelas(request, financiamento);

			response.ValorTotalComJuros = financiamento.ValorTotal;
			response.ValorDosJuros = financiamento.ValorTotal - request.ValorDoCredito;

			await SalvarFinanciamento(financiamento);
		}

		private IList<Parcela> CriarParcelas(SolicitacaoDeCreditoRequest request, Financiamento financiamento)
		{
			var parcelas = new List<Parcela>();
			var taxaDeJuros = request.TipoDoCredito.ObterTaxaDeJuros();
			var quantidadeParcelas = request.QuantidadeParcelas;

			decimal valorParcela;
			decimal valorFinal = 0m;

			valorParcela = request.ValorDoCredito * (1 + taxaDeJuros) / quantidadeParcelas;

			for (int i = 0; i < quantidadeParcelas; i++)
			{
				parcelas.Add(new Parcela
				{
					NumeroParcela = i + 1,
					ValorParcela = Math.Round(valorParcela, 2),
					DataVencimento = request.DataPrimeiroVencimento.AddMonths(i),
					FinanciamentoId = financiamento.Id,
					Financiamento = financiamento,
				});

				valorFinal += parcelas[i].ValorParcela;
			}

			financiamento.ValorTotal = valorFinal;
			return parcelas;
		}

		#region "SAC e Price"
		private IList<Parcela> CriarParcelasSac(SolicitacaoDeCreditoRequest request, Financiamento financiamento)
		{
			var parcelas = new List<Parcela>();
			var taxaDeJuros = request.TipoDoCredito.ObterTaxaDeJuros();
			var quantidadeParcelas = request.QuantidadeParcelas;

			decimal valorFinal = 0m;

			var amortizacao = request.ValorDoCredito / request.QuantidadeParcelas;
			var capital = request.ValorDoCredito;

			for (int i = 0; i < quantidadeParcelas; i++)
			{
				parcelas.Add(new Parcela
				{
					NumeroParcela = i + 1,
					ValorParcela = amortizacao + (capital * taxaDeJuros),
					DataVencimento = request.DataPrimeiroVencimento.AddMonths(i),
					FinanciamentoId = financiamento.Id,
					Financiamento = financiamento,
				});

				valorFinal += parcelas[i].ValorParcela;
				capital -= amortizacao;
			}

			financiamento.ValorTotal = valorFinal;
			return parcelas;
		}

		private IList<Parcela> CriarParcelasPrice(SolicitacaoDeCreditoRequest request, Financiamento financiamento)
		{
			var parcelas = new List<Parcela>();
			var taxaDeJuros = request.TipoDoCredito.ObterTaxaDeJuros();
			var quantidadeParcelas = request.QuantidadeParcelas;

			decimal valorFinal = 0m;

			for (int i = 0; i < quantidadeParcelas; i++)
			{
				parcelas.Add(new Parcela
				{
					NumeroParcela = i + 1,
					ValorParcela = CalculaParcelaPrice((double)request.ValorDoCredito, (double)taxaDeJuros, i),
					DataVencimento = request.DataPrimeiroVencimento.AddMonths(i),
					FinanciamentoId = financiamento.Id,
					Financiamento = financiamento,
				});

				valorFinal += parcelas[i].ValorParcela;
			}

			financiamento.ValorTotal = valorFinal;
			return parcelas;
		}

		//Price
		public decimal CalculaParcelaPrice(double capital, double juros, int periodo)
		{
			return (decimal)(capital * (Math.Pow(1 + juros, periodo) * juros) / (Math.Pow(1 + juros, periodo) - 1));
		}
		#endregion

		private async Task SalvarFinanciamento(Financiamento financiamento)
		{
			await _financiamentoRepository.AddAsync(financiamento);
			await _financiamentoRepository.SaveChangesAsync();
		}
	}
}
