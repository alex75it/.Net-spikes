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
            spikeRunner.RunSpike();

            System.Console.Write("\n\nPress any key to close ");
            System.Console.ReadKey();
        }

        private static SpikeRunner GetSpikeRunner()
        {
            return IocInstaller.CreateSpikeRunner();
        }
    }
}
