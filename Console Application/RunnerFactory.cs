using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.Console.Runners;

namespace Spikes.Console
{
	public class RunnerFactory<T> where T: IRunner
	{
		public static T CreateRunner()
		{
			IRunner runner;

			if(typeof(T) == typeof(CarRunner))
				runner = new CarRunner();
			else if(typeof(T) == typeof(Challenge9Runner))
				runner = new Challenge9Runner();
			else
				throw new Exception("Runner type not found: " + typeof(T));
			

			return (T)runner;
		}

	}
}
