using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Usuarios : Form
    {
        MySqlConnection connection = new MySqlConnection();
        String connectionString;
        string user;
        public Usuarios(string valor)
        {
            InitializeComponent();
            iniciarConexion();

            label2.Text = "Hola " + valor + ", ¿Qué desea hacer ?";
            user = valor;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        public void iniciarConexion()
        {
            try
            {
                connectionString = "Server=127.0.0.1; Database=bdrep; Uid=root; Pwd= ;";
                connection.ConnectionString = connectionString;
                connection.Close();
                //MessageBox.Show("La conexion se ha realizado con exito", "Bien hecho!");



            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "ERROR");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            connection.Open();
            MySqlCommand codigo = new MySqlCommand();
            
            codigo.Connection = connection;
            

            codigo.CommandText = ("select * from usuarios where Username = '" + user + "' and  Password = '" + passwordact.Text + "' ");

            MySqlDataReader leer = codigo.ExecuteReader();

            

            if (leer.Read())
            {
                connection.Close();
                connection.Open();

                MySqlCommand codigo2 = new MySqlCommand();
                codigo2.Connection = connection;

                if ((npassword.Text == rnpassword.Text)&&(npassword.Text != passwordact.Text))
                {
                    codigo2.CommandText = ("update bdrep.usuarios set Password='" + npassword.Text + "' where Username='" + user + "';");
                    codigo2.ExecuteReader();
                    MessageBox.Show("Se han Ingresado los datos");

                }
                else
                {
                    MessageBox.Show("No coinsiden o es igual a la contraseña anterior");
                }

                
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }



            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Panelinicio panelinicio = new Panelinicio(user);
            this.Hide();
            panelinicio.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarUser formularioUser = new AgregarUser(user);
            this.Hide();
            formularioUser.ShowDialog();
            this.Close();
        }
    }
}
