using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HomeWork4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder =new SqlConnectionStringBuilder();
            builder.ConnectionString = "server=(local);initial catalog=MyDB";
            builder.UserID = loginBox.Text;
            builder.Password = passwordBox.Text;


            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Вы подкючены!", "Успешно!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("неверный логин или пароль", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                
            }
        }
      
    }
}
