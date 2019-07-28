using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLRouteFinder
{
    public class ResponsePath
    {
        public string PreviousStepLastStepKey { get; set; }
        public string LastStepKey { get; set; }
        public double TotalCost { get; set; }
        public DistanceType distanceType { get; set; }
    }

    public class ResponseRoute:Status {
        public List<ResponsePath> responsePaths { get; set; }
        public string ShortestRooute { get; set; }
    }

    public class Status
    {

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
