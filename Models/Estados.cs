using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using LibConnection;
using MySql.Data.MySqlClient;

namespace ControleFinanc.Models
{
    public class Estados
    {
        public string uf { get; set; }
        public string nome { get; set; }
        public string ibge { get; set; }
        public int pais { get; set; }
        public string ddd { get; set; }


        Conexao cn;
        public List<Estados> Lista(string textoSql)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_estado WHERE Nome LIKE '%" + textoSql + "%' ORDER BY uf";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Estados> Estados_ = new List<Estados>();
                foreach (DataRow dr in table.Rows)
                {

                    Estados_.Add(new Estados
                    {

                        uf = dr["uf"].ToString(),
                        nome = dr["nome"].ToString(),
                        ibge = dr["ibge"].ToString(),
                        pais = int.Parse(dr["pais"].ToString()),
                        ddd = dr["ddd"].ToString()
                    });
                }

                return Estados_;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public Estados Unitario(int id)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_Estados WHERE ID=" + id;
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
                return new Estados()
                {

                    uf = dr["uf"].ToString(),
                    nome = dr["nome"].ToString(),
                    ibge = dr["ibge"].ToString(),
                    pais = int.Parse(dr["pais"].ToString()),
                    ddd = dr["ddd"].ToString()
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

    }
}
