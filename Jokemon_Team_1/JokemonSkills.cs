using System;
using System.Collections.Generic;
using System.Text;

namespace Jokemon_Team_1
{
    class JokemonSkills
    {
        public int healthdecrease { get; set; }
        public int defensedecrease { get; set; }
        public int attackdecrease { get; set; }
        public int specialdefensedecrease { get; set; }
        public int specialattackdecrease { get; set; }

        public int powerpoint { get; set; }
        //where types of skills are stored
        public JokemonSkills()
        {
            //constructor
        }

        public int NormalAttack() // every jokemon attack
        {
            healthdecrease = 20;
            return healthdecrease;
        }

        public int IronTail()  // pika a chu skill
        {

            defensedecrease = 10;
            return defensedecrease;
        }

        public void Nuzzle()   // pika a chu skill
        {

        }
    }
}
