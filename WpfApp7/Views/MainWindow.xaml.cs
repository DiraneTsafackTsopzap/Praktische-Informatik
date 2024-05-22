using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OeffneMeineProjekte(object sender, RoutedEventArgs e)
        {
            frameContent.Content = new ProjectListPage(frameContent);
        }

        private void NavigateBack(object sender, RoutedEventArgs e)
        {
            if(frameContent.CanGoBack)
            {
                frameContent.GoBack();
            }
        }
    }
}
