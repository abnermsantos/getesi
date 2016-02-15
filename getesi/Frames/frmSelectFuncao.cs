/*
 * Classe utilizada pelo usuário para escolher por onde irá navegar no sistema.
 * Possui as opções: Histórico(Acessada através do logo da empresa), Centro de Custos,
 * Gerenciamento de Projetos e Controle de Estoque. Os botões também inicializam a 
 * Tela Principal.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using getesi.Frames;

namespace getesi
{
    public partial class frmSelectFuncao : Form
    {
        public frmSelectFuncao()
        {
            InitializeComponent();
        }

//Método que realizada a chamada da Tela Histórico
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            //frmPrincipal principal = frmPrincipal.getInstance();
            //principal.Show();
            frmHistorico historico = frmHistorico.getInstance();
            historico.Show();
        }

//Método que realizada a chamada da Tela Principal e do Centro de Custos
        private void btnCustos_Click(object sender, EventArgs e)
        {
            //frmPrincipal principal = frmPrincipal.getInstance();
            //principal.Show();
            frmCustos custos = frmCustos.getInstance();
            custos.Show();
        }

//Método que realizada a chamada da Tela Principal e do Gerenciamento de Projetos
        private void btnProjetos_Click(object sender, EventArgs e)
        {
            //frmPrincipal principal = frmPrincipal.getInstance();
            //principal.Show();
            frmProjetos projetos = frmProjetos.getInstance();
            projetos.Show();
        }

//Método que realizada a chamada da Tela Principal e do Controle de Estoque
        private void btnEstoque_Click(object sender, EventArgs e)
        {
           // frmPrincipal principal = frmPrincipal.getInstance();
           // principal.Show();
            frmEstoque estoque = frmEstoque.getInstance();
            estoque.Show();
        }
    }
}