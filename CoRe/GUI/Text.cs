using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using CoRe.Utils;

namespace CoRe
{
    namespace GUI
    {
        public enum TextAlignment { Left, Right, Center };

        public class Text
        {
            protected SpriteFont font;
            protected Vector2 position;
            protected Color color = Color.White;
            protected string content;
            protected string fontName;
            protected int outline = 0;
            protected TextAlignment alignment = TextAlignment.Left;

            public Text(string Text, Vector2 Position) : this("SpriteFont1", Text, Position)
            { }

            public Text(string Filename, string Text, Vector2 Position)
            {
                if (Filename == "") { Filename = "SpriteFont1"; }
                fontName = Filename;
                font = Cache.Font(Filename);
                position = Position;
                content = Text;
            }

            public void Draw()
            { Draw(color); }

            public void Draw(Color Color)
            {
                Vector2 temp;
                switch (alignment)
                {
                    case TextAlignment.Left:   temp = new Vector2(0, 0);          break;
                    case TextAlignment.Right:  temp = new Vector2(Size.X, 0);     break;
                    case TextAlignment.Center: temp = new Vector2(Size.X / 2, 0); break;
                    default:                   temp = new Vector2(0, 0);          break;
                }
                if (outline != 0)
                { DrawOutlined(Color, temp); }
                else
                { DrawNormal(Color, temp); }
            }

            private void DrawNormal(Color Color, Vector2 Origin)
            {
                XNAGame.Instance.SpriteBatch.DrawString(font, content, position, Color, 0.0f,
                                                        Origin, 1.0f, SpriteEffects.None, 0);
            }

            private void DrawOutlined(Color color, Vector2 Origin)
            {
                XNAGame.I.SpriteBatch.DrawString(font, content, new Vector2(position.X+outline, position.Y), Color.Black, 0.0f,
                                                 Origin, 1.0f, SpriteEffects.None, 0);
                XNAGame.I.SpriteBatch.DrawString(font, content, new Vector2(position.X - outline, position.Y), Color.Black, 0.0f,
                                                 Origin, 1.0f, SpriteEffects.None, 0);
                XNAGame.I.SpriteBatch.DrawString(font, content, new Vector2(position.X, position.Y + outline), Color.Black, 0.0f,
                                                 Origin, 1.0f, SpriteEffects.None, 0);
                XNAGame.I.SpriteBatch.DrawString(font, content, new Vector2(position.X, position.Y - outline), Color.Black, 0.0f,
                                                 Origin, 1.0f, SpriteEffects.None, 0);
                XNAGame.I.SpriteBatch.DrawString(font, content, position, color, 0.0f, Origin, 1.0f, SpriteEffects.None, 0);
            }


            public string Font
            {
                get { return fontName; }
                set
                {
                    if (value == "") { value = "SpriteFont1"; }
                    if (value != fontName)
                    { font = Cache.Font(value); fontName = value; }
                }
            }

            public Vector2 Position { get { return position; } set { position = value; } }
            public Color Color { get { return color; } set { color = value; } }
            public string Content { get { return content; } set { content = value; } }

            public int Outline { get { return outline; } set { outline = value; } }

            public TextAlignment Alignment { get { return alignment; } set { alignment = value; } }

            public int Spacing { get { return font.LineSpacing; } }

            public Vector2 Size { get { return font.MeasureString(content); } }
        }
    }
}
