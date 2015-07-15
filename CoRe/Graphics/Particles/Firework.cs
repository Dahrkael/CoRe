using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Utils;

namespace CoRe.Graphics.Particles
{
    public class Firework : ParticleEmitter
    {
        private int DefaultParticlesNumber = 250;
        private int DefaultParticlesLife = 50;
        private int RocketLife = 50;

        private bool StageRocket = true;

        public Firework() : this(Vector2.Zero) { }

        public Firework(Vector2 Position)
        {
            regenerate = true;
            position = Position;
            color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            image = Cache.Particle("particle");
            //iGravity = new Vector2(0, 0.5f);

            CreateRocket();
        }

        private void CreateRocket()
        {
            float rndX = (float)random.NextDouble() * random.Next(-5, 5);
            float rndY = 8;//(float)(Random.NextDouble() + 2.0f) * 4;

            Particle particle = new Particle(this, image, position, new Vector2(rndX, -rndY), 0);
            particle.Color = color;
            particle.Zoom = 0.2f;
            particles.Add(particle);
        }

        protected override Particle GenerateParticle()
        {

            float rndX = (float)random.NextDouble() * random.Next(-5, 5);
            float rndY = (float)random.NextDouble() * random.Next(-5, 5);

            //Vector2 circle = new Vector2((float)Math.Cos(Math.PI * 2 * iParticles.Count / DefaultParticlesNumber), 
	        //           ((float)Math.Sin(Math.PI * 2 * iParticles.Count / DefaultParticlesNumber)/2)-0.75f);

            Particle particle = new Particle(this, image, position, new Vector2(rndX, -rndY), random.Next(DefaultParticlesLife));
            particle.Color = color;
            particle.Zoom = 0.4f;
            return particle;
        }

        public override bool Update()
        {
            Particle particle;
            if (StageRocket)
            {
                
                particle = particles[0];
                particle.Update();

                if (particle.Life > RocketLife)
                {
                    StageRocket = !StageRocket;
                    //iGravity = new Vector2(0, 0.1f);
                    position = particles[0].Position;
                    particles.RemoveAt(0);
                    for (int i = 0; i < DefaultParticlesNumber; i++)
                    { particles.Add(GenerateParticle()); }
                }
                return true;
            }

            for (int i = 0; i < particles.Count; i++)
            {
                particle = particles[i];
                if ((!particle.Update()) || (particle.Life > DefaultParticlesLife))
                { particles.RemoveAt(i); i--; }
                else
                { particle.Color = new Color(particle.Color.R, particle.Color.G, particle.Color.B, 255-particle.Life*4); }
            }

            if (particles.Count <= 0)
            { return false; }
            return true;
        }
    }
}
