using Spikes.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Algorithms.Sorting
{
    public class SortingSpike : SpikeBase
    {

        public const int TEST_ARRAY_LENGTH = 5;
        public const int MAX_VALUE_IN_ARRAY = 1000; // to be human readable

        public override void Run()
        {
            ICanSort sorting = new BubbleSort();
            
            foreach(var array in GetTestArrays(10))
            {
                Write("Initial: " + string.Join(", ", array));
                sorting.Sort(array);
                Write("Sorted: " + string.Join(", ", array));
            }            
        }

        private void Write(string message)
        {
            Console.WriteLine(message);
        }

        private void Show(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private IEnumerable<int[]> GetTestArrays(int numberOfCases)
        {
            string testFile = string.Format($"Arrays_{numberOfCases}.data");
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Data\\" + testFile);
           
            if (!File.Exists(testFile))
            {
                GenerateTestCases(path, numberOfCases);
            }

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                object data = new BinaryFormatter().Deserialize(stream);
                List<int[]> arrays = data as List<int[]>;
                if (arrays == null)
                    throw new Exception("Cannot deserialize data. Data are serialized as " + data.GetType());
                return arrays;
            }
        }

        private void GenerateTestCases(string path, int numberOfCases)
        {
            string rootPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            List<int[]> arrays = new List<int[]>(numberOfCases);
            Random random = new Random(DateTime.Now.Millisecond);
            while (numberOfCases-- > 0)
            {                
                int[] array = new int[TEST_ARRAY_LENGTH];
                int position = 0;
                while (position < TEST_ARRAY_LENGTH)
                {
                    array[position++] = random.Next(MAX_VALUE_IN_ARRAY);
                }
                arrays.Add(array);
            }

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                new BinaryFormatter().Serialize(stream, arrays);
            }
        }

    }
}
