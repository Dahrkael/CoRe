using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using CoRe.Input;
using CoRe.Audio;
using CoRe.Utils;

namespace CoRe.GUI.WindowCommand
{
    public delegate void CommandFunction(Command.Command c);
    public enum Alignment { Left, Right, Center };

    public abstract class WindowCommand
    {
        protected List<Command.Command> commands;
        protected int spacing = 25;
        protected int index = 0;
        protected Vector2 position;
        protected Sample moveSound;
        protected Sample selectSound;
        protected Alignment alignment = Alignment.Center;
        protected bool visible = true;
        protected bool active = true;

        //protected abstract void RebuildWindow();
        protected virtual void RebuildWindow()
        {
            int max = 0;
            switch (alignment)
            {
                case Alignment.Left:
                    for (int i = 0; i < commands.Count; i++)
                    { commands[i].Position = new Vector2(position.X + 10, position.Y + (i * spacing) + 10); }
                    break;
                case Alignment.Right:
                    foreach (Command.Command i in commands)
                    { if (max < i.Size.X) { max = (int)i.Size.X; } }
                    for (int i = 0; i < commands.Count; i++)
                    { commands[i].Position = new Vector2(position.X + max - commands[i].Size.X, position.Y + (i * spacing) + 10); }
                    break;
                case Alignment.Center:
                    foreach (Command.Command i in commands)
                    { if (max < i.Size.X) { max = (int)i.Size.X; } }
                    for (int i = 0; i < commands.Count; i++)
                    { commands[i].Position = new Vector2(position.X + ((max - commands[i].Size.X) / 2), position.Y + (i * spacing) + 10); }
                    break;
            }
            commands[index].Highlighted = true;
        }

        //public abstract void Update(GameTime gameTime);
        public virtual void Update(GameTime gameTime)
        {
            if (!active) { return; }

            if (InputManager.I.isKeyTriggered(Keys.Down))
            {
                if (moveSound != null) { moveSound.Play(); }
                index = (index + 1) % commands.Count;
                foreach (Command.Command i in commands)
                { i.Highlighted = false; }
                commands[index].Highlighted = true;
            }
            if (InputManager.I.isKeyTriggered(Keys.Up))
            {
                if (moveSound != null) { moveSound.Play(); }
                index = (index + (commands.Count - 1)) % commands.Count;
                foreach (Command.Command i in commands)
                { i.Highlighted = false; }
                commands[index].Highlighted = true;
            }

            if (InputManager.I.isKeyTriggered(Keys.Enter))
            {
                if (selectSound != null) { selectSound.Play(); }
                commands[index].Click();
            }
        }

        //public abstract void Draw();
        public virtual void Draw()
        {
            if (!visible) { return; }
            foreach (Command.Command i in commands)
            { i.Draw(); }
        }

        public virtual void ResetIndex()
        {
            index = 0;
            foreach (Command.Command i in commands)
            { i.Highlighted = false; }
            commands[index].Highlighted = true;
        }

        public virtual int Index { get { return index; } set { index = value; } }
        public virtual bool Visible { get { return visible; } set { visible = value; } }
        public virtual bool Active { get { return active; } set { active = value; } }

        public virtual void On()
        { active = true; visible = true; }

        public virtual void Off()
        { active = false; visible = false; }


        public int Width
        {
            get
            {
                int max = 0;
                foreach (Command.Command i in commands)
                { if (max < i.Size.X) { max = (int)i.Size.X; } }
                return max;
            }
        }

        public virtual Alignment Alignment
        { get { return alignment; } set { alignment = value; RebuildWindow(); } }

        public virtual int Spacing
        { get { return spacing; } set { spacing = value; RebuildWindow(); } }

        public virtual Vector2 Position
        { get { return position; } set { position = value; RebuildWindow(); } }

        public virtual string MoveSound { set { moveSound = new Sample(value); } }
        public virtual string SelectSound { set { selectSound = new Sample(value); } }

        public virtual float Volume
        { get { return moveSound.Volume; } set { moveSound.Volume = value; selectSound.Volume = value; } }
    }
}
