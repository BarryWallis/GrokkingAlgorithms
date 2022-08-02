using AlgorithmsLib;

namespace AlgorithmsTests;

[TestClass]
public class BinarySearchTests
{
    [TestMethod]
    public void CtorWithOnlyOneItemThrowsArgumentException()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(
            () => new BinarySearch<int>(new List<int>() { 5 }));
        Assert.AreEqual("Must have at least two elements. (Parameter 'Items')", ex.Message);
    }

    [TestMethod]
    public void CtorWithElementsOutOfOrderThrowsArgumentException()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(
            () => new BinarySearch<int>(new List<int>() { 5, 3 }));
        Assert.AreEqual("Must be in ascending order. (Parameter 'Items')", ex.Message);
    }

    [TestMethod]
    [DataRow(new[] { 1, 3, 5, 7, 9 }, 1)]
    [DataRow(new[] { 1, 3, 5, 7, 9 }, 0)]
    [DataRow(new[] { 1, 3, 5, 7, 9, 11 }, 5)]
    public void SearchWithValidListAndFoundElementReturnsIndexOfFoundElement(int[] items,
                                                                             int expectedItem)
    {
        BinarySearch<int> binarySearch = new(items);

        int? actual = binarySearch.Search(items[expectedItem]);

        Assert.AreEqual(expectedItem, actual);
    }

    [TestMethod]
    [DataRow(new[] { 1, 3, 5, 7, 9 }, -1)]
    [DataRow(new[] { 1, 3, 5, 7, 9 }, 6)]
    public void SearchForMissingElementReturnsNull(int[] items,
                                                   int searchValue)
    {
        BinarySearch<int> binarySearch = new(items);

        int? actual = binarySearch.Search(searchValue);

        Assert.IsNull(actual);
    }
}
