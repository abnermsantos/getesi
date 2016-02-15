/*
 * Classe utilizada para relacionar o banco de dados (tabelas do estoque) com a interface do usuario. Possui os
 * métodos get e set de cada atributo, inserir(), atualizarProduto(), atualizarQuantidade(), excluir(), listarTodos(),
 * listarTodos(string nome), preencheCampos(), inserirEntrada(), inserirSaida(), somaQtdEstoque(), subtraiQtdEstoque().
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class EstoqueDAO
    {
        private int codigo;
        private string nome;
        private int qtdMin;
        private int qtdAtual;
        private string descricao;
        private string fornecedor;
        private double valor;
        private DateTime data;
        private int quantidade;

        //Métodos SET() e GET()
        public void setCodigo(int cod)
        {
            this.codigo = cod;
        }

        public int getCodigo()
        {
            return codigo;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public String getNome()
        {
            return nome;
        }

        public void setMinimo(int min)
        {
            this.qtdMin = min;
        }

        public int getMinimo()
        {
            return qtdMin;
        }

        public void setAtual(int atual)
        {
            this.qtdAtual = atual;
        }

        public int getAtual()
        {
            return qtdAtual;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public String getDescricao()
        {
            return descricao;
        }

        public void setFornecedor(String forn)
        {
            this.fornecedor = forn;
        }

        public String getFornecedor()
        {
            return fornecedor;
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

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }

        public int getQuantidade()
        {
            return quantidade;
        }

//Método inserir()
        public bool inserir()
        {
            String sql = "INSERT INTO material (codigo, nome, qtd_minima, qtd_estoque, descricao, fornecedor, valor) VALUES('"+codigo+"','"+nome+"','"+qtdMin+"','"+qtdAtual+"','"+descricao+"','"+fornecedor+"',"+valor.ToString().Replace(",",".")+");";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método atualizarProduto()
        public bool atualizarProduto(int id)
        {
            bool resposta;
            string sql = " update material set nome = '"+nome+"', fornecedor = '"+fornecedor+"', descricao = '"+descricao+"', valor = '"+valor.ToString().Replace(",", ".")+"', qtd_minima = '"+qtdMin+"', qtd_estoque = '"+qtdAtual+"' where codigo = "+id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
        
//Método atualizarQuantidade()
        public bool atualizarQuantidade(int id)
        {
            bool resposta;
            string sql = " update material set qtd_estoque = "+qtdAtual+" where codigo = "+id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
        
//Método excluir()
        public bool excluir(int id)
        {
            bool resposta;
            string sql = "delete from material where codigo = "+id+"";

            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Metodo listarTodos()
        public DataTable listarTodos()
        {
            String sql = "select * from material;";
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método listarTodos() por nome
        public DataTable listarTodos(string nome)
        {
            String sql = "select * from material where nome like '" +nome+ "%';";
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método preencheCampos()
        public bool preencheCampos(int id)
        {
            string sql = "select *from material where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setNome(linha["nome"].ToString());
                setFornecedor(linha["fornecedor"].ToString());
                setDescricao(linha["descricao"].ToString());
                setValor(Convert.ToDouble(linha["valor"]));
                setAtual(Convert.ToInt16(linha["qtd_estoque"]));
                setMinimo(Convert.ToInt16(linha["qtd_minima"]));
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método inserirEntrada()
        public bool inserirEntrada()
        {
            String tipo = "Entrada";
            String sql = "INSERT INTO movimentacao (qtd, data, tipo) VALUES("+quantidade+",'"+data+"','"+tipo+"')";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método inserirSaida()
        public bool inserirSaida()
        {
            String tipo = "Saida";
            String sql = "INSERT INTO movimentacao (qtd, data, tipo) VALUES ("+quantidade+", '"+data+"', '"+tipo+"')";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método somaQtdEstoque()
        public bool somaQtdEstoque()
        {
            bool res = false;

            if (quantidade < 1)
            {
                res = false;
            }
            else
            {
                setAtual(quantidade + qtdAtual);
                res = true;
            }
            return res;
        }

//Método subtraiQtdEstoque()
        public bool subtraiQtdEstoque()
        {
            bool res = false;

            if (quantidade > qtdAtual)
            {
                res = false;
            }
            else
            {
                setAtual(qtdAtual - quantidade);
                res = true;
            }
            return res;
        }
    }
}