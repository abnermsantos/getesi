using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class FornecedorDAO
    {
        private int codigo;
        private string nome;
        private string cnpj;
        private string ie;
        private string contato;
        private string telefone;
        private string rua;
        private int numero;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;
        private string site;
        private string email;

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
        public string getNome()
        {
            return nome;
        }

        public void setCnpj(string cnpj)
        {
            this.cnpj = cnpj;
        }
        public string getCnpj()
        {
            return cnpj;
        }

        public void setIe(string ie)
        {
            this.ie = ie;
        }
        public string getIe()
        {
            return ie;
        }

        public void setContato(string contato)
        {
            this.contato = contato;
        }
        public string getContato()
        {
            return contato;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public string getTelefone()
        {
            return telefone;
        }

        public void setRua(string rua)
        {
            this.rua = rua;
        }
        public string getRua()
        {
            return rua;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }
        public int getNumero()
        {
            return numero;
        }

        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }
        public string getBairro()
        {
            return bairro;
        }

        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }
        public string getCidade()
        {
            return cidade;
        }

        public void setUf(string uf)
        {
            this.uf = uf;
        }
        public string getUf()
        {
            return uf;
        }

        public void setCep(string cep)
        {
            this.cep = cep;
        }
        public string getCep()
        {
            return cep;
        }

        public void setSite(string site)
        {
            this.site = site;
        }
        public string getSite()
        {
            return site;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return email;
        }

//Metodo listarTodos()
        public DataTable listarTodos()
        {
            String sql = "SELECT * FROM fornecedor where nome != 'Cheques'";
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método preenche campos Fornecedor
        public bool preencheCamposFornecedor(int id)
        {
            string sql = "select * from fornecedor where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setNome(linha["nome"].ToString());
                setCnpj(linha["cnpj"].ToString());
                setIe(linha["ie"].ToString());
                setContato(linha["contato"].ToString());
                setTelefone(linha["telefone"].ToString());
                setEmail(linha["email"].ToString());
                setSite(linha["site"].ToString());
                setRua(linha["rua"].ToString());
                setNumero(Convert.ToInt16(linha["numero"].ToString()));
                setBairro(linha["bairro"].ToString());
                setCep(linha["cep"].ToString());
                setCidade(linha["cidade"].ToString());
                setUf(linha["uf"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Inserir Fornecedor
        public bool inserirFornecedor()
        {
            String sql = "INSERT INTO fornecedor (nome, cnpj, ie, contato, telefone, email, site, rua, numero, bairro, cep, cidade, uf) VALUES('" + nome + "', '" + cnpj.ToString().Replace(",", ".") + "', '" + ie.ToString().Replace(",", ".") + "', '" + contato + "', '" + telefone + "', '" + email + "', '" + site + "', '" + rua + "', " + numero + ", '" + bairro + "', '" + cep.ToString().Replace(",", ".") + "', '" + cidade + "', '" + uf + "' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Fornecedor
        public bool atualizarFornecedor(int id)
        {
            bool resposta;
            string sql = " update fornecedor set nome = '" + nome + "', cnpj = '" + cnpj.ToString().Replace(",", ".") + "', ie = '" + ie.ToString().Replace(",", ".") + "', contato = '" + contato + "', telefone = '" + telefone + "', email = '" + email + "', site = '" + site + "', rua = '" + rua + "', numero = " + numero + ", bairro = '" + bairro + "', cep = '" + cep.ToString().Replace(",", ".") + "', cidade = '" + cidade + "', uf = '" + uf + "' where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Fornecedor
        public bool excluirFornecedor(int id)
        {
            bool resposta;
            string sql = "delete from fornecedor where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
    }
}
