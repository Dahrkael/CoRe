using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using CoRe.Utils;

namespace CoRe.Audio
{
    
    public class Music
    {
        private Song song;

        public static float DefaultVolume = 1.0f;

        public Music(string filename)
        {
            song = Cache.Song(filename);
            
        }

        public void Play(bool Looped)
        {
            if (MediaPlayer.State == MediaState.Playing) { return; }
            MediaPlayer.IsRepeating = Looped;
            MediaPlayer.Volume = DefaultVolume;
            MediaPlayer.Play(song);
        }

        public static void Stop()
        {
            if (MediaPlayer.State == MediaState.Stopped) { return; }
            MediaPlayer.Stop();
        }

        public float Volume
        {
            get { return MediaPlayer.Volume; }
            set { MediaPlayer.Volume = value; }
        }

    }
}
