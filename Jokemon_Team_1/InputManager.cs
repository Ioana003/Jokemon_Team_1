using Microsoft.Xna.Framework.Input;

namespace Jokemon_Team_1
{
    class InputManager
    {
        KeyboardState state;
        MouseState mouse;

        public bool CheckSettings(int width, int height)
        {
            mouse = Mouse.GetState();
            if (mouse.X <= (width / 2) + 150 && mouse.X >= (width / 2) - 150 && mouse.Y <= height / 3 - 50 && mouse.Y >= height / 3 - 150 && mouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEnd(int width, int height)
        {
            mouse = Mouse.GetState();
            if (mouse.X <= (width / 2) + 100 && mouse.X >= (width / 2) - 100 && mouse.Y <= height / 3 + 250 && mouse.Y >= height / 3 + 150 && mouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckStart(int width, int height)
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
        public bool CheckReturn(int width, int height)
        {
            mouse = Mouse.GetState();
            if (mouse.X <= (width / 2) + 100 && mouse.X >= (width / 2) - 70 && mouse.Y <= (height / 3) + 350 && mouse.Y >= (height / 3) + 250 && mouse.LeftButton == ButtonState.Pressed)
            {
                return false;
            }
            else
            {
                return true;
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


        }



    }
}


