using Vibe.Core.SongCollection.ValueObjects;

namespace Vibe.Core.Tests.SongCollection.ValueObjects
{
    [TestClass]
    public sealed class SongCollectionNameTests
    {
        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsEmpty()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new SongCollectionName(string.Empty));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsWhiteSpace()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new SongCollectionName(new string(' ', 10)));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsTooLong()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new SongCollectionName(new string('c', 129)));
        }
    }
}
