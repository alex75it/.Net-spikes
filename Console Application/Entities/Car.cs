using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console.Entities
{
	public class Car
	{
				

		public string Model { get; set; }

		public IEngine Engine { get; private set; }
		public bool BeansAreOn { get; private set; }


		public Car(string model, IEngine engine)
		{
			Model = model;
			Engine = engine;
		}

		public void Start()
		{
			Engine.Start();

			if (DateTime.Now.Hour < 6 || DateTime.Now.Hour > 19)
				TurnOnBeans();
	}
		
		public void TurnOnBeans() { BeansAreOn = true; System.Console.WriteLine("Turn on beans"); }
		public void TurnOffBeans() { BeansAreOn = false; System.Console.WriteLine("Turn off beans"); }
		
	}
}
