using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GLRouteFinder
{
  class RouterFinder
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
       
        public static void FillGraphWithEarthMap(Graph graph, DistanceType distanceType)
        {
            var routes = GetRoutes();
            var vertexes = GetVertexes();
            try
            {
                if (vertexes != null && vertexes.Count > 0)
                {
                    foreach (var item in vertexes)
                    {
                        //if (item.Latitute is string) {
                        //    if (item.Longitude.Contains(",")) {
                        //        var record = item.Longitude.Split(",");
                        //        item.Latitute = record[0];
                        //        item.Longitude = record[1];
                        //    }
                        //}
                        Node n = new Node(item.IATA3, null, Convert.ToDouble(item.Latitute), Convert.ToDouble(item.Longitude));
                        graph.AddNode(n);
                    }
                }
            }
            catch (Exception ex) {

            }

            if (routes != null && routes.Count > 0)
            {
                foreach (var item in routes)
                {
                    var nodeOrigin = graph.Nodes[item.Origin];
                    var nodeDestination = graph.Nodes[item.Destination];
                    graph.AddUndirectedEdge(nodeOrigin, nodeDestination, Haversine.Distance(nodeOrigin, nodeDestination, distanceType));
                }
            }

            //// 20 Vertexes
            //Node arad = new Node("Arad", null, 46.1792414, 21.3150154); // Creating a Node...
            //graph.AddNode(arad); // Adding the Node to the Graph...

            //Node bucharest = new Node("Bucharest", null, 44.4479237, 26.097879);
            //graph.AddNode(bucharest);

            //Node craiova = new Node("Craiova", null, 44.3182085, 23.8016427);
            //graph.AddNode(craiova);

            //Node dobreta = new Node("Dobreta", null, 44.6302374, 22.6519904);
            //graph.AddNode(dobreta);

            //Node eforie = new Node("Eforie", null, 44.049114, 28.652727);
            //graph.AddNode(eforie);

            //Node fagaras = new Node("Fagaras", null, 45.843342, 24.977871);
            //graph.AddNode(fagaras);

            //Node giurgiu = new Node("Giurgiu", null, 43.8959986, 25.9550199);
            //graph.AddNode(giurgiu);

            //Node hirsova = new Node("Hirsova", null, 44.691842, 27.951481);
            //graph.AddNode(hirsova);

            //Node iasi = new Node("Iasi", null, 47.1569514, 27.5898533);
            //graph.AddNode(iasi);

            //Node lugoj = new Node("Lugoj", null, 45.688011, 21.9161);
            //graph.AddNode(lugoj);

            //Node mehadia = new Node("Mehadia", null, 44.906575, 22.360437);
            //graph.AddNode(mehadia);

            //Node neamt = new Node("Neamt", null, 47.0355965, 26.4680355);
            //graph.AddNode(neamt);

            //Node oradea = new Node("Oradea", null, 47.06094, 21.9276655);
            //graph.AddNode(oradea);

            //Node pitesti = new Node("Pitesti", null, 44.858801, 24.8666793);
            //graph.AddNode(pitesti);

            //Node rimnicuVilcea = new Node("Rimnicu Vilcea", null, 45.110039, 24.382641);
            //graph.AddNode(rimnicuVilcea);

            //Node sibiu = new Node("Sibiu", null, 45.7931069, 24.1505932);
            //graph.AddNode(sibiu);

            //Node timisoara = new Node("Timisoara", null, 45.7479372, 21.2251759);
            //graph.AddNode(timisoara);

            //Node urziceni = new Node("Urziceni", null, 47.71996, 22.406675);
            //graph.AddNode(urziceni);

            //Node vaslui = new Node("Vaslui", null, 46.6403758, 27.7295175);
            //graph.AddNode(vaslui);

            //Node zerind = new Node("Zerind", null, 46.6247847, 21.5170587);
            //graph.AddNode(zerind);

            // 41 Edges
            // Arad <-> Sibiu
            //graph.AddUndirectedEdge(arad, sibiu, Haversine.Distance(arad, sibiu, distanceType));
            //// Arad <-> Timisoara
            //graph.AddUndirectedEdge(arad, timisoara, Haversine.Distance(arad, timisoara, distanceType));
            //// Arad <-> Zerind
            //graph.AddUndirectedEdge(arad, zerind, Haversine.Distance(arad, zerind, distanceType));

            //// Bucharest <-> Craiova
            //graph.AddUndirectedEdge(bucharest, craiova, Haversine.Distance(bucharest, craiova, distanceType));
            //// Bucharest <-> Eforie
            //graph.AddUndirectedEdge(bucharest, eforie, Haversine.Distance(bucharest, eforie, distanceType));
            //// Bucharest <-> Fagaras
            //graph.AddUndirectedEdge(bucharest, fagaras, Haversine.Distance(bucharest, fagaras, distanceType));
            //// Bucharest <-> Giurgiu
            //graph.AddUndirectedEdge(bucharest, giurgiu, Haversine.Distance(bucharest, giurgiu, distanceType));
            //// Bucharest <-> Hirsova
            //graph.AddUndirectedEdge(bucharest, hirsova, Haversine.Distance(bucharest, hirsova, distanceType));
            //// Bucharest <-> Neamt
            //graph.AddUndirectedEdge(bucharest, neamt, Haversine.Distance(bucharest, neamt, distanceType));
            //// Bucharest <-> Pitesti
            //graph.AddUndirectedEdge(bucharest, pitesti, Haversine.Distance(bucharest, pitesti, distanceType));
            //// Bucharest <-> Vaslui
            //graph.AddUndirectedEdge(bucharest, vaslui, Haversine.Distance(bucharest, vaslui, distanceType));

            //// Craiova <-> Dobreta
            //graph.AddUndirectedEdge(craiova, dobreta, Haversine.Distance(craiova, dobreta, distanceType));
            //// Craiova <-> Giurgiu
            //graph.AddUndirectedEdge(craiova, giurgiu, Haversine.Distance(craiova, giurgiu, distanceType));
            //// Craiova <-> Pitesti
            //graph.AddUndirectedEdge(craiova, pitesti, Haversine.Distance(craiova, pitesti, distanceType));
            //// Craiova <-> Rimnicu Vilcea
            //graph.AddUndirectedEdge(craiova, rimnicuVilcea, Haversine.Distance(craiova, rimnicuVilcea, distanceType));

            //// Dobreta <-> Mehadia
            //graph.AddUndirectedEdge(dobreta, mehadia, Haversine.Distance(dobreta, mehadia, distanceType));

            //// Eforie <-> Hirsova
            //graph.AddUndirectedEdge(eforie, hirsova, Haversine.Distance(eforie, hirsova, distanceType));
            //// Eforie <-> Giurgiu
            //graph.AddUndirectedEdge(eforie, giurgiu, Haversine.Distance(eforie, giurgiu, distanceType));

            //// Fagaras <-> Hirsova
            //graph.AddUndirectedEdge(fagaras, hirsova, Haversine.Distance(fagaras, hirsova, distanceType));
            //// Fagaras <-> Neamt
            //graph.AddUndirectedEdge(fagaras, neamt, Haversine.Distance(fagaras, neamt, distanceType));
            //// Fagaras <-> Pitesti
            //graph.AddUndirectedEdge(fagaras, pitesti, Haversine.Distance(fagaras, pitesti, distanceType));
            //// Fagaras <-> Sibiu
            //graph.AddUndirectedEdge(fagaras, sibiu, Haversine.Distance(fagaras, sibiu, distanceType));
            //// Fagaras <-> Urziceni
            //graph.AddUndirectedEdge(fagaras, urziceni, Haversine.Distance(fagaras, urziceni, distanceType));
            //// Fagaras <-> Vaslui
            //graph.AddUndirectedEdge(fagaras, vaslui, Haversine.Distance(fagaras, vaslui, distanceType));

            //// Hirsova <-> Vaslui
            //graph.AddUndirectedEdge(hirsova, vaslui, Haversine.Distance(hirsova, vaslui, distanceType));

            //// Iasi <-> Neamt
            //graph.AddUndirectedEdge(iasi, neamt, Haversine.Distance(iasi, neamt, distanceType));
            //// Iasi <-> Vaslui
            //graph.AddUndirectedEdge(iasi, vaslui, Haversine.Distance(iasi, vaslui, distanceType));

            //// Lugoj <-> Mehadia
            //graph.AddUndirectedEdge(lugoj, mehadia, Haversine.Distance(lugoj, mehadia, distanceType));
            //// Lugoj <-> Rimnicu Vilcea
            //graph.AddUndirectedEdge(lugoj, rimnicuVilcea, Haversine.Distance(lugoj, rimnicuVilcea, distanceType));
            //// Lugoj <-> Sibiu
            //graph.AddUndirectedEdge(lugoj, sibiu, Haversine.Distance(lugoj, sibiu, distanceType));
            //// Lugoj <-> Timisoara
            //graph.AddUndirectedEdge(lugoj, timisoara, Haversine.Distance(lugoj, timisoara, distanceType));
            //// Lugoj <-> Zerind
            //graph.AddUndirectedEdge(lugoj, zerind, Haversine.Distance(lugoj, zerind, distanceType));

            //// Mehadia <-> Rimnicu Vilcea
            //graph.AddUndirectedEdge(mehadia, rimnicuVilcea, Haversine.Distance(mehadia, rimnicuVilcea, distanceType));
            //// Mehadia <-> Timisoara
            //graph.AddUndirectedEdge(mehadia, timisoara, Haversine.Distance(mehadia, timisoara, distanceType));

            //// Neamt <-> Vaslui
            //graph.AddUndirectedEdge(neamt, vaslui, Haversine.Distance(neamt, vaslui, distanceType));
            //// Neamt <-> Urziceni
            //graph.AddUndirectedEdge(neamt, urziceni, Haversine.Distance(neamt, urziceni, distanceType));

            //// Oradea <-> Sibiu
            //graph.AddUndirectedEdge(oradea, sibiu, Haversine.Distance(oradea, sibiu, distanceType));
            //// Oradea <-> Urziceni
            //graph.AddUndirectedEdge(oradea, urziceni, Haversine.Distance(oradea, urziceni, distanceType));
            //// Oradea <-> Zerind
            //graph.AddUndirectedEdge(oradea, zerind, Haversine.Distance(oradea, zerind, distanceType));

            //// Pitesti <-> Rimnicu Vilcea
            //graph.AddUndirectedEdge(pitesti, rimnicuVilcea, Haversine.Distance(pitesti, rimnicuVilcea, distanceType));

            //// Rimnicu Vilcea <-> Sibiu
            //graph.AddUndirectedEdge(rimnicuVilcea, sibiu, Haversine.Distance(rimnicuVilcea, sibiu, distanceType));
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
        public static  Path<TNode> FindPath<TNode>(TNode start,TNode destination, Func<TNode, TNode, double> distance, Func<TNode, double> estimate) where TNode:IHasNeighbours<TNode>
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

                foreach (TNode n in path.LastStep.Neighbours.Distinct())
                {
                    double d = distance(path.LastStep, n);

                    var newPath = path.AddStep(n, d);

                    queue.Enqueue(newPath.TotalCost + estimate(n), newPath);
                }
            }

            return null;
        }

        public static List<airportsVM> GetVertexes()
        {
            List<airportsVM> airports = new List<airportsVM>();
            var connectionString = "Server= (LocalDb)\\MSSQLLocalDB;Database=GuestLogix;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_GetVertexes"))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            airports.Add(new airportsVM()
                            {
                                 IATA3 = reader["IATA3"].ToString(),
                                 Latitute=reader["Latitute"].ToString(),
                                 Longitude= reader["Longitude"].ToString()
                            });
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return airports;
        }
        public static List<routesVM> GetRoutes()
        {
            List<routesVM> routes = new List<routesVM>();
            var connectionString = "Server= (LocalDb)\\MSSQLLocalDB;Database=GuestLogix;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_GetRoutes"))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            routes.Add(new routesVM()
                            {
                                Origin = reader["origin"].ToString(),
                                Destination = reader["Destination"].ToString()
                            });
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return routes;
        }


    }
}
