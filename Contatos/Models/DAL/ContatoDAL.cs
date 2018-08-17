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
    public class ContatoDAL
    {
        private String strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        public void Salvar(Contato entidade)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO contatos(name,birthdate) VALUES(@name,@birthdate)", conn);
            cmd.Parameters.AddWithValue("@name", entidade.Nome);
            cmd.Parameters.AddWithValue("@birthdate", entidade.BirthDate);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Contato> Consultar(Contato contato)
        {
            List<Contato> lst = new List<Contato>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            StringBuilder sql = new StringBuilder("SELECT id, name, birthdate FROM contatos");
            if (contato != null)
            {
                sql.AppendLine(" WHERE 1=1 ");
                if (!string.IsNullOrEmpty(contato.Nome) && contato.Nome.Length == 1)
                {
                    sql.AppendLine(" and name LIKE '" + contato.Nome + "%'");
                }
            }
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new Contato()
                {
                    Id = (int)dr["id"],
                    Nome = (string)dr["name"],
                    BirthDate = (DateTime)dr["birthdate"]
                });
            }
            conn.Close();
            return lst;
        }
    }
}