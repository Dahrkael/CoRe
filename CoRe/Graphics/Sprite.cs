using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Utils;

namespace CoRe
{
    namespace Graphics
    {
        public class Sprite
        {
            protected Vector2   position = Vector2.Zero;
            protected float     zoom = 1.0f;
            protected Texture2D texture;
            protected float     rotation = 0.0f;
            protected Vector2   origin = Vector2.Zero;

            public Sprite() : this(Vector2.Zero)
            {}

            public Sprite(Vector2 Position)
            { position = Position; }

           /* 
            public void LoadTexture(string theAssetName)
            {
                texture = XNAGame.Instance.Content.Load<Texture2D>(theAssetName);
                 * Texture = Texture2D.FromFile(graphicsdevice, theAssetName + ".png");
                 * 
                 * Texture = Texture2D.FromStream(GameMain.Instance.GraphicsDevice, 
                 * File.Open(theAssetName + ".png", FileMode.Open, FileAccess.Read));
                 
            } 
            */


            public void Draw()
            { Draw(null); }

            public void Draw(Camera2D Camera)
            { Draw(Color.White, Camera); }

            public void Draw(Color Color, Camera2D Camera)
            {
                Rectangle destination;
                if (Camera == null)
                {
                    destination = new Rectangle((int)position.X, (int)position.Y, (int)(texture.Width * zoom), (int)(texture.Height * zoom));
                }
                else
                {
                    Vector2 relPosition = Vector2.Zero;
                    relPosition = Camera.Relative(position);
                    destination = new Rectangle((int)relPosition.X, (int)relPosition.Y, (int)(texture.Width * zoom), (int)(texture.Height * zoom));
                }
                XNAGame.Instance.SpriteBatch.Draw(texture, destination, new Rectangle(0, 0, texture.Width, texture.Height),
                                                  Color, rotation, origin, SpriteEffects.None, 0);

            }


            public Color GetPixel(Vector2 Position)
            {
                Rectangle pixel = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
                Color[] retrievedColor = new Color[1];
                texture.GetData<Color>(0, pixel, retrievedColor, 0, 1);

                return retrievedColor[0];
            }

            public void Fill(Color Color)
            {
                Color[] colors = new Color[texture.Width * texture.Height];
                for (int i = 0; i < colors.Length; i++)
                { colors.SetValue(Color, i); }
                texture.SetData<Color>(colors);
            }


            public void CenterOrigin()
            { origin = new Vector2(texture.Width / 2, texture.Height / 2); }

            public Vector2 Position
            { get { return position; } set { position = value; } }

            public float X
            {
                get { return position.X; }
                set { position.X = value; }
            }

            public float Y
            {
                get { return position.Y; }
                set { position.Y = value; }
            }

            public Texture2D Texture
            { get { return texture; } set { texture = value; } }

            public Vector2 Origin
            { get { return origin; } set { origin = value; } }

            public float Zoom
            { get { return zoom; } set { zoom = value; } }

            public float AngleInRadians
            { get { return rotation; } }

            public float AngleInDegrees
            { get { return Maths.ToDegrees(rotation); } }

            public void Rotate(float Degrees)
            {
                Degrees = Maths.ToRadians(Degrees);
                rotation += Degrees;
                rotation = rotation % (float)(2 * Math.PI);
            }
        }
    }
}
