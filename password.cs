using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = "password";
            var permutations = GetPermutations(password.ToCharArray());
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        static IEnumerable<string> GetPermutations(char[] chars)
        {
            if (chars.Length == 1)
            {
                yield return new string(chars);
            }
            else
            {
                foreach (var c in chars)
                {
                    var remaining = new string(chars).Replace(new string(c, 1), "");
                    foreach (var permutation in GetPermutations(remaining.ToCharArray()))
                    {
                        yield return c + permutation;
                    }
                }
            }
        }
    }
}
