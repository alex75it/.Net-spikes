using Ninject;
using Spikes.Common;
using Spikes.Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console
{
    public class IocInstaller
    {

        private static IKernel kernel;
        public static void Initialize()
        {
            kernel = new StandardKernel();
            kernel.Bind<ISpike>().To<CouchbaseSpike>();  
        }

        public static SpikeRunner CreateSpikeRunner()
        {
            ISpike spike = kernel.Get<ISpike>();
            SpikeRunner runner = new SpikeRunner(spike);
            return runner;
        }

        ~IocInstaller()
        {
            if(kernel != null && !kernel.IsDisposed)
                kernel.Dispose();
        }
    }
}
