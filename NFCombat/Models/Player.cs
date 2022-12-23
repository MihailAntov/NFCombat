using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    internal class Player
    {
        public bool IsDualWielding { get; set; }
        public Weapon MainHand { get; set; }
        public Weapon OffHand { get; set; }
        public int Health { get; set; }
        
    }
}
