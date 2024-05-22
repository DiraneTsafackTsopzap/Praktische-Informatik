using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7.Persistence.Repository.Timer
{
    public class TimerRepository
    {
        public TimerRepository()
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.CreateTable<Models.Timer>();
            }
        }

        public void TimerErstellen(Models.Timer timer)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Insert(timer);
                context.Close();
            }
        }
        public void TimerLoeschen(Models.Timer timer)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Delete(timer);
                context.Close();
            }
        }

        public void TimerUpdate(Models.Timer timer)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Update(timer);
                context.Close();
            }
        }
    }
}
