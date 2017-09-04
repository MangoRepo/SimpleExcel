using SimpleExcel.Models.Interfaces;

namespace SimpleExcel.Models.Calculators
{
	public class EndCalculator : ICalculator
	{
		public string Calculate(string formula)
		{
			return formula;
		}

		public void RegisterNext(ICalculator next)
		{
		}
	}
}
