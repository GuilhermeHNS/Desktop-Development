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

namespace Projeto_Chamada
{
    public partial class Form3 : Form
    {

        MySqlConnection con;
        public Form3()
        {
            InitializeComponent();

            InitializeComponent();
            try
            {
                con = new MySqlConnection("server=143.106.241.3; port=3306; UserID=cl19239; database=cl19239; password=cl*12052002");

            }
            catch
            {
                MessageBox.Show("Falha na conexão");
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy");
        }
    }
}
