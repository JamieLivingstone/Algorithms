using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class NextSmallerNumberWithSameDidgitsTests
    {
        [Test]
        [TestCase(9)]
        [TestCase(111)]
        [TestCase(135)]
        [TestCase(1027)]
        public void NextSmaller_WhenNoSmallerNumberWithSameDidgits_ReturnsMinusOne(long input)
        {
            // Act
            var result = NextSmallerNumberWithSameDigits.NextSmaller(input);
            
            // Assert
            Assert.That(result, Is.EqualTo(-1));
        }
        
        [Test]
        [TestCase(21, 12)]
        [TestCase(531, 513)]
        [TestCase(907, 790)]
        [TestCase(123456798, 123456789)]
        public void NextSmaller_WhenSmallerNumberWithSameDidgits_ReturnsSmallerNumber(long input, long expected)
        {
            // Act
            var result = NextSmallerNumberWithSameDigits.NextSmaller(input);
            
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}