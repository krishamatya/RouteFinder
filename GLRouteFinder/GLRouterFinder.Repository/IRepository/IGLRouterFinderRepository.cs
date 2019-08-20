using GLRouteFinder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GLRouterFinder
{
   public interface IGLRouterFinderRepository
    {

        IEnumerable<dynamic> GetVertexesDapper();
        IEnumerable<dynamic> GetRoutesDapper();
    }
}
