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

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO `cl19239`.`Palestras`(tituloPalestra, nomePalestrante, diaPalestra, horaPalestra)values('"+ textBox2.Text + "','"+ textBox3.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "')",con);
                insere.ExecuteNonQuery();
                MessageBox.Show("Cadastrado!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
