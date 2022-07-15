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

        public void CheckCollisionTrees(Player p, Rectangle t)
        {
            Rectangle playerProjectedPos = new Rectangle((int)p.spritePosition.X - 3, (int)p.spritePosition.Y - 3, (int)p.spriteSize.X + 3, (int)p.spriteSize.Y + 3);

            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(t))
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                }
                //need p.hascollidedtop to turn false once no longer collided
                
            }

            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(t))
                {
                    p.hasCollidedBottom = true;
                }
                if (p.hasCollidedBottom == false)
                {
                    goDown(p);
                    p.hasCollidedTop = false;

                }
            }
            else if (p.goingLeft)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(t))
                {
                    p.hasCollidedLeft = true;
                }
                if (p.hasCollidedLeft == false)
                {
                    goLeft(p);
                    p.hasCollidedRight = false;
                }
            }
            else if (p.goingRight)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X + collisionOffset, (int)p.spritePosition.Y);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(t))
                {
                    p.hasCollidedRight = true;
                }
                if (p.hasCollidedRight == false)
                {
                    goRight(p);
                    p.hasCollidedLeft = false;
                }

            }
        }
        public void checkCollision(Player p, Building b)
        {
            Rectangle BuildingRec = new Rectangle((int)b.spritePosition.X, (int)b.spritePosition.Y, (int)b.spriteSize.X, (int)b.spriteSize.Y);
            Rectangle projectedPlayerRect = new Rectangle((int)p.spritePosition.X - collisionOffset, (int)p.spritePosition.Y - collisionOffset, (int)p.spriteSize.X, (int)p.spriteSize.Y);
        }

        public bool GrassCollision(Sprite g, Player p)
        {
            bool inGrass = false;

            Rectangle grassRect = new Rectangle((int)g.spritePosition.X, (int)g.spritePosition.Y, (int)g.spriteSize.X, (int)g.spriteSize.Y);

              Rectangle projectedPlayerRect = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

            if(projectedPlayerRect.Intersects(grassRect))
            {
                inGrass = true;
            }

            return inGrass;
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

