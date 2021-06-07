using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_INFLACAO
    {
        private int _IdInflacao;

        public int IdInflacao
        {
            get { return _IdInflacao; }
            set { _IdInflacao = value; }
        }

        private string _NomeInflacao;

        public string NomeInflacao
        {
            get { return _NomeInflacao; }
            set { _NomeInflacao = value; }
        }

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_INFLACAO()
        {
        }

        public D_INFLACAO(int idInflacao, string nomeInflacao,  string textobuscar)
        {
            this.IdInflacao = idInflacao;
            this.NomeInflacao = nomeInflacao;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_INFLACAO INFLACAO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_Inflacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Inflacao =  new SqlParameter();
                ParId_Inflacao.ParameterName = "@ID_Inflacao";
                ParId_Inflacao.SqlDbType = SqlDbType.Int;
                ParId_Inflacao.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Inflacao);

                SqlParameter ParNome_Inflacao = new SqlParameter();
                ParNome_Inflacao.ParameterName = "@NOME_Inflacao";
                ParNome_Inflacao.SqlDbType = SqlDbType.VarChar;
                ParNome_Inflacao.Size = 50;
                ParNome_Inflacao.Value = INFLACAO.NomeInflacao;
                SqlCmd.Parameters.Add(ParNome_Inflacao);



                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Cadastrado";


            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;

        }

        // Metodo Editar

        public string Editar(D_INFLACAO inflacao)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_Inflacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Inflacao = new SqlParameter();
                ParId_Inflacao.ParameterName = "@ID_Inflacao";
                ParId_Inflacao.SqlDbType = SqlDbType.VarChar;
                ParId_Inflacao.Size = 50;
                ParId_Inflacao.Value = inflacao.IdInflacao;
                SqlCmd.Parameters.Add(ParId_Inflacao);

                SqlParameter ParNome_Inflacao = new SqlParameter();
                ParNome_Inflacao.ParameterName = "@NOME_CLIENTE";
                ParNome_Inflacao.SqlDbType = SqlDbType.VarChar;
                ParNome_Inflacao.Size = 50;
                ParNome_Inflacao.Value = inflacao.NomeInflacao;
                SqlCmd.Parameters.Add(ParNome_Inflacao);

              

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Actualizado";


            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Metodo Eliminar
        public string Eliminar(D_INFLACAO  Inflacao)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_Inflacao]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Inflacao = new SqlParameter();
                ParId_Inflacao.ParameterName = "@ID_Inflacao";
                ParId_Inflacao.SqlDbType = SqlDbType.Int;
                ParId_Inflacao.Value = Inflacao.IdInflacao;
                SqlCmd.Parameters.Add(ParId_Inflacao);
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : " Registo não Eliminado";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spmostrar_Inflacao]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_INFLACAO INFLACAO)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Ver_Dados_pela_Inflacao";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = INFLACAO.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }
    }
}
