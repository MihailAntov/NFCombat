using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    internal static class Fight
    {
        public static Player Player { get;  set; }
        public static Enemy Enemy { get; set; }
        public static int Range { get; set; }
        public static int MinHealth { get { return _minHealth; } set { _minHealth = value; } }
        private static int _minHealth = 0;
        private static int PlayerAtt { get { return (int)Math.Ceiling(Player.Health / 10.0); } }
        private static int EnemyAtt { get { return (int)Math.Ceiling(Enemy.Health / 10.0); } }

        public static void FightRound()
        {
            if(PlayerAtt > EnemyAtt)
            {
                Enemy.Health -= (PlayerAtt - EnemyAtt);
                if (Enemy.Health < 0)
                {
                    Enemy.Health = 0;
                }
            }
            else
            {
                Player.Health -= (EnemyAtt - PlayerAtt);
                if(Player.Health < MinHealth)
                {
                    Player.Health = MinHealth;
                }
            }

            Range = Range > 1 ? Range - 1 : Range;
        }

        public static void FightBattle()
        {

        }

        public static void SimulateBattle()
        {

        }

    }
}
