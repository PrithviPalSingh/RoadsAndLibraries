using GraphProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class BFSForCastleGrid
    {

        private bool[] Marked;

        private int[] EdgeTo;

        /// <summary>
        /// Not used need to understand while revision
        /// </summary>
        public int[] DistTo;

        bool moveHorizontal;

        bool moveVertical;

        private int S;

        string previousAlign;
        public BFSForCastleGrid(GraphAPI gapi, int s)
        {
            Marked = new bool[gapi.S];
            EdgeTo = new int[gapi.S];
            DistTo = new int[gapi.S];
            this.S = s;
            BFS(gapi, s);
        }

        private void BFS(GraphAPI gapi, int s)
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
                        string key = v < w ? v + "|" + w : w + "|" + v;
                        var align = gapi.dict[key];                       

                        queue.Enqueue(w);
                        Marked[w] = true;
                        EdgeTo[w] = v;
                        DistTo[w] = DistTo[v] + 1;
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
