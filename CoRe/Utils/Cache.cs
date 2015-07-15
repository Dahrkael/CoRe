using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace CoRe.Utils
{
    public class Cache
    {
        private static Dictionary<string, Texture2D>   Textures = new Dictionary<string, Texture2D>();
        private static Dictionary<string, SoundEffect> SoundEffects = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, SpriteFont>  Fonts = new Dictionary<string, SpriteFont>();

        public static void Clear()
        { Textures.Clear(); SoundEffects.Clear(); Fonts.Clear(); }

        private static Texture2D LoadTexture2D(string Folder, string Filename)
        {
            string path = Folder + Filename;
            if (!Textures.ContainsKey(path))
            { 
                Textures[path] = XNAGame.Instance.Content.Load<Texture2D>(path); 
            }
            return Textures[path];
        }

        private static SoundEffect LoadSoundEffect(string Folder, string Filename)
        {
            string path = Folder + Filename;
            if (!SoundEffects.ContainsKey(path))
            { SoundEffects[path] = XNAGame.Instance.Content.Load<SoundEffect>(path); }
            return SoundEffects[path];
        }

        private static SpriteFont LoadSpriteFont(string Folder, string Filename)
        {
            string path = Folder + Filename;
            if (!Fonts.ContainsKey(path))
            { Fonts[path] = XNAGame.Instance.Content.Load<SpriteFont>(path); }
            return Fonts[path];
        }

        public static Song Song(string Filename)
        {
            string path = "Music/" + Filename;
            return XNAGame.Instance.Content.Load<Song>(path);
        }

        public static Texture2D Texture(string Filename)
        { return LoadTexture2D("Textures/", Filename); }

        public static Texture2D Particle(string Filename)
        { return LoadTexture2D("Particles/", Filename); }

        public static Texture2D Picture(string Filename)
        { return LoadTexture2D("Pictures/", Filename); }

        public static Texture2D Tile(string Filename)
        { return LoadTexture2D("Tiles/", Filename); }

        public static SoundEffect SE(string Filename)
        { return LoadSoundEffect("SE/", Filename); }

        public static SpriteFont Font(string Filename)
        { return LoadSpriteFont("Fonts/", Filename); }
    }
}