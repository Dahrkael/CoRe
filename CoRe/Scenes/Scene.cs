using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CoRe
{
    namespace Scenes
    {
        public abstract class Scene
        {
            protected abstract void Initialize();

            public abstract void Update(GameTime gameTime);

            public abstract void Draw();
        }
    }
}
