using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProblems
{
    class GraphAPI
    {
        private ICollection<int>[] Collection;

        private int s;

        public GraphAPI(int s)
        {
            this.S = s;
            Collection = new List<int>[s];
            for (int i = 0; i < s; i++)
            {
                Collection[i] = new List<int>();
            }            
        }

        public int S { get => s; set => s = value; }

        public void AddEdge(int v, int w)
        {
            Collection[v].Add(w);
            Collection[w].Add(v);
        }

        public ICollection<int> Adjacent(int v)
        {
            return Collection[v];  
        }
    }
}
