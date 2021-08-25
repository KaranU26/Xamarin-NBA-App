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
    public partial class West : ContentPage
    {
        public ObservableCollection<History> history;
        public ObservableCollection<WestConference> east;
        public NetworkingManager networkingManager = new NetworkingManager();
        WestConference selectedTeam;
        public West()
        {
            history = new ObservableCollection<History>() { };
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            westDetails.ItemsSource = null;
            var list = await networkingManager.WestConf();
            east = new ObservableCollection<WestConference>(list);
            westDetails.ItemsSource = east;
            base.OnAppearing();
        }

        private async void westDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedTeam = westDetails.SelectedItem as WestConference;

            History tempTeam = new History();
            tempTeam.city = selectedTeam.city;
            tempTeam.fullName = selectedTeam.fullName;
            tempTeam.teamId = selectedTeam.teamId;
            tempTeam.nickname = selectedTeam.nickname;
            tempTeam.logo = selectedTeam.logo;
            tempTeam.shortName = selectedTeam.shortName;
            tempTeam.allStar = selectedTeam.allStar;
            tempTeam.nbaFranchise = selectedTeam.nbaFranchise;
            history.Add(tempTeam);

            await Navigation.PushAsync(new SelectedWestTeam(selectedTeam.teamId));


        }
    }
}