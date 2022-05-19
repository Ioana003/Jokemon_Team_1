using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class PauseMenu : Sprite
    {
        public bool shown;

        public PauseMenu(Texture2D tex, Vector2 pos, Vector2 size, bool vis) : base(tex, pos, size)
        {
            this.shown = vis;
        }
    }
}
