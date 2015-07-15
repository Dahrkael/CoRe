using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Utils;

namespace CoRe.Graphics.Particles
{
    public enum FountainType { Lineal, Arc, Wild};

    public class Fountain : ParticleEmitter
    {
        private int DefaultParticlesNumber = 400;
        private int DefaultParticlesLife = 150;

        private delegate Vector2 VelocityFunction();

        private VelocityFunction velocity;
        private FountainType type = FountainType.Arc;
        private bool active = true;

        public Fountain() : this(Vector2.Zero, Color.CornflowerBlue)
        { }

        public Fountain(Vector2 Position) : this(Position, Color.CornflowerBlue)
        { }

        public Fountain(Vector2 Position, Color Color)
        {
            regenerate = true;
            gravity = new Vector2(0, 0.5f);
            position = Position;
            color = Color;
            image = Cache.Particle("particle");
            switch (type)
            {
                case FountainType.Lineal:   velocity = LinealVelocity;  break;
                case FountainType.Arc:      velocity = ArcVelocity;     break;
                case FountainType.Wild:     velocity = WildVelocity;    break;
            }
            for (int i = 0; i < DefaultParticlesNumber / 10; i++)
            { particles.Add(GenerateParticle()); }
        }

        protected override Particle GenerateParticle()
        {
            Particle particle = new Particle(this, image, position, velocity(), random.Next(DefaultParticlesLife));
            particle.Color = color;
            particle.Zoom = 0.5f;
            return particle;
        }

        protected void ResetParticle(Particle particle)
        {
            particle.Position = position;
            particle.Velocity = velocity();
            particle.Life = random.Next(DefaultParticlesLife);
        }

        public override bool Update()
        {
            if (!active) { return true; }
            Particle particle;
            int count = particles.Count;

            for (int i = 0; i < count; i++)
            {
                particle = particles[i];
                if ((!particle.Update()) || (particle.Life > DefaultParticlesLife))
                {
                    ResetParticle(particle);
                }
            }

            if (particles.Count < DefaultParticlesNumber)
            { particles.Add(GenerateParticle()); }
            return true;
        }

        private Vector2 LinealVelocity()
        {
            float rndX = (float)random.Next(-5, 5) * (float)random.NextDouble() + 0.2f;
            float rndY = (float)15;
            return new Vector2(rndX, -rndY);
        }

        private Vector2 ArcVelocity()
        {
            float rndX = (float)random.Next(-5, 5) * (float)random.NextDouble() + 0.2f;
            float rndY = 15 - (float)(Math.Pow(Math.Abs(rndX), 2) / 10);
            return new Vector2(rndX, -rndY);
        }

        private Vector2 WildVelocity()
        {
            float rndX = (float)(random.NextDouble() + 1.0f) * random.Next(-3, 3);
            float rndY = (float)(random.NextDouble() + 1.0f) * 8;
            return new Vector2(rndX, -rndY);
        }

        public bool Active
        { get { return active; } set { active = value; } }
    }
}
