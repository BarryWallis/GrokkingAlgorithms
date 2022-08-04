// See https://aka.ms/new-console-template for more information
Dictionary<string, List<string>> _graph = new()
{
    { "you", new List<string> { "alice", "bob", "claire" } },
    { "bob", new List<string> { "anuj", "peggy" } },
    { "alice", new List<string> { "peggy" } },
    { "claire", new List<string> { "thom", "jonny" } },
    { "anuj", new List<string>() },
    { "peggy", new List<string>() },
    { "thom", new List<string>() },
    { "jonny", new List<string>() }
};

if (!Search(_graph, "you"))
{
    Console.WriteLine("No mango seller found.");
}

bool Search(Dictionary<string, List<string>> graph, string name)
{
    Queue<string> searchQueue = new();
    AddNames(graph, name, searchQueue);

    List<string> searched = new();
    while (searchQueue.Count > 0)
    {
        string person = searchQueue.Dequeue();
        if (!searched.Contains(person))
        {
            if (personIsSeller(person))
            {
                Console.WriteLine($"{person} is a mango seller!");
                return true;
            }
            else
            {
                AddNames(graph, person, searchQueue);
                searched.Add(person);
            }
        }
    }

    return false;
}


static void AddNames(Dictionary<string, List<string>> graph, string name, Queue<string> searchQueue)
{
    foreach (string item in graph[name])
    {
        searchQueue.Enqueue(item);
    }
}

bool personIsSeller(string person) => person.Last() == 'm';
