/*
 * Classe utilizada para conectar o sistema com a tabela fluxo_bancario do banco de dados.
 * Possui os métodos "get" e "set" para as suas variáveis, preencheCampos() para as contas
 * a pagar e receber,  listar()para as contas a pagar e receber, listarTodos(mes), 
 * inserirEntradaCaixa(), inserirContas() a pagar e receber, excluirContas() a pagar e receber,
 * atualizarContas() a pagar e receber, consultarSaldoAtual(), arquivarContas() a pagar e receber,
 * consultarValor() a pagar e receber, atualizarSaldo(), consultarData(), atualizarSaldoExcluirCaixa(),
 * consultarValorCaixa().
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class FluxoBancarioDAO
    {
        private int codigo;
        private double pagar;
        private string credor;
        private double receber;
        private string devedor;
        private double saldo;
        private DateTime data;
        private string descricao;
        private bool status;

//Metodos SET E GET
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public int getCodigo()
        {
            return codigo;
        }

        public void setPagar(double pagar)
        {
            this.pagar = pagar;
        }
        public double getPagar()
        {
            return pagar;
        }

        public void setCredor(string credor)
        {
            this.credor = credor;
        }
        public string getCredor()
        {
            return credor;
        }

        public void setReceber(double receber)
        {
            this.receber = receber;
        }
        public double getReceber()
        {
            return receber;
        }

        public void setDevedor(string devedor)
        {
            this.devedor = devedor;
        }
        public string getDevedor()
        {
            return devedor;
        }

        public void setSaldo(double saldo)
        {
            this.saldo = saldo;
        }
        public double getSaldo()
        {
            return saldo;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }
        public DateTime getData()
        {
            return data;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }
        public string getDescricao()
        {
            return descricao;
        }

        public void setStatus(bool status)
        {
            this.status = status;
        }
        public bool getStatus()
        {
            return status;
        }

//Método preenche campos Contas a Pagar
        public bool preencheCamposContasAPagar(int id)
        {
            string sql = "select *from fluxo_bancario where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"]));
                setPagar(Convert.ToDouble(linha["pagar"]));
                setCredor(linha["credor"].ToString());
                setDescricao(linha["descricao"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método preenche campos Contas a Receber
        public bool preencheCamposContasAReceber(int id)
        {
            string sql = "select * from fluxo_bancario where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"]));
                setReceber(Convert.ToDouble(linha["receber"]));
                setDevedor(linha["devedor"].ToString());
                setDescricao(linha["descricao"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método listarContasAPagar()
        public DataTable listarContasAPagar()
        {
            DateTime dataAtual = DateTime.Today;
            string sql = "SELECT codigo, data, pagar, credor, descricao FROM fluxo_bancario WHERE credor != 'null' AND status = FALSE AND data >= '"+dataAtual+"' ORDER BY data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setPagar(Convert.ToDouble(linha["pagar"].ToString()));
                setCredor(linha["credor"].ToString());
                setDescricao(linha["descricao"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método Listar Contas a Receber
        public DataTable listarContasAReceber()
        {
            DateTime dataAtual = DateTime.Today;
            string sql = "SELECT codigo, data, receber, devedor, descricao FROM fluxo_bancario WHERE devedor != 'null' AND status = FALSE AND data >= '"+dataAtual+"' ORDER BY data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setReceber(Convert.ToDouble(linha["receber"].ToString()));
                setDevedor(linha["devedor"].ToString());
                setDescricao(linha["descricao"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método listarTodos(string mes)
        public DataTable listarTodos(int mes)
        {
            string sql = "Select data, sum(pagar) as pagar, sum(receber) as receber from fluxo_bancario where (SELECT extract(MONTH FROM data)) = " + mes + " AND (SELECT extract(YEAR FROM data)) = (SELECT extract(YEAR FROM CURRENT_DATE)) group by data order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setPagar(Convert.ToDouble(linha["pagar"].ToString()));
                setReceber(Convert.ToDouble(linha["receber"].ToString()));
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método Inserir Entrada do Caixa
        public bool inserirEntradaCaixa()
        {
            setSaldo(consultarSaldoAtual() - pagar);
            atualizarSaldo(saldo);
            String sql = "INSERT INTO fluxo_bancario (data, pagar, descricao, receber, status) VALUES('" + data + "'," + pagar.ToString().Replace(",", ".") + ", 'Saque', 0, TRUE)";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Inserir Contas a Pagar
        public bool inserirContasAPagar()
        {
            setSaldo(consultarSaldoAtual());
            String sql = "INSERT INTO fluxo_bancario (data, pagar, credor, descricao, receber, status) VALUES('" + data + "'," + pagar.ToString().Replace(",", ".") + ",'" + credor + "','" + descricao + "', 0, "+status+")";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Excluir Contas a Pagar
        public bool excluirContasAPagar(int id)
        {
            bool resposta;
            string sql = "delete from fluxo_bancario where codigo = " + id + "";

            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Atualizar Contas a Pagar
        public bool atualizarContasAPagar(int id)
        {
            bool resposta;
            string sql = " update fluxo_bancario set data = '"+data+"', credor = '"+credor+"', descricao = '"+descricao+"', pagar = "+pagar.ToString().Replace(",", ".")+" where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Inserir Contas a Receber
        public bool inserirContasAReceber()
        {
            setSaldo(consultarSaldoAtual());
            String sql = "INSERT INTO fluxo_bancario (data, receber, devedor, descricao, pagar, status) VALUES('" + data + "'," + receber.ToString().Replace(",", ".") + ",'" + devedor + "','" + descricao + "', 0, "+status+")";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Excluir Contas a Receber
        public bool excluirContasAReceber(int id)
        {
            bool resposta;
            string sql = "delete from fluxo_bancario where codigo = " + id + "";

            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Atualizar Contas a Receber
        public bool atualizarContasAReceber(int id)
        {
            bool resposta;
            string sql = " update fluxo_bancario set data = '"+data+"', devedor = '"+devedor+"', descricao = '"+descricao+"', receber = "+receber.ToString().Replace(",", ".")+" where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Consultar Saldo Atual
        public double consultarSaldoAtual()
        {
            string sql = "Select saldo from conta_corrente where data <= '"+DateTime.Today+"'";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setSaldo(Convert.ToDouble(linha["saldo"].ToString()));
            }
            return saldo;
        }

//Método Arquivar Contas a Pagar
        public bool arquivarContasAPagar(int id)
        {
            bool resposta;
            double saldoAt = consultarSaldoAtual();
            double valor = consultarPagar(id);
            double saldo = saldoAt - valor;
            atualizarSaldo(saldo);
            string sql = " update fluxo_bancario set status = TRUE where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
//Método Consultar Valor à Pagar
        public double consultarPagar(int id)
        {
            string sql = "Select pagar from fluxo_bancario where codigo = "+id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setPagar(Convert.ToDouble(linha["pagar"].ToString()));
            }
            return pagar;
        }

//Método Arquivar Contas a Receber
        public bool arquivarContasAReceber(int id)
        {
            bool resposta;
            double saldoAt = consultarSaldoAtual();
            double valor = consultarReceber(id);
            double saldo = saldoAt + valor;
            atualizarSaldo(saldo);
            string sql = " update fluxo_bancario set status = TRUE where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Consultar Valor à Receber
        public double consultarReceber(int id)
        {
            string sql = "Select receber from fluxo_bancario where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setReceber(Convert.ToDouble(linha["receber"].ToString()));
            }
            return receber;
        }

//Método Atualizar Saldo
        public bool atualizarSaldo(double saldo)
        {
            bool resposta;
            DateTime data = consultarData();
            if (data == null)
            {
                string sql = " insert into conta_corrente (data, saldo) values('" + DateTime.Today + "', " + saldo + ")";
                resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
                return resposta;
            }
            else
            {
                string sql = " update conta_corrente  set data = '" + DateTime.Today + "', saldo = " + saldo;
                resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
                return resposta;
            }
        }

//Método Consultar Data
        public DateTime consultarData()
        {
            string sql = "Select data from conta_corrente where data = '" + DateTime.Today + "'";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"].ToString()));
            }
            return data;
        }

//Método Atualizar Saldo ao Excluir Entrada do Caixa
        public void atualizarSaldoExcluir(int id)
        {
            double saldoAt = consultarSaldoAtual();
            double valor = consultarCaixa(id);
            double saldo = saldoAt + valor;
            atualizarSaldo(saldo);
        }

//Método Consultar Valor do Caixa
        public double consultarCaixa(int id)
        {
            double valor = 0;
            string sql = "Select valor from caixa where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                valor = Convert.ToDouble(linha["valor"].ToString());
            }
            return valor;
        }

//Método Listar Relatorio Soma
        public DataTable listarRelatorioSoma()
        {
            string sql = "Select data, sum(pagar) as pagar, sum(receber) as receber from fluxo_bancario group by data order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            return dt;
        }

//Método Listar Relatorio Fornecedor_Gastos
        public DataTable listarRelatorioFornecedor_Gastos()
        {
            string sql = "Select data, credor as Fornecedor, pagar as Valor from fluxo_bancario where credor != 'Cheques'";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            return dt;
        }
    }
}