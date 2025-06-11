using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoDotNet.Business.Atributos
{
    public class ValidarTipoCreditoAttribute : ValidationAttribute
	{
		private readonly Type _enumType;

		public ValidarTipoCreditoAttribute(Type enumType)
		{
			_enumType = enumType;
		}

		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null || !_enumType.IsEnum)
				return new ValidationResult($"Valor inválido para o tipo {_enumType.Name}.");

			if (!Enum.IsDefined(_enumType, value))
				return new ValidationResult(ErrorMessage ?? $"Valor inválido para o tipo {_enumType.Name}.");

			return ValidationResult.Success;
		}
	}
}
