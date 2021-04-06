using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Chamada
{
    public partial class Form4 : Form
    {
        MySqlConnection con;
        int idPalestra, ra;
        public Form4()
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                con.Open();
                MySqlCommand busca_palestra = new MySqlCommand("Select tituloPalestra,idPalestras from Palestras where tituloPalestra='"+comboBox1.SelectedItem.ToString()+"'", con);
                MySqlDataReader resultado = busca_palestra.ExecuteReader();
                if (resultado.Read())
                {
                    idPalestra = Convert.ToInt32(resultado["idPalestras"].ToString());
                    MessageBox.Show(idPalestra.ToString());
                }
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
                    MySqlCommand busca_ra = new MySqlCommand("Select nomeAlunos, idAlunos, fotoAlunos from Alunos_CSharp where idAlunos=" + textBox1.Text, con);
                    MySqlDataReader resultado = busca_ra.ExecuteReader();
                    if (resultado.Read())
                    {
                        label4.Text = resultado["nomeAlunos"].ToString();
                        ra = Convert.ToInt32(resultado["idAlunos"].ToString());
                        try
                        {
                            string imagem = Convert.ToString(DateTime.Now.ToFileTime());
                            byte[] bimage = (byte[])resultado["fotoAlunos"];
                            FileStream fs = new FileStream(imagem, FileMode.CreateNew, FileAccess.Write);
                            fs.Write(bimage, 0, bimage.Length - 1);
                            fs.Close();
                            pictureBox2.BackgroundImage = Image.FromFile(imagem);
                            resultado.Close();
                        }
                        catch
                        {
                            pictureBox2.BackgroundImage = Image.FromFile("perdemo.jpg");
                        }
                        //inserir
                        con.Close();
                        try
                        {
                            con.Open();
                            MySqlCommand insere = new MySqlCommand("insert into Presenca (RA, idPalestra, Hora) values ("+ ra + ","+ idPalestra + ",'" + DateTime.Now.ToShortTimeString() + "')", con);
                            insere.ExecuteNonQuery();
                            MessageBox.Show("Registrado");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                            textBox1.Clear();
                            textBox1.Focus();
                            label3.Text = "Aluno";
                        }




                    }//if resultado.read
                }//tr
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }//catch
                finally
                {
                    con.Close();
                }//finally
            }//if
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand busca_palestra = new MySqlCommand("Select tituloPalestra from Palestras", con);
                MySqlDataReader resultado = busca_palestra.ExecuteReader();
                while (resultado.Read())
                {
                    comboBox1.Items.Add(resultado["tituloPalestra"].ToString());
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
}
