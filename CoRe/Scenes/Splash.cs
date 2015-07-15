using System;
using CoRe;
using CoRe.Graphics;
using CoRe.Utils;
using Microsoft.Xna.Framework;

namespace CoRe.Scenes
{
    public class SceneSplash : Scene
    {
        Sprite background;
        string filename;
        int step = 0;
        int delay = 100;
        NeutralFunction f;

        public SceneSplash(string Image, NeutralFunction F)
        {
            f = F;
            filename = Image;
            Initialize();
        }

        ~SceneSplash()
        {
        }

        protected override void Initialize()
        {
            background = new Sprite(new Vector2(0, 0));
            background.Texture = Cache.Picture(filename);
            XNAGame.I.FadeIn(100);
        }

        public override void Update(GameTime gameTime)
        {
            if (step == 0)
            {
                if (!XNAGame.I.Fading) { step = 1; }
            }
            if (step == 1)
            {
                delay--;
                if (delay <= 0) { XNAGame.I.FadeOut(100); step = 2; }
            }
            if (step == 2)
            {
                if (!XNAGame.I.Fading) { f(); XNAGame.I.FadeIn(10); }
            }
        }

        public override void Draw()
        {
            background.Draw();
        }
    }
}
