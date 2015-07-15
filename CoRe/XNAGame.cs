using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CoRe.Scenes;
using CoRe.Utils;

namespace CoRe
{
    public delegate void NeutralFunction();
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class XNAGame : Microsoft.Xna.Framework.Game
    {
        protected static XNAGame instance;

        public static XNAGame I
        { get { return instance; } }
        public static XNAGame Instance
        { get { return instance; } }

        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected int width;
        protected int height;
        protected Scene scene;
        protected FPSCounter FPSCounter;
        protected Texture2D fade;
        protected float fadeLevel = 0.0f;
        protected int fadeTime = 0;

        protected XNAGame(int Width, int Height, bool FullScreen)
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            width = Width;
            height = Height;
            graphics.IsFullScreen = FullScreen;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            FPSCounter = new FPSCounter();
            fade = new Texture2D(GraphicsDevice, width, height);
            Color[] colorData = new Color[width * height];
            for (int i = 0; i < width * height; i++)
            { colorData[i] = Color.Black; }
            fade.SetData<Color>(colorData);  

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            FPSCounter.Update(gameTime);
            FadeUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            FPSCounter.Draw();
            spriteBatch.Draw(fade, new Rectangle(0, 0, width, height), new Color(1.0f, 1.0f, 1.0f, fadeLevel));
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Finish()
        { this.Exit(); }

        private void FadeUpdate()
        {
            if (fadeTime > 0)
            {
                float Temp = fadeLevel / fadeTime;
                fadeLevel -= Temp;
                fadeTime--;
            }
            if (fadeTime < 0)
            {
                float Temp = (1.0f - fadeLevel) / (float)System.Math.Abs(fadeTime);
                fadeLevel += Temp;
                fadeTime++;
            }
        }

        public void FadeIn(int Duration)
        {
            fadeTime = Duration;
            fadeLevel = 1.0f;
        }

        public void FadeOut(int Duration)
        {
            fadeTime = -Duration;
            fadeLevel = 0.0f;
        }

        public bool Fading
        { get { return (fadeTime != 0); } }

        public SpriteBatch SpriteBatch { get { return spriteBatch; } set { } }
        public GraphicsDeviceManager Graphics { get { return graphics; } set { } }
        public int Width { get { return width; } set { } }
        public int Height { get { return height; } set { } }
        public Scene Scene { get { return Scene; } set { scene = value;  } }
    }
}
