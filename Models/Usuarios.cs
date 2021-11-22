using LibConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleFinanc.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Grupo Grupo { get; set; }
        public string Telefone_1 { get; set; }
        public string Telefone_2 { get; set; }
        public byte Status { get; set; }



        Conexao cn;
        public List<Usuarios> Lista(string textoSql)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_usuarios WHERE NOME LIKE '%" + textoSql + "%' ORDER BY NOME LIMIT 30";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Usuarios> Users = new List<Usuarios>();
                foreach (DataRow dr in table.Rows)
                {

                    Users.Add(new Usuarios
                    {
                        Id = int.Parse(dr["ID"].ToString()),
                        Nome = dr["Nome"].ToString(),
                        Usuario = dr["Usuario"].ToString(),
                        Telefone_1 = dr["telefone_1"].ToString(),
                        Telefone_2 = dr["telefone_2"].ToString(),
                        Email = dr["Email"].ToString(),
                        Grupo = new Grupo().GrupoUnico(int.Parse(dr["id_grupo"].ToString())),
                        Status = byte.Parse(dr["Status"].ToString())
                    });
                }

                return Users;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public bool Salvar()
        {

            string stringsql;
            cn = new Conexao();
            try
            {
                if (Id == 0)
                {
                    stringsql = "INSERT INTO tbl_usuarios (NOME, USUARIO, SENHA, EMAIL, ID_GRUPO, STATUS, TELEFONE_1, TELEFONE_2)" +
                      " VALUES (@NOME, @USUARIO, @SENHA, @EMAIL, @GRUPO, @STATUS, @TELEFONE_1, @TELEFONE_2)";

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@USUARIO", MySqlDbType.VarChar).Value = Usuario.ToUpper();
                    comando.Parameters.Add("@SENHA", MySqlDbType.VarChar).Value = "123456";
                    comando.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = Email;
                    comando.Parameters.Add("@GRUPO", MySqlDbType.Int32).Value = Grupo.Id;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Byte).Value = Status;
                    comando.Parameters.Add("@TELEFONE_1", MySqlDbType.VarChar).Value = Telefone_1;
                    comando.Parameters.Add("@TELEFONE_2", MySqlDbType.VarChar).Value = Telefone_2;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }
                else
                {

                    stringsql = "UPDATE tbl_usuarios SET NOME=@NOME,USUARIO=@USUARIO, EMAIL=@EMAIL,ID_GRUPO=@GRUPO,STATUS=@STATUS, TELEFONE_1=@TELEFONE_1, TELEFONE_2=@TELEFONE_2 WHERE id=" + Id;

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@USUARIO", MySqlDbType.VarChar).Value = Usuario.ToUpper();
                    comando.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = Email;
                    comando.Parameters.Add("@GRUPO", MySqlDbType.Int32).Value = Grupo.Id;
                    comando.Parameters.Add("@STATUS", MySqlDbType.Byte).Value = Status;
                    comando.Parameters.Add("@TELEFONE_1", MySqlDbType.VarChar).Value = Telefone_1;
                    comando.Parameters.Add("@TELEFONE_2", MySqlDbType.VarChar).Value = Telefone_2;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            

        }

        public Usuarios UsuarioUnico(int id)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from TBL_usuarios WHERE ID=" + id;
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();
                DataRow dr = table.Rows[0];

                return new Usuarios()
                {
                    Id = int.Parse(dr["ID"].ToString()),
                    Nome = dr["Nome"].ToString(),
                    Usuario = dr["Usuario"].ToString(),
                    Telefone_1= dr["telefone_1"].ToString(),
                    Telefone_2 = dr["telefone_2"].ToString(),
                    Email = dr["Email"].ToString(),
                    Grupo = new Grupo().GrupoUnico(int.Parse(dr["id_grupo"].ToString())),
                    Status = byte.Parse(dr["Status"].ToString())
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }

        }

        public bool Excluir()
        {
            string stringsql;
            cn = new Conexao();
            try
            {
                stringsql = "DELETE FROM tbl_usuarios WHERE id=" + Id;
                MySqlCommand comando = new MySqlCommand(stringsql, cn.cn); ;
                comando.Connection.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = stringsql;
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147467259)
                {
                    throw new Exception("Registro não pode ser excluido, pois está associado a um grupo.");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                cn.Close();
            }
        }
    }


}