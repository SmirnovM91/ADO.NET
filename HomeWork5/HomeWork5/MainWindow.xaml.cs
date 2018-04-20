using System;
using System.Collections.Generic;
using System.Data;
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

namespace HomeWork5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1 != null)
            {
                string table = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
                string connectionStr = @"Data Source=(local); Initial Catalog=sales;Integrated Security=True;Pooling=False";
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM "+ table, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        
                        dataGrid1.ItemsSource = dt.DefaultView;
                        
                        con.Close();
                    }
                }
            }

        }
    }
}
