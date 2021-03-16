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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<Form2>().Count() == 0)
            {
                Form2 filho2 = new Form2();
                filho2.MdiParent = this;
                filho2.Show();
            }
            else
            {
                MessageBox.Show("Janela já está aberta");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cadastrarPalestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<Form3>().Count() == 0){
                Form3 filho3 = new Form3();
                filho3.MdiParent = this;
                filho3.Show();
            }
        }
    }
}
