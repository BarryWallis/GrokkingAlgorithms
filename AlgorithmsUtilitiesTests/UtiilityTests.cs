using AlgorithmsUtilities;
namespace AlgorithmsUtilitiesTests;

[TestClass]
public class UtiilityTests
{
    [TestMethod]
    public void IsInAscendingOrderInAscendingOrderReturnsTrue()
    {
        List<int> list = new(System.Linq.Enumerable.Range(-5, 10));

        bool actual = list.IsInAscendingOrder();

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void IsInAscendingOrderNotInAscendingOrderReturnsTrue()
    {
        List<int> list = new() { 3, 1 };

        bool actual = list.IsInAscendingOrder();

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void IsInAscendingOrderHasLessThanTwoItemsThrowsArgumentException()
    {
        List<int> list = new() { 5 };

        ArgumentException ex
            = Assert.ThrowsException<ArgumentException>(() => list.IsInAscendingOrder());
        Assert.AreEqual("Parameter \"items\" (System.Collections.Generic.ICollection<int>) " +
            "must have a size of at least 2, had a size of <1> (Parameter 'items')", ex.Message);
    }

    [TestMethod]
    public void SelectionSortArrayReturnsSortedList()
    {
        List<int> items = new() { 5, 3, 6, 2, 10, };

        IList<int> actual = items.SelectionSort();

        Assert.IsTrue(actual.IsInAscendingOrder());
    }

    [TestMethod]
    public void SumDoubleArrayReturnsSumOfDoubles()
    {
        double[] items = new double[] { 1.1, 2.2, 3.3, };

        double actual = items.Sum();

        Assert.AreEqual(Enumerable.Sum(items), actual);
    }

    [TestMethod]
    public void CountArrayReturnsNumberOfItemsInArray()
    {
        int[] items = new int[] { 1, 2, 3, };

        int actual = Utility.Count(items);

#pragma warning disable CA1829 // Use Length/Count property instead of Count() when available
        Assert.AreEqual(Enumerable.Count(items), actual);
#pragma warning restore CA1829 // Use Length/Count property instead of Count() when available
    }

    [TestMethod]
    public void MaxListOfIntsReturnsMaxInt()
    {
        List<int> items = new() { 2, 8, 4, };

        int actual = Utility.Max(items);

        Assert.AreEqual(Enumerable.Max(items), actual);
    }

    [TestMethod]
    [DataRow(new int[] { 10, 5, 2, 3, }, DisplayName = "FiveElements")]
    [DataRow(new int[] { }, DisplayName = "NoElements")]
    [DataRow(new int[] { 4, }, DisplayName = "OneElement")]
    [DataRow(new int[] { 10, 5, }, DisplayName = "TwoElements")]
    public void QuickSortSortArrayReturnsSortedArray(int[] items)
    {
        IEnumerable<int> originalItems = new List<int>(items);
        List<int> sortedItems = new(items);
        sortedItems.Sort();

        IEnumerable<int> actual = items.Quicksort();

        CollectionAssert.AreEqual(originalItems.ToList(), items);
        CollectionAssert.AreEqual(sortedItems, actual.ToList());
    }
}
