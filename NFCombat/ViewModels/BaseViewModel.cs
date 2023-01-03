using NFCombat.Models;
using NFCombat.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace NFCombat.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static BaseViewModel viewModel;
        public Fight Fight { get; set; }
        public static BaseViewModel Instance()
        {
            if(viewModel == null)
            {
                viewModel = new BaseViewModel();
                viewModel.Fight = new Fight(new Player(), new Enemy());
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
                if(this.Fight.Range != value)
                {
                    this.Fight.Range = value;
                    OnPropertyChanged(nameof(Fight));
                }
            }
        }

        public int EnemyHealth
        {
            get
            {
                return this.Fight.Enemy.Health;
            }
            set
            {
                if (this.Fight.Enemy.Health != value)
                {
                    this.Fight.Enemy.Health = value;
                    OnPropertyChanged(nameof(Fight));
                }
            }
        }

        public void FightRound()
        {
            Fight.FightRound();
            OnPropertyChanged(nameof(Fight));
            //OnPropertyChanged(nameof(EnemyHealthValue));
            //OnPropertyChanged(nameof(RangeValue));
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
