using System.Diagnostics;
using System.Numerics;

using CommunityToolkit.Diagnostics;

namespace AlgorithmsUtilities;

public static class Utility
{
    /// <summary>
    /// Verify that the given collection is in ascending order.
    /// </summary>
    /// <typeparam name="T">The tyoe if items in the collection.</typeparam>
    /// <param name="items">The collection.</param>
    /// <returns>
    /// <see langword="true"/> if the collection is in ascending order; 
    /// otherwise <see langword="false"/>
    /// </returns>
    public static bool IsInAscendingOrder<T>(this ICollection<T> items) where T : IComparable<T>
    {
        Guard.HasSizeGreaterThanOrEqualTo(items, 2, nameof(items));

        T lastItem = items.First();
        foreach (T item in items)
        {
            if (item.CompareTo(lastItem) < 0)
            {
                return false;
            }

            lastItem = item;
        }

        return true;
    }

    /// <summary>
    /// Sort a list into ascending order.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="items">The list.</param>
    /// <returns>A new list in sorted order.</returns>
    public static IList<T> SelectionSort<T>(this IList<T> items) where T : IComparable<T>
    {
        Guard.HasSizeGreaterThan(items, 0, nameof(items));
#if DEBUG
        List<T> originalItems = new(items);
#endif

        List<T> oldItems = new(items);
        List<T> newItems = new();
        int count = oldItems.Count;
        for (int i = 0; i < count; i++)
        {
            int smallestIndex = FindSmallestIndex(oldItems);
            T item = oldItems[smallestIndex];
            oldItems.RemoveAt(smallestIndex);
            newItems.Add(item);
        }

        Debug.Assert(IsInAscendingOrder(newItems));
        Debug.Assert(items.SequenceEqual(originalItems));
        Debug.Assert(newItems.Count == originalItems.Count);
        return newItems;

        static int FindSmallestIndex(IList<T> items)
        {
            T smallestValue = items[0];
            int smallestIndex = 0;
            int count = items.Count;
            for (int i = 1; i < count; i++)
            {
                if (items[i].CompareTo(smallestValue) < 0)
                {
                    smallestValue = items[i];
                    smallestIndex = i;
                }
            }

            return smallestIndex;
        }
    }

    /// <summary>
    /// Calculate the sum of a collection of numbers.
    /// </summary>
    /// <typeparam name="T">The type of numbers in the list. Must be an INumber.</typeparam>
    /// <param name="numbers">The list of numbers.</param>
    /// <returns>The sum of the numbers in the list.</returns>
    public static T Sum<T>(this IEnumerable<T> numbers) where T : INumber<T>
        => numbers.Any() ? numbers.First() + numbers.Skip(1).Sum() : T.Zero;

    /// <summary>
    /// Count the number of items in a collection.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    /// <param name="items">The collection o items.</param>
    /// <returns>The number of items in the collection.</returns>
    public static int Count<T>(this IEnumerable<T> items)
        => items.Any() ? 1 + items.Skip(1).Count() : 0;

    /// <summary>
    /// Find the maximum value in  collection.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    /// <param name="items">The items in the collection.</param>
    /// <returns>The maximum value of the items in the collection.</returns>
    public static T Max<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        T currentMax;
        if (items.Count() == 2)
        {
            return items.First().CompareTo(items.Take(1).First()) > 0 ? items.First()
                                                                      : items.Take(1).First();
        }
        currentMax = items.Skip(1).Max();
        return items.First().CompareTo(currentMax) > 0 ? items.First() : currentMax;
    }

    /// <summary>
    /// Sort a collection using Quicksort. 
    /// </summary>
    /// <remarks>
    /// This extension method returns a new collection. The <paramref name="items"/> collection is 
    /// unchanged.
    /// </remarks>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    /// <param name="items">The collection to sort.</param>
    /// <returns>The sorted collection.</returns>
    public static IEnumerable<T> Quicksort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        List<T> result = new();
        if (items.Count() < 2)
        {
            return items;
        }

        T pivot = items.First();
        IEnumerable<T> lessThanPivot = items.Where(t => t.CompareTo(pivot) < 0);
        IEnumerable<T> greaterThanPivot = items.Where(t => t.CompareTo(pivot) > 0);

        foreach (T item in lessThanPivot.Quicksort())
        {
            result.Add(item);
        }

        result.Add(pivot);

        foreach (T item in greaterThanPivot.Quicksort())
        {
            result.Add(item);
        }

        return result;
    }

}
