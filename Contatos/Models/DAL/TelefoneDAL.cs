using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Contatos.Models.DAL
{
    public class TelefoneDAL
    {
        private readonly String strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        public void Salvar(Telefone telefone)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sql = "INSERT INTO ContatosTelefone(telefone,tipo,contato) VALUES(@telefone, @tipo, @contato)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@telefone",telefone.Numero.Trim().ToLower());
            cmd.Parameters.AddWithValue("@tipo",telefone.Tipo.GetHashCode());
            cmd.Parameters.AddWithValue("@contato", telefone.Contato.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}