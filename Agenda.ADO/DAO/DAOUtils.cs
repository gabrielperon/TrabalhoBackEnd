using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AgendaADONet.DAO
{
    class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            DbConnection conexao = new SqlConnection(@"Server=.\SQLEXPRESS;Initial Catalog=TreinaWebCsharpIntermediario;Trusted_Connection=True");
            conexao.Open();
            return conexao;
        }

        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }

        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
    }
}
