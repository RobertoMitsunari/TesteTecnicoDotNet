using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoDotNet.Business.Atributos
{
	public class DateInRangeAttribute : ValidationAttribute
	{
		private readonly int _minDays;
		private readonly int _maxDays;

		public DateInRangeAttribute(int minDays, int maxDays)
		{
			_minDays = minDays;
			_maxDays = maxDays;
		}

		public override bool IsValid(object? value)
		{
			if (value is not DateTime date)
				return false;

			var diff = (date.Date - DateTime.Now.Date).TotalDays;
			return diff >= _minDays && diff <= _maxDays;
		}
	}
}
