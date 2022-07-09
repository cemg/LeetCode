int[][] arr = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
Console.WriteLine("Wealth={0}", Solution.MaximumWealth(arr));
Console.ReadKey();

public class Solution
{
    public static int MaximumWealth(int[][] accounts)
    {
        int wealth = 0;
        // customer
        //for (int i = 0; i < accounts.Length; i++)
        foreach (var banks in accounts)
        {
            // bank
            int total = 0;
            //for (int j = 0; j < banks.Length; j++)
            foreach (var money in banks)
            {
                total += money;
            }
            if (total > wealth) wealth = total;
        }
        return wealth;
    }
}

