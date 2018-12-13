using RoadsAndLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProblems
{
    class Program
    {
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            #region RoadsAndLibraries
            //int q = 1;// Convert.ToInt32(Console.ReadLine());
            //for (int a0 = 0; a0 < q; a0++)
            //{
            //    //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = 6;// Convert.ToInt32(tokens_n[0]);
            //int m = 6;// Convert.ToInt32(tokens_n[1]);
            //long c_lib = 2;// Convert.ToInt32(tokens_n[2]);
            //long c_road = 5;// Convert.ToInt32(tokens_n[3]);
            //int[][] cities = new int[6][] { new int[] { 1, 3 }, new int[] { 3, 4 }, new int[] { 2, 4 },
            //       new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 5, 6 } };
            ////for (int cities_i = 0; cities_i < m; cities_i++)
            ////{
            ////    string[] cities_temp = Console.ReadLine().Split(' ');
            ////    cities[cities_i] = Array.ConvertAll(cities_temp, Int32.Parse);
            ////}
            //long result = roadsAndLibraries(n, c_lib, c_road, cities);
            //Console.WriteLine(result);
            #endregion

            #region -- Jounery to moon
            //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = 5;// Convert.ToInt32(tokens_n[0]);
            //int p = 3;// Convert.ToInt32(tokens_n[1]);
            //int[][] astronaut = new int[3][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 1, 5 } };
            //int n = 100000;// Convert.ToInt32(tokens_n[0]);100000 2          
            //int p = 2;// Convert.ToInt32(tokens_n[1]);
            //int[][] astronaut = new int[2][] { new int[] { 2, 3 }, new int[] { 4, 5 } };
            //long result = journeyToMoon(n, astronaut);
            //Console.WriteLine(result);
            #endregion

            //ConnectedSubsetComponents cc = new ConnectedSubsetComponents();
            //cc.FindSubsetComponents(new long[] { 2, 5, 9 });

            #region
            //TestNearestClone();
            #endregion

            #region
            TestDFSHard();
            #endregion

            Console.Read();
        }

        static void TestDFSHard()
        {
            int n = 3;

            int m = 6;

            int[][] grid = new int[n][];

            //for (int i = 0; i < n; i++)
            //{
            //    grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            //}

            grid[0] = Array.ConvertAll("1 1 1 1 0 1".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            grid[1] = Array.ConvertAll("0 0 0 0 1 0".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            grid[2] = Array.ConvertAll("0 1 0 1 0 1".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            //grid[3] = Array.ConvertAll("1 0 0 0".Split(' '), gridTemp => Convert.ToInt32(gridTemp));

            int res = maxRegion(grid, (n * m));

            Console.WriteLine(res);
        }

        static int maxRegion(int[][] grid, int nodeCount)
        {
            GraphAPI gapi = new GraphAPI(nodeCount);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int nodeNumber = 1;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    string key = i + "|" + j;
                    dict.Add(key, nodeNumber);
                    nodeNumber++;
                }
            }


            for (int i = 0; i < grid.Length; i++)
            {

                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var keyOuter = i + "|" + j;
                        var from = dict[keyOuter];
                                               
                        if (j > 0 && i < grid.Length - 1 && grid[i + 1][j - 1] == 1)
                        {
                            var keyInner = (i + 1) + "|" + (j - 1);
                            var to = dict[keyInner];
                            gapi.AddEdge(from, to);
                        }
                       
                        if (j < grid[i].Length-1 && grid[i][j + 1] == 1)
                        {
                            var keyInner = (i) + "|" + (j + 1);
                            var to = dict[keyInner];
                            gapi.AddEdge(from, to);
                        }
                                                
                        if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                        {
                            var keyInner = (i + 1) + "|" + j;
                            var to = dict[keyInner];
                            gapi.AddEdge(from, to);
                        }

                        if (i < grid.Length - 1 && j < grid[i].Length - 1 && grid[i + 1][j + 1] == 1)
                        {
                            var keyInner = (i + 1) + "|" + (j + 1);
                            var to = dict[keyInner];
                            gapi.AddEdge(from, to);
                        }


                    }
                }
            }

            CCForDFSHard cc = new CCForDFSHard(gapi);
            Array.Sort(cc.Id);

            return cc.Id[cc.Id.Length - 1];
        }

        static void TestNearestClone()
        {
            string[] graphNodesEdges = "5 4".Split(' ');
            int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
            int graphEdges = Convert.ToInt32(graphNodesEdges[1]);

            int[] graphFrom = new int[graphEdges];
            int[] graphTo = new int[graphEdges];
            string[] graphFromToArr = new string[] { "1 2", "1 3", "2 4", "3 5" };
            for (int i = 0; i < graphEdges; i++)
            {
                string[] graphFromTo = graphFromToArr[i].Split(' ');
                graphFrom[i] = Convert.ToInt32(graphFromTo[0]);
                graphTo[i] = Convert.ToInt32(graphFromTo[1]);
            }

            long[] ids = Array.ConvertAll("1 2 3 3 2".Split(' '), idsTemp => Convert.ToInt64(idsTemp));
            int val = 2;

            int ans = findShortest(graphNodes, graphFrom, graphTo, ids, val);
            Console.WriteLine(ans);
        }

        /*
         * For the unweighted graph, <name>:
         *
         * 1. The number of nodes is <name>Nodes.
         * 2. The number of edges is <name>Edges.
         * 3. An edge exists between <name>From[i] to <name>To[i].
         *
         */
        static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, long val)
        {
            List<int> maxInts = new List<int>();
            int minDist = int.MaxValue;
            GraphAPI gapi = new GraphAPI(graphNodes, ids);
            for (int i = 0; i < graphFrom.Length; i++)
            {
                gapi.AddEdge(graphFrom[i], graphTo[i]);
            }

            List<int> impNodes = new List<int>();

            for (int i = 0; i < graphNodes; i++)
            {
                if (ids[i] == val)
                    impNodes.Add(i);
            }

            for (int i = 0; i < impNodes.Count; i++)
            {
                BreadthFirstSearch bfs = new BreadthFirstSearch(gapi, gapi.S, impNodes[i], val);
                minDist = Math.Min(minDist, bfs.minDist);

                //List<int> innerValues = new List<int>();
                //for (int j = 0; j < graphNodes; j++)
                //{
                //    if (ids[j] == val)
                //    {
                //        innerValues.Add(dfs.DistTo[j]);
                //    }
                //}

                //innerValues.Sort();

                //if (innerValues.Count > 1)
                //{
                //    maxInts.Add(innerValues[0] + innerValues[1]);
                //}
            }

            //maxInts.Sort();

            return minDist != int.MaxValue ? minDist : -1;


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
                gapi.AddEdge(cities[i][0], cities[i][1]);
            }

            ConnectedComponents bfs = new ConnectedComponents(gapi, n);
            long result = ((c_road * bfs.RoadCount()) + (bfs.LibraryCount() * c_lib));

            if (c_lib * n < result)
                result = c_lib * n;

            return result;
        }
    }
}
