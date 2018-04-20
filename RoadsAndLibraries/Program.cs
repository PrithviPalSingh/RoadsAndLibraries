using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class Program
    {
        /// <summary>
        /// 2
        /// 3 3 2 1
        /// 1 2
        /// 3 1
        /// 2 3
        /// 6 6 2 5
        /// 1 3
        /// 3 4
        /// 2 4
        /// 1 2
        /// 2 3
        /// 5 6
        /// </summary>
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            #region RoadsAndLibraries
            ////int q = 1;// Convert.ToInt32(Console.ReadLine());
            ////for (int a0 = 0; a0 < q; a0++)
            ////{
            ////    //string[] tokens_n = Console.ReadLine().Split(' ');
            ////    int n = 6;// Convert.ToInt32(tokens_n[0]);
            ////    int m = 6;// Convert.ToInt32(tokens_n[1]);
            ////    long c_lib = 2;// Convert.ToInt32(tokens_n[2]);
            ////    long c_road = 5;// Convert.ToInt32(tokens_n[3]);
            //int[][] cities = new int[6][] { new int[] { 1, 3 }, new int[] { 3, 4 }, new int[] { 2, 4 },
            //        new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 5, 6 } };
            ////    //for (int cities_i = 0; cities_i < m; cities_i++)
            ////    //{
            ////    //    string[] cities_temp = Console.ReadLine().Split(' ');
            ////    //    cities[cities_i] = Array.ConvertAll(cities_temp, Int32.Parse);
            ////    //}
            ////    long result = roadsAndLibraries(n, c_lib, c_road, cities);
            ////    Console.WriteLine(result);
            #endregion

            #region -- Jounery to moon
            //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = 5;// Convert.ToInt32(tokens_n[0]);
            //int p = 3;// Convert.ToInt32(tokens_n[1]);
            //int[][] astronaut = new int[3][] { new int[] { 0, 1 }, new int[] { 2, 3 }, new int[] { 0, 4 } };
            int n = 100000;// Convert.ToInt32(tokens_n[0]);100000 2          
            int p = 2;// Convert.ToInt32(tokens_n[1]);
            int[][] astronaut = new int[2][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            long result = journeyToMoon(n, astronaut);
            Console.WriteLine(result);
            #endregion
            Console.Read();
        }

        /*Suppose that we have n groups, of sizes a1 to an. Except when n is smallish, the following formula for the number N of ways 
         * to choose a pair of people from different groups is more efficient: 
         * N=((a1+⋯+an)^2 − (a1^2 +⋯+ an^2)) / 2.
           To see that the formula does the job, expand (a1+⋯+an)2.*/
        static long journeyToMoon(int n, int[][] astronaut)
        {
            GraphAPI gapi = new GraphAPI(n);

            for (int i = 0; i < astronaut.Length; i++)
            {
                gapi.AddEdge(astronaut[i][0], astronaut[i][1]);
            }

            ConnectedComponents bfs = new ConnectedComponents(gapi, n);
            IList<long> IdCount = new List<long>();
            IdCount.Add(1);
            Array.Sort(bfs.Id);
            for (int k = 0; k < n - 1; k++)
            {
                if (bfs.Id[k] == bfs.Id[k + 1])
                {
                    ++IdCount[IdCount.Count - 1];
                    continue;
                }

                IdCount.Add(1);
            }

            long SumSquare = 0;
            for (int i = 0; i < IdCount.Count; i++)
            {
                SumSquare += IdCount[i];
            }

            SumSquare = (long)Math.Pow(SumSquare, 2);
            long SquareSum = 0;
            for (int i = 0; i < IdCount.Count; i++)
            {
                SquareSum += (long)Math.Pow(IdCount[i], 2);
            }
            
            return (SumSquare - SquareSum) / 2;
        }

        static long roadsAndLibraries(int n, long c_lib, long c_road, int[][] cities)
        {
            GraphAPI gapi = new GraphAPI(n);
            for (int i = 0; i < cities.Length; i++)
            {
                gapi.AddEdge(cities[i][0] - 1, cities[i][1] - 1);
            }

            ConnectedComponents bfs = new ConnectedComponents(gapi, n);
            long result = ((c_road * bfs.RoadCount()) + (bfs.LibraryCount() * c_lib));

            if (c_lib * n < result)
                result = c_lib * n;

            return result;
        }
    }
}
