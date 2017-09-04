namespace SimpleExcel.Models
{
	public class Spreadsheet
	{
		public Spreadsheet(int x, int y)
		{
			RawValues = new string[x, y];
			DisplayValues = new string[x, y];
		}

		public string[,] RawValues { get; set; }
		public string[,] DisplayValues { get; set; }
	}
}
