using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_1
{
    class PauseMenu : Sprite
    {
        public bool menuShown;

        public PauseMenu(Texture2D tex, Vector2 pos, Vector2 size, bool show) : base(tex, pos, size)
        {
            this.menuShown = show;
        }

        public void PauseMenuHappening()
        {
            menuShown = true;
            //when pause menu shown, pause menu fuctions begin
            //pause menu functions:
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            { ResumeGame(); }
            //Resume game(get out of pause mennu)
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            { ExitGame(); }
            //exit game
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            { SeePokemon(); }
            //see pokemon
        }
        public void ResumeGame()
        {
            menuShown = false;
        }

        public void ExitGame()
        {
            ExitGame();
        }
        public void SeePokemon()
        {
        
        }
    }
}
