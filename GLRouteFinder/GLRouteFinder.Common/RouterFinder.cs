using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLRouteFinder.Data;
using Microsoft.Extensions.Options;

namespace GLRouteFinder
{
    public class RouterFinder:IRouterFinder
    {

        /// <summary>
        /// Fills a Graph with Romania map information.
        /// The Graph contains Nodes that represents Cities of Romania.
        /// Each Node has as its key the City name and its Latitude and Longitude associated information.
        /// Nodes are vertexes in the Graph. Connections between Nodes are edges.
        /// </summary>
        /// <param name="graph">The Graph to be filled</param>
        /// <param name="distanceType">The DistanceType (KM or Miles) between neighbor cities</param>
        /// 
        private readonly Graph graph = new Graph();
        private readonly IGLRouterFinderServices routerFinderServices;
       
        public RouterFinder(IGLRouterFinderServices services)
        {
            routerFinderServices = services;
        }

        public dynamic GetShortestPath(string startCity, string destinationCity)
        {
            try
            {
                // Creating the Graph...
                

                FillGraphWithEarthMapAsync(graph, DistanceType.km);

                Node start = graph.Nodes[startCity];
                Node destination = graph.Nodes[destinationCity];

                if (start == null)
                {
                    return new 
                    {

                        StatusCode = 400,
                        StatusMessage = "Invalid Origin"
                    };
                }
                if (destination == null)
                {
                    return new 
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
                Path<Node> shortestPath = FindPath(start, destination, distance, haversineEstimation);

                string finalShortest = startCity;
               
                // Prints the shortest path.

                if (shortestPath != null)
                {
                    foreach (Path<Node> path in shortestPath.Reverse())
                    {
                        if (path.PreviousSteps != null)
                        {
                            finalShortest = finalShortest + "->" + path.LastStep.Key;
                        }
                    }
                    return new {
                       
                        ShortestRoute = finalShortest,
                        StatusCode = 200,
                        StatusMessage = "Success"
                    };
                }
                else
                {
                    return new 
                    {

                        StatusCode = 400,
                        StatusMessage = "No Shortest Route"
                    };

                }
            }
            catch (Exception ex)
            {
                return new
                {

                    StatusCode = 400,
                    StatusMessage = ex.Message
                };
            }



        }

        private void  FillGraphWithEarthMapAsync(Graph graph, DistanceType distanceType)
        {
            var routes =  routerFinderServices.GetRoutesDapper();
            
            var vertexes =  routerFinderServices.GetVertexesDapper();
            try
            {
                if (vertexes != null)
                {
                    
                    foreach (var item in vertexes)
                    {
                        Node n = new Node(item.IATA3, null, Convert.ToDouble(item.Latitute), Convert.ToDouble(item.Longitude));
                        graph.AddNode(n);
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            if (routes != null )
            {
               
                foreach (var item in routes)
                {
                    var nodeOrigin = graph.Nodes[item.origin];
                    var nodeDestination = graph.Nodes[item.Destination];
                    graph.AddUndirectedEdge(nodeOrigin, nodeDestination, Haversine.Distance(nodeOrigin, nodeDestination, distanceType));
                }
            }

        }

       

        /// <summary>
        /// This is the method responsible for finding the shortest path between a Start and Destination cities using the A*
        /// search algorithm.
        /// </summary>
        /// <typeparam name="TNode">The Node type</typeparam>
        /// <param name="start">Start city</param>
        /// <param name="destination">Destination city</param>
        /// <param name="distance">Function which tells us the exact distance between two neighbours.</param>
        /// <param name="estimate">Function which tells us the estimated distance between the last node on a proposed path and the
        /// destination node.</param>
        /// <returns></returns>
        private  Path<TNode> FindPath<TNode>(TNode start, TNode destination, Func<TNode, TNode, double> distance, Func<TNode, double> estimate) where TNode : IHasNeighbours<TNode>
        {
            var closed = new HashSet<TNode>();

            var queue = new PriorityQueue<double, Path<TNode>>();

            queue.Enqueue(0, new Path<TNode>(start));

            while (!queue.IsEmpty)
            {
                var path = queue.Dequeue();

                if (closed.Contains(path.LastStep))
                    continue;

                if (path.LastStep.Equals(destination))
                    return path;

                closed.Add(path.LastStep);

                foreach (TNode n in path.LastStep.Neighbours)
                {

                    double d = distance(path.LastStep, n);

                    var newPath = path.AddStep(n, d);

                    queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
                }
            }

            return null;
        }
    }

    public interface IRouterFinder{
        
        dynamic GetShortestPath(string startCity, string destinationCity);

    }
}
