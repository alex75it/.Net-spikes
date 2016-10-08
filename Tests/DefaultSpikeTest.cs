using NUnit.Framework;
using Spikes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Tests
{
    [TestFixture]
    public class DefaultSpikeTest
    {
        [Test]
        public void Run()
        {
            DefaultSpike spike = new DefaultSpike();
            string name = spike.GetName();
            spike.Run();
            Assert.Pass();
        }
    }
}