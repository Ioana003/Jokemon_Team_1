using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Jokemon_Team_1
{
    internal class PhysicsManager
    {
        private float speed = 0.25f;
        private int collisionOffset = 3;
        private Random randomJokemon = new Random();
        private int holdRandom;
        private bool jokemonAttack { get; set; }
        public bool allowMovement = true;

        public void CheckCollision(Player p, Rectangle t)
        {
            Rectangle playerProjectedPos = new Rectangle((int)p.spritePosition.X - 3, (int)p.spritePosition.Y - 3, (int)p.spriteSize.X + 3, (int)p.spriteSize.Y + 3);

            if (allowMovement == true)
            {

                if (playerProjectedPos.Intersects(t))
                {
                    if (t.Y >= playerProjectedPos.Y + playerProjectedPos.Height)
                    {
                        p.hasCollidedBottom = true;
                    }
                    if (t.X + t.Width <= playerProjectedPos.X)
                    {
                        p.hasCollidedLeft = true;
                    }
                    if (t.X >= playerProjectedPos.X + playerProjectedPos.Width)
                    {
                        p.hasCollidedRight = true;
                    }
                    if (t.Y + t.Height <= playerProjectedPos.Y)
                    {
                        p.hasCollidedTop = true;
                    }

                    allowMovement = false;
                }
            }

        }

        public bool checkCollision(Player p, Grass g)
        {
            Rectangle grassRect = new Rectangle((int)g.spritePosition.X, (int)g.spritePosition.Y, (int)g.spriteSize.X, (int)g.spriteSize.Y);

            Rectangle projectedPlayerRect = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

            if(projectedPlayerRect.Intersects(grassRect))
            {
                holdRandom = randomJokemon.Next(0, 100);

                if(holdRandom >= 99)
                {
                    jokemonAttack = true;
                }
                else
                {
                    jokemonAttack = false;
                }
            }

            return jokemonAttack;
        }

        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - speed, playerSprite.spritePosition.Y);
        }

        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + speed, playerSprite.spritePosition.Y);
        }

        public void goDown(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y + speed);
        }

        public void goUp(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y - speed);
        }



    }
}
