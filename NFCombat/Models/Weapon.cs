using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    public class Weapon
    {
        public char Accuracy { get; set; }
        public int DmgDice { get; set; }
        public int DmgFlat { get; set; }
        public int Range { get; set; }
    }
}
