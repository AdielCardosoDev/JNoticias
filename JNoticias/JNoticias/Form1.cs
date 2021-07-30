using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JNoticias
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_Noticias f_Noticias = new F_Noticias();
            f_Noticias.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_listanoticias.DataSource = Banco.ObterTodasNoticias();
            dgv_listanoticias.Columns[0].Width = 50;
            dgv_listanoticias.Columns[1].Width = 200;
            dgv_listanoticias.Columns[2].Width = 347;
            dgv_listanoticias.Columns[3].Width = 75;
            dgv_listanoticias.Columns[4].Width = 50;

        }

        private void btn_atualizarLista_Click(object sender, EventArgs e)
        {
            dgv_listanoticias.DataSource = Banco.ObterTodasNoticias();
            

        }
    }
}
