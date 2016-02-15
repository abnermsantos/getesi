/*
 *Classe utilizada para o sistema de Login de Usuários. Esta classe
 *se relaciona com a classe UsuarioDAO para poder validar o login 
 *ou informar o ERRO. Possui os métodos login() que chama a classe UsuarioDAO, 
 *o método txtsenha_KeyDown() que chama o botão login caso o usuario aperte ENTER no
 *txtSenha e o método Limpar() que limpa todos os textbox da tela.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using getesi.DAO;

namespace getesi.Frames
{
    public partial class frmLogin : Form
    {
        private bool logado = false;
        
        public frmLogin()
        {
         InitializeComponent();
        }
 
//Método Limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtsenha.Text = "";
        }

//Método btnLogin
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.setUsuario(txtUsuario.Text);
            usuarioDAO.setSenha(txtsenha.Text);
            //Chamada de Método da Classe UsuarioDAO com passagem de parâmetros
            logado = usuarioDAO.login(usuarioDAO);
            if (logado)
            {
                //Fecha a pagina atual
                this.DialogResult = DialogResult.OK;
                Close();                
            }
        }
//Método KeyDown
        private void txtsenha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13) //13 é ENTER (ASCII)
            {
                btnLogin_Click(sender, e);
            }
        }

        

     
    }
}