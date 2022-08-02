using AlgorithmsUtilities;

namespace AlgorithmsLib;

/// <summary>
/// Perform a binary search on the given items.
/// </summary>
/// <typeparam name="T">The type of items.</typeparam>
/// <param name="Items">The list of items.</param>
/// <exception cref="ArgumentException">
/// <paramref name="Items"/> must be in ascending order.
/// </exception>
public record BinarySearch<T>(IReadOnlyList<T> Items) where T : IComparable<T>
{
    private IReadOnlyList<T> Items { get; init; }
        = Items.Count < 2
          ? throw new ArgumentException("Must have at least two elements.", nameof(Items))
          : Items.IsInAscendingOrder()
            ? Items
            : throw new ArgumentException("Must be in ascending order.", nameof(Items));

    /// <summary>
    /// Search for the <paramref name="item"/> and return its position, if found.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <returns>
    /// The position of the <paramref name="item"/> 
    /// or null if the <paramref name="item"/> is not in the list.
    /// </returns>
    public int? Search(T item)
    {
        int low = 0;
        int high = Items.Count - 1;
        while (low <= high)
        {
            int middle = (low + high) / 2;
            T guess = Items[middle];
            if (guess.CompareTo(item) == 0)
            {
                return middle;
            }
            if (guess.CompareTo(item) > 0)
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }

        return null;
    }
}
