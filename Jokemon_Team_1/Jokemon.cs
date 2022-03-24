using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class Jokemon : Sprite
    {
        public int health;
        public Jokemon(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }
    }
}
