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

namespace CoRe
{
    namespace Physics
    {
        public class Rect
        {
            protected Fixture fixture;
            protected NeutralFunction f;

            public Rect(float Width, float Height, bool Dynamic)
            {
                Body body = BodyFactory.CreateBody(PhysicsEngine.world, Vector2.Zero);
                body.BodyType = Dynamic ? BodyType.Dynamic : BodyType.Static;
                //body.Inertia = 1 * (Width * Width + Height * Height) / 12;
                fixture = FixtureFactory.AttachRectangle(PhysicsEngine.ToMeters(Width), PhysicsEngine.ToMeters(Height), 1f, Vector2.Zero, body);
                fixture.UserData = this;
                fixture.Body.LinearDamping = 1.0f;
                //fixture.IsSensor = true;
            }

            private bool OnCollisionF(Fixture fixtureA, Fixture fixtureB, Contact contact)
            {
                f();
                return true;
            }

            public void Accelerate(Vector2 Impulse)
            {
                //fixture.Body.ApplyForce(Impulse);
                fixture.Body.ApplyLinearImpulse(Impulse);
            }

            public void Rotate(float Impulse)
            {
                //fixture.Body.ApplyTorque(Torque);
                fixture.Body.ApplyAngularImpulse(Impulse);
            }

            public NeutralFunction F
            {
                get { return f; }
                set { f = value; }
            }
            public Body Body
            { get { return fixture.Body; } }

            public Fixture Fixture
            { get { return fixture; } }

            public Vector2 Position
            {
                get { return PhysicsEngine.FromMeters(fixture.Body.Position); }
                set { fixture.Body.Position = PhysicsEngine.ToMeters(value); }
            }

            public float Rotation
            {
                get { return fixture.Body.Rotation; }
                set { fixture.Body.Rotation = value; }
            }

            public float Friction
            {
                get { return fixture.Body.Friction; }
                set { fixture.Body.Friction = value; }
            }

            public bool IgnoreGravity
            {
                get { return false; }
                set { fixture.Body.IgnoreGravity = value; }
            }
            public Vector2 Speed
            { get { return fixture.Body.LinearVelocity; } set { fixture.Body.LinearVelocity = value; } }

            public OnCollisionEventHandler OnCollision
            {
                get { return fixture.OnCollision; }
                set { fixture.OnCollision = (OnCollisionEventHandler)this.OnCollisionF; }
            }

            public bool Moving
            { get { return !(fixture.Body.LinearVelocity != Vector2.Zero); } }

        }
    }
}
