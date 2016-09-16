using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R = Rack;
using Should;

namespace Spikes.Tests
{
    [TestFixture, Category("Rack")]
    public class RackTest
    {

        [Test]
        public void ANewRack_Should_ContainsNoBalls()
        {
            R.Rack rack = new R.Rack();

            rack.Balls().ShouldBeEmpty();
        }
    }
}
