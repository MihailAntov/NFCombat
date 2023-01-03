using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;
using  NFCombat.Views;
using NFCombat.ViewModels;
namespace NFCombat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnemyPage : ContentPage
    {
        
        public EnemyPage()
        {
            InitializeComponent();
            BindingContext = BaseViewModel.Instance();
            
        }
    }
}