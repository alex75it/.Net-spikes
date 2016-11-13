using Spikes.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Algorithms.Sorting
{
    public class BubbleSort<T> : ICanSort<T>, ICanSort
    {
        public void Sort(object[] array)
        {
            this.Sort<object>(array);
        }

        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {

            }
        }
    }

}
