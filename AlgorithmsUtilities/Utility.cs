using CommunityToolkit.Diagnostics;

namespace AlgorithmsUtilities;

public static class Utility
{
    public static bool IsInAscendingOrder<T>(this IReadOnlyCollection<T> items) where T : IComparable<T>
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

    public static IList<T> SelectionSort<T>(this IReadOnlyList<T> items)
        => throw new NotImplementedException();
}
