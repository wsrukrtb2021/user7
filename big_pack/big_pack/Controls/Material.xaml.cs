using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace big_pack.Controls
{
    /// <summary>
    /// Логика взаимодействия для Material.xaml
    /// </summary>
    public partial class Material : UserControl
    {
        public MainWindow main;
        public Material()
        {
            InitializeComponent();
        }
        //кнопка для удаления материала по его идентификатору
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Clases.Connection.String))
            {
                if (MessageBox.Show("Вы точно хотите удалить материал?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"Delete FROM Material WHERE ID = {ID.Content}", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно удалены!");
                    main.Load_data("");
                }
                else
                {
                    MessageBox.Show("Отлично!");
                }
            }

        }
        //кнопка для открытия формы "Изменить"
        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите перейти на форму изминения материала?", "Изминение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                change change = new change();
                change.ID.Content = (string)ID.Content.ToString();
                change.MaterialType.Text = (string)Name_of_material.Content.ToString();
                
                change.Show();
            }
            else
            {
                MessageBox.Show("Отлично!");
            }
        }

    }
}
