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

            #region Jounery to moon
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

            #region connected sub components
            //ConnectedSubsetComponents cc = new ConnectedSubsetComponents();
            //cc.FindSubsetComponents(new long[] { 2, 5, 9 });
            #endregion

            #region Nearest clone
            //TestNearestClone();
            #endregion

            #region DFS Hard
            //TestDFSHard();
            #endregion

            #region Castle on the grid
            string[] grid = new string[] { ".X.", ".X.", "..." };
            //string[] grid = new string[] { "....", "....", ".XXX", "...." };
            //string[] grid = new string[] { "...X..", ".X....", ".X....", "......", "......", "......" };

            //string[] grid = new string[] { ".X..XX...X", "X.........",
            //".X.......X",
            //"..........",
            //"........X.",
            //".X...XXX..",
            //".....X..XX",
            //".....X.X..",
            //"..........",
            //".....X..XX"};
            #region bigger string
            //string[] grid = new string[] {  "...X......XX.X...........XX....X.XX.....", ".X..............X...XX..X...X........X.X",
            //                                "......X....X....X.........X...........X.", ".X.X.X..X........X.....X.X...X.....X..X.",
            //                                "....X.X.X...X..........X..........X.....", "..X......X....X....X...X....X.X.X....XX.",
            //                                "...X....X.......X..XXX.......X.X.....X..", "...X.X.........X.X....X...X.........X...",
            //                                "XXXX..X......X.XX......X.X......XX.X..XX", ".X........X....X.X......X..X....XX....X.",
            //                                "...X.X..X.X.....X...X....X..X....X......", "....XX.X.....X.XX.X...X.X.....X.X.......",
            //                                ".X.X.X..............X.....XX..X.........", "..X...............X......X........XX...X",
            //                                ".X......X...X.XXXX.....XX...........X..X",
            //                                "...X....XX....X...XX.X..X..X..X.....X..X",
            //                                "...X...X.X.....X.....X.....XXXX.........",
            //                                "X.....XX..X.............X.XX.X.XXX......",
            //                                ".....X.X..X..........X.X..X...X.X......X",
            //                                "...X.....X..X.............X......X..X..X",
            //                                "........X.....................X....X.X..",
            //                                "..........X.....XXX...XX.X..............",
            //                                "........X..X..........X.XXXX..X.........",
            //                                "..X..X...X.......XX...X.....X...XXX..X..",
            //                                ".X.......X..............X....X...X....X.",
            //                                ".................X.....X......X.....X...",
            //                                ".......X.X.XX..X.XXX.X.....X..........X.",
            //                                "X..X......X..............X..X.X.......X.",
            //                                "X........X.....X.....X....XX.......XX...",
            //                                "X.....X.................X.....X..X...XXX",
            //                                "XXX..X..X.X.XX..X....X.....XXX..X......X",
            //                                "..........X.....X.....XX................",
            //                                "..X.........X..X.........X...X.....X....",
            //                                ".X.X....X...XX....X...............X.....",
            //                                ".X....X....XX.XX........X..X............",
            //                                "X...X.X................XX......X..X.....",
            //                                "..X.X.......X.X..X.....XX.........X..X..",
            //                                "........................X..X.XX..X......",
            //                                "........X..X.X.....X.....X......X.......",
            //                                ".X..X....X.X......XX...................."};
            #endregion
            // Console.WriteLine(minimumMovesDij(grid, 34, 28, 16, 8));
            //Console.WriteLine(minimumMovesDij(grid, 0, 0, 4, 3));
            //Console.WriteLine(minimumMovesDij(grid, 9, 1, 9, 6));
            //Console.WriteLine(minimumMoves(grid, 0, 0, 0, 5));

            MinMoves(grid, 0, 0, 0, 2);
            #endregion

            Console.Read();
        }

        #region castle on the grid BFS
        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            int from = -1;
            int to = -1;
            int n = grid.Length;
            int[][] matrix = new int[n][];
            int tracker = 0;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != 'X')
                    {
                        matrix[i][j] = tracker;
                    }
                    else
                    {
                        matrix[i][j] = -1;
                    }

                    tracker++;
                    if (startX == i && startY == j)
                    {
                        from = matrix[i][j];
                    }

                    if (goalX == i && goalY == j)
                    {
                        to = matrix[i][j];
                    }
                }
            }

            GraphAPI gapi = new GraphAPI(tracker);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < n - 1 && matrix[i][j] != -1 && matrix[i + 1][j] != -1)
                        gapi.AddEdgeExt(matrix[i][j], matrix[i + 1][j], "V");

                    if (j < n - 1 && matrix[i][j] != -1 && matrix[i][j + 1] != -1)
                        gapi.AddEdgeExt(matrix[i][j], matrix[i][j + 1], "H");
                }
            }

            BFSForCastleGrid bfs = new BFSForCastleGrid(gapi, from);

            List<int> list = bfs.PathTo(to).ToList();
            string previousAllign = string.Empty;
            int count = 0;
            for (int i = 0; i < list.Count() - 1; i++)
            {
                string key = list[i] < list[i + 1] ? list[i] + "|" + list[i + 1] : list[i + 1] + "|" + list[i];
                var item = gapi.dict[key];

                if (previousAllign == string.Empty || previousAllign != item)
                {
                    count++;
                    previousAllign = item;
                }
            }

            return count;
        }
        #endregion

        #region castle on the grid dijkstra's
        static int minimumMovesDij(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            int from = -1;
            int to = -1;
            int n = grid.Length;
            int[][] matrix = new int[n][];
            int tracker = 0;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != 'X')
                    {
                        matrix[i][j] = tracker;
                    }
                    else
                    {
                        matrix[i][j] = -1;
                    }

                    tracker++;
                    if (startX == i && startY == j)
                    {
                        from = matrix[i][j];
                    }

                    if (goalX == i && goalY == j)
                    {
                        to = matrix[i][j];
                    }
                }
            }

            EdgeWeightedDiGraph ewdg = new EdgeWeightedDiGraph(tracker);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < n - 1 && matrix[i][j] != -1 && matrix[i + 1][j] != -1)
                    {
                        ewdg.AddEdge(new DirectedEdgeAPI(matrix[i][j], matrix[i + 1][j], 1), "V");
                        ewdg.AddEdge(new DirectedEdgeAPI(matrix[i + 1][j], matrix[i][j], 1), "V");
                    }

                    if (j < n - 1 && matrix[i][j] != -1 && matrix[i][j + 1] != -1)
                    {
                        ewdg.AddEdge(new DirectedEdgeAPI(matrix[i][j], matrix[i][j + 1], 1), "H");
                        ewdg.AddEdge(new DirectedEdgeAPI(matrix[i][j + 1], matrix[i][j], 1), "H");
                    }
                }
            }

            BellmanFordShortestPath djkForward = new BellmanFordShortestPath(ewdg, from);
            //DijkstraShortestPath djkBackward = new DijkstraShortestPath(ewdg, from);

            //var count = djkForward.DistTo[to] > djkBackward.DistTo[from] ? djkBackward.DistTo[from] : djkForward.DistTo[to];
            //List<int> list = djk.PathTo(from, to).ToList();
            //string previousAllign = string.Empty;
            //int count = 0;
            //for (int i = 0; i < list.Count() - 1; i++)
            //{
            //    string key = list[i] < list[i + 1] ? list[i] + "|" + list[i + 1] : list[i + 1] + "|" + list[i];
            //    var item = ewdg.dict[key];

            //    if (previousAllign == string.Empty || previousAllign != item)
            //    {
            //        count++;
            //        previousAllign = item;
            //    }
            //}

            return (int)0;
        }
        #endregion

        #region DFS hard
        static void TestDFSHard()
        {
            int n = 3;

            int m = 6;

            int[][] grid = new int[n][];

            grid[0] = Array.ConvertAll("1 1 1 1 0 1".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            grid[1] = Array.ConvertAll("0 0 0 0 1 0".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            grid[2] = Array.ConvertAll("0 1 0 1 0 1".Split(' '), gridTemp => Convert.ToInt32(gridTemp));
            //grid[3] = Array.ConvertAll("1 0 0 0".Split(' '), gridTemp => Convert.ToInt32(gridTemp));

            int res = maxRegion(grid, (n * m));

            Console.WriteLine(res);
        }
        #endregion

        #region Max region
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

                        if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
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
        #endregion

        #region Nearest clone
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
        #endregion

        #region find shortest
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
        #endregion

        #region journey to moon
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
        #endregion

        #region roads and libraries
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
        #endregion

        private static void MinMoves(string[] a, int sa, int sb, int ta, int tb)
        {
            int N = a.Length;
            int[] qx = new int[N * N];
            int[] qy = new int[N * N];
            int[][] d = new int[N][];
            for (int i = 0; i < N; i++)
            {
                d[i] = new int[N];
            }

            int e = 0;
            qx[e] = sa;
            qy[e] = sb;
            d[sa][sb] = 1;
            e++;
            for (int it = 0; it < e; it++)
            {
                int x = qx[it];
                int y = qy[it];
                for (int j = y + 1; j < N; j++)
                {
                    if (a[x][j] == 'X')
                        break;
                    if (d[x][j] == 0) // check
                    {
                        qx[e] = x;
                        qy[e] = j;
                        e++;
                        d[x][j] = d[x][y] + 1;
                    }
                }
                for (int j = y - 1; j >= 0; j--)
                {
                    if (a[x][j] == 'X')
                        break;
                    if (d[x][j] == 0)// check
                    {
                        qx[e] = x;
                        qy[e] = j;
                        e++;
                        d[x][j] = d[x][y] + 1;
                    }
                }
                for (int i = x + 1; i < N; i++)
                {
                    if (a[i][y] == 'X')
                        break;
                    if (d[i][y] == 0)//check
                    {
                        qx[e] = i;
                        qy[e] = y;
                        e++;
                        d[i][y] = d[x][y] + 1;
                    }
                }
                for (int i = x - 1; i >= 0; i--)
                {
                    if (a[i][y] == 'X')
                        break;
                    if (d[i][y] == 0)//check
                    {
                        qx[e] = i;
                        qy[e] = y;
                        e++;
                        d[i][y] = d[x][y] + 1;
                    }
                }
            }

            Console.WriteLine(d[ta][tb] - 1);
        }
    }
}
