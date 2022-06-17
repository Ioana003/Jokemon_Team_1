using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class Sprite
    {
        public Vector2 spritePosition { get; set; }
        public Vector2 spriteSize { get; set; }
        public Texture2D spriteTexture { get; set; }

        public Rectangle playerRectangle
        {
            get { return new Rectangle((int)spritePosition.X, (int)spritePosition.Y, spriteTexture.Width, spriteTexture.Height); }
        }

        public Color spriteColor = Color.White;

        public Sprite()
        {

        }

        public Sprite(Texture2D tex, Vector2 pos, Vector2 size)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
        }

        public void DrawSprite(SpriteBatch s, Texture2D t, Camera m)
        {
            spriteTexture = t;

            s.Begin(transformMatrix: m.transform);

            s.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColor);

            s.End();

        }
    }
}
