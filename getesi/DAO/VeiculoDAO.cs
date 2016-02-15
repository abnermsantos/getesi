using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace getesi.DAO
{
    class VeiculoDAO
    {
        int codigo;
        string placa;
        string nome;
        string fabricante;
        int ano;

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public int getCodigo()
        {
            return codigo;
        }

        public void setPlaca(string placa)
        {
            this.placa = placa;
        }
        public string getPlaca()
        {
            return placa;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return nome;
        }

        public void setFabricante(string fabricante)
        {
            this.fabricante = fabricante;
        }
        public string getFabricante()
        {
            return fabricante;
        }

        public void setAno(int ano)
        {
            this.ano = ano;
        }
        public int getAno()
        {
            return ano;
        }

//Metodo Listar Todos
        public DataTable listarTodos()
        {
            String sql = "SELECT * FROM veiculo";
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método preenche campos Usuario
        public bool preencheCamposVeiculo(int id)
        {
            string sql = "select * from veiculo where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setNome(linha["nome"].ToString());
                setFabricante(linha["fabricante"].ToString());
                setPlaca(linha["placa"].ToString());
                setAno(Convert.ToInt16(linha["ano"].ToString()));
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Inserir Veiculo
        public bool inserirVeiculo()
        {
            String sql = "INSERT INTO veiculo (nome, placa, ano, fabricante) VALUES('" + nome + "', '" + placa + "', " + ano + ", '" + fabricante + "' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Veiculo
        public bool atualizarVeiculo(int id)
        {
            bool resposta;
            string sql = " update veiculo set nome = '" + nome + "', fabricante = '" + fabricante + "', placa = '" + placa + "', ano = " + ano + " where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Veiculo
        public bool excluirVeiculo(int id)
        {
            bool resposta;
            string sql = "delete from veiculo where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
    }
}