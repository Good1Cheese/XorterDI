namespace XorterDI.UnitTests;

public class TestInjectableWithNoAttribute
{
    public TestBindable TestBindable { get; private set; }

    public void Construct(TestBindable testBindable)
    {
        TestBindable = testBindable;
    }
}