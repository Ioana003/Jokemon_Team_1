using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Jokemon_Team_1
{
    internal class PhysicsManager
    {
        private float speed = 0.5f;
        private int collisionOffset = 3;
        private Random randomJokemon = new Random();
        private int holdRandom;
        private bool jokemonAttack { get; set; }
        private bool allowMovement;

        public void checkCollision(Player p, Tree t)
        {
            Rectangle treeRec = new Rectangle((int)t.spritePosition.X, (int)t.spritePosition.Y, (int)t.spriteSize.X, (int)t.spriteSize.Y);

            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRect = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(treeRec))
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                }
            }

            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(treeRec))
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
                if (projectedPlayerRec.Intersects(treeRec))
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
                if (projectedPlayerRec.Intersects(treeRec))
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

            if (projectedPlayerRect.Intersects(BuildingRec))
            {
                if (p.goingUp)
                {
                    goUp(p);
                }
                else if (p.goingDown)
                {
                    goDown(p);
                }
                else if (p.goingLeft)
                {
                    goLeft(p);
                }
                else if (p.goingRight)
                {
                    goRight(p);
                }
            }

            if (p.goingUp)
            {
                p.projectedPos = new Vector2(p.spritePosition.X, p.spritePosition.Y - collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRec.Intersects(BuildingRec))
                {
                    p.hasCollidedTop = true;
                }
                if (p.hasCollidedTop == false)
                {
                    goUp(p);
                    p.hasCollidedBottom = false;
                }
            }

            else if (p.goingDown)
            {
                p.projectedPos = new Vector2((int)p.spritePosition.X, (int)p.spritePosition.Y + collisionOffset);
                Rectangle projectedPlayerRec = new Rectangle((int)p.projectedPos.X, (int)p.projectedPos.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                if (projectedPlayerRec.Intersects(BuildingRec))
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
                if (projectedPlayerRec.Intersects(BuildingRec))
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
                if (projectedPlayerRec.Intersects(BuildingRec))
                {
                    p.hasCollidedRight = true;
                }
                if (p.hasCollidedRight == false)
                {
                    goRight(p);
                    p.hasCollidedLeft = false;

                    //    }

                }
            }
        }

            public bool checkCollision(Player p, Grass g)
            {
                Rectangle grassRect = new Rectangle((int)g.spritePosition.X, (int)g.spritePosition.Y, (int)g.spriteSize.X, (int)g.spriteSize.Y);

                Rectangle projectedPlayerRect = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);

                if (projectedPlayerRect.Intersects(grassRect))
                {
                    holdRandom = randomJokemon.Next(0, 100);

                    if (holdRandom >= 99)
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

