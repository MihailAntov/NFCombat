using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;

namespace NFCombat.Models
{

    
    public class Fight 
    {
        public Fight(Player player, ObservableCollection<Enemy> enemies)
        {
            Player = player;
            Enemies = enemies;
        }
        public  Player Player { get;  set; }
        public ObservableCollection<Enemy> Enemies { get; set; }
        private  int _range = 12;
        public  int Range { get { return _range; } set { _range = value; } }
        public  int MinHealth { get { return _minHealth; } set { _minHealth = value; } }
        private  int _minHealth = 0;

        //private int _enemyCount = 1;
        //public int EnemyCount { get { return _enemyCount; } set { _enemyCount = value; } }
        public int CurrentEnemy { get { return _currentEnemy; } set { _currentEnemy = value; } }
        private int _currentEnemy = 0;
        
        public string EnemyAvgDamage
        {
            get 
            {
                return $"{Enemies[CurrentEnemy].AverageDamage:f2}";
            }
            
        }

        public void FightRound()
        {
            

            


        }

        public  void FightBattle()
        {

        }

        public  void SimulateBattle()
        {

        }

    }
}
