using System.ComponentModel.DataAnnotations;
using TesteTecnicoDotNet.Business.Atributos;

namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class ClienteRequest
    {
		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
		public required string Nome { get; set; }

		[Required(ErrorMessage = "O CPF é obrigatório.")]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
		[Cpf(ErrorMessage = "CPF inválido.")]
		public required string Cpf { get; set; }

		[Required(ErrorMessage = "A UF é obrigatória.")]
		[StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve conter 2 letras.")]
		public required string Uf { get; set; }

		[Required(ErrorMessage = "O celular é obrigatório.")]
		[Phone(ErrorMessage = "O número de celular não é válido.")]
		public required string Celular { get; set; }
	}
}
