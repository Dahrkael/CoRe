using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.Graphics.Particles
{
    public class Particle
    {
        public static readonly int MaxLife = 1000;

        private ParticleEmitter engine;
        private Vector2 position;
        private Vector2 velocity;
        private int life;
        private Sprite image;
        private Color color = Color.White;

        public Particle(ParticleEmitter Engine) : this(Engine, null, Vector2.Zero, Vector2.Zero, 0)
        { }

        public Particle(ParticleEmitter Engine, Texture2D Image, Vector2 Position, Vector2 Velocity, int Life)
        {
            engine = Engine;
            position = Position;
            velocity = Velocity;
            if (Life < 0) { life = 0; }
            else { life = Life; }
            image = new Sprite();
            image.Position = Position;
            if (Image == null)
            {
                image.Texture = new Texture2D(XNAGame.Instance.GraphicsDevice, 5, 5);
                image.Fill(Color.White);
            }
            else
            { image.Texture = Image; }
            
        }

        public bool Update()
        {
            velocity = velocity + engine.Gravity + engine.Wind;
            position = position + velocity;
            image.Position = position;
            life++;
            if (life > MaxLife) { return false; }
            return true;
        }

        public void Draw()
        { Draw(null); }

        public void Draw(Camera2D Camera)
        {
            image.Draw(color, Camera);
        }

        public Vector2 Position
        { get { return position; } set { position = value; } }

        public Vector2 Velocity
        { get { return velocity; } set { velocity = value; } }

        public int Life
        { get { return life; } set { life = value; } }

        public Color Color
        { get { return color; } set { color = value; } }

        public float Zoom
        { get { return image.Zoom; } set { image.Zoom = value; } }
    }
}
