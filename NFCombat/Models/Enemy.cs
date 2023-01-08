using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    public class Enemy
    {
        public Enemy(string name)
        {
            Health = 10;
            Name = name;
            MainHand = new Weapon();
            OffHand = new Weapon();
            IsDualWielding = false;
        }

        public double AverageDamage 
        { 
            get
            {
                if(IsDualWielding)
                {
                    return this.MainHand.AverageDamage + this.OffHand.AverageDamage;
                }
                return this.MainHand.AverageDamage;
            }
        }
        public Weapon MainHand { get; set; }
        public Weapon OffHand { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsDualWielding { get; set; }

        //private int EnemyMeleeAtt { get { return (int)Math.Ceiling(Enemy.Health / 10.0); } }
    }
}
