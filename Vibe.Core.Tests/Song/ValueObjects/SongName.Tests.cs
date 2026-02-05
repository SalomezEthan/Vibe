using Vibe.Core.Song.ValueObjects;

namespace Vibe.Core.Tests.Song.ValueObjects
{
    [TestClass]
    public class SongNameTests
    {
        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsEmpty()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new SongName(string.Empty));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsWhiteSpace()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new SongName(" "));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenNameIsTooLong()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new SongName(new string('x', 256)));
        }

        [TestMethod]
        public void ToString_ShouldReturnName()
        {
            string name = "MyLove";
            var songName = new SongName(name);
            Assert.AreEqual(name, songName.ToString());
        }
    }
}
