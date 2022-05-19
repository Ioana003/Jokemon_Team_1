using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class BattleSystem
    {
        private bool battleOver = false;
        private Jokemon selectedJkmn;
        private Jokemon unselectedJkmn;
        private string jokemonskillselected { get; set; }
        private string enemyskillselected { get; set; }

        public void Battling(Jokemon jokemon,Jokemon enemy)
        {
            while (!battleOver)
            {




                        if (jokemonskillselected == "Nuzzle")
                        {
                    enemy.health = enemy.health - jokemon.specialattack;
                        }
                        if (jokemonskillselected == "Iron Tail")
                        {
                    enemy.health = enemy.health - jokemon.attack;
                        }
                        if (jokemonskillselected == "Sneeze")
                        {
                    enemy.health = enemy.health - jokemon.specialattack;
                        }
                        if (jokemonskillselected == "Normal Attack")
                        {
                    enemy.health = enemy.health - jokemon.attack;
                        }
                        if (enemyskillselected == "Iron Tail")
                        {
                    jokemon.health -= enemy.attack;
                        }
                        if (enemyskillselected == "Normal Attack")
                        {
                    jokemon.health -= enemy.attack;
                }
                        if (enemyskillselected == "Nuzzle")
                        {
                    jokemon.health -= enemy.specialattack;
                }

                        


                


                if (jokemon.health <= 0 || enemy.health <= 0)
                {
                    battleOver = true;
                }

            }
        }
    }
}
