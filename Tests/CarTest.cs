using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Spikes.Console.Entities;
using Should;

namespace Tests
{
	[TestFixture]
    public class CarTest
    {

		[Test]
		public void Start_When_IsNight_Should_TurnOnBeans()
		{
			string model = "model";
			IEngine engine = new Mock<IEngine>().Object;

			var car = new Car(model, engine);

			car.Start();

			car.BeansAreOn.ShouldBeTrue();
		}


    }
}
