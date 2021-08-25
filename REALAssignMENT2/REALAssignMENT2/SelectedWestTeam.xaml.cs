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
    public partial class SelectedWestTeam : ContentPage
    {
        private string TeamID { get; set; }
        public ObservableCollection<Player> players;
        public NetworkingManager networkingManager = new NetworkingManager();
        public SelectedWestTeam(string teamId)
        {
            InitializeComponent();
            this.TeamID = teamId;
        }

        protected async override void OnAppearing()
        {
            playerDetails.ItemsSource = null;
            var list = await networkingManager.GetByTeamPlayers(this.TeamID);
            players = new ObservableCollection<Player>(list);
            playerDetails.ItemsSource = players;
            base.OnAppearing();

        }
    }
}