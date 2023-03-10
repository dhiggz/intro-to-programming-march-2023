
namespace CSharpSyntax;

public class WorkingWithMethods
{
    [Fact]
    public void WorkingWithStuff()
    {
        var o1 = new Stuff();
        o1.DoIt();

        var o2 = new Stuff();
        o2.DoIt();

        Assert.Equal(19, o2.GetX());
        Assert.Equal(19, o1.GetX());

        o2.DoIt();
        o2.DoIt();

        Assert.Equal(19, o1.GetX());
        Assert.Equal(17, o2.GetX());
    }

    [Fact]
    public void StackStuff()
    {
        int x = 10;

        int y = x;

        y = 20;

        Assert.Equal(10, x);
        Assert.Equal(20, y);
    }

    [Fact]
    public void HeapStuff()
    {
        var s1 = new Stuff();
        var s2 = s1;

        s2.SetX(108);

        Assert.Equal(108, s1.GetX());
        Assert.Equal(108, s2.GetX());


       
    }

    [Fact]
    public void SideEffects()
    {
        var s3 = new Stuff();
        StuffUtilies.DoSomeStuff(s3);

        Assert.NotEqual(20, s3.GetX());
    }
}
