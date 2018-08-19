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
        private readonly String strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        public void Salvar(Contato entidade)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Contatos(name,birthdate) VALUES(@name,@birthdate)", conn);
            cmd.Parameters.AddWithValue("@name", entidade.Nome.Trim().ToLower());
            cmd.Parameters.AddWithValue("@birthdate", entidade.BirthDate);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Contato> Consultar(Contato contato)
        {
            List<Contato> contatos = new List<Contato>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ct.id, ct.name, ct.birthdate,coalesce(email.id,0),coalesce(email.endereco,'')," +
                "coalesce(email.tipo,0),coalesce(tel.id,1),coalesce(tel.telefone,''),coalesce(tel.tipo,0) FROM Contatos ct");
            sql.AppendLine("LEFT JOIN ContatosEmail email on ct.id = email.contato");
            sql.AppendLine("LEFT JOIN ContatosTelefone tel on ct.id = tel.contato");


            if (contato != null)
            {
                sql.AppendLine(" WHERE 1=1 ");
                if(contato.Id > 0)
                {
                    sql.AppendLine($"and ct.id = ${contato.Id}");
                }

                if (!string.IsNullOrEmpty(contato.Nome) && contato.Nome.Length == 1)
                {
                    sql.AppendLine($" and ct.name LIKE '{contato.Nome}%'");
                }

                if (!string.IsNullOrEmpty(contato.Nome) && contato.Nome.Length > 0)
                {
                    sql.AppendLine($" and ct.name LIKE '%{contato.Nome}%'");
                }
            }

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var contatoId = reader.GetInt32(0);
                        var contatoName = reader.GetString(1);
                        var contatoBirthDate = reader.GetDateTime(2);
                        var emailId = reader.GetInt32(3);
                        var emailEndereco = reader.GetString(4);
                        var emailTipo = (enums.TiposEmail) reader.GetInt32(5);
                        var telId = reader.GetInt32(6);
                        var telNumber = reader.GetString(7);
                        var telTipo = (enums.TiposTelefone)reader.GetInt32(8);

                        var ct = contatos.Where(c => c.Id == contatoId).FirstOrDefault();
                        Telefone telefone;
                        Email email;
                        if (ct == null)
                        {
                            ct = new Contato
                            {
                                Id = contatoId,
                                Nome = contatoName,
                                BirthDate = contatoBirthDate,
                                Telefones = new List<Telefone>(),
                                Emails = new List<Email>()
                            };

                            email = new Email()
                            {
                                Id = emailId,
                                Endereco = emailEndereco,
                                Tipo = emailTipo
                            };

                            telefone = new Telefone()
                            {
                                Id = telId,
                                Numero = telNumber,
                                Tipo = telTipo
                            };

                            ct.Telefones.Add(telefone);
                            ct.Emails.Add(email);
                            contatos.Add(ct);
                        }
                        else
                        {
                            email = new Email()
                            {
                                Id = emailId,
                                Endereco = emailEndereco,
                                Tipo = emailTipo
                            };

                            telefone = new Telefone()
                            {
                                Id = telId,
                                Numero = telNumber,
                                Tipo = telTipo
                            };
                            if (!ct.Emails.Contains(email))
                                ct.Emails.Add(email);
                            if (!ct.Telefones.Contains(telefone))
                                ct.Telefones.Add(telefone);
                        }
                    }
                }
            }
            return contatos;
        }

        public void Alterar(Contato entidade)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Contatos SET name=@name, birthdate = @birthdate WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@name", entidade.Nome);
            cmd.Parameters.AddWithValue("@birthdate", entidade.BirthDate);
            cmd.Parameters.AddWithValue("@id", entidade.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Deletar(Contato entidade)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE Contatos WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", entidade.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}