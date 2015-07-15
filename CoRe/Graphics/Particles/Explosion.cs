using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Utils;

namespace CoRe.Graphics.Particles
{
    public class Explosion : ParticleEmitter
    {
        private int DefaultParticlesNumber = 250;
        private int DefaultParticlesLife = 25;

        public Explosion() : this(Vector2.Zero, Color.White)
        { }

        public Explosion(Vector2 Position) : this(Position, Color.White)
        { }

        public Explosion(Vector2 Position, Color Color)
        {
            regenerate = true;
            position = Position;
            color = Color;
            //iGravity = new Vector2(0, 0.5f);
            image = Cache.Particle("blast");
            for (int i = 0; i < DefaultParticlesNumber; i++)
            { particles.Add(GenerateParticle()); }
        }

        protected override Particle GenerateParticle()
        {

            float rndX = (float)random.NextDouble() * random.Next(-5, 5);
            float rndY = (float)random.NextDouble() * random.Next(-5, 5);

            Particle particle = new Particle(this, image, position, new Vector2(rndX, -rndY), random.Next(DefaultParticlesLife));
            particle.Color = color;
            particle.Zoom = 0.3f;
            return particle;
        }

        public override bool Update()
        {
            Particle particle;

            for (int i = 0; i < particles.Count; i++)
            {
                particle = particles[i];
                if ((!particle.Update()) || (particle.Life > DefaultParticlesLife))
                { particles.RemoveAt(i); i--; }
            }

            if (particles.Count <= 0)
            { return false; }
            return true;
        }
    }
}
