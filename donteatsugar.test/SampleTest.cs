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

    [Fact(Skip = "������ʾ")]
    public void AnonClass_Test()
    {
        //��������:ֻ��ʹ��һ��,�����ڵ�ǰ����Ŀ��ʹ��
        var aPeople = new { pName = "����", pAge = 26, pAddress = "����" };
        //Ƕ����������
        var aEmployee = new
        {
            JionDate = DateTime.Now,
            Salary = 8000,
            aPeople = new { pName = "����", pAge = 26, pAddress = "����" }
        };

        _testOutputHelper.WriteLine(aEmployee.aPeople.pName);//���������
        Assert.True(aEmployee.aPeople.pName =="����");
    }

    [Fact(DisplayName = "ExTest")]
    public void ExMethod_Test()
    {
        var sample = new SampleClass();
        Assert.True("F2" == sample.ToX2(0xf2));
    }

}