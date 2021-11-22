using MySql.Data.MySqlClient;
using System.Configuration;

namespace LibConnection
{
    public class Conexao
    {
        public MySqlConnection cn = new MySqlConnection(ConfigurationManager.AppSettings["stringConnection"]);
    
        public void Open()
        {
            if (cn.State!=System.Data.ConnectionState.Open)
            {
                cn.Open();
            }

        }
        public void Close()
        {
            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }
        }

    }


}
