// See https://aka.ms/new-console-template for more information
using AlgorithmsLib;

int[] myList = new int[] { 1, 3, 5, 7, 9, };
BinarySearch<int> binarySearch = new(myList);

Console.WriteLine(ConvertToString(binarySearch.Search(3)));
Console.WriteLine(ConvertToString(binarySearch.Search(-1)));

static string? ConvertToString(int? value) => value is null ? "No Value" : value.ToString();
