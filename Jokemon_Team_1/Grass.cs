using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_1
{
    class Grass : Sprite
    {
        //The grass needs to be shown
        //It can be walked on and interacted with which makes it so you can find a Jokemon

        public Grass() : base ()
        {

        }

        public Grass(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }

        
    }
}
