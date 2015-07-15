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
        public class Sample
        {
            public static float DefaultVolume = 1.0f;

            protected SoundEffect se;
            SoundEffectInstance sei;
            protected float pitch = 0.0f;
            protected float volume = DefaultVolume;

            public Sample(string Filename)
            {
                se = Cache.SE(Filename);
            }

            public void Play()
            {
                sei = se.CreateInstance();
                sei.Volume = volume;
                sei.Pitch = pitch;
                sei.Play();
            }

            public float Volume
            {
                get { return volume; }
                set { volume = value; }
            }

            public float Pitch
            {
                get { return pitch; }
                set { pitch = Math.Min(value, 1.0f); }
            }
        }
    }
}
