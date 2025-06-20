﻿using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoDotNet.Business.Atributos
{
	public class DataFuturaAttribute : ValidationAttribute
	{
		public override bool IsValid(object? value)
		{
			if (value is DateTime date)
			{
				return date > DateTime.Now;
			}
			return false;
		}
	}
}
