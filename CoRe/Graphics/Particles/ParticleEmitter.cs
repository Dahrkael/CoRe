using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.Graphics.Particles
{
    public abstract class ParticleEmitter
    {
        protected List<Particle> particles = new List<Particle>();
        protected bool           regenerate = false;
        protected Vector2        position;
        protected Color          color = Color.White;
        protected Texture2D      image;
        protected Vector2        gravity = Vector2.Zero;
        protected Vector2        wind = Vector2.Zero;
        protected Random         random = new Random();

        protected abstract Particle GenerateParticle();
        public    abstract bool     Update();

        public virtual void Draw()
        { Draw(null); }

        public virtual void Draw(Camera2D Camera)
        {
            XNAGame.Instance.SpriteBatch.End();
            XNAGame.Instance.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive);
            //XNAGame.Instance.GraphicsDevice.BlendState = BlendState.Additive;
            foreach (Particle particle in particles)
            {
                particle.Draw(Camera);
            }
            //XNAGame.Instance.GraphicsDevice.BlendState = BlendState.AlphaBlend;
            XNAGame.Instance.SpriteBatch.End();
            XNAGame.Instance.SpriteBatch.Begin();
        }

        public Particle this[int index]
        { get { return particles[index]; } }

        public int ParticlesCount
        { get { return particles.Count; } }

        public int ParticlesMaxLife
        { get { return Particle.MaxLife; } }

        public Vector2 Gravity
        { get { return gravity; } set { gravity = value; } }

        public Vector2 Wind
        { get { return wind; } set { wind = value; } }
    }
}
