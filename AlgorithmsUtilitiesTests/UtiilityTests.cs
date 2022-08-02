using AlgorithmsUtilities;

namespace AlgorithmsUtilitiesTests;

[TestClass]
public class UtiilityTests
{
    [TestMethod]
    public void IsInAscendingOrderInAscendingOrderReturnsTrue()
    {
        List<int> list = new(Enumerable.Range(-5, 10));

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
        Assert.AreEqual("Parameter \"items\" (System.Collections.Generic.IReadOnlyCollection<int>) " +
            "must have a size of at least 2, had a size of <1> (Parameter 'items')", ex.Message);
    }
}
