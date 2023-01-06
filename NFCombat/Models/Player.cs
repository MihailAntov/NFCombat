using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    public class Player 
    {
        public Player()
        {
            Health = 40;

        }
        public bool IsDualWielding { get; set; }
        public Weapon MainHand { get; set; }
        
        public  Weapon OffHand { get; set; }
        
        public int Health { get; set; }

        //private int PlayerMeleeAtt { get { return (int)Math.Ceiling(Player.Health / 10.0); } }
    }
}
