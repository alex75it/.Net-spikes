using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.MongoDB;

namespace Spikes
{
	public class Program
	{

		static void Main(string[] args)
		{
			//InsertTest.MainAsync(args).GetAwaiter().GetResult();

			Worker worker = new Worker();
			worker.Run();

			Console.WriteLine("\n\nPress any key to close.");
			

			int counter = 0;
			foreach(var c in "this. is a test.. aaa".ToCharArray()) if (c == '.') counter++;
			"aaaa".Select(c => c == '.').Count();

			Console.WriteLine("c: " + counter);

			Console.ReadKey();



		}
	}
}
