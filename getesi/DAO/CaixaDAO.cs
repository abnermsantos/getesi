/*
 * Classe utilizada para conectar o sistema com a tabela caixa do banco de dados.
 * Possui os métodos "get" e "set" para as suas variáveis, preencheCampos(), 
 * inserirEntrada(), inserirSaida(), excluir(), atualizar(), listarTodos(),
 * listarRelatório() e consultarSaldo().
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class CaixaDAO
    {
        private double saldo;
        private string funcionario;
        private DateTime data;
        private double valor;
        private string finalidade;
        private string tipo;

        public void setSaldo(double saldo)
        {
            this.saldo = saldo;
        }
        public double getSaldo()
        {
            return saldo;
        }

        public void setFuncionario(string funcionario)
        {
            this.funcionario = funcionario;
        }
        public string getFuncionario()
        {
            return funcionario;
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

        public void setFinalidade(string finalidade)
        {
            this.finalidade = finalidade;
        }
        public string getFinalidade()
        {
            return finalidade;
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }
        public string getTipo()
        {
            return tipo;
        }

//Método preenche campos Caixa
        public bool preencheCamposCaixa(int id)
        {
            string sql = "select * from caixa where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"]));
                setValor(Convert.ToDouble(linha["valor"]));
                setFinalidade(linha["finalidade"].ToString());
                setFuncionario(linha["funcionario"].ToString());
                setTipo(linha["tipo"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Inserir Entrada no Caixa
        public bool inserirEntradaCaixa()
        {
            setSaldo(consultarSaldo() + valor);
            String sql = "INSERT INTO caixa (saldo, data, valor, tipo) VALUES(" + saldo+ ",'"+data+"'," + valor.ToString().Replace(",", ".")  + ", 'entrada')";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Inserir Saida no Caixa
        public bool inserirSaidaCaixa()
        {
            setSaldo(consultarSaldo() - valor);
            String sql = "INSERT INTO caixa (saldo, funcionario, data, valor, finalidade, tipo) VALUES(" + saldo + ",'" + funcionario + "','" + data + "'," + valor.ToString().Replace(",", ".") + ", '" + finalidade + "', 'saida')";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Excluir do Caixa
        public bool excluirCaixa(int id)
        {
            bool resposta;
            string sql = "delete from caixa where codigo = " + id ;

            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Atualizar Caixa
        public bool atualizarCaixa(int id)
        {
            bool resposta;
            string sql = " update caixa set data = '" + data + "', funcionario = '" + funcionario + "', finalidade = '" + finalidade + "', valor = " + valor.ToString().Replace(",", ".") + ", saldo ="+saldo+" where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método listar todos
        public DataTable listarTodos()
        {
            string sql = "Select codigo, data, tipo, valor, finalidade, funcionario, saldo from caixa order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setTipo(linha["tipo"].ToString());
                setValor(Convert.ToDouble(linha["valor"].ToString()));
                setFuncionario(linha["funcionario"].ToString());
                setFinalidade(linha["finalidade"].ToString());
                setSaldo(Convert.ToDouble(linha["saldo"].ToString()));
                
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método listar Relatorio
        public DataTable listarRelatorio()
        {
            string sql = "Select data, tipo, valor, finalidade, saldo from caixa order by data";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setData(Convert.ToDateTime(linha["data"].ToString()));
                setTipo(linha["tipo"].ToString());
                setValor(Convert.ToDouble(linha["valor"].ToString()));
                setFinalidade(linha["finalidade"].ToString());
                setSaldo(Convert.ToDouble(linha["saldo"].ToString()));
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método Consultar Saldo Atual
        public double consultarSaldo()
        {
            string sql = "Select saldo from caixa where data <= '" + DateTime.Today + "'";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setSaldo(Convert.ToDouble(linha["saldo"].ToString()));
            }
            return saldo;
        }
    }
}
