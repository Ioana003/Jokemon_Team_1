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
        public string skill1 { get; set; }
        public string skill2 { get; set; }
        public string skill3 { get; set; }
        public string skill4 { get; set; }

        public bool attacked { get; set; } = false;

        public bool attacking { get; set; } = false;

        public bool isPlayerJokemon { get; set; }
        public Jokemon()
        {

        }
        public Jokemon(Texture2D tex, Vector2 pos, Vector2 size, int HP, int atk, int def, int spAtk, int spDef, int spd, string m1, string m2, string m3, string m4) : base(tex, pos, size)
        {
            health = HP;
            defense = def;
            specialattack = spAtk;
            specialdefense = spDef;
            speed = spd;
            skill1 = m1;
            skill2 = m2;
            skill3 = m3;
            skill4 = m4;
        }


        //public void Battle(JokemonSkills jokemonskills, JokemonSkills enemyjokemonskills, Jokemon enemyjokemon)
        //{

        //    if (attacked == true)
        //    {
        //        //health -= enemyjokemonskills.NormalAttack();
        //    }
        //    if (health <= 0)
        //    {
        //        enemyjokemon.attacked = false;
        //        //jokemon died
        //    }
        //    if (attacking == true)
        //    {
        //        //let player choose skills
        //        enemyjokemon.attacked = true;
        //    }
        //}

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
        public void DrawJokemon(SpriteBatch s, Texture2D t)
        {
            spriteTexture = t;

            s.Begin();

            s.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColor);

            s.End();

        }

    }
}
