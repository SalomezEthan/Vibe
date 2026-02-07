using Vibe.Core.User;

namespace Vibe.Core.Tests.User
{
    [TestClass]
    public sealed class UserEntityTests
    {
        private static UserEntity CreateUserEntitySample()
        {
            return new UserEntity(
                [Guid.NewGuid()]
                );
        }

        [TestMethod]
        public void AddFavoriteSong_ShouldThrow_WhenFavoritesAlreadyContainsSong()
        {
            var user = CreateUserEntitySample();
            Guid duplicatedId = user.FavoriteSongIds[0];
            Assert.ThrowsExactly<ArgumentException>(() => user.AddFavoriteSong(duplicatedId));
        }

        [TestMethod]
        public void RemoveFavoriteSong_ShouldThrow_WhenFavoriteNotContainsSong()
        {
            var user = CreateUserEntitySample();
            var randomId = Guid.NewGuid();
            Assert.ThrowsExactly<ArgumentException>(() => user.RemoveFavoriteSong(randomId));
        }
    }
}
