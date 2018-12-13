using GraphProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class CCForDFSHard
    {
    
        private bool[] Marked;

        public int[] Id;

        private int count;

        public CCForDFSHard(GraphAPI gapi)
        {
            Marked = new bool[gapi.S];
            Id = new int[gapi.S];

            for (int i = 0; i < gapi.S; i++)
            {
                count = 1;
                if (!Marked[i])
                {
                    DFS(gapi, i);
                    //count++;
                }

                Id[i] = count;
            }

        }

        private void DFS(GraphAPI gapi, int v)
        {
            Marked[v] = true;
            //Id[v] = count;
            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item])
                {
                    DFS(gapi, item);
                    count++;
                }
            }
        }

        private bool HasPathTo(int v)
        {
            return Marked[v];
        }

        public int Count()
        {
            return count;
        }

        public int ConnectedId(int v)
        {
            return Id[v];
        }

        public bool Connected(int v, int w)
        {
            return Id[v] == Id[w];
        }
    }
}
