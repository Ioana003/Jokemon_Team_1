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


    }
}
