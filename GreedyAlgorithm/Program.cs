// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

using StatesSet = System.Collections.Generic.HashSet<string>;
using Station = System.String;

StatesSet statesNeeded = new()
{
    "mt", "wa", "or", "id", "nv", "ut", "ca", "az",
};

Dictionary<Station, StatesSet> stations = new()
{
    ["kone"] = new StatesSet() { "id", "nv", "ut", },
    ["ktwo"] = new StatesSet() { "wa", "id", "mt", },
    ["three"] = new StatesSet() { "or", "nv", "ca", },
    ["kfour"] = new StatesSet() { "nv", "ut", },
    ["kfive"] = new StatesSet() { "ca", "az", },
};

StatesSet finalStations = new();
while (statesNeeded.Count > 0)
{
    Station? bestStation = null;
    StatesSet statesCovered = new();
    foreach (KeyValuePair<string, StatesSet> coverage in stations)
    {
        Station station = coverage.Key;
        StatesSet statesForStation = coverage.Value;
        StatesSet? covered
            = (new StatesSet(statesNeeded).Intersect(statesForStation)).ToHashSet();
        Debug.Assert(covered is not null);
        if (covered.Count > statesCovered.Count)
        {
            bestStation = station;
            statesCovered = new(covered);
        }
    }

    statesNeeded.ExceptWith(statesCovered);
    Debug.Assert(bestStation is not null);
    _ = finalStations.Add(bestStation);
}

Console.WriteLine(string.Join(", ", finalStations));
