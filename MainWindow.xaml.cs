using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryLogger
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

        private void EasyIdentify_Click(object sender, RoutedEventArgs e) {
            IdentifyAreas window = new IdentifyAreas(0);
            window.Show();
            this.Close();
        }

        private void MediumIdentify_Click(object sender, RoutedEventArgs e) {
            IdentifyAreas window = new IdentifyAreas(1);
            window.Show();
            this.Close();
        }

        private void HardIdentify_Click(object sender, RoutedEventArgs e) {
            IdentifyAreas window = new IdentifyAreas(2);
            window.Show();
            this.Close();
        }

        private void EasyReplace_Click(object sender, RoutedEventArgs e) {
            ReplaceBooksWindow window = new ReplaceBooksWindow(0);
            window.Show();
            this.Close();
        }

        private void MediumReplace_Click(object sender, RoutedEventArgs e) {
            ReplaceBooksWindow window = new ReplaceBooksWindow(1);
            window.Show();
            this.Close();
        }

        private void HardReplace_Click(object sender, RoutedEventArgs e) {
            ReplaceBooksWindow window = new ReplaceBooksWindow(2);
            window.Show();
            this.Close();
        }

        private void EasyBooks_Click(object sender, RoutedEventArgs e) {
            /*ReplaceBooksWindow window = new ReplaceBooksWindow(2);
            window.Show();
            this.Close();*/
        }

        private void MediumBooks_Click(object sender, RoutedEventArgs e) {
            /*ReplaceBooksWindow window = new ReplaceBooksWindow(2);
            window.Show();
            this.Close();*/
        }

        private void HardBooks_Click(object sender, RoutedEventArgs e) {
            /*ReplaceBooksWindow window = new ReplaceBooksWindow(2);
            window.Show();
            this.Close();*/
        }
    }
}
