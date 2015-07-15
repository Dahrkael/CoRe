using System;
using Microsoft.Xna.Framework;
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Common.PhysicsLogic;
using FarseerPhysics.Common.ConvexHull;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;

namespace CoRe.Physics
{
    public class PhysicsEngine
    {
        internal static World world = new World(new Vector2(0, 0));
        internal static float UnitsPerMeter = 50;

        public PhysicsEngine()
        {
        }

        public static void Update(GameTime gameTime)
        {
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public static void ClearWorld()
        {
            world.Clear();
            world.ClearForces();
        }

        public static Vector2 ToMeters(Vector2 Value)
        {
            return new Vector2(ToMeters(Value.X), ToMeters(Value.Y));
        }

        public static float ToMeters(float Value)
        {
            return Value / UnitsPerMeter;
        }

        public static Vector2 FromMeters(Vector2 Value)
        {
            return new Vector2(FromMeters(Value.X), FromMeters(Value.Y));
        }

        public static float FromMeters(float Value)
        {
            return Value * UnitsPerMeter;
        }
    }
}
