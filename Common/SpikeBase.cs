using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Common
{
    public abstract class SpikeBase : ISpike
    {
        public string GetName() {
            return this.GetType().Name;
        }

        public void Run()
        {
            // TODO: Why I have to define this?
            // empty
        }
    }
}
