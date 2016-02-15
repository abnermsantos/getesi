using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace getesi.DAO
{
    class ProjetosDAO
    {
        private int op;
        private int numPontos;
        private DateTime inicio;
        private DateTime fim;
        private string cliente;
        private string resumo;

        public void setOp(int op)
        {
            this.op = op;
        }
        public int getOp()
        {
            return op;
        }

        public void setNumPontos(int numPontos)
        {
            this.numPontos = numPontos;
        }
        public int getNumPontos()
        {
            return numPontos;
        }

        public void setInicio(DateTime inicio)
        {
            this.inicio = inicio;
        }
        public DateTime getInicio()
        {
            return inicio;
        }

        public void setFim(DateTime fim)
        {
            this.fim = fim;
        }
        public DateTime getFim()
        {
            return fim;
        }

        public void setCliente(string cliente)
        {
            this.cliente = cliente;
        }
        public string getCliente()
        {
            return cliente;
        }

        public void setResumo(string resumo)
        {
            this.resumo = resumo;
        }
        public string getResumo()
        {
            return resumo;
        }

//Método preenche campos Cadastro Projetos
        public bool preencheCamposCadastroProjetos(int id)
        {
            string sql = "select * from projeto where op = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setOp(Convert.ToInt16(linha["op"]));
                setNumPontos(Convert.ToInt16(linha["numPontos"]));
                setInicio(Convert.ToDateTime(linha["inicio"]));
                setFim(Convert.ToDateTime(linha["fim"].ToString()));
                setCliente(linha["cliente"].ToString());
                setResumo(linha["resumo"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Listar Todos
        public DataTable listarTodos()
        {
            string sql = "Select op, cliente, numPontos, inicio, fim, resumo from projeto order by op desc";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setOp(Convert.ToInt16(linha["op"].ToString()));
                setCliente(linha["cliente"].ToString());
                setNumPontos(Convert.ToInt16(linha["numPontos"].ToString()));
                setInicio(Convert.ToDateTime(linha["inicio"].ToString()));
                setFim(Convert.ToDateTime(linha["fim"].ToString()));
                setResumo(linha["resumo"].ToString());

            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Inserir Cadastro de Projetos
        public bool inserirCadastroProjetos()
        {
            String sql = "INSERT INTO projeto (op, numPontos, inicio, fim, cliente, resumo) VALUES("+op+", "+numPontos+", '"+inicio+"', '"+fim+"', '"+cliente+"', '"+resumo+"' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Cadastro Projetos
        public bool atualizarCadastroProjetos(int id)
        {
            bool resposta;
            string sql = " update projeto set op = " + op + ", numPontos = " + numPontos + ", inicio = '" + inicio + "', fim = '" + fim + "', cliente = '" + cliente + "', resumo = '"+resumo+"' where op = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Cadastro Projetos
        public bool excluirCadastroProjetos(int id)
        {
            bool resposta;
            string sql = "delete from projeto where op = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Listar Todos Relatorio
        public DataTable listarTodosRelatorio()
        {
            string sql = "select cliente, op, inicio, fim from projeto order by op, cliente";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            return dt;
        }
    }
}
