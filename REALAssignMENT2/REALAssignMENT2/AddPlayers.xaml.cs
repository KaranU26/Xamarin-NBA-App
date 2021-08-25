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
    public partial class AddPlayers : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<PlayersData> allPlayers = new ObservableCollection<PlayersData>();
        PlayersData updatedPlayers;
        public AddPlayers()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            allPlayers = await dbModel.CreateTable();
            playerListView.ItemsSource = allPlayers;
            base.OnAppearing();

        }

        public async void addNewPlayer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlayerScreen(allPlayers));
        }

        public void deletePlayer(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(player.Text))
            {
                DisplayAlert("Error", "Please select a player!!", "OK");
            }
            else
            {
                updatedPlayers = playerListView.SelectedItem as PlayersData;
                allPlayers.Remove(updatedPlayers);
                dbModel.deletePlayer(updatedPlayers);
                player.Text = "";
                Permanent.IsToggled = false;
                DisplayAlert("Success", " Player Sucessfully Deleted!", "OK");
            }
        }

        public void updatePlayer(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(player.Text))
            {
                DisplayAlert("Error", "Please select the player!", "OK");
            }
            else
            {
                updatedPlayers = playerListView.SelectedItem as PlayersData;
                updatedPlayers.player = player.Text;
                updatedPlayers.Permanent = Permanent.IsToggled;
                if (Permanent.IsToggled)
                    updatedPlayers.permanentStatus = "Player will remain until user removes";
                else
                    updatedPlayers.permanentStatus = "Player will dissapear in 7 days";
                (playerListView.SelectedItem as PlayersData).player = player.Text;
                (playerListView.SelectedItem as PlayersData).Permanent = Permanent.IsToggled;
                dbModel.updatePlayer(updatedPlayers);
                player.Text = "";
                Permanent.IsToggled = false;
                DisplayAlert("Success", " Sucessfully updated Player!", "OK");
            }
        }
        private void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            PlayersData v = e.SelectedItem as PlayersData;
            player.Text = v.player.ToString();
            Permanent.IsToggled = v.Permanent;

        }
    }
}