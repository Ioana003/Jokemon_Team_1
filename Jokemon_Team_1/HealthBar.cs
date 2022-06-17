using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class HealthBar
    {
        private Texture2D texture;
        private Vector2 position;
        private Jokemon jokemon;
        private Color color = Color.Red;

        public HealthBar()
        {

        }

        public HealthBar(Texture2D t, Jokemon j, Vector2 pos)
        {
            texture = t;
            jokemon = j;
            position = pos;
        }


        public void DrawHealth(SpriteBatch s, Jokemon user)
        {
            if (user.health > 0)
            {
                color = Color.White;
                s.Begin();
                s.Draw(texture, new Rectangle((int)position.X, (int)position.Y, jokemon.health, 20), color);
                s.End();
            }
  
        }
    }
}
