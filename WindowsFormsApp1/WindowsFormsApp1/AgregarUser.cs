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
    public partial class AgregarUser : Form
    {
        MySqlConnection connection = new MySqlConnection();
        String connectionString;
        string user;

        public AgregarUser(string valor)
        {
            InitializeComponent();
            iniciarConexion();
            user = valor;
        }

        public void iniciarConexion()
        {
            try
            {
                connectionString = "Server=127.0.0.1; Database=bdrep; Uid=root; Pwd= ;";
                connection.ConnectionString = connectionString;
                connection.Open();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "ERROR");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // connection.Open();
            MySqlCommand codigo = new MySqlCommand();

            codigo.Connection = connection;
            if (password.Text == rpassword.Text)
            {
                codigo.CommandText = ("insert into usuarios (Nombre,Username,Password) values('" + nombre.Text + "','" + username.Text + "','" + password.Text + "');");
                codigo.ExecuteReader();
                MessageBox.Show("Se han Ingresado los datos");

                Usuarios login = new Usuarios(user);
                this.Hide();
                login.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("No coinsiden");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarUser_Load(object sender, EventArgs e)
        {

        }
    }
}
