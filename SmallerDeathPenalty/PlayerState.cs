﻿using StardewValley;
using StardewValley.Tools;
using System.Collections.Generic;

namespace SmallerDeathPenalty
{
    //Tracks player's funds
    //Double type is necessary for calculating money loss
    internal class PlayerState
    {
        public double money;

        public int health;

        public PlayerState(double m, int h)
        {
            this.money = m;
            this.health = h;
        }
    }
}
