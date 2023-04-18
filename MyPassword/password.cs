using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordDictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = "password";
            var permutations = GetPermutations(password.ToCharArray());

            var words = new HashSet<string>();
            foreach (var permutation in permutations)
            {
                words.Add(permutation.ToLower());
                words.Add(permutation.ToUpper());
                words.Add(permutation.Replace('a', '@').Replace('s', '5').Replace('o', '0'));
                words.Add(permutation.Replace('a', '@').Replace('s', '5').Replace('o', '0').ToLower());
                words.Add(permutation.Replace('a', '@').Replace('s', '5').Replace('o', '0').ToUpper());
            }

            using (var writer = new StreamWriter("dict.txt"))
            {
                foreach (var word in words.OrderBy(w => w))
                {
                    writer.WriteLine(word);
                }
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



