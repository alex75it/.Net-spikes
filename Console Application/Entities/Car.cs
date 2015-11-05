using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spikes.Console.Services;

namespace Spikes.Console.Entities
{
	public class Car
	{
		private readonly IDaylightService daylightService;

		public string Model { get; set; }

		public IEngine Engine { get; private set; }
		public bool BeansAreOn { get; private set; }


		public Car(string model, IEngine engine, IDaylightService daylightService)
		{
			Model = model;
			Engine = engine;
			this.daylightService = daylightService;
		}

		public void Start()
		{
			Engine.Start();

			if (daylightService.IsDark())
				TurnOnBeans();
	}
		
		public void TurnOnBeans() { BeansAreOn = true; System.Console.WriteLine("Turn on beans"); }
		public void TurnOffBeans() { BeansAreOn = false; System.Console.WriteLine("Turn off beans"); }
		
	}
}
