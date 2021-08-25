using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace REALAssignMENT2
{
    public class History: INotifyPropertyChanged
    {
        public string city { get; set; }
        public string fullName { get; set; }
        public string teamId { get; set; }
        public string nickname { get; set; }
        public string logo { get; set; }
        public string shortName { get; set; }
        public string allStar { get; set; }
        public string nbaFranchise { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
