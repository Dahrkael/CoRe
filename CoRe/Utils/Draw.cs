using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.Utils
{
    public static class Draw
    {
        private static Texture2D pixel = new Texture2D(XNAGame.I.GraphicsDevice, 1, 1);

        public static void Line(float width, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Maths.Angle(point1, point2);
            float length = Vector2.Distance(point1, point2);

            XNAGame.I.SpriteBatch.Draw(pixel, point1, null, Color.Black, angle, Vector2.Zero,
                                       new Vector2(length, width), SpriteEffects.None, 0);
        }
    }
}
