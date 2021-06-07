using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_ARTIGO
    {
        private int _IdArtigo;

        public int IdArtigo
        {
            get { return _IdArtigo; }
            set { _IdArtigo = value; }
        }

        private string _NomeArtigo;

        public string NomeArtigo
        {
            get { return _NomeArtigo; }
            set { _NomeArtigo = value; }
        }

        private int _id_inflacao;
        public int id_inflacao
        {
            get { return _id_inflacao; }
            set { _id_inflacao = value; }
        }
        

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_ARTIGO()
        {
        }

        public D_ARTIGO(int idArtigo, string nomeArtigo, int id_inflacao, string textobuscar)
        {
            this.IdArtigo = idArtigo;
            this.NomeArtigo = nomeArtigo;
            this.id_inflacao = id_inflacao;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_ARTIGO ARTIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_Artigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Artigo = new SqlParameter();
                ParId_Artigo.ParameterName = "@ID_ARTIGO";
                ParId_Artigo.SqlDbType = SqlDbType.Int;
                ParId_Artigo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Artigo);

                SqlParameter ParNome_Artigo = new SqlParameter();
                ParNome_Artigo.ParameterName = "@NOME_ARTIGO";
                ParNome_Artigo.SqlDbType = SqlDbType.VarChar;
                ParNome_Artigo.Size = 50;
                ParNome_Artigo.Value = ARTIGO.NomeArtigo;
                SqlCmd.Parameters.Add(ParNome_Artigo);

                SqlParameter ParINFLACAO = new SqlParameter();
                ParINFLACAO.ParameterName = "@ID_INFLACAO";
                ParINFLACAO.SqlDbType = SqlDbType.VarChar;
                ParINFLACAO.Size = 50;
                ParINFLACAO.Value = ARTIGO.id_inflacao;
                SqlCmd.Parameters.Add(ParINFLACAO);



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

        public string Editar(D_ARTIGO ARTIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_ARTIGO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Artigo = new SqlParameter();
                ParId_Artigo.ParameterName = "@ID_ARTIGO";
                ParId_Artigo.SqlDbType = SqlDbType.VarChar;
                ParId_Artigo.Size = 50;
                ParId_Artigo.Value = ARTIGO.IdArtigo;
                SqlCmd.Parameters.Add(ParId_Artigo);


                SqlParameter ParNome_Artigo = new SqlParameter();
                ParNome_Artigo.ParameterName = "@NOME_ARTIGO";
                ParNome_Artigo.SqlDbType = SqlDbType.VarChar;
                ParNome_Artigo.Size = 50;
                ParNome_Artigo.Value = ARTIGO.NomeArtigo;
                SqlCmd.Parameters.Add(ParNome_Artigo);

                SqlParameter ParINFLACAO = new SqlParameter();
                ParINFLACAO.ParameterName = "@ID_INFLACAO";
                ParINFLACAO.SqlDbType = SqlDbType.VarChar;
                ParINFLACAO.Size = 50;
                ParINFLACAO.Value = ARTIGO.id_inflacao;
                SqlCmd.Parameters.Add(ParINFLACAO);


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
        public string Eliminar(D_ARTIGO ARTIGO)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_ARTIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_Artigo = new SqlParameter();
                ParId_Artigo.ParameterName = "@ID_ARTIGO";
                ParId_Artigo.SqlDbType = SqlDbType.VarChar;
                ParId_Artigo.Size = 50;
                ParId_Artigo.Value = ARTIGO.IdArtigo;
                SqlCmd.Parameters.Add(ParId_Artigo);
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
                SqlCmd.CommandText = "[spmostrar_ARTIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarArtigo(D_ARTIGO ARTIGO)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_ARTIGO]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = ARTIGO.TextoBuscar;
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
