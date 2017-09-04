using System;

namespace SimpleExcel.Models
{
	public class SpreadsheetBuilder
	{
		private SpreadsheetCalculator _spreadsheetCalculator;

		public SpreadsheetBuilder()
		{
			_spreadsheetCalculator = new SpreadsheetCalculator();

		}
		private string ColumnName(int x)
		{
			return Convert.ToChar(65 + x).ToString();
		}

		public bool Build(ref Spreadsheet sheet)
		{
			int x, y;
			var s = Console.ReadLine();
			var dimensions = s.Split('*');
			if (dimensions.Length == 2 && int.TryParse(dimensions[0], out x) && int.TryParse(dimensions[1], out y))
			{
				sheet = new Spreadsheet(x, y);
				return true;
			}
			else
			{
				Console.WriteLine("Enter Spreadsheet size in format: Number*Number");
				return false;
			}
		}

		public void Read(Spreadsheet sheet)
		{
			for (var j = 0; j < sheet.RawValues.GetLength(1); j++)
			{
				for (var i = 0; i < sheet.RawValues.GetLength(0); i++)
				{
					Console.Write($"{ColumnName(i).ToLower()}{(j + 1)} = ");
					sheet.RawValues[i, j] = Console.ReadLine();
				}
			}
		}

		public void Calculate(Spreadsheet sheet)
		{
			_spreadsheetCalculator.Calculate(sheet);
		}

		public void Display(Spreadsheet sheet)
		{
			Console.Write("  ");
			for (var i = 0; i < sheet.DisplayValues.GetLength(0); i++)
			{
				Console.Write($"{ColumnName(i)}  ");
			}
			Console.WriteLine();
			for (var j = 0; j < sheet.DisplayValues.GetLength(1); j++)
			{
				Console.Write($"{j + 1} ");
				for (var i = 0; i < sheet.DisplayValues.GetLength(0); i++)
				{
					Console.Write($"{sheet.DisplayValues[i, j]}  ");
				}
				Console.WriteLine();
			}
		}
	}
}
