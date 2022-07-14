using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Jokemon_Team_1
{
    class BattleSystem
    {
        private bool battleOver = false;

        MouseState state;

        public BattleSystem()
        {

        }
        public void Battling(Jokemon jokemon,Jokemon enemy,bool IsBattle,Sprite skillbox1,Sprite skillbox2, Sprite skillbox3, Sprite skillbox4)
        {
            battleOver = !IsBattle;
      
                if (state.LeftButton == ButtonState.Pressed)
                {
                    Rectangle mouserec = new Rectangle(state.X + 25, state.Y + 25, 50, 50);
                    Rectangle skillbox1rec = new Rectangle((int)skillbox1.spritePosition.X, (int)skillbox1.spritePosition.Y, (int)skillbox1.spriteSize.X,(int) skillbox1.spriteSize.Y);
                    if (mouserec.Intersects(skillbox1rec))
                    {
                        enemy.health -= 10;
                    }
                }


                if (jokemon.health <= 0 || enemy.health <= 0)
                {
                    battleOver = true;
                    
                
                }

            
        }
    }
}
