using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using CoRe.Utils;
namespace CoRe
{
    namespace Audio
    {
        public class LoopedSample
        {
            private SoundEffect se;
            private SoundEffectInstance sei;

            public LoopedSample(string Filename)
            {
                se = Cache.SE(Filename);
                sei = se.CreateInstance();
                sei.Volume = Sample.DefaultVolume;
            }

            public void Play()
            {
                if (sei.State == SoundState.Playing)
                { return; }
                if (!sei.IsLooped)
                { sei.IsLooped = true; }
                sei.Play();
            }

            public void Stop()
            {
                if (sei.State != SoundState.Stopped)
                { sei.Stop(); }
            }

            public void Dispose()
            {
                sei.Dispose();
            }

            public float Volume
            {
                get { return sei.Volume; }
                set { sei.Volume = value; }
            }

            public float Pitch
            {
                get { return sei.Pitch; }
                set { sei.Pitch = Math.Max(0.0f, Math.Min(value, 1.0f)); }
            }
        }
    }
}
