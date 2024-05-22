using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WpfApp7.Models
{
    /// <summary>
    /// Prrojekt, was aus Aufgaben besteht
    /// </summary>
    public class Projekt
    {
        [PrimaryKey, AutoIncrement]

        public Guid Id { get; set; }

        /// <summary>
        /// Name vom Projekt
        /// </summary>
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Aufgabe> Projektaufgaben { get; set; }
    }
}
