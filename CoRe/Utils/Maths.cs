using System;
using Microsoft.Xna.Framework;

namespace CoRe
{
    namespace Utils
    {
        public static class Maths
        {
            public static float ToRadians(float Degrees)
            {
                return MathHelper.ToRadians(Degrees);
            }

            public static float ToDegrees(float Radians)
            {
                return MathHelper.ToDegrees(Radians);
            }

            public static double OffsetX(double Angle, double Radius)
            {
                return Math.Cos(Angle) * Radius;
            }

            public static double OffsetY(double Angle, double Radius)
            {
                return Math.Sin(Angle) * Radius;
            }

            public static double Angle(Vector2 Vector1, Vector2 Vector2)
            {
                return Math.Atan2(Vector2.Y - Vector1.Y, Vector2.X - Vector1.X);
            }
	    
	    public static double HorizontalAngle(Vector2 Vector1, Vector2 Vector2)
            {
                return Math.Atan2(Vector2.Y - Vector1.Y, Vector2.X - Vector1.X);
            }
	    
	    public static double VerticallAngle(Vector2 Vector1, Vector2 Vector2)
            {
                return Math.Atan2(Vector2.X - Vector1.X, Vector1.Y - Vector2.Y);
            }
        }
    }
}
