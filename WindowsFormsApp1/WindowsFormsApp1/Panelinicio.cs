using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Panelinicio : Form
    {
        string user;
        public Panelinicio(string valor )
        {
            InitializeComponent();
            
            CultureInfo ci = new CultureInfo("Es-Es");
            string dia = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string hora = DateTime.Now.ToString("HH:mm tt");
            label2.Text = "Buen día " + valor + ". Hoy es "+dia+" "+hora;
            user = valor;
        }

        private void Panelinicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Usuarios usuarios = new Usuarios(user))
            {
                this.Hide();
                usuarios.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
