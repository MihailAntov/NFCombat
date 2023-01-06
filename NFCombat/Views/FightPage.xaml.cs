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

            if (Fight.Player.Health == Fight.MinHealth || Fight.Enemies.All(n=>n.Health == 0))
            {
                DisplayAlert("Invalid input!", "Both sides need to be alive.", "Okay");
                return;
            }

                BaseViewModel.Instance().FightRound();
            if (Fight.Player.Health == Fight.MinHealth)
            {
                DisplayAlert("Defeat!", "You have died.", "Okay");
            }

            if (Fight.Enemies.All(n=>n.Health == 0))
            {
                DisplayAlert("Victory!", "You have won!", "Okay");
            }



        }




    }
}