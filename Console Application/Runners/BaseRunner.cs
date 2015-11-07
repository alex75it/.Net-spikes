using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console.Runners
{
	public abstract class BaseRunner :IRunner
	{
		//public virtual static IRunner Instance();



		public void Run()
		{
			System.Console.WriteLine("BarseRunner Run");
		}
	}
}
