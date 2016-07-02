using NUnit.Framework;
using Spikes.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class DefaultSpikeTest
    {

        [Test]
        public void Run()
        {
            DefaultSpike spike = new DefaultSpike();
            spike.Run();
            Assert.Pass();
        }
    }
}
