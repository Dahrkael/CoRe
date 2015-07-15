using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoRe.GUI.WindowCommand.Command
{
    public class TextOnly : Command
    {
        private Text text;
        private Color unselectedColor;
        private Color selectedColor;

        public TextOnly(string Text) : this(Text, Color.White, Color.Red)
        { }

        public TextOnly(string Text, Color UnselectedColor, Color SelectedColor)
        {
            text = new Text(Text, new Vector2(400, 200));
            unselectedColor = UnselectedColor;
            selectedColor = SelectedColor;
        }

        public override string Content
        {
            get { return text.Content; }
            set { text.Content = value; }
        }

        public override Vector2 Position
        {
            get { return text.Position; }
            set { text.Position = value; }
        }

        public override Vector2 Size
        { get { return text.Size; } set { } }

        public int Outline
        {
            get { return text.Outline; }
            set { text.Outline = value; }
        }

        public string Font
        {
            get { return text.Font; }
            set { text.Font = value; }
        }

        public override void Draw()
        {
            if (highlighted) 
            { text.Draw(selectedColor); }
            else 
            { text.Draw(unselectedColor); }
        }
    }
}
