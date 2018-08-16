using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetFun
{
    class Wizard
    {

        private string _name;
        private int _spellCastingLevel;
        private bool _isVisiable;


        public string Name { get; set; }
        public int SpellCastingLevel { get; set; }
        public bool IsVisible { get; set; }


        public Wizard(string name, int spellLvl)
        {
            this.Name = name;
            this.SpellCastingLevel = spellLvl;
            this.IsVisible = true;

        }





        public bool toggleVisibility()
        {
            if (this.IsVisible)
            {
                this.IsVisible = false;
                return false;
            }
            else
            {

                this.IsVisible = true;
                return true;
            }
        }

        public string CastSpell(int spellNum)
        {
            string sp;
            string[] spells = { "Mage hand", "Fireblast", "Fireball", "Necrotic lance", "Finger of Death", "Five finger death punch", "Polymorph" };

            if (spellNum <= this.SpellCastingLevel)
            {
                 sp = "You cast " + spells[spellNum -1].ToString() + "!";
            }
            else
            {
                sp = "Your spell casting level is to low. Only " + this.SpellCastingLevel + " or below";
            }
            return sp;
        }
    }
}
