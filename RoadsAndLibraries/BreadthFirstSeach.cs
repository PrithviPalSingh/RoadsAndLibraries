using GraphProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class BreadthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

        /// <summary>
        /// Not used need to understand while revision
        /// </summary>
        public int[] DistTo;

        public int minDist;

        private int S;

        public BreadthFirstSearch(GraphAPI gapi, int s, int i, long color)
        {
            Marked = new bool[gapi.S];
            EdgeTo = new int[gapi.S];
            DistTo = new int[gapi.S];
            this.S = s;
            BFS(gapi, i, color);
        }

        private void BFS(GraphAPI gapi, int s, long color)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            Marked[s] = true;
            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                foreach (var w in gapi.Adjacent(v))
                {
                    if (!Marked[w])
                    {
                        queue.Enqueue(w);
                        Marked[w] = true;
                        EdgeTo[w] = v;
                        DistTo[w] = DistTo[v] + 1;

                        if (gapi.Color[w] == color)
                        {
                            minDist = DistTo[w];
                            return;
                        }
                    }
                }
            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i != S; i = EdgeTo[i])
            {
                path.Push(i);
            }

            path.Push(S);
            return path;
        }

        private bool HasPathTo(int v)
        {
            return Marked[v];
        }
    }
}
