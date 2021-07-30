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
    public partial class F_Noticias : Form
    {
        public F_Noticias()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Noticias noticias = new Noticias();
            noticias.Titulo = C_titulo.Text;
            noticias.Data = C_data.Text;
            noticias.Hora = C_hora.Text;
            noticias.Descricao = C_descrisao.Text;

            if (
                C_titulo.Text.Trim().ToString() == "" ||
                C_data.Text.Trim().ToString() == ""||
                C_hora.Text.Trim().ToString() == ""||
                C_descrisao.Text.Trim().ToString() == ""
                )
            {
                MessageBox.Show("Todos os campos são obrigatórios!!!");
            }
            else
            {
                Banco.NovaNoticia(noticias);

                C_titulo.Clear();
                C_hora.Clear();
                C_descrisao.Clear();
                C_titulo.Focus();
                dgv_listanoticias.DataSource = Banco.ObterTodasNoticias();

            }
        }

        private void F_Noticias_Load(object sender, EventArgs e)
        {
            dgv_listanoticias.DataSource = Banco.ObterTodasNoticias();
            dgv_listanoticias.Columns[0].Width = 50;
            dgv_listanoticias.Columns[1].Width = 200;
            dgv_listanoticias.Columns[2].Width = 347;
            dgv_listanoticias.Columns[3].Width = 75;
            dgv_listanoticias.Columns[4].Width = 50;
        }

        private void dgv_listanoticias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgb = (DataGridView)sender;
            int contLinhas = dgv_listanoticias.SelectedRows.Count;
            if(contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv_listanoticias.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosNoticias(vid);
                C_titulo.Text = dt.Rows[0].Field<string>("Titulo").ToString();
                C_data.Text = dt.Rows[0].Field<string>("Data").ToString();
                C_hora.Text = dt.Rows[0].Field<string>("Hora").ToString();
                C_descrisao.Text = dt.Rows[0].Field<string>("descricao").ToString();
            }
            
        }
    }
}
