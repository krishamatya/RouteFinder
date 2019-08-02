using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GLRouteFinder;
using Microsoft.Extensions.Options;

namespace GLRouteFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteFinderController : ControllerBase
    {
        
        private readonly IRouterFinder routerFinder;
        private readonly IOptions<ConnectionStrings> _appSettings;
        public RouteFinderController(IRouterFinder _routerFinder,IOptions<ConnectionStrings> appsettings) {
            routerFinder = _routerFinder;
            _appSettings = appsettings;
        }

        [HttpGet("SearchRoute")]
        public  IActionResult SearchRoute(string origin, string destination)
        {
            var data = GetShortestPath(origin, destination);
            
            return Ok(data);
            
        }
       

        private  ResponseRoute GetShortestPath(string startCity, string destinationCity) {
            try
            {
                // Creating the Graph...
                Graph graph = new Graph();

                DistanceType distanceType = DistanceType.km;

                routerFinder.FillGraphWithEarthMapAsync(graph, distanceType);
               
                Node start = graph.Nodes[startCity];
                Node destination = graph.Nodes[destinationCity];
               
                if (start == null)
                {
                    return new ResponseRoute()
                    {

                        StatusCode = 400,
                        StatusMessage = "Invalid Origin"
                    };
                }
                if (destination == null)
                {
                    return new ResponseRoute()
                    {

                        StatusCode = 400,
                        StatusMessage = "Invalid Destination"
                    };
                }

                // Function which tells us the exact distance between two neighbours.
                Func<Node, Node, double> distance = (node1, node2) => node1.NeighborsList.Single(etn => etn.Neighbor.Key == node2.Key).Cost;

                // Estimation/Heuristic function (Manhattan distance)
                // It tells us the estimated distance between the last node on a proposed path and the destination node.
                //Func<Node, double> manhattanEstimation = n => Math.Abs(n.X - destination.X) + Math.Abs(n.Y - destination.Y);

                // Estimation/Heuristic function (Haversine distance)
                // It tells us the estimated distance between the last node on a proposed path and the destination node.
                Func<Node, double> haversineEstimation =
                    n => Haversine.Distance(n, destination, DistanceType.km);

                // Path<Node> shortestPath = FindPath(start, destination, distance, manhattanEstimation);
                Path<Node> shortestPath = RouterFinder.FindPath(start, destination, distance, haversineEstimation);

                string finalShortest = startCity;
                List<ResponsePath> pathList = new List<ResponsePath>();
                // Prints the shortest path.

                if (shortestPath != null)
                {
                    foreach (Path<Node> path in shortestPath.Reverse())
                    {
                        if (path.PreviousSteps != null)
                        {
                            ResponsePath responsePath = new ResponsePath();
                            responsePath.PreviousStepLastStepKey = path.PreviousSteps.LastStep.Key;
                            responsePath.LastStepKey = path.LastStep.Key;
                            responsePath.TotalCost = path.TotalCost;
                            responsePath.distanceType = distanceType;
                            pathList.Add(responsePath);
                            finalShortest = finalShortest + "->" + responsePath.LastStepKey;
                          
                        }
                    }
                    return new ResponseRoute()
                    {
                        responsePaths = pathList,
                        ShortestRooute = finalShortest,
                        StatusCode = 200,
                        StatusMessage = "Success"
                    };
                }
                else
                {
                    return new ResponseRoute()
                    {

                        StatusCode = 400,
                        StatusMessage = "No Shortest Route"
                    };

                }
            }
            catch (Exception ex) {
                return new ResponseRoute()
                {

                    StatusCode = 400,
                    StatusMessage = ex.Message
                };
            }
           

           
        }

       
    }
}
