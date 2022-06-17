using System;
using System.Collections.Generic;
using System.Text;

namespace Jokemon_Team_1
{
    class JokemonSkills
    {
        public int damagedealt { get; set; }

        public bool isspecialattack { get; set; }
        public int specialdamagedealt { get; set; }

        public int powerpoint { get; set; }
        //where types of skills are stored
        public JokemonSkills( bool spdamage, int damagepoint, int spdamagepoint)

        {
            damagedealt = damagepoint;
            isspecialattack = spdamage;
            specialdamagedealt = spdamagepoint;


        }
        public JokemonSkills()
        {

        }

        //public int NormalAttack() // every jokemon attack
        //{
        //    damagedealt = 20;
        //    return damagedealt;
        //}

        //public int IronTail()  // pika a chu skill
        //{

        //    defensedecrease = 10;
        //    return defensedecrease;
        //}

        //public void Nuzzle()   // pika a chu skill
        //{

        //}
    }
}
