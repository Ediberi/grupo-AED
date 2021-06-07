using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_TIPO_LEI_CODIGO
    {
        private int _IdTIPO_LEI_CODIGO;

        public int IdTIPO_LEI_CODIGO
        {
            get { return _IdTIPO_LEI_CODIGO; }
            set { _IdTIPO_LEI_CODIGO = value; }
        }

        private string _NomeTIPO_LEI_CODIGO;

        public string NomeTIPO_LEI_CODIGO
        {
            get { return _NomeTIPO_LEI_CODIGO; }
            set { _NomeTIPO_LEI_CODIGO = value; }
        }

       
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_TIPO_LEI_CODIGO()
        {
        }

        public D_TIPO_LEI_CODIGO(int idTIPO_LEI_CODIGO, string nomeTIPO_LEI_CODIGO, string textobuscar)
        {
            this.IdTIPO_LEI_CODIGO = idTIPO_LEI_CODIGO;
            this.NomeTIPO_LEI_CODIGO = nomeTIPO_LEI_CODIGO;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_TIPO_LEI_CODIGO TIPO_LEI_CODIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_TIPO_LEI_CODIGO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_LEI_CODIGO = new SqlParameter();
                ParId_TIPO_LEI_CODIGO.ParameterName = "@ID_TIPO_LEI_CODIGO";
                ParId_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.Int;
                ParId_TIPO_LEI_CODIGO.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_TIPO_LEI_CODIGO);

                SqlParameter ParNome_TIPO_LEI_CODIGO = new SqlParameter();
                ParNome_TIPO_LEI_CODIGO.ParameterName = "@NOME_TIPO_LEI_CODIGO";
                ParNome_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.VarChar;
                ParNome_TIPO_LEI_CODIGO.Size = 50;
                ParNome_TIPO_LEI_CODIGO.Value = TIPO_LEI_CODIGO.NomeTIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParNome_TIPO_LEI_CODIGO);

               
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

        public string Editar(D_TIPO_LEI_CODIGO TIPO_LEI_CODIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_TIPO_LEI_CODIGO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_LEI_CODIGO = new SqlParameter();
                ParId_TIPO_LEI_CODIGO.ParameterName = "@ID_TIPO_LEI_CODIGO";
                ParId_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.VarChar;
                ParId_TIPO_LEI_CODIGO.Size = 50;
                ParId_TIPO_LEI_CODIGO.Value = TIPO_LEI_CODIGO.IdTIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParId_TIPO_LEI_CODIGO);

                SqlParameter ParNome_TIPO_LEI_CODIGO = new SqlParameter();
                ParNome_TIPO_LEI_CODIGO.ParameterName = "@NOME_TIPO_LEI_CODIGO";
                ParNome_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.VarChar;
                ParNome_TIPO_LEI_CODIGO.Size = 50;
                ParNome_TIPO_LEI_CODIGO.Value = TIPO_LEI_CODIGO.IdTIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParNome_TIPO_LEI_CODIGO);


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
        public string Eliminar(D_TIPO_LEI_CODIGO TIPO_LEI_CODIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_TIPO_LEI_CODIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_TIPO_LEI_CODIGO = new SqlParameter();
                ParId_TIPO_LEI_CODIGO.ParameterName = "@ID_TIPO_LEI_CODIGO";
                ParId_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.Int;
                ParId_TIPO_LEI_CODIGO.Value = TIPO_LEI_CODIGO.IdTIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParId_TIPO_LEI_CODIGO);
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
                SqlCmd.CommandText = "[spmostrar_TIPO_LEI_CODIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_TIPO_LEI_CODIGO TIPO_LEI_CODIGO)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_TIPO_LEI_CODIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TIPO_LEI_CODIGO.TextoBuscar;
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
