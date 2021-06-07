using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_TIPO_SANCOES
    {
        private int _IdTIPO_SANCOES;

        public int IdTIPO_SANCOES
        {
            get { return _IdTIPO_SANCOES; }
            set { _IdTIPO_SANCOES = value; }
        }

        private string _NomeTIPO_SANCOES;

        public string NomeTIPO_SANCOES
        {
            get { return _NomeTIPO_SANCOES; }
            set { _NomeTIPO_SANCOES = value; }
        }

        private int _ID_MULTA;

        public int ID_MULTA
        {
            get { return _ID_MULTA; }
            set { _ID_MULTA = value; }
        }

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_TIPO_SANCOES()
        {
        }

        public D_TIPO_SANCOES(int idTIPO_SANCOES, string nomeTIPO_SANCOES, int ID_MULTA, string textobuscar)
        {
            this.IdTIPO_SANCOES = idTIPO_SANCOES;
            this.NomeTIPO_SANCOES = nomeTIPO_SANCOES;
            this.ID_MULTA = _ID_MULTA;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_TIPO_SANCOES TIPO_SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_TIPO_SANCOES";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_SANCOES = new SqlParameter();
                ParId_TIPO_SANCOES.ParameterName = "@ID_TIPO_SANCOES";
                ParId_TIPO_SANCOES.SqlDbType = SqlDbType.Int;
                ParId_TIPO_SANCOES.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_TIPO_SANCOES);

                SqlParameter ParNome_TIPO_SANCOES = new SqlParameter();
                ParNome_TIPO_SANCOES.ParameterName = "@NOME_TIPO_SANCOES";
                ParNome_TIPO_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParNome_TIPO_SANCOES.Size = 50;
                ParNome_TIPO_SANCOES.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParNome_TIPO_SANCOES);

                SqlParameter ParID_MULTA = new SqlParameter();
                ParID_MULTA.ParameterName = "@ID_MULTA";
                ParID_MULTA.SqlDbType = SqlDbType.VarChar;
                ParID_MULTA.Size = 50;
                ParID_MULTA.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParID_MULTA);




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

        public string Editar(D_TIPO_SANCOES TIPO_SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_TIPO_SANCOES";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_SANCOES = new SqlParameter();
                ParId_TIPO_SANCOES.ParameterName = "@ID_TIPO_SANCOES";
                ParId_TIPO_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParId_TIPO_SANCOES.Size = 50;
                ParId_TIPO_SANCOES.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParId_TIPO_SANCOES);

                SqlParameter ParNome_TIPO_SANCOES = new SqlParameter();
                ParNome_TIPO_SANCOES.ParameterName = "@NOME_TIPO_SANCOES";
                ParNome_TIPO_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParNome_TIPO_SANCOES.Size = 50;
                ParNome_TIPO_SANCOES.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParNome_TIPO_SANCOES);

                SqlParameter ParID_MULTA = new SqlParameter();
                ParID_MULTA.ParameterName = "@ID_MULTA";
                ParID_MULTA.SqlDbType = SqlDbType.VarChar;
                ParID_MULTA.Size = 50;
                ParID_MULTA.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParID_MULTA);


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
        public string Eliminar(D_TIPO_SANCOES TIPO_SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_TIPO_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_SANCOES = new SqlParameter();
                ParId_TIPO_SANCOES.ParameterName = "@ID_TIPO_SANCOES";
                ParId_TIPO_SANCOES.SqlDbType = SqlDbType.Int;
                ParId_TIPO_SANCOES.Value = TIPO_SANCOES.IdTIPO_SANCOES;
                SqlCmd.Parameters.Add(ParId_TIPO_SANCOES);
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
                SqlCmd.CommandText = "[spmostrar_TIPO_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_TIPO_SANCOES TIPO_SANCOES)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_TIPO_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TIPO_SANCOES.TextoBuscar;
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
