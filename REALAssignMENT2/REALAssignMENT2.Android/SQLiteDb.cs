using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using REALAssignMENT2.Droid;
using Xamarin.Forms;
using System.IO;
using REALAssignMENT2;

[assembly: Dependency(typeof(SQLiteDb))]
namespace REALAssignMENT2.Droid
{
    public class SQLiteDb : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "players.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}