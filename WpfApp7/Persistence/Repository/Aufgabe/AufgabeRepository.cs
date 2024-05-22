using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using WpfApp7.Models;

namespace WpfApp7.Persistence.Repository.Aufgabe
{
    public class AufgabeRepository
    {
        public AufgabeRepository()
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.CreateTable<Models.Aufgabe>();
            }
        }

        public List<Models.Aufgabe> GetAufgabeByProjectId(Guid projektId)
        {
            var aufgaben = new List<Models.Aufgabe>();
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                aufgaben = context.GetWithChildren<Models.Projekt>(projektId, recursive: true).Projektaufgaben;
                context.Close();
            }

            return aufgaben;
        }

        public void AufgabeErstellen(Models.Aufgabe aufgabe)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.InsertWithChildren(aufgabe);
                context.Close();
            }
        }

        public void AufgabeLoeschen(Models.Aufgabe aufgabe)
        {
            using (SQLiteConnection context = new SQLiteConnection(DatabaseConnectionValues.database_path))
            {
                context.Delete(aufgabe);
                context.Close();
            }
        }
    }
}
