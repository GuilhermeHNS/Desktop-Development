using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Projeto_Chamada
{
    public partial class Form2 : Form
    {

        MySqlConnection con;
        public Form2()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO `cl19239`.`Alunos_C#`(idAlunos, nomeAlunos, turmaAlunos, emailAlunos) values (" + textBox1.Text + ", '" + textBox2.Text + " ',' " + comboBox1.SelectedItem.ToString() + " ','"+textBox3.Text+"')", con);
                insere.ExecuteNonQuery();
                MessageBox.Show("Gravação realizada com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
