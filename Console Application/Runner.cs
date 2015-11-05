using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.Console.Entities;

namespace Spikes.Console
{
	public class Runner
	{
		public static void Run()
		{

			IEngine engine = new PetrolEngine();

			Car car = new Car("Opel Corsa", engine);
			car.Start();
			
		}

	}
}
