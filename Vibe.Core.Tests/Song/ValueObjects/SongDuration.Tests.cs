using Vibe.Core.Song.ValueObjects;

namespace Vibe.Core.Tests.Song.ValueObjects
{
    [TestClass]
    public sealed class SongDurationTests
    {
        [TestMethod]
        public void Constructor_ShouldThrow_WhenDurationIsZero()
        {
            Assert.ThrowsExactly<ArgumentException>(() => new SongDuration(TimeSpan.Zero));
        }

        [TestMethod]
        public void ToTimeSpan_ShouldReturnTimeSpan()
        {
            var duration = TimeSpan.FromSeconds(30);
            var songDuration = new SongDuration(duration);
            Assert.AreEqual(duration, songDuration.ToTimeSpan());
        }
    }
}
