public class Solution
{
    public static void Main()
    {
        Console.WriteLine($"{Test.sum()}");
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }
}



public class Test
{
    public static int sum()
    {
        return Solution.Add(1, 3);
    }
}



