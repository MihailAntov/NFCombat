using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;
using NFCombat.ViewModels;



namespace NFCombat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FightPage : ContentPage
    {
        public FightPage()
        {
            InitializeComponent();
            BindingContext = BaseViewModel.Instance();
            Fight = BaseViewModel.Instance().Fight;
        }



        public Fight Fight;

        private void FightClicked(object sender, EventArgs e)
        {

            BaseViewModel.Instance().FightRound();
            if (PlayerHealth.Text == Fight.MinHealth.ToString())
            {
                DisplayAlert("Defeat!", "You have died.", "Okay");
            }

            //if (EnemyHealth == 0)
            //{
            //    DisplayAlert("Victory!", "You have won!", "Okay");
            //}



        }




    }
}