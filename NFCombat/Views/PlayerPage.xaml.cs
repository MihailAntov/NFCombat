using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;
using NFCombat.Views;


namespace NFCombat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        //private int count = 0;
        
        public PlayerPage()
        {
            InitializeComponent();
            BindingContext = this;
           
        }


        private int _playerHealthValue = Fight.Player.Health;
        public int PlayerHealthValue
        {
            get => _playerHealthValue;
            set
            {
                if (value != _playerHealthValue)
                {
                    _playerHealthValue = value;
                    Fight.Player.Health = _playerHealthValue;
                    OnPropertyChanged(nameof(PlayerHealthValue));
                }
            }
        }

        

        
    }
}
