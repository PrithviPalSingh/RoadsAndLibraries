using GraphProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class DepthFirstSearch
    {
        private bool[] Marked;

        private int[] EdgeTo;

        private int S;

        public int[] DistTo;

        public List<int> countIds = new List<int>();

        /// <summary>
        /// 1. DFS marks all the vertices connected to s in time proportional
        ///    to sum of their degrees.
        /// 2. If w is marked, then w is connected to s. 
        /// 3. If w is connected to s, then w is marked.
        /// 4. Visit each vertex once.
        /// </summary>
        /// <param name="gapi"></param>
        /// <param name="s"></param>
        public DepthFirstSearch(GraphAPI gapi, int s)
        {
            Marked = new bool[gapi.S];
            EdgeTo = new int[gapi.S];
            DistTo = new int[gapi.S];
            this.S = s;
            for (int i = 0; i < gapi.S; i++)
            {
                if (!Marked[i])
                {
                    DFS(gapi, i);
                }
            }
        }

        //public DepthFirstSearch(GraphAPI gapi, int s, long color)
        //{
        //    Marked = new bool[gapi.S];
        //    EdgeTo = new int[gapi.S];
        //    this.S = s;
        //    for (int i = 0; i < gapi.S; i++)
        //    {
        //        int count = 0;
        //        long currentColor = gapi.Color[i];
        //        if (!Marked[i])
        //        {
        //            DFS(gapi, i, color, countIds, count, currentColor);
        //        }
        //    }
        //}

        //public DepthFirstSearch(DiaGraphAPI gapi, int s)
        //{
        //    Marked = new bool[gapi.V];
        //    EdgeTo = new int[gapi.V];
        //    this.S = s;
        //    DFS(gapi, s);
        //}

        private void DFS(GraphAPI gapi, int v, long color, List<int> countIds, int count, long currenColor)
        {
            Marked[v] = true;

            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item - 1])
                {
                    count++;
                    if (gapi.Color[item - 1] == color && currenColor == color)
                    {
                        countIds.Add(count);
                    }

                    DFS(gapi, item - 1, color, countIds, count, currenColor);
                    EdgeTo[item - 1] = v;
                }
            }
        }

        private void DFS(GraphAPI gapi, int v)
        {
            Marked[v] = true;
            int count = 0;
            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item - 1])
                {
                    count++;
                    DFS(gapi, item - 1);
                    EdgeTo[item - 1] = v;
                    DistTo[item - 1] = count;
                }
            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v - 1))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v - 1; i != S; i = EdgeTo[i])
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
