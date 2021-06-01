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

namespace big_pack.Controls
{
    /// <summary>
    /// Логика взаимодействия для change.xaml
    /// </summary>
    public partial class change : Window
    {
        MainWindow main;
        public change()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите сохранить изминения?", "Изминение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
