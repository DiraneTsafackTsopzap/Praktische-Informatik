using SQLite;
using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Aufgabe;

namespace WpfApp7.Views.Aufgabe
{
    /// <summary>
    /// Interaktionslogik für AufgabeWindow.xaml
    /// </summary>
    public partial class AufgabeWindow : Window
    {
        private readonly AufgabeRepository Repository;
        private readonly Projekt selektierteProjekt;

        public AufgabeWindow(Projekt selektierteProjekt)
        {
            Repository = new AufgabeRepository();
            InitializeComponent();
            this.selektierteProjekt = selektierteProjekt;
        }

        private void AufgabeSpeichern(object sender, RoutedEventArgs e)
        {
            var Aufgabe = new Models.Aufgabe();
            Aufgabe.Name = AufgabeTextBoxName.Text;
            Aufgabe.ProjektId = selektierteProjekt.Id;

            DateTime TimerDatum;
            var isvalidated = DateTime.TryParse(this.TimerTextbox.Text, out TimerDatum);

            if (AufgabeTextBoxName.Text == string.Empty)
            {
                MessageBox.Show("Geben Sie bitte einen Namen für die Aufgabe ein!");
            }
            else if(!isvalidated)
            {
                MessageBox.Show("ungültiges Zeitformat! Bitte in Form HH:mm:ss eingeben");
            }
            else
            {
                var Timer = new Timer();
                Timer.Id = Guid.NewGuid();
                Timer.Timerstartzeit = TimerTextbox.Text;
                Timer.Status = TimerStatus.InBearbeitung.ToString();
                Aufgabe.TimerId = Timer.Id;
                Aufgabe.Timer = Timer;

                Repository.AufgabeErstellen(Aufgabe);

                Close();
            }
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
