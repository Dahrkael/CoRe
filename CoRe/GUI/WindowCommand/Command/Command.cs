using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.GUI.WindowCommand.Command
{
    public abstract class Command
    {
        protected bool highlighted = false;
        protected CommandFunction f;

        public virtual void Click()
        { f(this); }

        public abstract void Draw();

        public virtual bool Highlighted
        { get { return highlighted; } set { highlighted = value; } }

        public virtual CommandFunction OnClick
        { get { return f; } set { f = value; } }

        public abstract string Content { get; set; }
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Size { get; set; }
    }
}
