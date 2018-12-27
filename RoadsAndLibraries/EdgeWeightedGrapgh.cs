using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class EdgeWeightedDiGraph
    {
        private int v;

        private ICollection<DirectedEdgeAPI>[] adj;

        public Dictionary<string, string> dict = new Dictionary<string, string>();

        public EdgeWeightedDiGraph(int v)
        {
            this.V = v;
            adj = new ICollection<DirectedEdgeAPI>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<DirectedEdgeAPI>();
            }
        }

        public int V { get => v; set => v = value; }

        public void AddEdge(DirectedEdgeAPI e, string align)
        {
            int v = e.From();
            int w = e.To();
            adj[v].Add(e);

            string key = v < w ? v + "|" + w : w + "|" + v;
            if (!dict.ContainsKey(key))
                dict.Add(key, align);
        }

        public IEnumerable<DirectedEdgeAPI> Adj(int v)
        {
            return adj[v];
        }
    }
}
