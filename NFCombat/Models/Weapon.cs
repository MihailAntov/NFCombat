using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFCombat.Models
{
    public class Weapon
    {
        static Dictionary<char, Accuracy> AccuracyTable = new Dictionary<char, Accuracy>
        {
            {'S',new Accuracy(new int[]{1},new int[] {2,3,4}, new int[]{5,6}) },
            {'A',new Accuracy(new int[]{1},new int[] {2,3,4,5}, new int[]{6}) },
            {'B',new Accuracy(new int[]{1,2},new int[] {3,4,5}, new int[]{6}) },
            {'C',new Accuracy(new int[]{1,2},new int[] {3,4,5,6}, new int[]{}) },
            {'D',new Accuracy(new int[]{1,2,3},new int[] {4,5,6}, new int[]{}) },
            {'E',new Accuracy(new int[]{1,2,3,4},new int[] {5,6}, new int[]{}) }
        };
        public Weapon()
        {
            Accuracy = 'S';
            DmgDice = 1;
            DmgFlat = 0;
            Range = 10;
        }

        public char Accuracy { get; set; }
        public int DmgDice { get; set; }
        public int DmgFlat { get; set; }
        public int Range { get; set; }
        public double HittingDice
        {
            get
            {
                return 1.0 * AccuracyTable[Accuracy].Hits.Length + AccuracyTable[Accuracy].Crits.Length * 2;
            }
        }
        public double AverageDamage
        {
            get
            {
                return HittingDice * DmgDice / 6.0 * 3.5;
            }
        }

        public int Hits(int diceResult)
        {

            if (AccuracyTable[Accuracy].Crits.Contains(diceResult))
            {
                return 2;
            }

            if (AccuracyTable[Accuracy].Hits.Contains(diceResult))
            {
                return 1;
            }
            return 0;

        }
    }
}
