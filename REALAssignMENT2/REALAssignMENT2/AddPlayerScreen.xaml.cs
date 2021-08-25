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
    public partial class AddPlayerScreen : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<PlayersData> Player;
        PlayersData newPlayer;
        bool playerPermanent;
        public AddPlayerScreen(ObservableCollection<PlayersData>_Player)
        {
            InitializeComponent();
            this.Player = _Player;
        }


        private void Permanent_Toggled(object sender, ToggledEventArgs e)
        {
            playerPermanent = e.Value;

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(player.Text))
            {
                await DisplayAlert("Error", "Please add all the information!", "OK");
            }
            else
            {
                newPlayer = new PlayersData();
                newPlayer.player = player.Text;
                newPlayer.Permanent = Permanent.IsToggled;
                Player.Add(newPlayer);
                await DisplayAlert("Success", "New Player is added!", "Ok");
                dbModel.insertPlayer(newPlayer);
                await Navigation.PopAsync();
            }

        }
    }
}