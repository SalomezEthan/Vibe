using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Vibe.WinUI.Composants.Common.Messages
{
    internal sealed class PlaybackStateChangedMessage : ValueChangedMessage<bool>
    {
        public PlaybackStateChangedMessage(bool value) : base(value)
        {
        }
    }
}
