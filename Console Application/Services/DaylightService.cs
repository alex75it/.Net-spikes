using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console.Services
{
	public class DaylightService :IDaylightService
	{

		public bool IsDark()
		{
			var hour = DateTime.Now.Hour;
			return hour < 6 || hour > 19;
		}
	}
}
