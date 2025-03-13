using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Lab_interfejssy
{
	public class Pracownik
	{
		private string nazwisko;
		public string Nazwisko
		{
			get => nazwisko;
			set => nazwisko = value.Trim().ToUpper();
		}
		
		public DateTime DataZatrudnienia { get; set; }
		public decimal Wynagrodzenie { get; set; }
	}
}
