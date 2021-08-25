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
    public partial class East : ContentPage
    {
        public ObservableCollection<History> history;
        public ObservableCollection<EastConference> east;
        public NetworkingManager networkingManager = new NetworkingManager();
        EastConference selectedTeam;
        public East()
        {
            history = new ObservableCollection<History>(){};
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            eastDetails.ItemsSource = null;
            var list = await networkingManager.EastConf();
            east = new ObservableCollection<EastConference>(list);
            eastDetails.ItemsSource = east;
            base.OnAppearing();
        }

        private async void eastDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedTeam = eastDetails.SelectedItem as EastConference;

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

            await Navigation.PushAsync(new SelectedEastTeam(selectedTeam.teamId));


        }
    }
}