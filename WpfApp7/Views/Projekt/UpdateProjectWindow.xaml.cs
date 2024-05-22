using SQLite;
using System;
using System.Windows;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Projekt;

namespace WpfApp7
{
    /// <summary>
    /// Logique d'interaction pour ProjetPage_Updelete.xaml
    /// </summary>
    public partial class UpdateProjectWindow : Window
    {
        Projekt Project;
        private readonly ProjektRepository Repository;

        public UpdateProjectWindow(Projekt project)
        {
            this.Project = project;
            InitializeComponent();
            Repository = new ProjektRepository();
            TextboxUpdate.Text = Project.Name;
        }

        private void ProjektBearbeiten(object sender, RoutedEventArgs e)
        {
            Project.Name = TextboxUpdate.Text;
            Repository.ProjektUpdate(Project);

            TextboxUpdate.Text = String.Empty;

            Close();
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
