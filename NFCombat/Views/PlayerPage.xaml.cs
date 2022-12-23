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
    public partial class PlayerPage : ContentPage
    {
        //private int count = 0;

        public PlayerPage()
        {
            InitializeComponent();
            BindingContext = this;
            _player = new Player();
            _enemy = new Enemy();
            _fight = new Fight(Player, Enemy, RangeValue);
            
        }
        private Fight _fight;
        internal Fight Fight { get { return _fight; }}

        
        private Player _player;
        internal Player Player
        {
            get { return _player; }
        }

        private Enemy _enemy;
        internal Enemy Enemy
        {
            get { return _enemy; }
        }

        private int _rangeValue = 12;
        public int RangeValue
        {
            get => _rangeValue;
            set
            {
                if (value != _rangeValue)
                {
                    _rangeValue = value;
                    
                    OnPropertyChanged(nameof(RangeValue));
                }
            }
        }

        private int _playerHealthValue = 30;
        public int PlayerHealthValue
        {
            get => _playerHealthValue;
            set
            {
                if (value != _playerHealthValue)
                {
                    _playerHealthValue = value;
                    Player.Health = _playerHealthValue;
                    OnPropertyChanged(nameof(PlayerHealthValue));
                }
            }
        }

        private int _enemyHealthValue = 10;
        public int EnemyHealthValue
        {
            get => _enemyHealthValue;
            set
            {
                if (value != _enemyHealthValue)
                {
                    _enemyHealthValue = value;
                    Enemy.Health = _enemyHealthValue;
                    OnPropertyChanged(nameof(EnemyHealthValue));
                }
            }
        }

        private void FightClicked(object sender, EventArgs e)
        {
            Player.Health = _playerHealthValue;
            Enemy.Health = _enemyHealthValue;
            _fight.FightRound();
            PlayerHealthValue = Player.Health;
            EnemyHealthValue = Enemy.Health;
            
        }
    }
}
