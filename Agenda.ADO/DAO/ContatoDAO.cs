using AgendaADONet.Classes;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AgendaADONet.DAO
{
    public class ContatoDAO
    {
        public DataTable GetContatos()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CONTATOS";

            DbDataReader reader = DAOUtils.GetDataReader(comando);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;

            //DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)comando);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "CONTATOS");
            //return ds;
        }

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.ExecuteNonQuery();
        }


        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS (NOME, EMAIL, TELEFONE) VALUES (@nome, @email, @telefone)";
            comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            comando.Parameters.Add(new SqlParameter("@email", contato.Email));
            comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
            comando.ExecuteNonQuery();

        }

        public void Atualizar(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE CONTATOS SET NOME = @nome, EMAIL = @email, TELEFONE = @telefone WHERE ID = @id";
            comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            comando.Parameters.Add(new SqlParameter("@email", contato.Email));
            comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
            comando.Parameters.Add(new SqlParameter("@id", contato.Id));
            comando.ExecuteNonQuery();
        }

        public DataTable GetContato(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CONTATOS WHERE ID = @id";
            comando.Parameters.Add(new SqlParameter("@id", id));

            DbDataReader reader = DAOUtils.GetDataReader(comando);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;

            
        }
    }
}
