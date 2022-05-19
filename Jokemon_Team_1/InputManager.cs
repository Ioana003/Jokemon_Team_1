using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_1
{
    class InputManager
    {
        KeyboardState state;

        public void checkKeyboard(Player playerSprite, Jokemon jokemon)
        {
            state = Keyboard.GetState();
            playerSprite.goingLeft = false;
            playerSprite.goingRight = false;
            playerSprite.goingUp = false;
            playerSprite.goingDown = false;

            if (state.IsKeyDown(Keys.A))
            {
                playerSprite.goingLeft = true;
            }

            if (state.IsKeyDown(Keys.D))
            {
                playerSprite.goingRight = true;
            }

            if (state.IsKeyDown(Keys.W))
            {
                playerSprite.goingUp = true;
            }

            if (state.IsKeyDown(Keys.S))
            {
                playerSprite.goingDown = true;
            }
  
            
        }



    }
}
