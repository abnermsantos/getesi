/*
 * Classe utilizada para conexão com a tabela usuario do banco de dados.
 * Possui os métodos: Login() que valida o usuário cadastrado no sistema, 
 * e método consultaTodos() que busca todos os dados da tabela e preenche
 * uma lista do tipo DataTable.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using getesi.Frames;


namespace getesi.DAO
{
    class UsuarioDAO
    {
        int codigo;
        string usuario;
        string pwd;
        int categoria;

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public int getCodigo()
        {
            return codigo;
        }

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getUsuario()
        {
            return usuario;
        }

        public void setSenha(string senha)
        {
            this.pwd = senha;
        }
        public string getSenha()
        {
            return pwd;
        }

        public void setCategoria(int categoria)
        {
            this.categoria = categoria;
        }
        public int getCategoria()
        {
            return categoria;
        }

//Método Login()
        public bool login(UsuarioDAO usuario)
        {
            bool logado = false;

            String sql = "Select * FROM usuario WHERE usuario = '" + usuario.getUsuario() + "'AND senha = '" + usuario.getSenha() + "'";
            DataTable dt = ConexaoPG.getInstancia().consultar(sql);
            if (dt.Rows.Count > 0)
            {
                logado = true;
            }
            else
            {
                logado = false;
                MessageBox.Show("Login ou Senha inválidos", "ATENÇÃO");
            }
            return logado;
        }

//Método Listar Todos
        public DataTable listarTodos()
        {
            string sql = "Select codigo, usuario, senha, categoria from usuario";
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setUsuario(linha["usuario"].ToString());
                setSenha(linha["senha"].ToString());
                setCategoria(Convert.ToInt16(linha["categoria"].ToString()));
            }
            return DAO.ConexaoPG.getInstancia().consultar(sql);
        }

//Método preenche campos Usuario
        public bool preencheCamposUsuario(int id)
        {
            string sql = "select * from usuario where codigo = " + id;
            DataTable dt = DAO.ConexaoPG.getInstancia().consultar(sql);
            foreach (DataRow linha in dt.Rows)
            {
                setCodigo(Convert.ToInt16(linha["codigo"].ToString()));
                setUsuario(linha["usuario"].ToString());
                setSenha(linha["senha"].ToString());
                setCategoria(Convert.ToInt16(linha["categoria"].ToString()));
            }
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Inserir Usuario
        public bool inserirUsuario()
        {
            String sql = "INSERT INTO usuario (usuario, senha, categoria) VALUES('" + usuario + "', '" + pwd + "', " + categoria + ")";
            return DAO.ConexaoPG.getInstancia().persistir(sql);
        }

//Método Atualizar Usuario
        public bool atualizarUsuario(int id)
        {
            bool resposta;
            string sql = " update usuario set usuario = '" + usuario + "', senha = '" + pwd + "', categoria = " + categoria + " where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }

//Método Excluir Usuario
        public bool excluirUsuario(int id)
        {
            bool resposta;
            string sql = "delete from usuario where codigo = " + id;
            resposta = DAO.ConexaoPG.getInstancia().persistir(sql);
            return resposta;
        }
    }
}
