using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{
    internal class Fight
    {
        public Fight(Player player, Enemy enemy, int range)
        {
            Player = player;
            Enemy = enemy;
            Range = range;
        }

        public Player Player { get;  set; }
        public Enemy Enemy { get; set; }
        public int Range { get; set; }
        private int PlayerAtt { get { return (int)Math.Ceiling(Player.Health / 10.0); } }
        private int EnemyAtt { get { return (int)Math.Ceiling(Enemy.Health / 10.0); } }

        public void FightRound()
        {
            if(PlayerAtt > EnemyAtt)
            {
                Enemy.Health -= (PlayerAtt - EnemyAtt);
            }
            else
            {
                Player.Health -= (EnemyAtt - PlayerAtt);
            }
            Range = Range > 1 ? Range-- : Range;
        }

        public void FightBattle()
        {

        }

        public void SimulateBattle()
        {

        }

    }
}
