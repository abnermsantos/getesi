using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace getesi.DAO
{
    class ViagemDAO
    {
        int codigo;
        int op;
        double pedagio;
        double outros;
        double refeicao;
        double combustivel;
        string materiais;
        string tarefa;
        string veiculo;
        string equipe;
        DateTime data;

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public int getCodigo()
        {
            return codigo;
        }

        public void setOp(int op)
        {
            this.op = op;
        }
        public int getOp()
        {
            return op;
        }

        public void setPedagio(double pedagio)
        {
            this.pedagio = pedagio;
        }
        public double getPedagio()
        {
            return pedagio;
        }

        public void setOutros(double outros)
        {
            this.outros = outros;
        }
        public double getOutros()
        {
            return outros;
        }

        public void setRefeicao(double refeicao)
        {
            this.refeicao = refeicao;
        }
        public double getRefeicao()
        {
            return refeicao;
        }

        public void setCombutivel(double combustivel)
        {
            this.combustivel = combustivel;
        }
        public double getCombustivel()
        {
            return combustivel;
        }

        public void setMateriais(string materiais)
        {
            this.materiais = materiais;
        }
        public string getMateriais()
        {
            return materiais;
        }

        public void setTarefa(string tarefa)
        {
            this.tarefa = tarefa;
        }
        public string getTarefa()
        {
            return tarefa;
        }

        public void setVeiculo(string veiculo)
        {
            this.veiculo = veiculo;
        }
        public string getVeiculo()
        {
            return veiculo;
        }

        public void setEquipe(string equipe)
        {
            this.equipe = equipe;
        }
        public string getEquipe()
        {
            return equipe;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }
        public DateTime getData()
        {
            return data;
        }

//Método preenche campos Viagem
        public bool preencheCamposViagens(int id)
        {
            string sql = "select * from viagem where codigo = " + id ;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setOp(Convert.ToInt16(linha["op"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setVeiculo(linha["veiculo"].ToString());
                setTarefa(linha["tarefa"].ToString());
                setPedagio(Convert.ToDouble(linha["pedagio"].ToString()));
                setOutros(Convert.ToDouble(linha["outros"].ToString()));
                setCombutivel(Convert.ToDouble(linha["combustivel"].ToString()));
                setRefeicao(Convert.ToDouble(linha["refeicao"].ToString()));
                setMateriais(linha["materiais"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Listar Todos
        public DataTable listarTodos()
        {
            string sql = "Select codigo, op, data, veiculo, tarefa, pedagio, outros, combustivel, refeicao, materiais from viagem order by op";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setOp(Convert.ToInt16(linha["op"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setVeiculo(linha["veiculo"].ToString());
                setTarefa(linha["tarefa"].ToString());
                setPedagio(Convert.ToDouble(linha["pedagio"].ToString()));
                setOutros(Convert.ToDouble(linha["outros"].ToString()));
                setCombutivel(Convert.ToDouble(linha["combustivel"].ToString()));
                setRefeicao(Convert.ToDouble(linha["refeicao"].ToString()));
                setMateriais(linha["materiais"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Inserir Viagem
        public bool inserirViagem()
        {
            String sql = "INSERT INTO viagem (op, data, veiculo, tarefa, pedagio, outros, combustivel, refeicao, materiais) VALUES(" + op + ", '" + data + "', '" + veiculo + "', '" + tarefa + "', " + pedagio.ToString().Replace(",", ".") + ", " + outros.ToString().Replace(",", ".") + ", " + combustivel.ToString().Replace(",", ".") + ", " + refeicao.ToString().Replace(",", ".") + ", '" + materiais + "' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Viagem
        public bool atualizarViagens(int id)
        {
            bool resposta;
            string sql = " update viagem set op = " + op + ", veiculo = '" + veiculo + "', data = '" + data + "', combustivel = " + combustivel.ToString().Replace(",", ".") + ", pedagio = " + pedagio.ToString().Replace(",", ".") + ", outros = " + outros.ToString().Replace(",", ".") + ", refeicao = " + refeicao.ToString().Replace(",", ".") + ", tarefa = '"+tarefa+"', materiais = '"+materiais+"' where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Viagem
        public bool excluirViagens(int id)
        {
            bool resposta;
            string sql = "delete from viagem where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
        
//Método Listar Todos Relatorio
        public DataTable listarTodosRelatorio()
        {
            string sql = "select data, op, veiculo, (combustivel + refeicao + pedagio + outros) as Gastos from viagem order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            return dt;
        }
    }
}
