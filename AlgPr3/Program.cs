using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Definiowanie grafu jako listy sąsiedztwa
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>()
        {
            { 0, new List<int> { 1, 2 } },
            { 1, new List<int> { 0, 3, 4 } },
            { 2, new List<int> { 0, 5 } },
            { 3, new List<int> { 1 } },
            { 4, new List<int> { 1, 5 } },
            { 5, new List<int> { 2, 4 } }
        };

        Console.WriteLine("Wybierz algorytm (1 - DFS, 2 - BFS): ");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj wierzchołek początkowy: ");
        int start = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj wierzchołek końcowy: ");
        int end = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("DFS:");
            DFS(graph, start, end);
        }
        else if (choice == 2)
        {
            Console.WriteLine("BFS:");
            BFS(graph, start, end);
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór.");
        }
    }

    static void DFS(Dictionary<int, List<int>> graph, int start, int end)
    {
        HashSet<int> visited = new HashSet<int>();
        List<int> path = new List<int>();
        DFSUtil(graph, start, end, visited, path);
    }

    static void DFSUtil(Dictionary<int, List<int>> graph, int current, int end, HashSet<int> visited, List<int> path)
    {
        visited.Add(current);
        path.Add(current);
        Console.WriteLine(current);

        if (current == end)
        {
            return;
        }

        foreach (var neighbor in graph[current])
        {
            if (!visited.Contains(neighbor))
            {
                DFSUtil(graph, neighbor, end, visited, path);
                if (path.Contains(end)) // Jeśli dotarliśmy do końca, przerywamy
                    return;
            }
        }

        path.Remove(current); // Usuwamy wierzchołek z ścieżki, jeśli nie prowadzi do końca
    }

    static void BFS(Dictionary<int, List<int>> graph, int start, int end)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        List<int> path = new List<int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            path.Add(current);
            Console.WriteLine(current);

            if (current == end)
            {
                return;
            }

            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}