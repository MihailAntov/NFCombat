using NFCombat.Services;
using NFCombat.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;

namespace NFCombat
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            Fight fight = new Fight(new Player(), new Enemy());
            Resources.Add("fight", fight);
            
            

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
