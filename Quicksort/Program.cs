// See https://aka.ms/new-console-template for more information
using AlgorithmsUtilities;

List<int> items = new() { 10, 5, 3, 2 };
Console.WriteLine(string.Join(", ", items.Quicksort()));
