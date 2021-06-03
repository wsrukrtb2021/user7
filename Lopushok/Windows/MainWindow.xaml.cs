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
using System.IO;
using Lopushok.Clases;
using Lopushok.User_Controls1;
using System.Data.SqlClient;
using Lopushok.Windows;


namespace Lopushok
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        internal void Load_Data (string a)
        {
            lopushok_list.Children.Clear();
            using (SqlConnection connection = new SqlConnection(connect_bd.String))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"SELECT  Product.ID
                                                              ,Product.Title
                                                              ,ProductType.Title AS Title2
                                                              ,Product.ArticleNumber
                                                              ,Product.Description
                                                              ,Product.Image
                                                              ,Product.ProductionPersonCount
                                                              ,Product.ProductionWorkshopNumber
                                                              ,Material.Cost
                                                              ,Material.Title
                                                   FROM [dbo].[Product]
                                        INNER JOIN ProductType ON Product.ProductTypeID = ProductType.ID
                                        INNER JOIN Material ON Product.ID = Material.ID
                 WHERE (Product.Title like '%{search.Text}%' or Product.Description like '%{search.Text}%')
                 AND ProductType.Title like '{(Filtr.SelectedIndex == 0 ? "" : ((ComboBoxItem)Filtr.SelectedItem).Content)}%'
                 ORDER BY {(Sort.SelectedIndex == 0 ? "Product.ID" : (Sort.SelectedIndex == 1 ? "MinCostForAgent" : "MinCostForAgent"))}"
                 + a, connection);

                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        lopushok_controls lopush = new lopushok_controls();
                        lopush.label_id.Content = reader[0];
                        lopush.label_type_and_title.Content = $@"{reader[1]} | {reader[2]}";
                        lopush.label_article_number.Content = reader[3];
                        lopush.label_description.Content = reader[4];
                        lopush.label_image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[5].ToString().Replace("jpg","jpeg")));
                        lopush.label_production_person_caount.Content = reader[6];
                        lopush.label_production_workshop_number.Content = reader[7];
                        lopush.label_cont.Content = reader[8];
                        lopush.label_material.Content = $@" Материалы: {reader[9]}";
                        lopush.Main = this;

                        lopushok_list.Children.Add(lopush);

                    }
                }
            }
        }

        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            page_scroll.PageUp();
        }

        private void page_down_Click(object sender, RoutedEventArgs e)
        {
            page_scroll.PageDown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Data("");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load_Data("");
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filtr != null)
            {
                Load_Data("");
            }
        }

        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load_Data("");
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Add_Windows add = new Add_Windows();
            add.Show();
            this.Hide();
        }
    }
}
