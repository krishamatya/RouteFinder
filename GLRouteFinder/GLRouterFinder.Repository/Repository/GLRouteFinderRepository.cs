using GLRouteFinder;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GLRouterFinder
{
   public class GLRouteFinderRepository:IGLRouterFinderRepository
    {
        private IDapperManager _dapperManager;
       
        public GLRouteFinderRepository(IDapperManager dapperManager) {
            _dapperManager = dapperManager;
        }
       
        public IEnumerable<dynamic> GetVertexesDapper()
        {
            var data = _dapperManager.QueryAsync(sql: "usp_GetVertexes",  commandType: CommandType.StoredProcedure);
            return data.Result;
        }
        public IEnumerable<dynamic> GetRoutesDapper()
        {
            var data =  _dapperManager.QueryAsync(sql: "usp_GetRoutes", commandType: CommandType.StoredProcedure);
            return data.Result;
        }
    }
}
