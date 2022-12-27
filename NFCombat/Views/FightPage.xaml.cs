using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;

namespace NFCombat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FightPage : ContentPage
    {
        public FightPage()
        {
            InitializeComponent();
            BindingContext = this;
            Fight.Player = new Player();
            Fight.Enemy = new Enemy();
            Fight.Range = 12;            
            
        }


        public int PlayerHealth { get { return Fight.Player.Health; } }
        public int EnemyHealth { get { return Fight.Enemy.Health; } }
        public int Range { get { return Fight.Range; } }

       

        private void FightClicked(object sender, EventArgs e)
        {
            
            Fight.FightRound();
            PlayerHealthValue.Text = PlayerHealth.ToString();
            EnemyHealthValue.Text = EnemyHealth.ToString();
            RangeValue.Text = Range.ToString();
            
            if (PlayerHealth == Fight.MinHealth)
            {
                DisplayAlert("Defeat!", "You have died.", "Okay");
            }

            if (EnemyHealth == 0)
            {
                DisplayAlert("Victory!", "You have won!", "Okay");
            }

        }

        

        
    }
}