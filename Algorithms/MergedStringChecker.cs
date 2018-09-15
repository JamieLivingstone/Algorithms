// At a job interview, you are challenged to write an algorithm to check if a given string, s, can be formed from two other strings, part1 and part2.
// 
// The restriction is that the characters in part1 and part2 are in the same order as in s.
// 
// The interviewer gives you the following example and tells you to figure out the rest from the given test cases.
// 
// For example:
// 
// 'codewars' is a merge from 'cdw' and 'oears':
// 
// s:  c o d e w a r s   = codewars
// part1:  c   d   w         = cdw
// part2:    o   e   a r s   = oears

namespace Algorithms
{
    public static class MergedStringChecker
    {
        public static bool IsMerge(string s, string part1, string part2)
        {
            if (part1.Length + part2.Length != s.Length)
            {
                return false;
            }
            
            var isMatch = s.Length > 0 || part1 == "" && part2 == "";

            for (var i = 0; i < s.Length; i++)
            {
                var character = s[i];

                if (isMatch == false)
                    break;

                if (part1.Length > 1 && part2.Length > 1 && part1[0] == part2[0] && i + 1 < s.Length)
                {
                    var nextChar = s[i + 1];

                    if (part1[1] == nextChar)
                    {
                        part1 = part1.Substring(1);
                    }
                    else
                    {
                        part2 = part2.Substring(1);
                    }

                } else if (part1.Length > 0 && part1[0] == character)
                {
                    part1 = part1.Substring(1);
                }
                else if (part2.Length > 0 && part2[0] == character)
                {
                    part2 = part2.Substring(1);
                }
                else
                {
                    isMatch = false;
                }
            }

            return isMatch;
        }
    }
}