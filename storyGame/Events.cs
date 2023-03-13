using System;
using System.Collections.Generic;
using System.Text;

namespace storyGame
{
    class Events
    {
        /*
         * OLD VERISON
        public string eventPrompt;
        public int health;
        public int happiness;
        public int population;
        public int army;
        public int culture;
        public int gold;
        */
    
        public string eventPrompt;
        public int NOhealth;
        public int NOhappiness;
        public int NOpopulation;
        public int NOarmy;
        public int NOculture;
        public int NOgold;

        public int YEShealth;
        public int YEShappiness;
        public int YESpopulation;
        public int YESarmy;
        public int YESculture;
        public int YESgold;

        public Events(string _eventPrompt, int _YEShealth, int _YEShappiness, int _YESpopulation, 
            int _YESarmy, int _YESculture, int _YESgold, int _NOhealth, int _NOhappiness, 
            int _NOpopulation, int _NOarmy, int _NOculture, int _NOgold)
        {
            eventPrompt = _eventPrompt;

            YEShealth =        _YEShealth;
            YEShappiness =     _YEShappiness;
            YESpopulation =    _YESpopulation;
            YESarmy =          _YESarmy;
            YESculture =       _YESculture;
            YESgold =          _YESgold;

            NOhealth =        _NOhealth;
            NOhappiness =     _NOhappiness;
            NOpopulation =    _NOpopulation;
            NOarmy =          _NOarmy;
            NOculture =       _NOculture;
            NOgold =          _NOgold;

        }
    }
}
