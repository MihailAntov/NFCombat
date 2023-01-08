using NFCombat.Models;
using NFCombat.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Xamarin.Forms;

namespace NFCombat.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static BaseViewModel viewModel;
        public Fight Fight
        {
            get; set;
        }
        public static BaseViewModel Instance()
        {
            if (viewModel == null)
            {
                viewModel = new BaseViewModel();
                viewModel.Fight = new Fight(new Player(), new ObservableCollection<Enemy> { new Enemy("Enemy") });
            }
            return viewModel;
        }


        public int PlayerHealth
        {
            get
            {
                return this.Fight.Player.Health;
            }
            set
            {
                if (this.Fight.Player.Health != value)
                {
                    this.Fight.Player.Health = value;
                    OnPropertyChanged(nameof(Fight));

                }
            }
        }

        public int Range
        {
            get
            {
                return this.Fight.Range;
            }
            set
            {
                if (this.Fight.Range != value)
                {
                    this.Fight.Range = value;
                    OnPropertyChanged(nameof(Fight));
                }
            }
        }

        //public int EnemyCount
        //{
        //    get
        //    {
        //        return this.Fight.EnemyCount;
        //    }
            //set
            //{
            //    if (this.Fight.EnemyCount != value)
            //    {
            //        this.Fight.EnemyCount = value;
            //        //while (this.Fight.Enemies.Count != this.Fight.EnemyCount)
            //        //{
            //        //    if (this.Fight.EnemyCount > this.Fight.Enemies.Count)
            //        //    {
            //        //        this.Fight.Enemies.Add(new Enemy("Enemy"));
            //        //    }
            //        //    else if (this.Fight.EnemyCount < this.Fight.Enemies.Count)
            //        //    {
            //        //        this.Fight.Enemies.RemoveAt(this.Fight.Enemies.Count - 1);
            //        //    }
            //        //}



            //        OnPropertyChanged(nameof(Fight));
            //        OnPropertyChanged(nameof(Enemies));
            //        OnPropertyChanged(nameof(HasNextEnemies));
            //        OnPropertyChanged(nameof(HasPrevEnemies));
            //        OnPropertyChanged(nameof(SelectionDisplay));

            //    }
            //}
        //}
        public bool HasPrevEnemies
        {
            get
            {
                return (this.Fight.Enemies.Count > 1 && this.Fight.CurrentEnemy > 0);
            }
        }

        public bool HasNextEnemies
        {
            get
            {
                return (this.Fight.Enemies.Count > 1 && this.Fight.CurrentEnemy < this.Fight.Enemies.Count - 1);
            }
        }
        public ObservableCollection<Enemy> Enemies
        {
            get
            {
                return this.Fight.Enemies;
            }
            set
            {
                this.Fight.Enemies = value;
                OnPropertyChanged(nameof(Enemies));
                OnPropertyChanged(nameof(Fight));
            }
        }

        public int SelectedEnemy
        {
            get
            {
                return this.Fight.CurrentEnemy;
            }
            set
            {
                if (this.Fight.CurrentEnemy != value)
                {
                    this.Fight.CurrentEnemy = value;
                    OnPropertyChanged(nameof(Fight));
                    OnPropertyChanged(nameof(EnemyHealth));
                    OnPropertyChanged(nameof(EnemyName));
                    OnPropertyChanged(nameof(Enemies));
                }



            }
        }

        
        public int EnemyHealth
        {
            get
            {
                return this.Fight.Enemies[SelectedEnemy].Health;
            }
            set
            {
                if (this.Fight.Enemies[SelectedEnemy].Health != value)
                {
                    this.Fight.Enemies[SelectedEnemy].Health = value;

                    OnPropertyChanged(nameof(Fight));
                }
            }
        }
        public string EnemyName
        {
            get
            {
                return this.Fight.Enemies[SelectedEnemy].Name;
            }
            set
            {
                if (this.Fight.Enemies[SelectedEnemy].Name != value)
                {
                    this.Fight.Enemies[SelectedEnemy].Name = value;
                    OnPropertyChanged(nameof(EnemyName));
                    OnPropertyChanged(nameof(Fight));

                }


            }
        }
        public char SetEnemyMHAcc
        {
            get
            {
                return this.Fight.Enemies[this.Fight.CurrentEnemy].MainHand.Accuracy;
            }
            set
            {
                if(this.Fight.Enemies[this.Fight.CurrentEnemy].MainHand.Accuracy != value)
                {
                    this.Fight.Enemies[this.Fight.CurrentEnemy].MainHand.Accuracy = value;
                    //OnPropertyChanged(nameof(SetEnemyMHAcc));
                    //OnPropertyChanged(nameof(EnemyAverageDamage));
                    OnPropertyChanged(nameof(Fight));
                    
                }
            }
        }
        public string EnemyAverageDamage
        {
            get
            {
                return this.Fight.EnemyAvgDamage;
            }
            
        }
        public string SelectionDisplay
        {
            get
            {
                return $"{1 + this.Fight.CurrentEnemy} / {this.Fight.Enemies.Count}";
            }
        }
        public void FightRound()
        {
            Fight.FightRound();
            OnPropertyChanged(nameof(Fight));

            //OnPropertyChanged(nameof(EnemyHealthValue));
            //OnPropertyChanged(nameof(RangeValue));
        }

        
        public void PrevEnemy()
        {
            this.Fight.CurrentEnemy--;
            if(this.Fight.CurrentEnemy < 0)
            {
                this.Fight.CurrentEnemy = 0;
            }
            OnPropertyChanged(nameof(SelectedEnemy));
            OnPropertyChanged(nameof(EnemyHealth));
            OnPropertyChanged(nameof(EnemyName));
            OnPropertyChanged(nameof(SelectionDisplay));
            OnPropertyChanged(nameof(HasPrevEnemies));
            OnPropertyChanged(nameof(HasNextEnemies));
        }

        public void NextEnemy()
        {
            this.Fight.CurrentEnemy++;
            if (this.Fight.CurrentEnemy > this.Fight.Enemies.Count -1)
            {
                this.Fight.CurrentEnemy = this.Fight.Enemies.Count - 1;
            }
            OnPropertyChanged(nameof(SelectedEnemy));
            OnPropertyChanged(nameof(EnemyHealth));
            OnPropertyChanged(nameof(EnemyName));
            OnPropertyChanged(nameof(SelectionDisplay));
            OnPropertyChanged(nameof(HasPrevEnemies));
            OnPropertyChanged(nameof(HasNextEnemies));
        }

        public void AddEnemy()
        {
            this.Fight.Enemies.Insert(this.Fight.CurrentEnemy+1, new Enemy("Enemy"));
            this.Fight.CurrentEnemy++;
            OnPropertyChanged(nameof(SelectedEnemy));
            OnPropertyChanged(nameof(EnemyHealth));
            OnPropertyChanged(nameof(EnemyName));
            OnPropertyChanged(nameof(SelectionDisplay));
            OnPropertyChanged(nameof(HasPrevEnemies));
            OnPropertyChanged(nameof(HasNextEnemies));
            OnPropertyChanged(nameof(CanRemove));
            OnPropertyChanged(nameof(Fight));
            

        }
        public bool CanRemove
        {
            get
            {
                return this.Fight.Enemies.Count > 1;
            }
        }
        public void RemoveEnemy()
        {
            this.Fight.Enemies.RemoveAt(this.Fight.CurrentEnemy);
            if(this.Fight.CurrentEnemy >= this.Fight.Enemies.Count)
            {
                this.Fight.CurrentEnemy--;
            }

            OnPropertyChanged(nameof(SelectedEnemy));
            OnPropertyChanged(nameof(EnemyHealth));
            OnPropertyChanged(nameof(EnemyName));
            OnPropertyChanged(nameof(SelectionDisplay));
            OnPropertyChanged(nameof(HasPrevEnemies));
            OnPropertyChanged(nameof(HasNextEnemies));
            OnPropertyChanged(nameof(CanRemove));
            OnPropertyChanged(nameof(Fight));
            

        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        



    }
}
