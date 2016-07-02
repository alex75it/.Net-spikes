using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            IocInstaller.Initialize();

            SpikeRunner spikeRunner = GetSpikeRunner();
            System.Console.Write(string.Format("Spike: {0}.", spikeRunner.SpikeName));
            spikeRunner.RunSpike();

            if (spikeRunner.IsDefaultSpike)
            {
                System.Console.WriteLine(@"
    Create your Spike class deriving from SpikeBase.
    Then inject it in the Spikes.Console.IocInstaller class."
                );
            }

            System.Console.Write("\n\nPress any key to close ");
            System.Console.ReadKey();
        }

        private static SpikeRunner GetSpikeRunner()
        {
            return IocInstaller.CreateSpikeRunner();
        }
    }
}
