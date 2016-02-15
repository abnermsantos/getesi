using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace getesi.DAO
{
    class MedicaoDAO
    {
        int op;
        int numMedicao;
        DateTime data;
        double valor;
        string observacao;
        string descricao;

        public void setOp(int op)
        {
            this.op = op;
        }
        public int getOp()
        {
            return op;
        }

        public void setNumMedicao(int numMedicao)
        {
            this.numMedicao = numMedicao;
        }
        public int getNumMedicao()
        {
            return numMedicao;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }
        public DateTime getData()
        {
            return data;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }
        public double getValor()
        {
            return valor;
        }

        public void setObservacao(string observacao)
        {
            this.observacao = observacao;
        }
        public string getObservacao()
        {
            return observacao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        public string getDescricao()
        {
            return descricao;
        }

//Método preenche campos Medição
        public bool preencheCamposMedicao(int id, int num)
        {
            string sql = "select * from medicao where op = " + id +" AND numMedicao = "+num;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setOp(Convert.ToInt16(linha["op"]));
                setNumMedicao(Convert.ToInt16(linha["numMedicao"]));
                setData(Convert.ToDateTime(linha["data"]));
                setValor(Convert.ToDouble(linha["valor"]));
                setObservacao(linha["observacao"].ToString());
                setDescricao(linha["descricao"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Listar Todos
        public DataTable listarTodos()
        {
            string sql = "Select op, numMedicao, data, valor, observacao, descricao from medicao order by op";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setOp(Convert.ToInt16(linha["op"].ToString()));
                setNumMedicao(Convert.ToInt16(linha["numMedicao"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setValor(Convert.ToDouble(linha["valor"].ToString()));
                setObservacao(linha["observacao"].ToString());
                setDescricao(linha["descricao"].ToString());

            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Inserir Medição
        public bool inserirMedicao()
        {
            String sql = "INSERT INTO medicao (op, numMedicao, data, valor, observacao, descricao) VALUES(" + op + ", " + numMedicao + ", '" + data + "', '" + valor.ToString().Replace(",",".") + "', '" + observacao + "', '" + descricao + "' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Medição
        public bool atualizarMedicao(int id, int num)
        {
            bool resposta;
            string sql = " update medicao set op = " + op + ", numMedicao = " + numMedicao + ", data = '" + data + "', valor = '" + valor.ToString().Replace(",", ".") + "', observacao = '" + observacao + "', descricao = '" + descricao + "' where op = " + id +" AND numMedicao = "+num ;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Medição
        public bool excluirMedicao(int id, int num)
        {
            bool resposta;
            string sql = "delete from medicao where op = " + id+" AND numMedicao = "+num;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
    }
}
