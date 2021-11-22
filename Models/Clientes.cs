using LibConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleFinanc.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Apelido { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Telefone_1 { get; set; }
        public string Telefone_2 { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf_cnpj { get; set; }
        public string SspLocal { get; set; }


        Conexao cn;
        public List<Clientes> Lista(string textoSql)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_Clientes WHERE Nome LIKE '%" + textoSql + "%' ORDER BY Nome LIMIT 30";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };
                DataTable table = new DataTable();
                adapter.Fill(table);
                command.Connection.Close();

                List<Clientes> Clientes_ = new List<Clientes>();
                foreach (DataRow dr in table.Rows)
                {

                    Clientes_.Add(new Clientes
                    {

                        Id = int.Parse(dr["Id"].ToString()),
                        Nome = dr["Nome"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Apelido = dr["Apelido"].ToString(),
                        Endereco = dr["Endereco"].ToString(),
                        Bairro = dr["Bairro"].ToString(),
                        Cidade = dr["Cidade"].ToString(),
                        Uf = dr["Uf"].ToString(),
                        Cep = dr["Cep"].ToString(),
                        Telefone_1 = dr["Telefone_1"].ToString(),
                        Telefone_2 = dr["Telefone_2"].ToString(),
                        Email = dr["Email"].ToString(),
                        Rg = dr["Rg"].ToString(),
                        Cpf_cnpj = dr["cpf_cnpj"].ToString(),
                        SspLocal = dr["SspLocal"].ToString()
                    });
                }

                return Clientes_;

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
                    stringsql = "INSERT INTO tbl_Clientes (NOME,TIPO,APELIDO,ENDERECO,BAIRRO,CIDADE,UF,CEP,TELEFONE_1,TELEFONE_2,EMAIL,RG,CPF_CNPJ,SspLocal) " +
                        "VALUES (@NOME,@TIPO,@APELIDO,@ENDERECO,@BAIRRO,@CIDADE,@UF,@CEP,@TELEFONE_1,@TELEFONE_2,@EMAIL,@RG,@CPF_CNPJ,@SspLocal);";

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = Tipo.ToUpper();
                    comando.Parameters.Add("@APELIDO", MySqlDbType.VarChar).Value = Apelido;
                    comando.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = Endereco;
                    comando.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = Bairro;
                    comando.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = Cidade;
                    comando.Parameters.Add("@UF", MySqlDbType.VarChar).Value = Uf;
                    comando.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = Cep;
                    comando.Parameters.Add("@TELEFONE_1", MySqlDbType.VarChar).Value = Telefone_1;
                    comando.Parameters.Add("@TELEFONE_2", MySqlDbType.VarChar).Value = Telefone_2;
                    comando.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = Email;
                    comando.Parameters.Add("@RG", MySqlDbType.VarChar).Value = Rg;
                    comando.Parameters.Add("@CPF_CNPJ", MySqlDbType.VarChar).Value = Cpf_cnpj;
                    comando.Parameters.Add("@SspLocal", MySqlDbType.VarChar).Value = SspLocal; ;
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }
                else
                {

                    stringsql = "UPDATE tbl_Clientes SET NOME=@NOME,TIPO=@TIPO,APELIDO=@APELIDO,ENDERECO=@ENDERECO,BAIRRO=@BAIRRO,CIDADE=@CIDADE,UF=@UF,CEP=@CEP,TELEFONE_1=@TELEFONE_1,TELEFONE_2=@TELEFONE_2,EMAIL=@EMAIL,RG=@RG,CPF_CNPJ=@CPF_CNPJ,SspLocal=@SspLocal WHERE Id=" + Id; ;

                    MySqlCommand comando = new MySqlCommand(stringsql, cn.cn);
                    comando.Connection.Open();
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = stringsql;

                    comando.Parameters.Add("@NOME", MySqlDbType.VarChar).Value = Nome.ToUpper();
                    comando.Parameters.Add("@TIPO", MySqlDbType.VarChar).Value = Tipo;
                    comando.Parameters.Add("@APELIDO", MySqlDbType.VarChar).Value = Apelido.ToUpper();
                    comando.Parameters.Add("@ENDERECO", MySqlDbType.VarChar).Value = Endereco;
                    comando.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = Bairro;
                    comando.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = Cidade;
                    comando.Parameters.Add("@UF", MySqlDbType.VarChar).Value = Uf;
                    comando.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = Cep;
                    comando.Parameters.Add("@TELEFONE_1", MySqlDbType.VarChar).Value = Telefone_1;
                    comando.Parameters.Add("@TELEFONE_2", MySqlDbType.VarChar).Value = Telefone_2;
                    comando.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = Email;
                    comando.Parameters.Add("@RG", MySqlDbType.VarChar).Value = Rg;
                    comando.Parameters.Add("@CPF_CNPJ", MySqlDbType.VarChar).Value = Cpf_cnpj;
                    comando.Parameters.Add("@SspLocal", MySqlDbType.VarChar).Value = SspLocal; ;
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

        public Clientes Unitario(int id)
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from tbl_Clientes WHERE Id=" + id;
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
                return new Clientes()
                {

                    Id = int.Parse(dr["Id"].ToString()),
                    Nome = dr["Nome"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Apelido = dr["Apelido"].ToString(),
                    Endereco = dr["Endereco"].ToString(),
                    Bairro = dr["Bairro"].ToString(),
                    Cidade = dr["Cidade"].ToString(),
                    Uf = dr["Uf"].ToString(),
                    Cep = dr["Cep"].ToString(),
                    Telefone_1 = dr["Telefone_1"].ToString(),
                    Telefone_2 = dr["Telefone_2"].ToString(),
                    Email = dr["Email"].ToString(),
                    Rg = dr["Rg"].ToString(),
                    Cpf_cnpj = dr["cpf_cnpj"].ToString(),
                    SspLocal = dr["SspLocal"].ToString()
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
                stringsql = "DELETE FROM tbl_Clientes WHERE id=" + Id;
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
