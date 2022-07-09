Console.WriteLine("answer={0}", String.Join(", ", Solution.FizzBuzz(7)));
Console.ReadKey();

public class Solution
{
    public static IList<string> FizzBuzz(int n)
    {
        var list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            var div3 = i % 3 == 0;
            var div5 = i % 3 == 0;
            if (div3 && div5) list.Add("FizzBuzz");
            else if (div3) list.Add("Fizz");
            else if (div5) list.Add("Buzz");
            else list.Add(i.ToString());

            //if (i % 3 == 0 && i % 5 == 0) list.Add("FizzBuzz");
            //else if (i % 3 == 0) list.Add("Fizz");
            //else if (i % 5 == 0) list.Add("Buzz");
            //else list.Add(i.ToString());
        }
        return list;
    }
}