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
    /// Логика взаимодействия для Redaction_Vindows.xaml
    /// </summary>
    public partial class Redaction_Vindows : Window
    {
        public Redaction_Vindows()
        {
            InitializeComponent();
        }

        private void btn_add_back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
