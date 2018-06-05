using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProblems
{
    class ConnectedComponents
    {
        private bool[] Marked;

        private int[] id;

        private int libraryCount = 0;

        private int roadCount = 0;

        public int[] Id { get => id; set => id = value; }

        public ConnectedComponents(GraphAPI gapi, int s)
        {
            Marked = new bool[gapi.S];
            Id = new int[gapi.S];
            for (int i = 0; i < s; i++)
            {
                if (!Marked[i])
                {
                    DFS(gapi, i);
                    libraryCount++;
                }
            }
        }


        private void DFS(GraphAPI gapi, int v)
        {
            Marked[v] = true;
            Id[v] = libraryCount;

            foreach (var item in gapi.Adjacent(v))
            {
                if (!Marked[item])
                {                    
                    DFS(gapi, item);
                    roadCount++;
                }
            }
        }

        public int LibraryCount()
        {
            return libraryCount;
        }

        public int RoadCount()
        {
            return roadCount;
        }

        public int ConnectedId(int v)
        {
            return Id[v];
        }
    }
}

