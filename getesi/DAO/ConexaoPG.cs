/*
 * Classe utilizada para realizar a conexão com o Banco de dados. Possui os métodos para setar valores, 
 * inicializar e apagar instância, consultar DataSet e consultarna tabela, possui um método de persistência 
 * de conexão e um para testar a conexão. Essa classe deve receber os parâmetros da classe DAO.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Windows.Forms;

namespace getesi.DAO
{
    class ConexaoPG
    {
        //Cria o objeto de conexão
        private OdbcConnection objConexao;

        //Cria o adaptador para realizar a iteração com o DataSet
        private OdbcDataAdapter objAdapter;

        //Declaração das variáveis necessárias
        private DataSet objDataSet;
        private static ConexaoPG instancia;

        protected static String strServidor;
        protected static String strBanco;
        protected static String strUsuario;
        protected static String strSenha;
        protected static String strConexao;
        protected static String strDriver;
        protected static String strPort;

        private String strErro;

        //Método getErro
        public String getErro()
        {
            return strErro;
        }

        //Retorna sempre a mesma instancia de Conexao.
        public static ConexaoPG getInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConexaoPG();
            }
            return instancia;
        }

        //Metodo setUsuario
        public void setUsuario(String s)
        {
            strUsuario = s;
        }

        //Metodo setSenha
        public void setSenha(String s)
        {
            strSenha = s;
        }

        //Metodo setBanco
        public void setBanco(String s)
        {
            strBanco = s;
        }

        //Metodo setServidor
        public void setServidor(String s)
        {
            strServidor = s;
        }

        //Método setDriver
        public void setDriver(String s)
        {
            strDriver = s;
        }

        //Método setPort
        public void setPort(String s)
        {
            strPort = s;
        }

        //Construtor da Classe
        public ConexaoPG()
        {
            objDataSet = new DataSet();

            //buscando dados do registro
            //Registro objRegistro = new Registro();
            String usuario = "postgres";//objRegistro.getValor("Usuario");
            String senha = "1";//objRegistro.getValor("Senha");
            String servidor = "localhost";// objRegistro.getValor("Servidor");
            String banco = "gts"; //objRegistro.getValor("Banco");
            String driver = "PostgreSQL30";
            String port = "5432";

            setServidor(servidor);
            setBanco(banco);
            setSenha(senha);
            setUsuario(usuario);
            setDriver(driver);
            setPort(port);

            strConexao = "Dsn=" + strDriver + "; server=" + strServidor + "; port=" + strPort + "; database=" + strBanco + "; uid=" + strUsuario + "; pwd=" + strSenha + ";";

            //CRIAR A CONEXAO COM O BD
            try
            {
                objConexao = new OdbcConnection(strConexao);
            }
            catch (Exception ex)
            {
                strErro = ex.Message;
                throw new Exception("Erro ao conectar!!");
            }
        }

        //Método Persistir
        public bool persistir(String sql)
        {
            try
            {
                //abre a conexao
                objConexao.Open();

                if (objConexao.State == ConnectionState.Open)
                {
                    //Cria um adapter usando a instruçao SQL 
                    objAdapter = new OdbcDataAdapter(sql, objConexao);

                    //Preenche o dataset via adapter para um alias "dados"
                    objAdapter.Fill(objDataSet, "dados");
                    objConexao.Close();
                }
                return true;
            }
            catch (System.Exception e)
            {
                strErro = e.Message.ToString();
                objConexao.Close();
                throw new Exception("Erro na persistencia: " + e.Message);
            }
        }

        //Método Consultar (retorna um DataTable)
        public DataTable consultar(String sql)
        {
            DataTable objDataTable = new DataTable();
            try
            {
                //Abre a conexao
                objConexao.Open();

                if (objConexao.State == ConnectionState.Open)
                {
                    //Cria um adapter usando a instruçao SQL 
                    objAdapter = new OdbcDataAdapter(sql, objConexao);
                    objDataTable.Clear();
                    objAdapter.Fill(objDataTable);
                    objConexao.Close();
                }
                return objDataTable;
            }
            catch (System.Exception e)
            {
                strErro = e.Message.ToString();
                objConexao.Close();
                throw new Exception("Erro na consulta:" + e.Message);
            }
        }

        //Método apagar instância 
        public void apagarInstancia()
        {
            instancia = null;
        }

        //Método consulta DataSet
        public DataSet consultarDS(String sql)
        {
            try
            {
                //Abre a conexao
                objConexao.Open();

                if (objConexao.State == ConnectionState.Open)
                {
                    //Cria um adapter usando a instruçao SQL 
                    objAdapter = new OdbcDataAdapter(sql, objConexao);

                    //Preenche o dataset via adapter
                    objDataSet.Clear();
                    objAdapter.Fill(objDataSet, "dados");
                    objConexao.Close();
                }
                return objDataSet;
            }
            catch (System.Exception e)
            {
                strErro = e.Message.ToString();
                objConexao.Close();
                return null;
            }
        }

        //Método Testa conexão
        public bool testaConexao()
        {
            try
            {
                objConexao = new OdbcConnection(strConexao);
                objConexao.Open();
                objConexao.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}