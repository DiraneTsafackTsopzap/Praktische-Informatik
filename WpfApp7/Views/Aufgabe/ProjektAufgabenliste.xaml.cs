using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp7.Dispatching;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Aufgabe;
using WpfApp7.Views.Aufgabe;

namespace WpfApp7
{
    /// <summary>
    /// Logique d'interaction pour SouspageAdd.xaml
    /// </summary>
    public partial class ProjektAufgabenlistePage : Page
    {
        List<Aufgabe> ListeAufgaben;
        Projekt selektiertesProjekt = new Projekt();
        DispatcherTimer Timer = new DispatcherTimer();
        private readonly AufgabeRepository Repository;

        public ProjektAufgabenlistePage(Projekt selektiertesProjekt)
        {
            Repository = new AufgabeRepository();
            this.selektiertesProjekt = selektiertesProjekt;
            InitializeComponent();

            this.DataContext = Timer;

            this.LabelProjektName.Content = $"Projektname: {this.selektiertesProjekt.Name}";
            ListeAufgabeLaden();

            Timer.TimerFinished += UpdateUI;
        }

        private void AufgabeHinzufuegen(object sender, RoutedEventArgs e)
        {
            var window = new AufgabeWindow(selektiertesProjekt);
            window.ShowDialog();
            ListeAufgabeLaden();
        }

        void ListeAufgabeLaden()
        {
            ListeAufgaben = Repository.GetAufgabeByProjectId(selektiertesProjekt.Id);

            listView.ItemsSource = ListeAufgaben;
        }

        private void TimerStartClick(object sender, RoutedEventArgs e)
        {
            var SelektierteAufgabe = (sender as FrameworkElement).DataContext as Aufgabe;
            listView.IsEnabled = false;
            StopTimerButton.Visibility = Visibility.Visible;
            TimerProgressBar.Visibility = Visibility.Visible;
            LabelAufgabe.Content = $"Aufgabe: {SelektierteAufgabe.Name}";
            DateTime TimerZeit = DateTime.Parse(SelektierteAufgabe.Timer.Timerstartzeit);
            TimerProgressBar.Maximum = TimerZeit.Second + (TimerZeit.Minute * 60) + (TimerZeit.Hour * 3600);
            Timer.StartTimer(SelektierteAufgabe.Timer, TimerZeit);
        }

        private void StopTimer(object sender, RoutedEventArgs e)
        {
            Timer.StopTimer();
            UpdateUI(sender, "");
        }

        private void UpdateUI(object sender, string args)
        {
            listView.IsEnabled = true;
            StopTimerButton.Visibility = Visibility.Hidden;
            TimerProgressBar.Visibility = Visibility.Hidden;
            LabelAufgabe.Content = "";
            ListeAufgabeLaden();
        }

        private void DeleteAufgabe(object sender, RoutedEventArgs e)
        {
            var SelektierteAufgabe = (sender as FrameworkElement).DataContext as Aufgabe;
            Repository.AufgabeLoeschen(SelektierteAufgabe);
            ListeAufgabeLaden(); 
        }
    }
}
