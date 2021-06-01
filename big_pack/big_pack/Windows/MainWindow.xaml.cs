using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace big_pack
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow main;
        public MainWindow()
        {
            InitializeComponent();
        }
        internal void Load_data(string a)
        {
                //очистка 
                spisok.Children.Clear();
            //подключение к базе данных
            using (SqlConnection connection = new SqlConnection(Clases.Connection.String))
                try
                {
                    connection.Open();
                    //запрос к базе данных на выборку
                    SqlCommand command = new SqlCommand($@"SELECT [ID] , [MaterialTypeID] , [Title] , [CountInPack] , [MinCount], [Image]  FROM [dbo].[Material]" + a , connection);
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    // если есть строчки, то программа выполняется
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Controls.Material material = new Controls.Material();

                                material.ID.Content = reader[0];

                                material.MaterialType.Content = reader[1];

                                material.Name_of_material.Content = reader[2];

                                material.countInPack.Content = reader[3];

                                material.MinCount.Content = reader[4];

                                material.Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[5]));

                                //material.postavka.Content = reader[6];

                                material.main = this;

                                spisok.Children.Add(material);
                            }

                        }

                    }
                catch (Exception e)
                {
                    //вывод ошибки, если она произойдёт
                    Console.WriteLine(e.Message);

                    throw;
                }
        }



        //загрузка данных
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_data("");
        }
        private void find_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load_data($@"WHERE Title like '{find.Text}%' or Description like '{find.Text}%'");
        }
    }
}
