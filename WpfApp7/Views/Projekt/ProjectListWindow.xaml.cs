using SQLite;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Projekt;
using WpfApp7.Views;

namespace WpfApp7
{
    /// <summary>
    /// Logique d'interaction pour ProjectPage.xaml
    /// </summary>
    public partial class ProjectListPage : Page
    {
        private Frame frameContent;
        private readonly ProjektRepository Repository;

        public ProjectListPage(Frame frameContent)
        {
            InitializeComponent();
            Repository = new ProjektRepository();
            ListeLaden();
            this.frameContent = frameContent;
        }

        public ProjectListPage()
        {
            InitializeComponent();
            Repository = new ProjektRepository();
            ListeLaden();
        }
        void ListeLaden()
        {
            var alleProjekte = Repository.AlleProjekteLaden();

            if(alleProjekte != null)
            {
                listviewName.ItemsSource = alleProjekte;
            }
        }


        private void AufgabenLaden(object sender, RoutedEventArgs e)
        {
            Projekt SelektiertesProjekt = (sender as FrameworkElement).DataContext as Projekt;
            frameContent.Content = new ProjektAufgabenlistePage(SelektiertesProjekt);
        }

        private void ProjektHinzufuegen(object sender, RoutedEventArgs e)
        {
            var windows = new AddProjectWindow();
            windows.ShowDialog();

            ListeLaden();
        }

        private void ProjektBearbeiten(object sender, RoutedEventArgs e)
        {
            var SelektiertesProjekt = (sender as FrameworkElement).DataContext as Projekt;
            if (SelektiertesProjekt != null)
            {
                UpdateProjectWindow pro = new UpdateProjectWindow(SelektiertesProjekt);
                pro.ShowDialog();
            }

            ListeLaden();
        }

        private void ProjektLoeschen(object sender, RoutedEventArgs e)
        {
            var SelektiertesProjekt = (sender as FrameworkElement).DataContext as Projekt; //holt das Projekt in der Zeile, wo der Button geklickt wurde
            Repository.ProjektLoeschen(SelektiertesProjekt);

            ListeLaden();
        }
    }
}
