using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class Player : Sprite
    {

        public Vector2 projectedPos;
        public bool hasCollidedTop = false;
        public bool hasCollidedBottom = false;
        public bool hasCollidedLeft = false;
        public bool hasCollidedRight = false;
        public bool goingLeft;
        public bool goingRight;
        public bool goingUp;
        public bool goingDown;
  

        public Player(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }

        public void movePlayer(PhysicsManager pMan, Player p)
        {
            if(pMan.allowMovement == true)
            {
                if (goingDown)
                {
                    pMan.goDown(p);
                }
                if (goingLeft)
                {
                    pMan.goLeft(p);
                }
                if (goingRight)
                {
                    pMan.goRight(p);
                }
                if (goingUp)
                {
                    pMan.goUp(p);
                }
            }

            if(pMan.allowMovement == false)
            {
                if (hasCollidedBottom == true)
                {

                    if (goingLeft && hasCollidedLeft == false)
                    {
                        pMan.goLeft(p);
                    }
                    if (goingRight && hasCollidedRight == false)
                    {
                        pMan.goRight(p);
                    }
                    if (goingUp && hasCollidedTop == false)
                    {
                        pMan.goUp(p);
                        hasCollidedBottom = false;
                        pMan.allowMovement = true;
                    }

                }
                if (hasCollidedLeft == true)
                {

                    if (goingDown && hasCollidedBottom == false)
                    {
                        pMan.goDown(p);
                    }
                    if (goingRight && hasCollidedRight == false)
                    {
                        pMan.goRight(p);
                        hasCollidedLeft = false;
                        pMan.allowMovement = true;
                    }
                    if (goingUp && hasCollidedTop == false)
                    {
                        pMan.goUp(p);
                    }

                }
                if (hasCollidedRight == true)
                {

                    if (goingDown && hasCollidedBottom == false)
                    {
                        pMan.goDown(p);
                    }
                    if (goingLeft && hasCollidedLeft == false)
                    {
                        pMan.goLeft(p);
                        hasCollidedRight = false;
                        pMan.allowMovement = true;
                    }
                    if (goingUp && hasCollidedTop == false)
                    {
                        pMan.goUp(p);
                    }
                }
                if (hasCollidedTop == true)
                {

                    if (goingDown && hasCollidedBottom == false)
                    {
                        pMan.goDown(p);
                        hasCollidedTop = false;
                        pMan.allowMovement = true;
                    }
                    if (goingRight && hasCollidedRight == false)
                    {
                        pMan.goRight(p);
                    }
                    if (goingLeft && hasCollidedLeft == false)
                    {
                        pMan.goLeft(p);
                    }
                }
            }
        }

    }
}
