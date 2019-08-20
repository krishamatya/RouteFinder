using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GLRouteFinder
{
   public interface IGLRouterFinderServices
    {
        IEnumerable<dynamic> GetVertexesDapper();
        IEnumerable<dynamic> GetRoutesDapper();
    }
}
