using System;
using System.Collections.Generic;

class Program
{

    // Recursive function for DFS traversal
    static void DFSRec(List<List<int>> adj, bool[] visited, int s)
    {

        // Mark the current vertex as visited
        visited[s] = true;

        // Print the current vertex
        Console.Write(s + " ");

        // Recursively visit all adjacent vertices
        // that are not visited yet
        foreach (int i in adj[s])
        {
            if (!visited[i])
            {
                DFSRec(adj, visited, i);
            }
        }
    }

    // Main DFS function that initializes the visited array
    static void PerformDFS(List<List<int>> adj, int s)
    {
        bool[] visited = new bool[adj.Count];
        // Call the recursive DFS function
        DFSRec(adj, visited, s);
    }

    static void AddEdge(List<List<int>> adj, int s, int t)
    {
        adj[s].Add(t);
        adj[t].Add(s);
    }

    static void Main()
    {
        int V = 5;

        // Create an adjacency list for the graph
        List<List<int>> adj = new List<List<int>>(V);
        for (int i = 0; i < V; i++)
        {
            adj.Add(new List<int>());
        }

        // Define the edges of the graph
        int[,] edges = {
            { 1, 2 }, { 1, 0 }, { 2, 0 }, { 2, 3 }, { 2, 4 }
        };

        // Populate the adjacency list with edges
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            AddEdge(adj, edges[i, 0], edges[i, 1]);
        }

        int source = 1; // Starting vertex for DFS
        Console.WriteLine("DFS from source: " + source);
        PerformDFS(adj, source);
    }
}