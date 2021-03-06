﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProblems
{
    class GraphAPI
    {
        private ICollection<int>[] Collection;

        public Dictionary<string, string> dict = new Dictionary<string, string>();

        private int s;

        private long[] color;

        public GraphAPI(int s)
        {
            this.S = s;
            Collection = new List<int>[s];
            for (int i = 0; i < s; i++)
            {
                Collection[i] = new List<int>();
            }
        }

        public GraphAPI(int s, long[] color)
        {
            this.S = s;
            Collection = new List<int>[s];
            this.color = new long[s];
            for (int i = 0; i < s; i++)
            {
                Collection[i] = new List<int>();
                this.color[i] = color[i];
            }
        }

        public int S { get => s; set => s = value; }
        public long[] Color { get => color; set => color = value; }

        public void AddEdge(int v, int w)
        {
            Collection[v - 1].Add(w - 1);
            Collection[w - 1].Add(v - 1);
        }

        public void AddEdgeExt(int v, int w, string align)
        {
            Collection[v].Add(w);
            Collection[w].Add(v);
            string key = v < w ? v + "|" + w : w + "|" + v;
            dict.Add(key, align);
        }

        public ICollection<int> Adjacent(int v)
        {
            return Collection[v];
        }
    }
}
