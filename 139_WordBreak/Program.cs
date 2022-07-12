var inputs = new Dictionary<string, string[]>();
inputs.Add("leetcode", new[] { "leet", "code" }); //Expected: true
inputs.Add("applepenapple", new[] { "apple", "pen" }); //Expected: true
inputs.Add("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }); //Expected: false
inputs.Add("cars", new[] { "car", "ca", "rs" }); // //Expected: true
inputs.Add("aaaaaaa", new[] { "aaaa", "aaa" });  //Expected: true
inputs.Add("goalspecial", new[] { "go", "goal", "goals", "special" }); //Expected: true

foreach (var input in inputs)
{
    Console.WriteLine("String: {0}", input.Key);
    Console.WriteLine("Dictionary: {0}", String.Join(",", input.Value));
    Console.WriteLine($"Input: {input.Key}, Output: {Solution.WordBreak(input.Key, input.Value)}");
    Console.WriteLine();
}
Console.ReadKey();

public class Solution
{
    public static bool WordBreak(string s, IList<string> wordDict)
    {
        Dictionary<string, bool> list = new();

        return WordBreakHelper(s, wordDict, list);
    }

    public static bool WordBreakHelper(string s, IList<string> wordDict, Dictionary<string, bool> list)
    {
        if (s == "") return true;
        if (list.ContainsKey(s)) return list[s];

        for (int i = 1; i <= s.Length; i++)
        {
            var word = s.Substring(0, i);
            var matchedWord = wordDict.Contains(word);
            if (matchedWord)
            {
                Console.WriteLine("Word: {0}, Matched={1}", word, matchedWord);
                var restOfString = s.Substring(word.Length);
                Console.WriteLine("Rest={0}", restOfString);
                var wb = WordBreakHelper(restOfString, wordDict, list);
                if (!list.ContainsKey(restOfString)) list[restOfString] = wb;
                if (wb)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Resolve by dictionary list
    /// </summary>
    /// <param name="s"></param>
    /// <param name="wordDict"></param>
    /// <returns></returns>
    public static bool WordBreak2(string s, IList<string> wordDict)
    {
        if (s == "") return true;

        foreach (var word in wordDict)
        {
            var matchedWord = s.StartsWith(word);
            if (matchedWord)
            {
                Console.WriteLine("Word: {0}, Matched={1}", word, matchedWord);
                var restOfString = s.Substring(word.Length);
                Console.WriteLine("Rest={0}", restOfString);
                var wb = WordBreak(restOfString, wordDict);
                if (wb)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// First try
    /// </summary>
    /// <param name="s"></param>
    /// <param name="wordDict"></param>
    /// <returns></returns>
    public static bool WordBreak3(string s, IList<string> wordDict)
    {
        while (s != "")
        {
            var startingWords = GetStartingWords(s, wordDict);
            if (startingWords.Count > 0)
            {
                var sIndex = startingWords.IndexOf(s);
                if (sIndex != -1 && startingWords[sIndex] == s)
                    s = "";
                else
                    s = s.Substring(startingWords[0].Length);
            }
            else
            {
                break;
            }
        }
        return s == "";
    }

    public static IList<string> GetStartingWords(string s, IList<string> wordDict)
    {
        var words = new List<string>();
        foreach (var word in wordDict)
        {
            if (s.StartsWith(word))
            {
                words.Add(word);
            }
        }
        return words.OrderBy(e => e.Length).ToList();
    }
}