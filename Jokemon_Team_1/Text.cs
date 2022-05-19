using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class Text
    {
        public Vector2 textPosition { get; set; }
        public string textContent { get; set; }
        public SpriteFont font { get; set; }

        public Color spriteColor;
        public Text()
        { 
        
        }
        public Text(SpriteFont f, string text, Vector2 pos, Color col)
        {
            spriteColor = col;
            this.textPosition = pos;
            this.textContent = text;
            this.font = f;
        }
        public void DrawText(SpriteBatch s)
        {
            s.Begin();

            s.DrawString(font, textContent, textPosition, spriteColor);

            s.End();
        }
    }
}
