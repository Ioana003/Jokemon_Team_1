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

        MouseState mouse;

        public bool CheckMouse(int width, int height)
        {
            mouse = Mouse.GetState();
            if (mouse.X <= (width / 2) + 200 && mouse.X >= (width / 2) - 200 && mouse.Y <= height / 3 + 100 && mouse.Y >= height / 3 && mouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void checkKeyboard(Player playerSprite)
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
            if (state.IsKeyDown(Keys.C))
            {
                playerSprite.clone = true;
            }
            if (state.IsKeyDown(Keys.N))
            {
                playerSprite.clone = false;
            }
        }



    }
}
