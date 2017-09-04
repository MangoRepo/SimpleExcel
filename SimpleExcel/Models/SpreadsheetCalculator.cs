using SimpleExcel.Models.Calculators;
using SimpleExcel.Models.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SimpleExcel.Models
{
	public class SpreadsheetCalculator
	{
		private ICalculator _calculation;
		public SpreadsheetCalculator()
		{
			ICalculator multiple = new MultipleCalculator();
			ICalculator divide = new DivideCalculator();
			ICalculator add = new AddCalculator();
			ICalculator subtract = new SubtractCalculator();
			ICalculator end = new EndCalculator();
			multiple.RegisterNext(divide);
			divide.RegisterNext(add);
			add.RegisterNext(subtract);
			subtract.RegisterNext(end);

			_calculation = multiple;
		}

		public void Calculate(Spreadsheet sheet)
		{
			for (var j = 0; j < sheet.RawValues.GetLength(1); j++)
			{
				for (var i = 0; i < sheet.RawValues.GetLength(0); i++)
				{
					sheet.DisplayValues[i, j] = CalculateCell(sheet, i, j);
				}
			}
		}

		private int ColumnIndex(string val)
		{
			return val[0] - 'a';
		}

		private string CalculateCell(Spreadsheet sheet, int i, int j)
		{
			//Check if Field is Numeric
			double val;
			if (Double.TryParse(sheet.RawValues[i, j], out val))
				return val.ToString();

			//Replace Cell References with Values
			string value = ReplaceRefCells(sheet, sheet.RawValues[i, j]);

			return _calculation.Calculate(ReplaceRefCells(sheet, sheet.RawValues[i, j]));
		}

		private string ReplaceRefCells(Spreadsheet sheet, string value)
		{
			Regex regex = new Regex(@"([a-zA-Z])(\d+)", RegexOptions.Compiled);
			var m = regex.Match(value);
			while (m.Success)
			{
				var i = ColumnIndex(m.Groups[1].Value.ToLower());
				var j = Convert.ToInt32(m.Groups[2].Value) - 1;
				if (i < sheet.RawValues.GetLength(0) && j < sheet.RawValues.GetLength(1))
					value = value.Replace(m.Groups[0].Value, CalculateCell(sheet, i, j));

				m = regex.Match(value);
			}

			return value;
		}
	}
}
