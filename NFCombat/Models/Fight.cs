using System;
using System.Collections.Generic;
using System.Text;

namespace NFCombat.Models
{

    
    public class Fight 
    {
        public Fight(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }
        public  Player Player { get;  set; }
        public  Enemy Enemy { get; set; }
        private  int _range = 12;
        public  int Range { get { return _range; } set { _range = value; } }
        public  int MinHealth { get { return _minHealth; } set { _minHealth = value; } }
        private  int _minHealth = 0;
        private  int PlayerAtt { get { return (int)Math.Ceiling(Player.Health / 10.0); } }
        private  int EnemyAtt { get { return (int)Math.Ceiling(Enemy.Health / 10.0); } }

        public void FightRound()
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
            Player.Health--;


        }

        public  void FightBattle()
        {

        }

        public  void SimulateBattle()
        {

        }

    }
}
