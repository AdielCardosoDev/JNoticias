using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

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
                using (var cmd = conexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT *FROM tb_Noticias";
                    da = new SQLiteDataAdapter(cmd.CommandText, conexaoBanco());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
