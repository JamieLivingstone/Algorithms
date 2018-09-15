using System.Collections.Generic;

namespace Algorithms
{
    public static class Permutation
    {
        public static string MiddlePermutation(string str)
        {
            var permutations = Permutate(str);
            return permutations[permutations.Count / 2 - 1];
        }
        
        public static List<string> Permutate(string str)
        {
            return GetPermutations(str, 0, str.Length - 1, new List<string>());
        }
        
        private static List<string> GetPermutations(string str, int point, int length, List<string> temp)
        {
            if (point == length)
            {
                temp.Add(str);
            }

            for (var i = point; i <= length; i++)
            {
                str = Swap(str, point, i);
                GetPermutations(str, point + 1, length, temp);
            }
            
            return temp;
        }

        public static string Swap(string str, int i, int j)
        {
            var chars = str.ToCharArray();
            chars[i] = str[j];
            chars[j] = str[i];

            return new string(chars);
        }
    }
}