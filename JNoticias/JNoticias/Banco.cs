using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JNoticias
{
    class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection conexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source=C:\\Users\\Adiel Cardoso\\Documents\\GitHub\\JNoticias\\JNoticias\\JNoticias\\Banco\\Banco_noticias.db");
            conexao.Open();
            
            return conexao;
        }

        public static DataTable ObterTodasNoticias()
        {

            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {                
                var vcon = conexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "select ID, Titulo, Descricao as 'Descrição da Noticia', Data, Hora from tb_Noticias";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);                   
                da.Fill(dt);
                vcon.Close();
                return dt;                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        

        public static void NovaNoticia(Noticias n)
        {           

            try
            {
                var cmd = conexaoBanco().CreateCommand();
                cmd.CommandText = "INSERT INTO  tb_Noticias (Titulo, Data, Hora, Descricao) VALUES (@titulo, @data, @hora, @descricao)";
                cmd.Parameters.AddWithValue("@titulo", n.Titulo);
                cmd.Parameters.AddWithValue("@data", n.Data);
                cmd.Parameters.AddWithValue("@hora", n.Hora);
                cmd.Parameters.AddWithValue("@descricao", n.Descricao);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Noticia Salva...");               
                conexaoBanco().Close();          




            }
            catch
            {                
                MessageBox.Show("Erro na comunicação com o Banco!!!");
            }

        }

        


    }
}
