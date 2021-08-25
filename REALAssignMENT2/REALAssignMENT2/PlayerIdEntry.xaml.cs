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
    public partial class PlayerIdEntry : ContentPage
    {

        ObservableCollection<PlayerStatistics> PlayerStats = new ObservableCollection<PlayerStatistics>();
        public NetworkingManager networkingManager = new NetworkingManager();
        public PlayerIdEntry()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var Id = playersID.Text;
            var list = await networkingManager.GetPlayerStats(Id);
            PlayerStats = new ObservableCollection<PlayerStatistics>(list);
            await Navigation.PushAsync(new PlayerStatsDisplay(PlayerStats));
        }
    }
}