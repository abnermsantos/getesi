using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using getesi.DAO;

namespace getesi.Frames
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private static frmPrincipal instance;

//Método getInstance()
        public static frmPrincipal getInstance()
        {
            if (instance == null)
            {
                instance = new frmPrincipal();
            }
            return instance;
        }

//Método FormLoad
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmSelectFuncao frmSelectFuncao = new frmSelectFuncao();
            frmSelectFuncao.Show();
        }

//Método FormClosing
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

//Método Sair
        private void SairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método Iniciar Calculadora
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Calc.exe");
        }

//Método Iniciar Calendário
        private void calendárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalendario calendario = frmCalendario.getInstance();
            calendario.Show();
        }

//Método Formulário Sobre
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = frmSobre.getInstance();
            sobre.Show();
        }

//Método Formulário Cadastro
        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastro cadastro = frmCadastro.getInstance();
            cadastro.Show();
        }

//Método Formulário Relatório
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmRelatórios relatorio = frmRelatórios.getInstance();
            relatorio.Show();
        }

//Método Formulário Projetos
        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProjetos frmProjetos = frmProjetos.getInstance();
            frmProjetos.Show();
        }

//Método Formulário Custos
        private void centroDeCustosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustos frmCustos = frmCustos.getInstance();
            frmCustos.Show();
        }

//Método Formulário Estoque
        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque frmEstoque = frmEstoque.getInstance();
            frmEstoque.Show();
        }

//Método Formulário Histórico
        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorico frmHistorico = frmHistorico.getInstance();
            frmHistorico.Show();
        }
    }
}