using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon_Team_1
{
    class Jokemon : Sprite
    {
        public int health { get; set; }
        public int catchrate { get; set; }
        public int defense { get; set; }
        public int attack { get; set; }
        public int specialdefense { get; set; }
        public int specialattack { get; set; }
        public int speed { get; set; }
        public JokemonSkills skill1 { get; set; }
        public JokemonSkills skill2 { get; set; }
        public JokemonSkills skill3 { get; set; }
        public JokemonSkills skill4 { get; set; }
        private bool isPlayerJokemon { get; set; }

        public bool attacked { get; set; } = false;

        public bool attacking { get; set; } = false;

        public Jokemon() : base ()
        {

        }

        public Jokemon(Texture2D tex, Vector2 pos, Vector2 size) : base(tex, pos, size)
        {

        }

        public JokemonSkills UsingSkill1(JokemonSkills theskill)
        {
            return skill1;  // might not need
        }

        public void Battle(JokemonSkills jokemonskills, JokemonSkills enemyjokemonskills, Jokemon enemyjokemon)
        {
            if (attacked == true)
            {
                health -= enemyjokemonskills.NormalAttack();
            }
            if( health <= 0)
            {
                //jokemon died
            }
            if (attacking == true)
            {
                //let player choose skills
                enemyjokemon.attacked = true;
            }
        }

        public void Catching()
        {
            //higher catchrate the easier to catch
        }

        public void ShowJokemon(Texture2D playerJokemonTexture, Texture2D opposingJokemon, GameWindow window)
        {
            

            if(isPlayerJokemon == true)
            {
                spriteTexture = playerJokemonTexture;
                spritePosition = new Vector2(window.ClientBounds.Width / 5, window.ClientBounds.Height / 4 * 3);
            }
            else
            {
                spriteTexture = opposingJokemon;
                spritePosition = new Vector2(window.ClientBounds.Width - window.ClientBounds.Width / 5, window.ClientBounds.Height / 4);
            }
        }

    }
}
