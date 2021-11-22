using LibConnection;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanc.Models
{
    public class Login
    {
        //CLASSE BASICA PARA MODELO
        [Required(ErrorMessage = "Campo usuário necessário.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo senha necessário.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool LembrarMe { get; set; }

        Conexao cn;

        public bool Logar()
        {
            try
            {
                cn = new Conexao();

                string queryString = "Select * from TBL_USUARIOS WHERE USUARIO='" + Usuario + "' AND SENHA='" + Senha + "'";
                MySqlCommand command = new MySqlCommand(queryString, cn.cn);
                command.Connection.Open();

                MySqlDataReader dr = command.ExecuteReader();


                //VERIFICA SE TEM LINHAS
                if (dr.HasRows)
                {
                    command.Connection.Close();
                    return true;
                }
                else
                {
                    command.Connection.Close();
                    return false;
                }

                
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }

    }
}