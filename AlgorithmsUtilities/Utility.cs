using System.Diagnostics;

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
}
