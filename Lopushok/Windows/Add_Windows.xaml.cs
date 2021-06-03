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

namespace Lopushok.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add_Windows.xaml
    /// </summary>
    public partial class Add_Windows : Window
    {
        public Add_Windows()
        {
            InitializeComponent();
        }

        private void btn_add_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow add = new MainWindow();
            add.Show();
            this.Hide();
        }
    }
}
