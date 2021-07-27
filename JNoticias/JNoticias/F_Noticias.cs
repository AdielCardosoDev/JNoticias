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

            Banco.NovaNoticia(noticias);


        }
    }
}
