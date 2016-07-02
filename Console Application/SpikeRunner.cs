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

        public object SpikeName { get { return spike.GetName(); } }
                public bool IsDefaultSpike
        {
            get { return spike is DefaultSpike; }
        }

        public void RunSpike()
        {
            spike.Run();
        }

    }
}
