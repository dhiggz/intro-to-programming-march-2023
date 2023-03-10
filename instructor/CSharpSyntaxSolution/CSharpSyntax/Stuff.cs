
namespace CSharpSyntax;

public class Stuff
{
    private int x = 20;
    public void DoIt() {
        x -= 1;
    }

    public int GetX()
    {
        return x;
    }

    public void SetX(int newValue)
    {
        x = newValue;
    }
}


public class StuffUtilies
{
    public static void DoSomeStuff(Stuff obj)
    {
        obj.SetX(50000);
    }
}