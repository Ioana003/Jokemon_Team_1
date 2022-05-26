using System;
using System.Collections.Generic;
using System.Text;

namespace Jokemon_Team_1
{
    class SettingsMenu
    {
        public bool settingsHasStarted { get; set; }

        public SettingsMenu()
        {

        }
        public SettingsMenu(bool inHasStarted)
        {
            settingsHasStarted = inHasStarted;
        }
    }
}
