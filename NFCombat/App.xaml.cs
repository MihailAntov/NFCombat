using NFCombat.Services;
using NFCombat.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFCombat.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;

namespace NFCombat
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            Fight fight = new Fight(new Player(), new ObservableCollection<Enemy>());
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
