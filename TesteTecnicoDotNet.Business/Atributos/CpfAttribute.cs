using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TesteTecnicoDotNet.Business.Atributos
{
    public class CpfAttribute : ValidationAttribute
	{
		public override bool IsValid(object? value)
		{
			if (value is not string cpf)
				return false;

			cpf = Regex.Replace(cpf, @"[^\d]", "");

			if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
				return false;

			var digitos = cpf.Select(c => int.Parse(c.ToString())).ToArray();

			int soma = 0;
			for (int i = 0; i < 9; i++)
				soma += digitos[i] * (10 - i);

			int resto = soma % 11;
			int dv1 = resto < 2 ? 0 : 11 - resto;

			if (digitos[9] != dv1)
				return false;

			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += digitos[i] * (11 - i);

			resto = soma % 11;
			int dv2 = resto < 2 ? 0 : 11 - resto;

			return digitos[10] == dv2;
		}
	}
}
