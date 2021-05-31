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
    public partial class Form6 : Form
    {
        MySqlConnection con;
        int idPalestra;
        string diaPalestra = "", horaPalestra = "";
        public Form6()
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

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand busca_palestra = new MySqlCommand("Select tituloPalestra from Palestras", con); //where diaPalestra = "+DateTime.Now.ToShortDateString().ToString(), con);
                MySqlDataReader resultado = busca_palestra.ExecuteReader();
                while (resultado.Read())
                {
                    comboBox1.Items.Add(resultado["tituloPalestra"].ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand busca_palestra = new MySqlCommand("Select tituloPalestra, idPalestras, diaPalestra, horaPalestra from Palestras where tituloPalestra='" + comboBox1.SelectedItem.ToString() + "'", con);
                MySqlDataReader resultado = busca_palestra.ExecuteReader();
                if (resultado.Read())
                {
                    idPalestra = Convert.ToInt32(resultado["idPalestras"].ToString());
                    diaPalestra = resultado["diaPalestra"].ToString();
                    horaPalestra = resultado["horaPalestra"].ToString();
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
    }
}
