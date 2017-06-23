using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Qotd 
{
	public static class Program 
	{
		public static void Main(string[] args) 
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

            var quotesFile = configuration["quotesFile"];
			if (quotesFile == null)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You must specify a quotes file.");
				Console.ResetColor();
				return;
			}
			var quotes = File.ReadAllLines(quotesFile);
			var randomQuote = quotes[new Random().Next(0, quotes.Length-1)];
			
			Console.WriteLine("[QOTD]: {0}", randomQuote);
		}
	}
}
