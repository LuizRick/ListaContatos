using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Contatos.Models.DAL
{
    public class EmailDAL
    {
        private readonly string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        public void Salvar(Models.Email email)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sql = @"INSERT INTO ContatosEmail(endereco, contato, tipo) VALUES(@endereco, @contato, @tipo)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@endereco",email.Endereco);
            cmd.Parameters.AddWithValue("@contato", email.Contato.Id);
            cmd.Parameters.AddWithValue("@tipo", email.Tipo.GetHashCode());
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}