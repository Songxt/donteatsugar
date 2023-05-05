using Xunit.Abstractions;

namespace donteatsugar.test;

public class SampleTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SampleTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var sample = new SampleClass();
        sample.Name = "A";
        Assert.Equal("A", sample.Name);
        _testOutputHelper.WriteLine($"{nameof(sample.Name2)}:{sample.Name2}");
        Assert.IsType<byte>(sample[1]);
    }

    [Fact]
    public void Test2()
    {
        var sample = new SampleClass();
        var sample2 = new SampleClass();
        Assert.NotSame(sample2, sample);
    }

    [Fact]
    public void TestDelegate()
    {
        var mc = new AnonDelegate();
        //���ö���ķ���ί��
        mc.Config(mc.DoIt, 10);
        var x = 10;
        //ʹ������ί��
        mc.Config(delegate(int a) { Console.WriteLine(a + x); }, 10);
        //ʹ��lamda���ʽ
        mc.Config(a => Console.WriteLine(a + x), 10);

        //��ǿ��
        //ʹ������ί��
        mc.Config(delegate(int a, string b) { return a + b; });
        //ʹ��lamda���ʽ �Ƽ�
        mc.Config((a, b) => a + b);
        Assert.Equal("12", mc.Config((a, b) => { return a + b; }));
    }
}