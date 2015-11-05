using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console.Entities
{
	public class PetrolEngine :IEngine
	{
		public void Start()
		{
			System.Console.WriteLine("Engine start");
			//Console.WriteLine("start");
		}
	}
}
