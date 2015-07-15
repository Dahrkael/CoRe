using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Input;
using CoRe.Audio;

namespace CoRe.GUI.WindowCommand
{
    public class TextOnly : WindowCommand
    {
        protected string fontName = "";
        protected int outline = 0;

        public TextOnly(Vector2 Position)
        {
            commands = new List<Command.Command>();
            position = Position;
        }

        public void AddCommand(string Text, CommandFunction F)
        {
            Command.TextOnly temp = new Command.TextOnly(Text);
            temp.OnClick = F;
            commands.Add(temp);
            RebuildWindow();
        }

        public string Font
        {
            get { return fontName; }
            set
            {
                if (fontName == value) { return; }
                fontName = value;
                foreach (Command.TextOnly i in commands)
                { i.Font = value; }
            }
        }

        public int Outline
        {
            get { return outline; }
            set { outline = value; foreach (Command.TextOnly i in commands) { i.Outline = outline; } }
        }
    }
}
