using Factory.Cap1;
using System.Data;

IDbConnection conexao = new ConnectionFactory().GetConnection();

IDbCommand comando = conexao.CreateCommand();
comando.CommandText = "select * from tabela";