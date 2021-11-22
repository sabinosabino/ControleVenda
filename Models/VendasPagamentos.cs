using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using LibConnection;
using MySql.Data.MySqlClient;

namespace ControleFinanc.Models
{
    public class VendasPagamentos
    {
        public Clientes idCliente { get; set; }
        public decimal valor_venda { get; set; }
        public decimal valor_pago { get; set; }
        public decimal diferenca { get; set; }
        Conexao cn;
        public List<VendasPagamentos> Lista()
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from vendas_pagamentos";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<VendasPagamentos> vendas_ = new List<VendasPagamentos>();
                foreach (DataRow dr in table.Rows)
                {

                    vendas_.Add(new VendasPagamentos
                    {
                        idCliente = new Clientes().Unitario(int.Parse(dr["idCliente"].ToString())),
                        valor_venda = decimal.Parse(dr["SomaVenda"].ToString()),
                        valor_pago = decimal.Parse(dr["somaPag"].ToString()),
                        diferenca = decimal.Parse(dr["diferenca"].ToString()), 
                    });
                }

                return vendas_;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

    }
}
