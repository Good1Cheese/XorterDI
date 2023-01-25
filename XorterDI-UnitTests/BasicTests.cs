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

        void Act() => container.Bind<TestBindable>(null);

        Assert.ThrowsException<ArgumentNullException>(Act);
    }

    [TestMethod]
    public void Inject_WithNoAttribute_ReturnsNull()
    {
        var fakeInjectable = new TestInjectableWithNoAttribute();
        var bindable = new TestBindable();
        var container = new Container();

        container.Bind(bindable);
        container.Inject(fakeInjectable);

        Assert.IsNull(fakeInjectable.TestBindable);
    }
}
