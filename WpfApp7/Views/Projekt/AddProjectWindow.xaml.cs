using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Projekt;

namespace WpfApp7.Views
{
    /// <summary>
    /// Interaktionslogik für AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
       public static string name = string.Empty;
       private readonly ProjektRepository Repository;
        public AddProjectWindow()
        {
            InitializeComponent();
            Repository = new ProjektRepository();
        }

        
        List<Projekt> listes_projeck = new List<Projekt>();

        private void ProjektSpeichern(object sender, RoutedEventArgs e)
        {
            Projekt Projekt = new Projekt();
            Projekt.Name = ProjectTextBoxName.Text;

            if (ProjectTextBoxName.Text == string.Empty)
            {
                MessageBox.Show("Geben Sie bitte einen Namen ein!");

            }
          
            else
            {
                Repository.ProjektErstellen(Projekt);
                Close();
            }

            ProjectTextBoxName.Text = string.Empty;
        }

        private void Abbrechen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
