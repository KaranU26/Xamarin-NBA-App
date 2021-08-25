using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace REALAssignMENT2
{
    public class PlayersData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _player;
        [MaxLength(255)]

        public string player
        {
            get { return _player; }
            set
            {
                if (value == _player)
                    return;
                _player = value;

                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(player)));
                }
            }
        }
        public bool Permanent { get; set; }
        public string permanentStatus
        {
            get
            {
                if (Permanent)
                    return "Player will remain in list";
                else
                    return "Player will dissappear in 7 days";

            }
            set { }
        }
    }
}
