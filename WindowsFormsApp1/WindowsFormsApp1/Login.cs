using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection();
        String connectionString;

        public Login()
        {
            InitializeComponent();
            iniciarConexion();


        }

        public void iniciarConexion()
        {
            try
            {
                connectionString = "Server=127.0.0.1; Database=bdrep; Uid=root; Pwd= ;";
                connection.ConnectionString = connectionString;
                connection.Close();
           
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "ERROR");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            MySqlCommand codigo = new MySqlCommand();

            codigo.Connection = connection;
            codigo.CommandText = ("select * from usuarios where Username = '"+username.Text+"' and  Password = '"+password.Text+"' ");

            MySqlDataReader leer = codigo.ExecuteReader();

            if (leer.Read())
            {
                MessageBox.Show("Bienvenido");
                
                using (Panelinicio panelinicio = new Panelinicio(username.Text))
                {
                    this.Hide();
                    panelinicio.ShowDialog();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta");
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
