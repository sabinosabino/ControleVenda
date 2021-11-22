using LibConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleFinanc.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Status { get; set; }


        Conexao cn;
        public List<Grupo> Lista(string textoSql)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from TBL_GRUPO WHERE NOME LIKE '%" + textoSql + "%' ORDER BY NOME LIMIT 30";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Grupo> Grupos = new List<Grupo>();
                foreach (DataRow dr in table.Rows)
                {

                    Grupos.Add(new Grupo
                    {
                        Id = int.Parse(dr["ID"].ToString()),
                        Nome = dr["Nome"].ToString(),
                        Status = int.Parse(dr["Status"].ToString())
                    });
                }

                return Grupos;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public bool Excluir()
        {
            string stringsql;
            cn = new Conexao();
            try
            {
                stringsql = "DELETE FROM tbl_grupo WHERE id=" + Id;
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
                    throw new Exception("Registro não pode ser excluido, pois está associado a usuários.");
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

        public List<Grupo> ListaAtivos(string textoSql)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from TBL_GRUPO WHERE NOME LIKE '%" + textoSql + "%' ORDER BY NOME And STATUS=1";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Grupo> Grupos = new List<Grupo>();
                foreach (DataRow dr in table.Rows)
                {
                    Grupos.Add(new Grupo
                    {
                        Id = int.Parse(dr["ID"].ToString()),
                        Nome = dr["Nome"].ToString(),
                        Status = int.Parse(dr["STATUS"].ToString())
                    });
                }

                return Grupos;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public Grupo GrupoUnico(int id)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from TBL_GRUPO WHERE ID=" + id;
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

                return new Grupo
                {
                    Id = int.Parse(dr["ID"].ToString()),
                    Nome = dr["Nome"].ToString(),
                    Status = int.Parse(dr["STATUS"].ToString())
                };
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
                    stringsql = "INSERT INTO tbl_grupo (NOME, STATUS)" +
                      " VALUES (@NOME, @STATUS)";

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn); ;
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;
                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int32).Value = Status;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }
                else
                {

                    stringsql = "UPDATE tbl_grupo  SET NOME=@NOME,STATUS=@STATUS WHERE ID=" + Id;
                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn); ;
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@STATUS", MySqlDbType.Int32).Value = Status;
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

    }

}