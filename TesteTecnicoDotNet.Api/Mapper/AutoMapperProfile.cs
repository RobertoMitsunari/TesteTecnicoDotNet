using AutoMapper;
using TesteTecnicoDotNet.Business.Dtos.Requests;
using TesteTecnicoDotNet.Business.Models;

namespace TesteTecnicoDotNet.Api.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Cliente, ClienteRequest>().ReverseMap();
			CreateMap<Financiamento, FinanciamentoRequest>().ReverseMap();
			CreateMap<Parcela, ParcelaRequest>().ReverseMap();
		}
	}
}
