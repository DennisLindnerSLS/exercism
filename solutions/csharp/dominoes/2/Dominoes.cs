public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        Graph g = new();
        foreach (var dominoe in dominoes)
        {
            g.AddEdge(dominoe.Item1, dominoe.Item2);
            g.AddEdge(dominoe.Item2, dominoe.Item1);
        }

        return g.IsEularianCycle();
    }
}

public class Graph
{
    private Dictionary<int, List<int>> _nodes = new();

    public void AddEdge(int startNode, int endNode)
    {
        if(!_nodes.ContainsKey(startNode)) _nodes[startNode] = new();
        if(!_nodes.ContainsKey(endNode)) _nodes[endNode] = new();

        _nodes[startNode].Add(endNode);
    }

    private bool deepFirstSearch(int node, bool[] visited)
    {
        visited[node - 1] = true;

        foreach(var neighbour in _nodes[node])
        {
            if(!visited[neighbour - 1])
                deepFirstSearch(neighbour, visited);
        }

        return !visited.Contains(false);
    }

    public bool IsEularianCycle()
    {
        if(_nodes.Count == 0)
            return true;

        bool[] visited = new bool[_nodes.Count];

        if(!deepFirstSearch(_nodes.First().Key, visited))
            return false; //Not connected

        foreach(var node in _nodes)
        {
            //if uneven number of edges its imposible to visit all edges just once
            if(node.Value.Count % 2 != 0)
                return false;
        }

        //Cycle found
        return true;
    }
}