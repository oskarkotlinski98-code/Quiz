using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NewQuizClick(object sender, RoutedEventArgs e)
        {
            CreateQuizWindow newWindow = new CreateQuizWindow();
            newWindow.Show();
            this.Hide();

            newWindow.Closed += (s, args) => this.Show();
        }

        private void EditQuizClick(object sender, RoutedEventArgs e)
        {

        }

        private void PlayQuizClick(object sender, RoutedEventArgs e)
        {

        }
    }
}