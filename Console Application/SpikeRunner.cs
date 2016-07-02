using Spikes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console
{
    public class SpikeRunner
    {
        private readonly ISpike spike;
        public SpikeRunner(ISpike spike)
        {
            this.spike = spike;
        }

        public void RunSpike()
        {
            spike.Run();
        }
    }
}
