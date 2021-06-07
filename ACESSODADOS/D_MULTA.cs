using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACESSODADOS
{
    public class D_MULTA
    {
        private int _Id_MULTA;

        public int Id_MULTA
        {
            get { return _Id_MULTA; }
            set { _Id_MULTA = value; }
        }

        private string _NomeMULTA;

        public string NomeMULTA
        {
            get { return _NomeMULTA; }
            set { _NomeMULTA = value; }
        }

        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        // Construtores

        public D_MULTA()
        {
        }

        public D_MULTA(int idMulta, string nomeMulta, string textobuscar)
        {
            this.Id_MULTA = idMulta;
            this.NomeMULTA = nomeMulta;
            this.TextoBuscar = textobuscar;
        }

        // Metodo Inserir
        public string Inserir(D_MULTA MULTA)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_Inserir_MULTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_MULTA = new SqlParameter();
                ParId_MULTA.ParameterName = "@ID_MULTA";
                ParId_MULTA.SqlDbType = SqlDbType.Int;
                ParId_MULTA.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_MULTA);

                SqlParameter ParNome_MULTA = new SqlParameter();
                ParNome_MULTA.ParameterName = "@NOME_MULTA";
                ParNome_MULTA.SqlDbType = SqlDbType.VarChar;
                ParNome_MULTA.Size = 50;
                ParNome_MULTA.Value = MULTA.NomeMULTA;
                SqlCmd.Parameters.Add(ParNome_MULTA);

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

        public string Editar(D_MULTA MULTA)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_MULTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_MULTA = new SqlParameter();
                ParId_MULTA.ParameterName = "@ID_MULTA";
                ParId_MULTA.SqlDbType = SqlDbType.VarChar;
                ParId_MULTA.Size = 50;
                ParId_MULTA.Value = MULTA.Id_MULTA;
                SqlCmd.Parameters.Add(ParId_MULTA);

                SqlParameter ParNome_MULTA = new SqlParameter();
                ParNome_MULTA.ParameterName = "@NOME_MULTA";
                ParNome_MULTA.SqlDbType = SqlDbType.VarChar;
                ParNome_MULTA.Size = 50;
                ParNome_MULTA.Value = MULTA.Id_MULTA;
                SqlCmd.Parameters.Add(ParNome_MULTA);

             
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
        public string Eliminar(D_MULTA MULTA)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[speliminar_MULTA]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId_MULTA = new SqlParameter();
                ParId_MULTA.ParameterName = "@ID_MULTA";
                ParId_MULTA.SqlDbType = SqlDbType.Int;
                ParId_MULTA.Value = MULTA.Id_MULTA;
                SqlCmd.Parameters.Add(ParId_MULTA);
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
                SqlCmd.CommandText = "[spmostrar_MULTA]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }

            catch (Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarCliente(D_MULTA MULTA)
        {
            DataTable DtResultado = new DataTable("Cliente - Empresa");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = CONEXAO.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[spbuscar_nome_MULTA]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = MULTA.TextoBuscar;
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
