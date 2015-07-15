using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CoRe
{
    namespace Utils
    {
        public class FPSCounter
        {
            private float currentTime = 0.0f;
            private float deltaTime = 0.0f;
            private float lastTime = 0.0f;
            private float myFPS = 0.0f;
            private GUI.Text text;

            public FPSCounter()
            {
                text = new GUI.Text("", "", new Vector2(0, 0));
            }

            public void Update(GameTime gameTime)
            {
                currentTime = (float)gameTime.TotalGameTime.TotalMilliseconds;
                deltaTime = currentTime - lastTime;
                lastTime = currentTime;
                myFPS = (int)(1.0 / (.001 * deltaTime));
            }
            public void Draw()
            {
                text.Content = "FPS: " + myFPS.ToString();
                text.Draw();
            }
        }
    }
}
