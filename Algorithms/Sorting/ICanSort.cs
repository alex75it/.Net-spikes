using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Algorithms.Sorting
{

    internal interface ICanSort
    {
        void Sort<T>(T[] array) where T: IComparable<T>;
    }
}
