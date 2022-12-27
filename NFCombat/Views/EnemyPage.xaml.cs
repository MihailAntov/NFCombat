using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;
using  NFCombat.Views;
namespace NFCombat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnemyPage : ContentPage
    {
        
        public EnemyPage()
        {
            InitializeComponent();
            
        }

        private int _enemyHealthValue = Fight.Enemy.Health;
        public int EnemyHealthValue
        {
            get => _enemyHealthValue;
            set
            {
                if (value != _enemyHealthValue)
                {
                    _enemyHealthValue = value;
                    Fight.Enemy.Health = _enemyHealthValue;
                    OnPropertyChanged(nameof(EnemyHealthValue));
                }
            }
        }
    }
}