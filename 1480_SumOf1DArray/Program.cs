int[] arr = { 1, 2, 3, 4 };
Console.WriteLine("Arr={0}", String.Join(", ", arr));
Console.WriteLine("SumOf1DArr={0}", String.Join(", ", Solution.RunningSum(arr)));
Console.ReadKey();

public class Solution
{
    public static int[] RunningSum(int[] nums)
    {
        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}