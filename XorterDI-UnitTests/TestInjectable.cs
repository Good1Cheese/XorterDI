namespace XorterDI.UnitTests;

public class TestInjectable
{
    public TestBindable TestBindable { get; private set; }

    [Inject]
    public void Construct(TestBindable testBindable)
    {
        TestBindable = testBindable;
    }
}
