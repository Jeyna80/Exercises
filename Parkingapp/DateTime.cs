using System;

public class DateTimeFormatting
{
    public static void Main()
    {
        DateTime now = DateTime.Now;

        Console.WriteLine("yyyy-MM-dd HH:mm:ss: " + now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
