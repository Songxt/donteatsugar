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
    public void Delegate_Test()
    {
        var mc = new AnonDelegate();
        //调用定义的方法委托
        mc.Config(mc.DoIt, 10);
        var x = 10;
        //使用匿名委托
        mc.Config(delegate(int a) { Console.WriteLine(a + x); }, 10);
        //使用lamda表达式
        mc.Config(a => Console.WriteLine(a + x), 10);

        //加强版
        //使用匿名委托
        mc.Config(delegate(int a, string b) { return a + b; });
        //使用lamda表达式 推荐
        mc.Config((a, b) => a + b);
        Assert.Equal("12", mc.Config((a, b) => { return a + b; }));
    }

    [Fact(Skip = "仅仅演示")]
    public void AnonClass_Test()
    {
        //匿名类型:只能使用一次,仅能在当前的项目中使用
        var aPeople = new { pName = "张三", pAge = 26, pAddress = "美国" };
        //嵌套匿名类型
        var aEmployee = new
        {
            JionDate = DateTime.Now,
            Salary = 8000,
            aPeople = new { pName = "张三", pAge = 26, pAddress = "美国" }
        };

        _testOutputHelper.WriteLine(aEmployee.aPeople.pName);//输出：张三
        Assert.True(aEmployee.aPeople.pName =="张三");
    }

    [Fact(DisplayName = "ExTest")]
    public void ExMethod_Test()
    {
        var sample = new SampleClass();
        Assert.True("F2" == sample.ToX2(0xf2));
    }

}