using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using LibConnection;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ControleFinanc.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public Clientes idCliente { get; set; }
        public DateTime? data_Venda { get; set; }
        public decimal valor_venda { get; set; }
        public string detalhe_venda { get; set; }
        public decimal valor_pago { get; set; }
        public string detalhe_pagamento { get; set; }
        public int tipo { get; set; }
        Conexao cn;
        public List<Vendas> Lista(int tipo)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_vendas WHERE tipo=" + tipo + " ORDER BY data_venda desc";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Vendas> vendas_ = new List<Vendas>();
                foreach (DataRow dr in table.Rows)
                {

                    vendas_.Add(new Vendas
                    {

                        Id = int.Parse(dr["Id"].ToString()),
                        idCliente = new Clientes().Unitario(int.Parse(dr["idCliente"].ToString())),
                        data_Venda = DateTime.Parse(dr["data_Venda"].ToString()),
                        valor_venda = decimal.Parse(dr["valor_venda"].ToString()),
                        detalhe_venda = dr["detalhe_venda"].ToString(),
                        valor_pago = decimal.Parse(dr["valor_pago"].ToString()),
                        detalhe_pagamento = dr["detalhes_pagamento"].ToString(), 
                        tipo= int.Parse(dr["tipo"].ToString())
                    });
                }

                return vendas_;

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
                    stringsql = "INSERT INTO tbl_vendas (IDCLIENTE,DATA_VENDA,VALOR_VENDA,DETALHE_VENDA, VALOR_PAGO, DETALHES_PAGAMENTO, TIPO) " +
                        "VALUES (@IDCLIENTE,@DATA_VENDA,@VALOR_VENDA,@DETALHE_VENDA, @VALOR_PAGO, @DETALHES_PAGAMENTO, @TIPO);";

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@IDCLIENTE", MySqlDbType.Int32).Value = idCliente.Id;
                    comando.Parameters.Add("@DATA_VENDA", MySqlDbType.DateTime).Value = data_Venda;
                    comando.Parameters.Add("@VALOR_VENDA", MySqlDbType.Decimal).Value = valor_venda;
                    comando.Parameters.Add("@DETALHE_VENDA", MySqlDbType.VarChar).Value = detalhe_venda;
                    comando.Parameters.Add("@VALOR_PAGO", MySqlDbType.Decimal).Value = valor_pago;
                    comando.Parameters.Add("@DETALHES_PAGAMENTO", MySqlDbType.VarChar).Value = detalhe_pagamento;
                    comando.Parameters.Add("@TIPO", MySqlDbType.Int32).Value = tipo;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }

                else
                {

                    stringsql = "UPDATE tbl_vendas SET IDCLIENTE=@IDCLIENTE," +
                                            "DATA_VENDA=@DATA_VENDA,VALOR_VENDA=@VALOR_VENDA," +
                                            "DETALHE_VENDA=@DETALHE_VENDA, VALOR_PAGO=@VALOR_PAGO, " +
                                            "DETALHES_PAGAMENTO=@DETALHES_PAGAMENTO, TIPO=@TIPO WHERE Id=" + Id;
                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@IDCLIENTE", MySqlDbType.Int32).Value = 64;//idCliente.Id;
                    comando.Parameters.Add("@DATA_VENDA", MySqlDbType.DateTime).Value = data_Venda;
                    comando.Parameters.Add("@VALOR_VENDA", MySqlDbType.Decimal).Value = valor_venda;
                    comando.Parameters.Add("@DETALHE_VENDA", MySqlDbType.VarChar).Value = detalhe_venda;
                    comando.Parameters.Add("@VALOR_PAGO", MySqlDbType.Decimal).Value = valor_pago;
                    comando.Parameters.Add("@DETALHES_PAGAMENTO", MySqlDbType.VarChar).Value = detalhe_pagamento;
                    comando.Parameters.Add("@TIPO", MySqlDbType.Int32).Value = tipo;
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

        public Vendas Unitario(int id)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_vendas WHERE ID=" + id;
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
                return new Vendas()
                {

                    Id = int.Parse(dr["Id"].ToString()),
                    idCliente = new Clientes().Unitario(int.Parse(dr["idCliente"].ToString())),
                    data_Venda = DateTime.Parse(dr["data_Venda"].ToString()),
                    valor_venda = decimal.Parse(dr["valor_venda"].ToString()),
                    detalhe_venda = dr["detalhe_venda"].ToString(),
                    valor_pago = decimal.Parse(dr["valor_pago"].ToString()),
                    detalhe_pagamento = dr["detalhes_pagamento"].ToString(), 
                    tipo=int.Parse(dr["tipo"].ToString())

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
                stringsql = "DELETE FROM tbl_vendas WHERE id=" + Id;
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
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
