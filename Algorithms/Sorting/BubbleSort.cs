using Spikes.Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Algorithms.Sorting
{
    public class BubbleSort : ICanSort
    {
        public event EventHandler<SwapEventArgs> Swap;

        public void Sort<T>(T[] array) where T: IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        T temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;

                        Swap?.Invoke(this, new SwapEventArgs(array[j], array[j - 1]));
                    }
                }
            }
        }
    }

}
