using System.Security.Cryptography;

namespace AdventOfCode2015.Puzzle4;

public static class Puzzle
{
    private static string[] GetRows(string inputName)
    {
        return File.ReadAllLines($"inputs/{inputName}")
            .Select(x => x).ToArray();
    }


    public static long PartOne(string inputName)
    {
        var row = GetRows(inputName)[0].ToString();

        var i = 0L;

        using var md5 = MD5.Create();
        while (true)
        {
            var hash = CalculateMD5Hash(md5, row + ++i);
            if (hash.StartsWith("00000"))
            {
                return i;
            }
        }
    }

    private static string CalculateMD5Hash(MD5 md5, string input)
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }

   

    public static long PartTwo(string inputName)
    {
        var row = GetRows(inputName)[0];

        var i = 254575;

        using var md5 = MD5.Create();
        while (true)
        {
            var hash = CalculateMD5Hash(md5, row + ++i);
            if (hash.StartsWith("000000"))
            {
                return i;
            }
        }
    }
}