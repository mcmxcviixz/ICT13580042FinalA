using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ICT13580042FinalA.Models;

namespace ICT13580042FinalA.Helpers
{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Profile>();
        }

        public int AddProfile(Profile profile)
        {
            db.Insert(profile);
            return profile.Id;
        }

        public List<Profile> GetProfiles()
        {
            return db.Table<Profile>().ToList();
        }

        public int UpdateProfile(Profile profile)
        {
            return db.Update(profile);
        }

        public int DeleteProfile(Profile profile)
        {
            return db.Delete(profile);
        }
    }
}
