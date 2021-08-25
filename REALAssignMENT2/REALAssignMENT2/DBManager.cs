using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using REALAssignMENT2;
using SQLite;
using Xamarin.Forms;

namespace REALAssignMENT2
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;

        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        public async Task<ObservableCollection<PlayersData>> CreateTable()
        {
            await _connection.CreateTableAsync<PlayersData>();
            var players = await _connection.Table<PlayersData>().ToListAsync();
            var players_ = new ObservableCollection<PlayersData>(players);
            return players_;
        }

        public void insertPlayer(PlayersData player)
        {
            _connection.InsertAsync(player);
        }
        public void deletePlayer(PlayersData player)
        {
            _connection.DeleteAsync(player);
        }
        public void updatePlayer(PlayersData player)
        {
            _connection.UpdateAsync(player);
        }
    }
}
