// See https://aka.ms/new-console-template for more information
using Cost = System.Double;
using Node = System.String;
#region DefineNodes
Node _start = new("start");
Node _a = new("a");
Node _b = new("b");
Node _fin = new("fin");
#endregion

Dictionary<string, Dictionary<Node, Cost>> graph = new()
{
    [_start] = new()
    {
        [_a] = 6,
        [_b] = 2,
    },

    [_a] = new()
    {
        [_fin] = 1,
    },
    [_b] = new()
    {
        [_a] = 3,
        [_fin] = 5,
    },
    [_fin] = new(),
};

Dictionary<Node, Cost> costs = new()
{
    [_a] = 6,
    [_b] = 2,
    [_fin] = Cost.PositiveInfinity,
};

Dictionary<Node, Node?> parents = new()
{
    [_a] = _start,
    [_b] = _start,
    [_fin] = null,
};

List<string> processed = new();

Node? node;
while ((node = FindLowestCostNode(costs, processed)) is not null)
{
    Cost cost = costs[node];
    Dictionary<string, double> neigbors = graph[node];
    foreach (string neighborNode in neigbors.Keys)
    {
        Cost newCost = cost + neigbors[neighborNode];
        if (costs[neighborNode] > newCost)
        {
            costs[neighborNode] = newCost;
            parents[neighborNode] = node;
        }
    }

    processed.Add(node);
}
Console.WriteLine(string.Join(", ", costs));

static string? FindLowestCostNode(Dictionary<Node, Cost> costs, List<string> processed)
{
    Cost lowestCost = Cost.PositiveInfinity;
    Node? lowestCostNode = null;
    foreach (KeyValuePair<string, double> kvp in costs)
    {
        Cost cost = kvp.Value;
        if (cost < lowestCost && !processed.Contains(kvp.Key))
        {
            lowestCost = cost;
            lowestCostNode = kvp.Key;
        }
    }

    return lowestCostNode;
}
