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