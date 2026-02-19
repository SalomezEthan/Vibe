using System;
using System.Collections.Generic;
using Vibe.Core.Application.Ports;
using Vibe.Core.Domain.Persistence;

namespace Vibe.WinUI.Infrastructure
{
    internal sealed class SystemShuffleService : IShuffleService
    {
        private readonly Random random = new();

        public IEnumerable<Song> ShuffleSongs(IEnumerable<Song> songs)
        {
            List<Song> orderList = [.. songs];
            List<Song> shuffledList = [];

            while (orderList.Count > 0)
            {
                int randomIndex = random.Next(orderList.Count);
                shuffledList.Add(orderList[randomIndex]);
                orderList.RemoveAt(randomIndex); 
            }

            return shuffledList;
        }
    }
}
