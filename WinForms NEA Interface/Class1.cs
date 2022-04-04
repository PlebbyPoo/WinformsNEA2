using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_NEA_Interface
{

    public class RouteNode
    {
        public int Distance { get; set; }

        public int NodeIndex { get; set; }
    }
    class ShortestPathAnalysis
    {
        //The amount of vertices of graph 1
        int Graph1Vertices = 5;
        /*if (SelectedGraph==1){
            CurrentGraph=*/
        //Creating the first graph          
        int[,] Graph1 = new int[5, 5]
            {
                {0,2,4,0,0 },
                {2,0,1,5,0 },
                {4,1,0,3,1 },
                {0,5,3,0,0 },
                {0,0,1,0,0 } };
        //The amount of vertices of graph 2
        int Graph2Vertices = 8;
        //Creating the second graph
        int[,] Graph2 = new int[8, 8]
            {
                {0,2,0,2,0,0,8,0 },
                {2,0,1,0,0,3,0,5 },
                {0,1,0,1,0,0,0,0 },
                {2,0,1,0,2,0,0,0 },
                {0,0,0,2,0,1,0,0 },
                {0,3,0,0,1,0,3,0 },
                {8,0,0,0,0,3,0,1 },
                {0,5,0,0,0,0,1,0 } };
        //The amount of vertices of graph 3
        int Graph3Vertices = 10;
        //Creating the third graph
        int[,] Graph3 = new int[10, 10]
        {
                {0,0,1,4,5,0,0,0,0,15 },
                {0,0,0,0,0,3,0,0,5,0 },
                {1,0,0,2,0,0,0,0,0,0 },
                {4,0,2,0,1,0,1,0,0,0 },
                {5,0,0,1,0,0,0,0,0,0 },
                {0,3,0,0,0,0,3,2,4,0 },
                {0,0,0,1,0,3,0,6,0,0 },
                {0,0,0,0,0,2,6,0,5,0 },
                {0,5,0,0,0,4,0,5,0,3 },
                {15,0,0,0,0,0,0,0,3,0 } };
        
        int MinimumDistance(int CurrentGraphVertices, int[] Distance, bool[] VerticesSet)
        {
            var Minimum = int.MaxValue;
            var Minimum_index = -1;
            for (int v = 0; v < CurrentGraphVertices; v++)
            {
                if ((VerticesSet[v] == false) && (Distance[v] <= Minimum))
                {
                    Minimum = Distance[v];
                    Minimum_index = v;
                }
            }
            return Minimum_index;
        }
        public void PrintSolution(List<RouteNode> Route)
        {
            Console.Write("The route is ");
            foreach (var RouteNode in Route)
            {
                Console.Write(RouteNode.NodeIndex + ", ");
            }
            Console.WriteLine("The route's total distance is " + Route.Last().Distance);
        }
        public List<RouteNode> DijkstraAlgorithm(int CurrentGraphVertices, int[,] CurrentGraph, int SourceNode, int DestinationNode)
        {
            int[] Distance = new int[CurrentGraphVertices];
            bool[] VerticesSet = new bool[CurrentGraphVertices];
            for (int i = 0; i < CurrentGraphVertices; i++)
            {
                Distance[i] = int.MaxValue;
                VerticesSet[i] = false;
            }
            Distance[SourceNode] = 0;
            for (int Count = 0; Count < (CurrentGraphVertices - 1); Count++)
            {
                int u = MinimumDistance(CurrentGraphVertices, Distance, VerticesSet);

                for (int v = 0; v < CurrentGraphVertices; v++)
                {
                    if (!VerticesSet[v] && CurrentGraph[u, v] != 0 && Distance[u] != int.MaxValue && Distance[u] + CurrentGraph[u, v] < Distance[v])
                    {
                        Distance[v] = Distance[u] + CurrentGraph[u, v];
                    }
                }
                VerticesSet[u] = true;
            }
            // Order the distances into new objects, that contains their distance and original index
            var Route = Distance.Select((x, i) => new RouteNode { Distance = x, NodeIndex = i + 1 }).OrderBy(x => x.Distance).ToList();

            // Get the index of the destination node
            var DestinationNodeIndex = Route.IndexOf(Route.First(x => x.NodeIndex == DestinationNode));

            // Remove any elements with a index greater than the index of our destination node
            Route = Route.Where((x, i) => i <= DestinationNodeIndex).ToList();

            // Reverse the list
            Route.Reverse();
            var CurrentNode = Route[0];
            var ActualRoute = new List<RouteNode> { CurrentNode };
            for (int i = 0; i < Route.Count; i++)
            {
                if (i < Route.Count - 1)
                {
                    var NextNode = Route[i + 1];
                    var RouteDist = CurrentGraph[CurrentNode.NodeIndex - 1, NextNode.NodeIndex - 1];
                    if (RouteDist > 0)
                    {
                        if (CurrentNode.Distance - RouteDist == NextNode.Distance)
                        {
                            CurrentNode = NextNode;
                            ActualRoute.Add(CurrentNode);
                        }
                    }
                }
            }
            ActualRoute.Reverse();
            return ActualRoute;
        }
    }
}