using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2
{
    public abstract class Polygon
    {
        public abstract List<ActiveEdge> ActiveEdges { get; }
    }
}
