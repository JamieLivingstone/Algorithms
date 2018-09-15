using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MergedStringCheckerTests
    {
        [Test]
        public void IsMerge_GivenTwoPartsThatDontContainTheCharactersInTheString_ReturnsFalse()
        {
            // Arrange
            const string completeString = "hello";
            const string part1 = "hl";
            const string part2 = "el";

            // Act
            var result = MergedStringChecker.IsMerge(completeString, part1, part2);
            
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsMerge_GivenTwoPartsThatMatchInIncorrectOrder_ReturnsFalse()
        {
            // Arrange
            const string completeString = "world";
            const string part1 = "ow";
            const string part2 = "rld";

            // Act
            var result = MergedStringChecker.IsMerge(completeString, part1, part2);
            
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("", "", "")]
        [TestCase("example", "eape", "xml")]
        [TestCase("Can we merge it? Yes, we can!", "n ee tYw n!", "Cawe mrgi? es, eca")]
        public void IsMerge_GivenTwoPartsThatMatchInOrder_ReturnsTrue(string completeString, string part1, string part2)
        {
            // Act
            var result = MergedStringChecker.IsMerge(completeString, part1, part2);
            
            // Assert
            Assert.That(result, Is.True);
        }
    }
}