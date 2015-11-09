using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.Console.Runners;

namespace Spikes.Console
{
	public class Program
	{
		static void Main(string[] args)
		{
			IRunner runner = RunnerFactory<CarRunner>.CreateRunner();
			runner.Run();


			System.Console.Write("\n\nPress any key to close ");
			System.Console.ReadKey();

		}
	}
}
