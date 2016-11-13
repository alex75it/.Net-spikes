using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Algorithms.Sorting
{
    public interface ICanSort
    {
        //event SwapEvent Swap;
        event EventHandler<SwapEventArgs> Swap;
        void Sort<T>(T[] array) where T : IComparable<T>;
    }

    //internal delegate void SwapEvent(ICanSort sort, SwapEventArgs args);

    public class SwapEventArgs : EventArgs
    {
        public object ValueA { get; private set; }
        public object ValueB { get; private set; }

        public SwapEventArgs(object valueA, object valueB)
        {
            ValueA = valueA;
            ValueB = valueB;
        }
    }
}
