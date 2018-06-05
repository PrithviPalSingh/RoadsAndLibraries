using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsAndLibraries
{
    class ConnectedSubComponentAPI
    {
        List<long> list = null;

        int connectedComponents = 64;

        public ConnectedSubComponentAPI(List<long> listtoadd, long[] arr)
        {
            if (listtoadd == null)
                return;

            List = new List<long>();

            foreach (var item in arr)
            {
                foreach (var item2 in listtoadd)
                {
                    if (item2 != item)
                    {
                        List.Add(item);
                    }
                }
            }

            foreach (var item in List)
            {
                for (int i = 0; i < item; i++)
                {
                    if (((item >> i) & 1) == 1)
                    {
                        connectedComponents--;
                    }
                }
            }
        }

        public List<long> List { get => list; set => list = value; }
    }
}
