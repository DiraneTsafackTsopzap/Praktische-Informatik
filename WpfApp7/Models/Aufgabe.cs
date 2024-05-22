using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace WpfApp7.Models
{
    /// <summary>
    /// Aufgabe vom Projekt
    /// </summary>
    public class Aufgabe
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        /// <summary>
        /// Name von der Aufgabe
        /// </summary>
        public string Name { get; set; }


        [ForeignKey(typeof(Projekt))]
        public Guid ProjektId { get; set; }


        [ForeignKey(typeof(Timer))]
        public Guid TimerId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Timer Timer { get; set; }
    }

    public enum AufgabeStatus
    {
        InBearbeitung,
        Fertig
    }
}
