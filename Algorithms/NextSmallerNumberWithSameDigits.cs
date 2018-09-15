// Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.
// 
// For example:
// 
// nextSmaller(21) == 12
// nextSmaller(531) == 513
// nextSmaller(2071) == 2017
// Return -1, when there is no smaller number that contains the same digits. Also return -1 when the next smaller number with the same digits would require the leading digit to be zero.
// 
// nextSmaller(9) == -1
// nextSmaller(111) == -1
// nextSmaller(135) == -1
// nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
// some tests will include very large numbers.
// test data only employs positive integers.

using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class NextSmallerNumberWithSameDigits
    {
        public static long NextSmaller(long n)
        {
            var nStr = n.ToString().Select(i => int.Parse(i.ToString())).ToList();
            
            // Find the first digit greater than the previous [5,(8),1,2]
            var x = -1;

            for (var i = nStr.Count - 1; i > 0; i--)
            {
                var left = nStr[i - 1];
                var right = nStr[i];
                
                if (left > right)
                {
                    x = i - 1;
                    break;
                }
            }

            // No possible matches
            if (x == -1)
            {
                return -1;
            }

            // Create two seqences from x position
            var leftSequence = nStr.Take(x).ToList();
            var rightSequence = nStr.Skip(x + 1).Take((nStr.Count - 1) - x).ToList();
            
            // Y = Find closest digit in right sequence to x value
            var xValue = int.Parse(nStr[x].ToString());
            var yIndex = 0;
            var yValue = 0;

            for (var i = 0; i < rightSequence.Count; i++)
            {
                var num = rightSequence[i];
                
                if (num > yValue && num < xValue)
                {
                    yValue = num;
                    yIndex = i;
                }
            }
            
            // Swap X and Y
            rightSequence[yIndex] = xValue;
            xValue = yValue;
            
            // Sort right sequence descending
            rightSequence = new List<int>(rightSequence.OrderByDescending(rs => rs));
            
            // Create strings from lists
            var lsString = string.Join("", leftSequence.Select(ls => ls.ToString()).ToArray());
            var rsString = string.Join("", rightSequence.Select(rs => rs.ToString()).ToArray());
            var combined = lsString + xValue + rsString;
            
            return combined[0] == '0' ? -1 : long.Parse(combined);
        }
    }
}