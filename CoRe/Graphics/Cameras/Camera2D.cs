using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe
{
    namespace Graphics
    {
        public class Camera2D
        {
            public Vector2 position = Vector2.Zero;
            public int minY = 0;
            public int minX = 0;
            public int maxY = 0;
            public int maxX = 0;
            public int width = 800;
            public int height = 600;

            public Camera2D(Vector2 Position, int MaxX, int MaxY)
            {
                position = Position;
                maxX = MaxX;
                maxY = MaxY;
            }

            public Camera2D(Vector2 Position, int MaxX, int MaxY, int MinX, int MinY)
            {
                position = Position;
                maxX = MaxX;
                maxY = MaxY;
                minX = MinX;
                minY = MinY;
            }

            public Vector2 Relative(Vector2 AbsolutePosition)
            {
                Vector2 newPosition = Vector2.Zero;
                Vector2.Subtract(ref AbsolutePosition, ref position, out newPosition);
                return newPosition;
            }

            public void Update(Vector2 NewPosition)
            {
                Vector2 temp = Vector2.Zero;
                temp.X = Math.Min(Math.Max(NewPosition.X, 0), maxX);
                temp.Y = Math.Min(Math.Max(NewPosition.Y, 0), maxY);
                position = temp;
            }

            public bool InScreen(Vector2 Object)
            {
                Vector2 temp = Relative(Object);
                if (temp.X < 0) { return false; }
                if (temp.X > width) { return false; }
                if (temp.Y < 0) { return false; }
                if (temp.Y > height) { return false; }
                return true;
            }
        }
    }
}
