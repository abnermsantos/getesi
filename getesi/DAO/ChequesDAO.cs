/*
 * Classe utilizada para conectar o sistema com a tabela cheques do banco de dados.
 * Possui os métodos "get" e "set" para as suas variáveis, preencheCampos(), 
 * inserir(), excluir(), atualizar(), listarTodos().
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class ChequesDAO
    {
        private int numCheque;
        private double valor;
        private DateTime data;
        private string finalidade;

        public void setNumCheque(int numCheque)
        {
            this.numCheque = numCheque;
        }
        public int getNumCheque()
        {
            return numCheque;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }
        public double getValor()
        {
            return valor;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }
        public DateTime getData()
        {
            return data;
        }

        public void setFinalidade(string finalidade)
        {
            this.finalidade = finalidade;
        }
        public string getFinalidade()
        {
            return finalidade;
        }

//Método listarTodos()
        public DataTable listarTodos()
        {
            string sql = "Select numCheque, data, valor, finalidade from cheques order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setNumCheque(Convert.ToInt16(linha["numCheque"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setValor(Convert.ToDouble(linha["valor"].ToString()));
                setFinalidade(linha["finalidade"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método Inserir
        public bool inserirCheque()
        {
            String sql = "INSERT INTO cheques (numCheque, valor, data, finalidade) VALUES('"+numCheque+"',"+valor.ToString().Replace(",", ".")+",'"+data+"','"+finalidade+"')";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Excluir
        public bool excluirCheque(int id)
        {
            bool resposta;
            string sql = "delete from cheques where numCheque = "+id+"";

            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Atualizar
        public bool atualizarCheque(int id)
        {
            bool resposta;
            string sql = " update cheques set data = '"+data+"', numCheque = '"+numCheque+"', finalidade = '"+finalidade+"', valor = "+valor.ToString().Replace(",", ".")+" where numCheque = " +id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método preenche campos Cheques
        public bool preencheCamposCheques(int id)
        {
            string sql = "select * from cheques where numCheque = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setNumCheque(Convert.ToInt16(linha["numCheque"].ToString()));
                setData(Convert.ToDateTime(linha["data"]));
                setValor(Convert.ToDouble(linha["valor"]));
                setFinalidade(linha["finalidade"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }
    }
}