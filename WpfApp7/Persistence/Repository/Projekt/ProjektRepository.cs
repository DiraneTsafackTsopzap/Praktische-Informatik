using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;

namespace WpfApp7.Persistence.Repository.Projekt
{
    public class ProjektRepository
    {
        public ProjektRepository()
        {
            RefreshData();
        }

        public List<Models.Projekt> AlleProjekteLaden()
        {
            var projekte = new List<Models.Projekt>();
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                projekte = context.GetAllWithChildren<Models.Projekt>();
                context.Close();
            }

            return projekte;
        }
        public void ProjektErstellen(Models.Projekt projekt)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Insert(projekt);
                context.Close();
            }
            RefreshData();
        }


        public void ProjektLoeschen(Models.Projekt projekt)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Delete(projekt);
                context.Close();
            }
            RefreshData();
        }


        public void ProjektUpdate(Models.Projekt projekt)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Update(projekt);
                context.Close();
            }
            RefreshData();
        }

        /// <summary>
        /// Refresh die Daten in der Database
        /// </summary>
        private void RefreshData()
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.CreateTable<Models.Projekt>();
            }
        }
    }
}
