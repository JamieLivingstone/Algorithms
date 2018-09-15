using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PermutationAlgorithmTests
    {
        [Test]
        public void Swap_GivenAStringAndTwoIndexes_ShouldSwapTheIndexesAndReturnTheNewString()
        {
            // Arrange
            var input = "abc";
            
            // Act
            var result = Permutation.Swap(input, 0, 2);
            
            // Asssert
            Assert.That(result, Is.EqualTo("cba"));
        }
        
        [Test]
        public void GetPermutations_GivenAString_ReturnsAllPermutationsInAlphabeticalOrder()
        {
            // Arrange
            var input = "abc";
            
            // Act
            var result = Permutation.Permutate(input);

            // Assert
            var expectedOutput = new List<string> {"abc", "acb", "bac", "bca", "cab", "cba"};
          
            Assert.That(expectedOutput, Is.EqualTo(result));
        }

        [Test]
        [TestCase("abc", "bac")]
        [TestCase("abcd", "bdca")]
        [TestCase("abcdx", "cbxda")]
        public void MiddlePermutation_BasicTests_ReturnsMiddlePermutation(string permutation, string expected)
        {
            // Act
            var result = Permutation.MiddlePermutation(permutation);
            
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}