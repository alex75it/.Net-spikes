using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Spikes.Console.Entities;
using Should;
using Spikes.Console.Services;

namespace Tests
{
	[TestFixture]
    public class CarTest
    {

		[Test]
		public void Start_When_IsDark_Should_TurnOnBeans()
		{
			string model = "model";
			IEngine engine = new Mock<IEngine>().Object;
			Mock<IDaylightService> daylightService = new Mock<IDaylightService>();
			daylightService.Setup(s => s.IsDark()).Returns(true);

			var car = new Car(model, engine, daylightService.Object);

			car.Start();

			car.BeansAreOn.ShouldBeTrue();
		}

		[Test]
		public void Start_When_IsNotDark_Should_TurnOffBeans()
		{
			string model = "model";
			IEngine engine = new Mock<IEngine>().Object;
			Mock<IDaylightService> daylightService = new Mock<IDaylightService>();
			daylightService.Setup(s => s.IsDark()).Returns(false);

			var car = new Car(model, engine, daylightService.Object);

			car.Start();

			car.BeansAreOn.ShouldBeFalse();
		}


    }
}
