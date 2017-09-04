using SimpleExcel.Models;

namespace SimpleExcel
{
	class Program
	{
		static void Main(string[] args)
		{
			Spreadsheet sheet = null;
			SpreadsheetBuilder spreadsheetBuilder = new SpreadsheetBuilder();
			while (!spreadsheetBuilder.Build(ref sheet)) { }
			spreadsheetBuilder.Read(sheet);
			spreadsheetBuilder.Calculate(sheet);
			spreadsheetBuilder.Display(sheet);
		}
	}
}
