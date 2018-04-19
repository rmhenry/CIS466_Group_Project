﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Dice
    {
        private int sides;
        Random d = new Random();

        public Dice(int damageMax)
        {
            sides = damageMax;
        }

        public int Roll()
        {
            int damage = d.Next(0, sides);
            return damage;
        }
    }//end of class
}//end of namespace
