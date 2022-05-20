using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Jokemon_Team_1
{
    class Camera
    {
        public Matrix transform { get; private set; }


        public void Follow(Sprite target)
        {
            var position = Matrix.CreateTranslation(-target.playerRectangle.X - (target.playerRectangle.Width / 2), -target.playerRectangle.Y - (target.playerRectangle.Height / 2), 0);
            var offset = Matrix.CreateTranslation(Game1.screenWidth / 2, Game1.screenHeight / 2, 0);

            transform = position * offset;
        }
    }
}
