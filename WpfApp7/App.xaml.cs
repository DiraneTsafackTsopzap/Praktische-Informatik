using System.Windows;
using WpfApp7.Persistence.Repository.Projekt;
using WpfApp7.Persistence.Repository.Aufgabe;
using WpfApp7.Persistence.Repository.Timer;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            var ProjectRepository = new ProjektRepository();
            var AufgabeRepository = new AufgabeRepository();
            var TimerRepository = new TimerRepository();
        }
    }
}
