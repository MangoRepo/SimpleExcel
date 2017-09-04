using SimpleExcel.Models.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SimpleExcel.Models.Calculators
{
	public class SubtractCalculator : ICalculator
	{
		private ICalculator _next;
		private readonly Regex regex = new Regex(@"(-?\d+\.?\d*)\s*\-\s*(-?\d+\.?\d*)", RegexOptions.Compiled);
		public string Calculate(string formula)
		{
			var m = regex.Match(formula);
			while (m.Success)
			{
				formula = formula.Replace(m.Groups[0].Value, (Convert.ToDouble(m.Groups[1].Value) - Convert.ToDouble(m.Groups[2].Value)).ToString());
				m = regex.Match(formula);
			}

			return _next.Calculate(formula);
		}

		public void RegisterNext(ICalculator next)
		{
			_next = next;
		}
	}
}
