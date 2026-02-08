using System;
using System.Collections.Generic;
using System.Text;

namespace Vibe.Core
{
    public sealed class Song
    {
        public Song(Guid id, string title, string reference)
        {
            Id = id;
            Title = title;
            Reference = reference;
        }

        public Guid Id { get; }
        public string Title { get; private set; }
        public string Reference { get; private set; }

        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Un son ne peut pas avoir un titre vide.");
            }

            Title = newTitle;
        }
    }
}
