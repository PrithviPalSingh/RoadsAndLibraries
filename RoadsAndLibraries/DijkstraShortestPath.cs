using GraphProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class DijkstraShortestPath
    {
        private DirectedEdgeAPI[] edgeTo;

        private double[] distTo;

        private IndexedMinPQ<double> pq;

        Dictionary<string, bool> mapEdges;

        public DijkstraShortestPath(EdgeWeightedDiGraph DG, int s)
        {
            //s = 96;
            EdgeTo = new DirectedEdgeAPI[DG.V];
            DistTo = new double[DG.V];
            pq = new IndexedMinPQ<double>(DG.V);
            mapEdges = new Dictionary<string, bool>();

            for (int i = 0; i < DG.V; i++)
            {
                DistTo[i] = double.PositiveInfinity;
            }

            DistTo[s] = 0;

            pq.insert(s, 0.0);

            while (!pq.isEmpty())
            {
                int v = pq.deleteMin();
                string align = string.Empty;
                bool verticallyReachable = false;
                bool horizontallyReachable = false;
                DirectedEdgeAPI horiEdge = null;
                DirectedEdgeAPI vertiEdge = null;
                foreach (DirectedEdgeAPI e in DG.Adj(v))
                {
                    var v1 = e.From();
                    var v2 = e.To();
                    var key = v1 < v2 ? v1 + "|" + v2 : v2 + "|" + v1;

                    if (mapEdges.ContainsKey(key))
                    {
                        align = DG.dict[key];

                        if (align == "H")
                        {
                            horizontallyReachable = true;
                            horiEdge = e;
                        }
                        else if (align == "V")
                        {
                            verticallyReachable = true;
                            vertiEdge = e;
                        }
                    }
                }

                foreach (DirectedEdgeAPI e in DG.Adj(v))
                {
                    var v1 = e.From();
                    var v2 = e.To();
                    var key = v1 < v2 ? v1 + "|" + v2 : v2 + "|" + v1;

                    //if (mapEdges.ContainsKey(key))
                    //{
                    //    continue;
                    //}

                    EdgeRelaxation(e, horizontallyReachable, verticallyReachable, DG.dict, s);


                    if (!mapEdges.ContainsKey(key))
                        mapEdges.Add(key, true);
                }
            }
        }

        public double[] DistTo { get => distTo; set => distTo = value; }
        internal DirectedEdgeAPI[] EdgeTo { get => edgeTo; set => edgeTo = value; }

        public void EdgeRelaxation(DirectedEdgeAPI e, bool horizontallyReachable,
            bool verticallyReachable, Dictionary<string, string> dict, int startIndex)
        {
            int v = e.From();
            int w = e.To();
            var key = v < w ? v + "|" + w : w + "|" + v;
            var align = string.Empty;
            if (dict.ContainsKey(key))
                align = dict[key];

            if (DistTo[w] > (DistTo[v] + e.Weight()))
            {
                if ((horizontallyReachable && verticallyReachable) || (horizontallyReachable && align == "H")
                    || (verticallyReachable && align == "V"))
                {
                    DistTo[w] = DistTo[v];
                }
                else
                {
                    DistTo[w] = DistTo[v] + e.Weight();
                }

                EdgeTo[w] = e;

                if (pq.contains(w))
                    pq.decreaseKey(w, DistTo[w]);
                else
                    pq.insert(w, DistTo[w]);
            }

            //if (DistTo[v] > DistTo[w] && DistTo[v] != double.PositiveInfinity && w != startIndex && v != startIndex)
            //{
            //    if ((horizontallyReachable && verticallyReachable) || (horizontallyReachable && align == "H")
            //           || (verticallyReachable && align == "V"))
            //    {
            //        DistTo[v] = DistTo[w];

            //        EdgeTo[w] = e;

            //        if (pq.contains(v))
            //            pq.decreaseKey(v, DistTo[v]);
            //        else
            //            pq.insert(v, DistTo[v]);
            //    }
            //}
        }

        public IEnumerable<int> PathTo(int from, int to)
        {
            //if (!HasPathTo(v))
            //{
            //    return null;
            //}

            Stack<int> path = new Stack<int>();
            for (int i = to; i != from; i = EdgeTo[i].V)
            {
                path.Push(i);
            }

            path.Push(from);
            return path;
        }
    }
}
