using GLRouterFinder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GLRouteFinder
{
  public  class GLRouterFinderServices: IGLRouterFinderServices
    {
        private readonly IGLRouterFinderRepository _routerFinderRepository;
        public GLRouterFinderServices(IGLRouterFinderRepository routerFinderRepository) {
            _routerFinderRepository = routerFinderRepository;
        }
        public  IEnumerable<airportsVM> GetVertexesDapper()
        {
           return  _routerFinderRepository.GetVertexesDapper();

        }
        public  IEnumerable<routesVM> GetRoutesDapper()
        {
            return  _routerFinderRepository.GetRoutesDapper();

        }

    }
}
