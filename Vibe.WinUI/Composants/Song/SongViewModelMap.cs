using System;
using System.Collections.Concurrent;
using Vibe.Core.Application.Models;
using Vibe.WinUI.Composants.Song.ViewModels;

namespace Vibe.WinUI.Composants.Song
{
    internal sealed class SongViewModelMap(SongViewModelFactory factory)
    {
        private readonly ConcurrentDictionary<Guid, SongViewModel> viewModelMap = [];

        public SongViewModel GetOrCreate(SongModel model)
        {
            return viewModelMap.GetOrAdd(model.Id, factory.Create(model));
        }
    }
}
