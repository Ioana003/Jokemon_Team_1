using System;
using System.Collections.Generic;
using System.Text;

namespace Jokemon_Team_1
{
    class JokemonSkills
    {
        public int healthdecrease { get; set; }
        //where types of skills are stored
        public JokemonSkills()
        {
            //constructor
        }

        public int IronTail()  // pika a chu skill
        {
            healthdecrease = 10;
            return healthdecrease;
        }

        public void Nuzzle()   // pika a chu skill
        {

        }
    }
}
