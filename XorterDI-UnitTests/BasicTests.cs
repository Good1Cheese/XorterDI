namespace XorterDI.UnitTests;

[TestClass]
public class BasicTests
{
    [TestMethod]
    public void Inject_ExistingDependency_ReturnsIt()
    {
        var injectable = new TestInjectable();
        var bindable = new TestBindable();
        var container = new Container();

        container.Bind(bindable);
        container.Inject(injectable);

        Assert.IsNotNull(injectable.TestBindable);
    }

    [TestMethod]
    public void Bind_Null_ReturnsException()
    {
        var container = new Container();

        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            container.Bind<TestBindable>(null);
        });
    }
}
