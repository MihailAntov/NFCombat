using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    internal class Accuracy
    {
        public Accuracy(int[] miss, int[] hits, int[] crits)
        {
            Hits = hits;
            Crits = crits;
            Miss = miss;
        }

        public int[] Hits { get; set; }
        public int[] Crits { get; set; }
        public int[] Miss { get; set; }
    }
}
