using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7.Models
{
    /// <summary>
    /// Ein Timer, der gebraucht wird, um eine Aufgabe zu erledigen
    /// </summary>
    public class Timer
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        ///  Datum wo ich fange an, ein timer anzulegen
        /// </summary>
        public string Startdatum { get; set; } 


        /// <summary>
        /// Datum wenn timer = 0 , die Arbeit ist fertig
        /// </summary>
        public string EndDatum { get; set; } 


        /// <summary>
        /// Name von mein Thema
        /// </summary>
        ///
        public string Projekt { get; set; }


        /// <summary>
        /// Name von eine der Teilaufgaben
        /// </summary>
        public string Aufgabe { get; set; }


        /// <summary>
        ///  der wert von meiner eingegeben timer
        /// </summary>
        public string Timerstartzeit { get; set; }


        /// <summary>
        /// status, ob timer = 0 , dann fertig ansonsten Arbeit noch nicht fertig
        /// </summary>
        public string Status { get; set; }
    }

    public enum TimerStatus
    {
        InBearbeitung,
        Fertig
    }
}
