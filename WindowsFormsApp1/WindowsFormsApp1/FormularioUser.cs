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
    public partial class FormularioUser : Form
    {
        MySqlConnection connection = new MySqlConnection();
        String connectionString;

        public FormularioUser()
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
                connection.Open();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "ERROR");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           // connection.Open();
            MySqlCommand codigo = new MySqlCommand();

            codigo.Connection = connection;
            if(password.Text == rpassword.Text)
            {
                codigo.CommandText = ("insert into usuarios (Nombre,Username,Password) values('" + nombre.Text + "','" + username.Text + "','" + password.Text + "');");
                codigo.ExecuteReader();
                MessageBox.Show("Usuario agregado");

                Login login = new Login();
                this.Hide();
                login.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinsiden");
            }

        }

        private void rpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormularioUser_Load(object sender, EventArgs e)
        {

        }
    }
}
