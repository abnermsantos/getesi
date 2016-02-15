using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace getesi.DAO
{
    class FuncionarioDAO
    {
        private int codigo;
        private string nome;
        private string cpf;
        private string rg;
        private string sexo;
        private string celular;
        private string telefone;
        private DateTime admissao;
        private DateTime dataNasc;
        private string cargo;
        private double salario;
        private string rua;
        private int numero;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;
        
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
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
                
        public string getCidade()
        {
            return cidade;
        }
        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }

        public string getUf()
        {
            return uf;
        }
        public void setUf(string uf)
        {
            this.uf = uf;
        }
        public string getCep()
        {
            return cep;
        }
        public void setCep(string cep)
        {
            this.cep = cep;
        }
        public double getSalario()
        {
            return salario;
        }
        public void setSalario(double salario)
        {
            this.salario = salario;
        }
        public string getTelefone()
        {
            return telefone;
        }
        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public string getCelular()
        {
            return celular;
        }
        public void setCelular(string celular)
        {
            this.celular = celular;
        }
        public DateTime getAdmissao()
        {
            return admissao;
        }
        public void setAdmissao(DateTime admissao)
        {
            this.admissao = admissao;
        }
        public string getCpf()
        {
            return cpf;
        }
        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }
        public string getRg()
        {
            return rg;
        }
        public void setRg(string rg)
        {
            this.rg = rg;
        }
        public DateTime getDataNasc()
        {
            return dataNasc;
        }
        public void setDataNasc(DateTime dataNasc)
        {
            this.dataNasc = dataNasc;
        }
        public string getCargo()
        {
            return cargo;
        }
        public void setCargo(string cargo)
        {
            this.cargo = cargo;
        }
        public string getSexo()
        {
            return sexo;
        }
        public void setSexo(string sexo)
        {
            this.sexo = sexo;
        }
        
//Método Listar Todos
        public DataTable listarTodos()
        {
            string sql = "Select * from funcionario";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setNome(linha["nome"].ToString());
                setCpf(linha["cpf"].ToString());
                setRg(linha["rg"].ToString());
                setCelular(linha["celular"].ToString());
                setTelefone(linha["telefone"].ToString());
                setSexo(linha["sexo"].ToString());
                setAdmissao(Convert.ToDateTime(linha["admissao"].ToString()));
                setDataNasc(Convert.ToDateTime(linha["dataNasc"].ToString()));
                setCargo(linha["cargo"].ToString());
                setSalario(Convert.ToDouble(linha["salario"].ToString()));
                setRua(linha["rua"].ToString());
                setNumero(Convert.ToInt16(linha["numero"].ToString()));
                setBairro(linha["bairro"].ToString());
                setCidade(linha["cidade"].ToString());
                setUf(linha["uf"].ToString());
                setCep(linha["cep"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método preenche campos Funcionario
        public bool preencheCamposFuncionario(int id)
        {
            string sql = "select * from funcionario where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setNome(linha["nome"].ToString());
                setCpf(linha["cpf"].ToString());
                setRg(linha["rg"].ToString());
                setCelular(linha["celular"].ToString());
                setTelefone(linha["telefone"].ToString());
                setSexo(linha["sexo"].ToString());
                setAdmissao(Convert.ToDateTime(linha["admissao"].ToString()));
                setDataNasc(Convert.ToDateTime(linha["dataNasc"].ToString()));
                setCargo(linha["cargo"].ToString());
                setSalario(Convert.ToDouble(linha["salario"].ToString()));
                setRua(linha["rua"].ToString());
                setNumero(Convert.ToInt16(linha["numero"].ToString()));
                setBairro(linha["bairro"].ToString());
                setCidade(linha["cidade"].ToString());
                setUf(linha["uf"].ToString());
                setCep(linha["cep"].ToString());
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Inserir Funcionario
        public bool inserirFuncionario()
        {
            String sql = "INSERT INTO funcionario (nome, cpf, rg, sexo, celular, telefone, admissao, dataNasc, cargo, salario, rua, numero, bairro, cep, cidade, uf) VALUES('" + nome + "', '" + cpf.ToString().Replace(",", ".") + "', '" + rg.ToString().Replace(",", ".") + "', '" + sexo + "', '" + celular + "', '"+ telefone + "', '" + admissao + "', '" + dataNasc + "', '" + cargo + "', " + salario.ToString().Replace(",", ".") + ", '" + rua + "', " + numero + ", '" + bairro + "', '" + cep.ToString().Replace(",", ".") + "', '" + cidade + "', '" + uf + "' )";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Funcionario
        public bool atualizarFuncionario(int id)
        {
            bool resposta;
            string sql = " update funcionario set nome = '" + nome + "', cpf = '" + cpf.ToString().Replace(",", ".") + "', rg = '" + rg.ToString().Replace(",", ".") + "', sexo = '" + sexo + "', celular = '" + celular + "', telefone = '" + telefone + "', admissao = '" + admissao + "', dataNasc = '" + dataNasc + "', cargo = '" + cargo + "', salario = " + salario.ToString().Replace(",", ".") + ", rua = '" + rua + "', numero = " + numero + ", bairro = '" + bairro + "', cep = '" + cep.ToString().Replace(",", ".") + "', cidade = '" + cidade + "', uf = '" + uf + "' where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Funcionario
        public bool excluirFuncionario(int id)
        {
            bool resposta;
            string sql = "delete from funcionario where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
    }
}