namespace TheClassLib;
public class Class1
{
    public static string Hello()
    {
        return "World!";
    }

    public static DateTimeOffset When()
    {
        var now = DateTimeOffset.Now;

        if (now.Month == 12 && now.Day < 25)
        {
            Console.WriteLine("It is soon Christmas!");
        }

        return now;
    }
}
