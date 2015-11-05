using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.Console.Entities;
using Spikes.Console.Services;

namespace Spikes.Console
{
	public class Runner
	{
		public static void Run()
		{

			IEngine engine = new PetrolEngine();
			DaylightService daylightService = new DaylightService();

			Car car = new Car("Opel Corsa", engine, daylightService);
			car.Start();
			
		}

	}
}
