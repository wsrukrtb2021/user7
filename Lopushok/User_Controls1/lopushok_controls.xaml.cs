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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;
using Lopushok.Clases;
using Lopushok.User_Controls1;
using Lopushok.Windows;

namespace Lopushok.User_Controls1
{
    /// <summary>
    /// Логика взаимодействия для lopushok_controls.xaml
    /// </summary>
    public partial class lopushok_controls : UserControl
    {
        public lopushok_controls()
        {
            InitializeComponent();
        }
        public MainWindow Main;

        private void btn_delet_product_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connect_bd.String))
            {
                if (MessageBox.Show("Хотите удалить агента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($@"DELETE FROM [dbo].[Product] WHERE ID = '{label_id.Content}'", connection);
                    command.ExecuteNonQuery();
                    Main.Load_Data("");
                }
                else
                {

                }
            }
        }

        private void btn_redaction_Click(object sender, RoutedEventArgs e)
        {
            Redaction_Vindows rea = new Redaction_Vindows();
            rea.Show();
        }
    }
}
