using Declarations.Events;

namespace Declarations.Players
{
    /// <summary>
    /// Player used for IMediaList playback.
    /// </summary>
    public interface IMediaListPlayer : IPlayer
   {
      /// <summary>
      /// Plays next item in the media list.
      /// </summary>
      void PlayNext();

      /// <summary>
      /// Plays previos item in the media list.
      /// </summary>
      void PlayPrevios();

      /// <summary>
      /// Sets or gets media list playback mode.
      /// </summary>
      PlaybackMode PlaybackMode { get; set; }

      /// <summary>
      /// Plays media item at specified index.
      /// </summary>
      /// <param name="index">Index of media</param>
      void PlayItemAt(int index);

      /// <summary>
      /// Gets media list player state.
      /// </summary>
      MediaState PlayerState { get; }

      /// <summary>
      /// Gets the inner player of the media list player.
      /// </summary>
      IDiskPlayer InnerPlayer { get; }

      /// <summary>
      /// Gets events raised by media list player instnce.
      /// </summary>
      IMediaListPlayerEvents MediaListPlayerEvents { get; }
   }
}
