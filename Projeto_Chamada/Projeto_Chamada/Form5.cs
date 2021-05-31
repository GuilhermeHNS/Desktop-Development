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
    public partial class Form5 : Form
    {

        MySqlConnection con;
        public Form5()
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand busca_ra = new MySqlCommand("Update Alunos_CSharp set status = 1 where idAlunos = " + textBox1.Text, con);
                busca_ra.ExecuteNonQuery();

                MessageBox.Show("Aluno Inativado");

                textBox1.Clear();
                textBox2.Clear();
                label2.Text = "Aluno";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                try
                {
                    con.Open();
                    MySqlCommand busca_ra = new MySqlCommand("Select nomeAlunos, idALunos, emailAlunos from Alunos_CSharp where idAlunos = " + textBox1.Text, con);
                    MySqlDataReader resultado = busca_ra.ExecuteReader();

                    if (resultado.Read())
                    {
                        label2.Text = resultado["nomeAlunos"].ToString();
                        textBox2.Text = resultado["nomeAlunos"].ToString();
                        textBox3.Text = resultado["emailAlunos"].ToString();
                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand atualliza_nome = new MySqlCommand("Update Alunos_CSharp set nomeAlunos = '" + textBox2.Text + "', emailAlunos = '" + textBox3.Text + "' where idAlunos=" + textBox1.Text, con);
                atualliza_nome.ExecuteNonQuery();
                MessageBox.Show("Atualização efetuada");
                textBox1.Clear();
                textBox2.Clear();
                label2.Text = "Aluno";
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
