using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.Graphics.Cameras
{
    public class Camera2DMatrix
    {
        protected float     zoom;       // Camera Zoom
        public Matrix       transform;  // Matrix Transform
        public Vector2      position;   // Camera Position
        protected float     rotation;   // Camera Rotation

        public Camera2DMatrix()
        {
            zoom = 1.0f;
            rotation = 0.0f;
            position = Vector2.Zero;
        }


        public void Move(Vector2 Amount)
        {
            position += Amount;
        }

        public Matrix Transformation
        {
            get 
            { 
                transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                                     Matrix.CreateRotationZ(Rotation) *
                                                     Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                                     Matrix.CreateTranslation(new Vector3(XNAGame.I.GraphicsDevice.Viewport.Width * 0.5f,
                                                                                          XNAGame.I.GraphicsDevice.Viewport.Height * 0.5f,
                                                                                          0));
                return transform; 
            }
            set { }
        }

        public Vector2 Position
        { get { return position; } set { position = value; } }

        public float Zoom
        { get { return zoom; } set { zoom = value; if (zoom < 0.1f) zoom = 0.1f; } }

        public float Rotation
        { get { return rotation; } set { rotation = value; } }
    }
}
