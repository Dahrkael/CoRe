using System;
using SharpMod;
using SharpMod.Song;
using SharpMod.SoundRenderer;
using Microsoft.Xna.Framework.Audio;

namespace CoRe.Audio
{
    public class Chiptune
    {
        SongModule mod;
        ModulePlayer player;

        public Chiptune(string ModFilename)
        {
            mod = ModuleLoader.Instance.LoadModule(ModFilename);
            player = new ModulePlayer(mod);
            XnaSoundRenderer drv = new XnaSoundRenderer(new DynamicSoundEffectInstance(48000, AudioChannels.Stereo));
            player.RegisterRenderer(drv);
        }

        public void Play()
        {
            if (!player.IsPlaying) { player.Start(); }
        }

        public void Stop()
        {
            if (player.IsPlaying) { player.Stop(); }
        }
    }
}
