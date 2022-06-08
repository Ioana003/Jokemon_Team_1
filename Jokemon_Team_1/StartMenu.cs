using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Jokemon_Team_1
{
    class StartMenu
    {

        public bool hasStarted { get; set; }

        public StartMenu ()
        {

        }
        public StartMenu(bool inHasStarted)
        {
            hasStarted = inHasStarted;
        }
    }
}
