using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class ConnectedSubsetComponents
    {
        public void FindSubsetComponents(long[] arr)
        {
            long pow = (long)Math.Pow(2, arr.Length);
            ConnectedSubComponentAPI[] arrayOfPossibilities = new ConnectedSubComponentAPI[pow];
            arrayOfPossibilities[0] = new ConnectedSubComponentAPI(null, arr);

            for (int i = 1; i <= arr.Length; i++)
            {
                arrayOfPossibilities[i] = new ConnectedSubComponentAPI(new List<long> { arr[i] }, arr);
            }

            for (int i = arr.Length + 1; i < pow; i++)
            {
                if (arrayOfPossibilities[i - arr.Length].List.Contains(arr[i]))
                {
                    i--;
                    continue;
                }
                arrayOfPossibilities[i] = new ConnectedSubComponentAPI(arrayOfPossibilities[i - arr.Length].List, arr);
            }

            Console.WriteLine();
        }
    }
}
