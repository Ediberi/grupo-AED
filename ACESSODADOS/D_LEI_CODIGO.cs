using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_LEI_CODIGO
    {
        private int _Id_LEI_CODIGO;

        public int Id_LEI_CODIGO
        {
            get { return _Id_LEI_CODIGO; }
            set { _Id_LEI_CODIGO = value; }
        }

        private string _NomeLei_codigo;

        public string NomeLei_codigo
        {
            get { return NomeLei_codigo; }
            set { NomeLei_codigo = value; }
        }

        private int _IdARTIGO;

        public int IdARTIGO
        {
            get { return _IdARTIGO; }
            set { _IdARTIGO = value; }
        }

        private int _IdSancoes;

        public int IdSancoes
        {
            get { return _IdSancoes; }
            set { _IdSancoes = value; }
        }

        private int _Id_TIPO_LEI_CODIGO;

        public int Id_TIPO_LEI_CODIGO
        {
            get { return _Id_TIPO_LEI_CODIGO; }
            set { _Id_TIPO_LEI_CODIGO = value; }
        }

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_LEI_CODIGO()
        {
        }

        public D_LEI_CODIGO(int IdLei_codigo, string nomeLEI_CODIGO, int Id_ARTIGO, int IdSancoes, int Id_TIPO_LEI_CODIGO, string textobuscar)
        {
            this.Id_LEI_CODIGO = IdLei_codigo;
            this.NomeLei_codigo = NomeLei_codigo;
            this.IdARTIGO = Id_ARTIGO;
            this.IdSancoes = IdSancoes;
            this.Id_TIPO_LEI_CODIGO = Id_TIPO_LEI_CODIGO;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_LEI_CODIGO LEI_CODIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_Lei_Codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Lei_Codigo = new SqlParameter();
                ParId_Lei_Codigo.ParameterName = "@ID_Lei_Codigo";
                ParId_Lei_Codigo.SqlDbType = SqlDbType.Int;
                ParId_Lei_Codigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Lei_Codigo);

                SqlParameter ParNome_lei_Codigo = new SqlParameter();
                ParNome_lei_Codigo.ParameterName = "@NOME_Lei_Codigo";
                ParNome_lei_Codigo.SqlDbType = SqlDbType.VarChar;
                ParNome_lei_Codigo.Size = 50;
                ParNome_lei_Codigo.Value = LEI_CODIGO.NomeLei_codigo;
                SqlCmd.Parameters.Add(ParNome_lei_Codigo);

                SqlParameter ParIdARTIGO = new SqlParameter();
                ParIdARTIGO.ParameterName = "@IdARTIGO";
                ParIdARTIGO.SqlDbType = SqlDbType.VarChar;
                ParIdARTIGO.Size = 50;
                ParIdARTIGO.Value = LEI_CODIGO._IdARTIGO;
                SqlCmd.Parameters.Add(ParIdARTIGO);


                SqlParameter ParIdSancoes = new SqlParameter();
                ParIdSancoes.ParameterName = "@IdSancoes";
                ParIdSancoes.SqlDbType = SqlDbType.VarChar;
                ParIdSancoes.Size = 50;
                ParIdSancoes.Value = LEI_CODIGO._IdSancoes;
                SqlCmd.Parameters.Add(ParIdSancoes);

                SqlParameter ParIdTio_Lei_Codigo = new SqlParameter();
                ParIdTio_Lei_Codigo.ParameterName = "@IdTIPO_Lei_Codigo";
                ParIdTio_Lei_Codigo.SqlDbType = SqlDbType.VarChar;
                ParIdTio_Lei_Codigo.Size = 50;
                ParIdTio_Lei_Codigo.Value = LEI_CODIGO.Id_TIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParIdTio_Lei_Codigo);




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

        public string Editar(D_LEI_CODIGO Lei_Codigo)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_Lei_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Lei_Codigo= new SqlParameter();
                ParId_Lei_Codigo.ParameterName = "@ID_Lei_Codigo";
                ParId_Lei_Codigo.SqlDbType = SqlDbType.VarChar;
                ParId_Lei_Codigo.Size = 50;
                ParId_Lei_Codigo.Value = Lei_Codigo.Id_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParId_Lei_Codigo);

                SqlParameter ParNome_Lei_Codigo = new SqlParameter();
                ParNome_Lei_Codigo.ParameterName = "@NOME_Lei_Codigo";
                ParNome_Lei_Codigo.SqlDbType = SqlDbType.VarChar;
                ParNome_Lei_Codigo.Size = 50;
                ParNome_Lei_Codigo.Value = Lei_Codigo.NomeLei_codigo;
                SqlCmd.Parameters.Add(ParNome_Lei_Codigo);

                SqlParameter ParIdARTIGO = new SqlParameter();
                ParIdARTIGO.ParameterName = "@Id_ARTIGO";
                ParIdARTIGO.SqlDbType = SqlDbType.VarChar;
                ParIdARTIGO.Size = 50;
                ParIdARTIGO.Value = Lei_Codigo.IdARTIGO;
                SqlCmd.Parameters.Add(ParIdARTIGO);


                SqlParameter ParIdSancoes = new SqlParameter();
                ParIdSancoes.ParameterName = "@IdSancoes";
                ParIdSancoes.SqlDbType = SqlDbType.VarChar;
                ParIdSancoes.Size = 50;
                ParIdSancoes.Value = Lei_Codigo.IdSancoes;
                SqlCmd.Parameters.Add(ParIdSancoes);

                SqlParameter ParIdTipo_Lei_Codigo = new SqlParameter();
                ParIdTipo_Lei_Codigo.ParameterName = "@Id_Tipo_Lei_Codigo";
                ParIdTipo_Lei_Codigo.SqlDbType = SqlDbType.VarChar;
                ParIdTipo_Lei_Codigo.Size = 50;
                ParIdTipo_Lei_Codigo.Value = Lei_Codigo.Id_TIPO_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParIdTipo_Lei_Codigo);

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
        public string Eliminar(D_LEI_CODIGO LEI_CODIGO )
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_Lei_Codigo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Lei_Codigo = new SqlParameter();
                ParId_Lei_Codigo.ParameterName = "@ID_Lei_Codigo";
                ParId_Lei_Codigo.SqlDbType = SqlDbType.Int;
                ParId_Lei_Codigo.Value = LEI_CODIGO.Id_LEI_CODIGO;
                SqlCmd.Parameters.Add(ParId_Lei_Codigo);
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
                SqlCmd.CommandText = "[spmostrar_Lei_Codigo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_LEI_CODIGO LEI_CODIGO)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_Lei_Codigo]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = LEI_CODIGO.TextoBuscar;
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
