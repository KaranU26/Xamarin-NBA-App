using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace REALAssignMENT2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerStatsDisplay : ContentPage
    {
        ObservableCollection<PlayerStatistics> PlayerStats;
        public PlayerStatsDisplay(ObservableCollection<PlayerStatistics> _PlayerStats)
        {
            InitializeComponent();
            this.PlayerStats = _PlayerStats;
        }

        protected async override void OnAppearing()
        {
            
            playerStatsList.ItemsSource = PlayerStats;
            base.OnAppearing();

        }
    }
}