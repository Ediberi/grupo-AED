using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_SANCOES
    {
        private int _IdSANCOES;

        public int IdSANCOES
        {
            get { return _IdSANCOES; }
            set { _IdSANCOES = value; }
        }

        private string _NomeSANCOES;

        public string NomeSANCOES
        {
            get { return _NomeSANCOES; }
            set { _NomeSANCOES = value; }
        }

        private int _ID_TIPO_LEI_CODIGO;
       
        public int ID_TIPO_LEI_CODIGO
        {
            get { return _ID_TIPO_LEI_CODIGO; }
            set { _ID_TIPO_LEI_CODIGO = value; }
        }

        private int _ID_TIPO_SANCOES;

        public int ID_TIPO_SANCOES
        {
            get { return _ID_TIPO_SANCOES; }
            set { _ID_TIPO_SANCOES = value; }
        }

       
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_SANCOES()
        {
        }

        public D_SANCOES(int idSANCOES, string nomeSANCOES, int ID_TIPO_LEI_CODIGO, int ID_TIPO_SANCOES, string textobuscar)
        {
            this.IdSANCOES = idSANCOES;
            this.NomeSANCOES = nomeSANCOES;
            this.ID_TIPO_LEI_CODIGO = ID_TIPO_LEI_CODIGO;
            this.ID_TIPO_SANCOES = _ID_TIPO_SANCOES;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_SANCOES SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_SANCOES";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_SANCOES = new SqlParameter();
                ParId_SANCOES.ParameterName = "@ID_SANCOES";
                ParId_SANCOES.SqlDbType = SqlDbType.Int;
                ParId_SANCOES.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_SANCOES);

                SqlParameter ParNome_SANCOES = new SqlParameter();
                ParNome_SANCOES.ParameterName = "@NOME_SANCOES";
                ParNome_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParNome_SANCOES.Size = 50;
                ParNome_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParNome_SANCOES);

                SqlParameter ParID_TIPO_LEI_CODIGO = new SqlParameter();
                ParID_TIPO_LEI_CODIGO.ParameterName = "@ID_TIPO_LEI_CODIGO";
                ParID_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.VarChar;
                ParID_TIPO_LEI_CODIGO.Size = 50;
                ParID_TIPO_LEI_CODIGO.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParID_TIPO_LEI_CODIGO);


                SqlParameter ParID_TIPO_SANCOES = new SqlParameter();
                ParID_TIPO_SANCOES.ParameterName = "@ID_TIPO_SANCOES";
                ParID_TIPO_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParID_TIPO_SANCOES.Size = 50;
                ParID_TIPO_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParID_TIPO_SANCOES);
                

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

        public string Editar(D_SANCOES SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_SANCOES";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_SANCOES = new SqlParameter();
                ParId_SANCOES.ParameterName = "@ID_SANCOES";
                ParId_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParId_SANCOES.Size = 50;
                ParId_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParId_SANCOES);

                SqlParameter ParNome_SANCOES = new SqlParameter();
                ParNome_SANCOES.ParameterName = "@NOME_SANCOES";
                ParNome_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParNome_SANCOES.Size = 50;
                ParNome_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParNome_SANCOES);

                SqlParameter ParID_TIPO_LEI_CODIGO = new SqlParameter();
                ParID_TIPO_LEI_CODIGO.ParameterName = "@ID_TIPO_LEI_CODIGO";
                ParID_TIPO_LEI_CODIGO.SqlDbType = SqlDbType.VarChar;
                ParID_TIPO_LEI_CODIGO.Size = 50;
                ParID_TIPO_LEI_CODIGO.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParID_TIPO_LEI_CODIGO);


                SqlParameter ParID_TIPO_SANCOES = new SqlParameter();
                ParID_TIPO_SANCOES.ParameterName = "@ID_TIPO_SANCOES";
                ParID_TIPO_SANCOES.SqlDbType = SqlDbType.VarChar;
                ParID_TIPO_SANCOES.Size = 50;
                ParID_TIPO_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParID_TIPO_SANCOES);

               
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
        public string Eliminar(D_SANCOES SANCOES)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_SANCOES = new SqlParameter();
                ParId_SANCOES.ParameterName = "@ID_SANCOES";
                ParId_SANCOES.SqlDbType = SqlDbType.Int;
                ParId_SANCOES.Value = SANCOES.IdSANCOES;
                SqlCmd.Parameters.Add(ParId_SANCOES);
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
                SqlCmd.CommandText = "[spmostrar_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_SANCOES SANCOES)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_SANCOES]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = SANCOES.TextoBuscar;
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
