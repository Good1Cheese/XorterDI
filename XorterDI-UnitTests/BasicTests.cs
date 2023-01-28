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
    public void Inject_WithNoAttribute_ReturnsException()
    {
        var fakeInjectable = new TestInjectableWithNoAttribute();
        var bindable = new TestBindable();
        var container = new Container();

        container.Bind(bindable);
        void Act() => container.Inject(fakeInjectable);

        Assert.ThrowsException<XorterDIException>(Act);
    }

    [TestMethod]
    public void Inject_WithNothingBinded_ReturnsException()
    {
        var injectable = new TestInjectable();
        var container = new Container();

        void Act() => container.Inject(injectable);

        Assert.ThrowsException<XorterDIException>(Act);
    }

    [TestMethod]
    public void Inject_Null_ReturnsException()
    {
        var container = new Container();

        void Act() => container.Inject<TestBindable>(null);

        Assert.ThrowsException<ArgumentNullException>(Act);
    }

    [TestMethod]
    public void Bind_Null_ReturnsException()
    {
        var container = new Container();

        void Act() => container.Bind<TestBindable>(null);

        Assert.ThrowsException<ArgumentNullException>(Act);
    }
}
