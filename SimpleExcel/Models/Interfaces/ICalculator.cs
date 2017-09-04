using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExcel.Models.Interfaces
{
	public interface ICalculator
	{
		void RegisterNext(ICalculator next);
		string Calculate(string formula);
	}
}
