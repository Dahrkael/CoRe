using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace CoRe.GUI
{
    public class HelpText : Text
    {
        protected List<string> texts;
        protected bool visible = true;

        public HelpText(Vector2 Position) : this(Position, 0)
        { }

        public HelpText(Vector2 Position, int Size) : base("", Position)
        { texts = new List<string>(7); }

        public void AddText(string Text)
        { texts.Add(Text); }

        public void AddText(string Text, int Index)
        { texts.Insert(Index, Text); }

        public new void Draw()
        {
            if (!visible) { return; }
            base.Draw();
        }
        public int Index
        { set { content = texts[value]; } }

        public bool Visible
        { get { return visible; } set { visible = value; } }
    }
}
