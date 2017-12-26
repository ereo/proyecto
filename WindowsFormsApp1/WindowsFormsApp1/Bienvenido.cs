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
    public partial class Bienvenido : Form
    {
        MySqlConnection connection = new MySqlConnection();
        String connectionString;
        public Bienvenido()
        {
            InitializeComponent();
            iniciarConexion();

            MySqlCommand codigo = new MySqlCommand();

            codigo.Connection = connection;
            codigo.CommandText = ("select * from usuarios");

            MySqlDataReader leer = codigo.ExecuteReader();

            if (leer.Read())
            {
                Login login = new Login();
                this.Hide();
                login.ShowDialog();

            }
            else
            {

            }
            this.Close();
        }
        public void iniciarConexion()
        {
            try
            {
                connectionString = "Server=127.0.0.1; Database=reproductor; Uid=root; Pwd= ;";
                connection.ConnectionString = connectionString;
                connection.Open();
                //MessageBox.Show("La conexion se ha realizado con exito", "Bien hecho!");



            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "ERROR");
            }
        }

        private void Bienvenido_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormularioUser formulariouser = new FormularioUser();
            this.Hide();
            formulariouser.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
