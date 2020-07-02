using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Program
	{
		//TODO Artikli
		//Nalik ovoj aplikaciji, napraviti da korisnik unosi artikle,
		//artikal ce da ima sifru, naziv i cenu. Cena je decimal :) 

		//TODO OOP -- Artikli
		//Artikal je klasa koja sadrzi sifru, naziv i cenu   (moze i ulazna cena i marza)

		static void Main(string[] args)
		{
			List<Osoba> Imenik = new List<Osoba>();

			string izbor = "";			
			while(izbor != "5")
			{
				PrikaziMeni();
				izbor = Console.ReadKey().KeyChar.ToString();
				Console.WriteLine();

				switch(izbor)
				{
					case "1":
						Unos(Imenik);
						break;
					case "2":
						foreach (Osoba o in Imenik)
						{
							Console.WriteLine($"{o.Ime} {o.Prezime} {o.TelBroj}");
						}
						break;
					case "3":
						Pretraga(Imenik);
						break;
					case "4":
						Brisanje(Imenik);
						break;
					case "5":
						Console.WriteLine("Vidimo se :)");
						break;
					default:
						Console.WriteLine("Pogresna opcija :(");
						break;
				}
			}


			Console.ReadKey();
		}

		static void Brisanje (List<Osoba> Osobe)
		{

			Console.Write("Unesite ime ili prezime: ");
			string pretraga = Console.ReadLine();

			Osoba zaBrisanje = null;

			foreach (Osoba o in Osobe)
			{
				if (o.Ime.ToLower().Contains(pretraga.ToLower()) || o.Prezime.ToLower().Contains(pretraga.ToLower()))
				{
					Console.WriteLine($"Da li zelite da obrisete: {o.Ime} {o.Prezime} {o.TelBroj}? (d/n)");
					string unos = Console.ReadKey().KeyChar.ToString();
					if (unos == "d")
					{
						zaBrisanje = o;
						break;
					}
				}
			}

			Osobe.Remove(zaBrisanje);
		}

		static void Pretraga(List<Osoba> Osobe)
		{
			Console.Write("Unesite ime ili prezime: ");
			string pretraga = Console.ReadLine();

			foreach (Osoba o in Osobe)
			{   
				if (o.Ime.ToLower().Contains(pretraga.ToLower()) || o.Prezime.ToLower().Contains(pretraga.ToLower()))
				{
					Console.WriteLine($"{o.Ime} {o.Prezime} {o.TelBroj}");
				}
			}

			/*for (int indeks = 0; indeks < i.Count; indeks++)
			{
				if (i[indeks].ToLower().Contains(pretraga.ToLower()))
				{
					Console.WriteLine($"{indeks + 1}. {i[indeks]} -- {b[indeks]}");
				}
			}*/
		}

		static void Unos(List<Osoba> Osobe)
		{
			Osoba o = new Osoba();

			Console.Write("Unesite ime: ");
			o.Ime = Console.ReadLine();
			Console.Write("Unesite prezime: ");
			o.Prezime = Console.ReadLine();

			Console.Write("Unesite tel: ");
			o.TelBroj = Console.ReadLine();

			Osobe.Add(o);
		}

		static void PrikaziMeni()
		{
			Console.WriteLine("1 --- Unos");
			Console.WriteLine("2 --- Pregled");
			Console.WriteLine("3 --- Pretraga");
			Console.WriteLine("4 --- Ukloni");
			Console.WriteLine("5 --- Izlaz");
			Console.WriteLine("---------------");
			Console.Write("Unesite izbor: ");
		}
	}

	class Osoba
	{
		public string Ime;
		public string Prezime;
		public string TelBroj;

		public Osoba(string i, string p, string b)
		{
			Ime = i;
			Prezime = p;
			TelBroj = b;
		}

		public Osoba() { }
	}
}
