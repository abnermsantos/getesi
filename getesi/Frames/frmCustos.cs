/*
 * Classe utilizada para ser a interface do centro de custos para o usuario. Possui 
 * um estilo de "abas", sendo no total 6. Cada "ABA" possui seus métodos específicos 
 * separados por comentários no código. Os métodos são de fácil compreenção e estão 
 * com os comentários necessários para localização e entendimento. Nas duas primeiras Abas,
 * existe a opção de arquivar operação, somente após esta que o saldo é atualizado.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using getesi.DAO;

namespace getesi.Frames
{
    public partial class frmCustos : Form
    {
        public frmCustos()
        {
            InitializeComponent();
            popularComboFornecedor();
            popularComboCliente();
            popularComboFuncionario();
        }

        private static frmCustos instance;

        //Método getInstance()
        public static frmCustos getInstance()
        {
            if (instance == null)
            {
                instance = new frmCustos();
            }
            return instance;
        }

//Método FormClosing
        private void frmCustos_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        int id;
        FluxoBancarioDAO fluxoBancarioDAO = new FluxoBancarioDAO();
        ChequesDAO chequesDAO = new ChequesDAO();
        CaixaDAO caixaDAO = new CaixaDAO();

        //Método Limpar Campos
        public void limparCampos()
        {
            txtDataContasAPagar.Text = "";
            txtDescricaoContasAPagar.Text = "";
            txtValorContasAPagar.Text = "";
            cmbFornecedorContasAPagar.Text = "";
            
            txtDataContasAReceber.Text = "";
            txtDescricaoContasAReceber.Text = "";
            txtValorContasAReceber.Text = "";
            cmbClienteContasAReceber.Text = "";

            txtDataCaixa.Text = "";
            txtFinalidadeCaixa.Text = "";
            txtValorCaixa.Text = "";
            cmbFuncionarioCaixa.Text = "";
            optEntradaCaixa.Checked = false;
            optSaidaCaixa.Checked = false;
            
            txtNumFolha.Text = "";
            txtValorCheque.Text = "";
            txtDataCheque.Text = "";
            txtFinalidadeCheque.Text = "";
            
            cmbMesFluxoBancario.Text = "";
        }

/*
 * TAB 01 
*/

//Método Sair
        private void btnSairContasAPagar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método Listar Todos
        private void btnListarContasAPagar_Click(object sender, EventArgs e)
        {
            popularGridContasAPagar();
        }

//Método popularGrid()
        public void popularGridContasAPagar()
        {
            dgrContasAPagar.DataSource = fluxoBancarioDAO.listarContasAPagar();
            if (dgrContasAPagar.Columns.Count > 0)
            {
                dgrContasAPagar.Columns[0].Width = 80;
                dgrContasAPagar.Columns[1].Width = 100;
                dgrContasAPagar.Columns[2].Width = 100;
                dgrContasAPagar.Columns[3].Width = 100;
                dgrContasAPagar.Columns[4].Width = 300;

                dgrContasAPagar.Columns[1].HeaderText = "Codigo";
                dgrContasAPagar.Columns[1].HeaderText = "Data";
                dgrContasAPagar.Columns[2].HeaderText = "Valor";
                dgrContasAPagar.Columns[3].HeaderText = "Credor";
                dgrContasAPagar.Columns[4].HeaderText = "Descrição";
            }
        }

//Método popularComboFornecedor()
        public void popularComboFornecedor()
        {
            FornecedorDAO fornecedor = new FornecedorDAO();
            cmbFornecedorContasAPagar.DataSource = fornecedor.listarTodos();
            cmbFornecedorContasAPagar.DisplayMember = "Nome";
            cmbFornecedorContasAPagar.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbFornecedorContasAPagar.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbFornecedorContasAPagar.SelectedIndex = 0;
        }

//Método verificarBrancos()
        public bool verificarBrancos()
        {
            bool resposta;
            if (cmbFornecedorContasAPagar.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

        //Método txtValor_TextChanged()
        private void txtValorContasAPagar_TextChanged(object sender, EventArgs e)
        {
            btnInserirContasAPagar.Enabled = true;
        }

        //Método CellDoubleClick()
        private void dgrContasAPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrContasAPagar.Rows[e.RowIndex].Cells[0].Value.ToString());
            fluxoBancarioDAO.preencheCamposContasAPagar(id);
            popularTextBoxContasAPagar();
            btnArquivarContasAPagar.Visible = true;
            btnInserirContasAPagar.Enabled = false;
            btnAtualizarContasAPagar.Enabled = true;
            btnExcluirContasAPagar.Enabled = true;
        }

        //Método Popular TextBox
        public void popularTextBoxContasAPagar()
        {
            txtDataContasAPagar.Text = fluxoBancarioDAO.getData().ToString("dd/MM/yyyy");
            txtDescricaoContasAPagar.Text = fluxoBancarioDAO.getDescricao();
            txtValorContasAPagar.Text = fluxoBancarioDAO.getPagar().ToString();
            cmbFornecedorContasAPagar.Text = fluxoBancarioDAO.getCredor();
        }

        //Método Inserir
        private void btnInserirContasAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    fluxoBancarioDAO.setCredor(cmbFornecedorContasAPagar.Text);
                    fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataContasAPagar.Text));
                    fluxoBancarioDAO.setPagar(Convert.ToDouble(txtValorContasAPagar.Text));
                    fluxoBancarioDAO.setDescricao(txtDescricaoContasAPagar.Text);
                    fluxoBancarioDAO.setStatus(false);

                    try
                    {
                        resposta = fluxoBancarioDAO.inserirContasAPagar();

                        if (resposta)
                        {
                            MessageBox.Show("Conta cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridContasAPagar();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os dados digitados", "ERRO");
            }

        }

        //Método Excluir
        private void btnExcluirContasAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    try
                    {
                        resposta = fluxoBancarioDAO.excluirContasAPagar(id);

                        if (resposta)
                        {
                            MessageBox.Show("Conta excluida com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridContasAPagar();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao excluir", "ERRO");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

        //Método Atualizar
        private void btnAtualizarContasAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataContasAPagar.Text));
                    fluxoBancarioDAO.setCredor(cmbFornecedorContasAPagar.Text);
                    fluxoBancarioDAO.setDescricao(txtDescricaoContasAPagar.Text);
                    fluxoBancarioDAO.setPagar(Convert.ToDouble(txtValorContasAPagar.Text));
                    try
                    {
                        resposta = fluxoBancarioDAO.atualizarContasAPagar(id);
                        limparCampos();
                        popularGridContasAPagar();
                        if (resposta)
                        {
                            MessageBox.Show("Conta atualizada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!", "ATENÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

//Método Arquivar Contas a Pagar
        private void btnArquivarContasAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                bool resposta;
                try
                {
                    resposta = fluxoBancarioDAO.arquivarContasAPagar(id);
                    limparCampos();
                    popularGridContasAPagar();
                    if (resposta)
                    {
                        MessageBox.Show("OPERAÇÃO REALIZADA COM SUCESSO", "CONFIRMAÇÃO");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERRO AO CONCLUIR OPERAÇÃO!", "TENTE NOVAMENTE");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO AO CONCLUIR OPERAÇÃO!", "ERRO");
            }
        }
            
/*
 * TAB 02 
*/

        //Método Sair
        private void btnSairContasAReceber_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Método popularGrid()
        public void popularGridContasAReceber()
        {
            dgrContasAReceber.DataSource = fluxoBancarioDAO.listarContasAReceber();
            if (dgrContasAReceber.Columns.Count > 0)
            {
                dgrContasAReceber.Columns[0].Width = 80;
                dgrContasAReceber.Columns[1].Width = 100;
                dgrContasAReceber.Columns[2].Width = 100;
                dgrContasAReceber.Columns[3].Width = 100;
                dgrContasAReceber.Columns[4].Width = 300;

                dgrContasAReceber.Columns[1].HeaderText = "Codigo";
                dgrContasAReceber.Columns[1].HeaderText = "Data";
                dgrContasAReceber.Columns[2].HeaderText = "Valor";
                dgrContasAReceber.Columns[3].HeaderText = "Devedor";
                dgrContasAReceber.Columns[4].HeaderText = "Descrição";
            }
        }

        //Método popularComboCliente()
        public void popularComboCliente()
        {
            ClienteDAO cliente = new ClienteDAO();
            cmbClienteContasAReceber.DataSource = cliente.listarTodos();
            cmbClienteContasAReceber.DisplayMember = "Nome";
            cmbClienteContasAReceber.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbClienteContasAReceber.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbClienteContasAReceber.SelectedIndex = 0;
        }

        //Método verificarBrancos()
        public bool verificarBrancosContasAReceber()
        {
            bool resposta;
            if (cmbClienteContasAReceber.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

        //Método txtValor_TextChanged()
        private void txtValorContasAReceber_TextChanged(object sender, EventArgs e)
        {
            btnInserirContasAReceber.Enabled = true;
        }

        //Método CellDoubleClick()
        private void dgrContasAReceber_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrContasAReceber.Rows[e.RowIndex].Cells[0].Value.ToString());
            fluxoBancarioDAO.preencheCamposContasAReceber(id);
            popularTextBoxContasAReceber();
            btnArquivarContasAReceber.Visible = true;
            btnInserirContasAReceber.Enabled = false;
            btnAtualizarContasAReceber.Enabled = true;
            btnExcluirContasAReceber.Enabled = true;
        }

        //Método Popular TextBox
        public void popularTextBoxContasAReceber()
        {
            txtDataContasAReceber.Text = fluxoBancarioDAO.getData().ToString("dd/MM/yyyy");
            txtDescricaoContasAReceber.Text = fluxoBancarioDAO.getDescricao();
            txtValorContasAReceber.Text = fluxoBancarioDAO.getReceber().ToString();
            cmbClienteContasAReceber.Text = fluxoBancarioDAO.getDevedor();
        }

//Método Listar Todos
        private void btnListarContasAReceber_Click(object sender, EventArgs e)
        {
            popularGridContasAReceber();
        }

//Método Arquivar Contas a Receber
        private void btnArquivarContasAReceber_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosContasAReceber())
                {
                    bool resposta;
                    try
                    {
                        resposta = fluxoBancarioDAO.arquivarContasAReceber(id);
                        limparCampos();
                        popularGridContasAReceber();
                        if (resposta)
                        {
                            MessageBox.Show("OPERAÇÃO REALIZADA COM SUCESSO", "CONFIRMAÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERRO AO CONCLUIR OPERAÇÃO!", "TENTE NOVAMENTE");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO AO CONCLUIR OPERAÇÃO!", "ERRO");
            }
        }

        //Método Inserir
        private void btnInserirContasAReceber_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosContasAReceber())
                {
                    bool resposta;
                    fluxoBancarioDAO.setDevedor(cmbClienteContasAReceber.Text);
                    fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataContasAReceber.Text));
                    fluxoBancarioDAO.setReceber(Convert.ToDouble(txtValorContasAReceber.Text));
                    fluxoBancarioDAO.setDescricao(txtDescricaoContasAReceber.Text);
                    fluxoBancarioDAO.setStatus(false);

                    try
                    {
                        resposta = fluxoBancarioDAO.inserirContasAReceber();

                        if (resposta)
                        {
                            MessageBox.Show("Conta cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridContasAReceber();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os dados digitados", "ERRO");
            }

        }

        //Método Excluir
        private void btnExcluirContasAReceber_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosContasAReceber())
                {
                    bool resposta;
                    try
                    {
                        resposta = fluxoBancarioDAO.excluirContasAReceber(id);

                        if (resposta)
                        {
                            MessageBox.Show("Conta excluida com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridContasAReceber();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao excluir", "ERRO");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

        //Método Atualizar
        private void btnAtualizarContasAReceber_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosContasAReceber())
                {
                    bool resposta;
                    fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataContasAReceber.Text));
                    fluxoBancarioDAO.setDevedor(cmbClienteContasAReceber.Text);
                    fluxoBancarioDAO.setDescricao(txtDescricaoContasAReceber.Text);
                    fluxoBancarioDAO.setReceber(Convert.ToDouble(txtValorContasAReceber.Text));
                    try
                    {
                        resposta = fluxoBancarioDAO.atualizarContasAReceber(id);
                        limparCampos();
                        popularGridContasAReceber();
                        if (resposta)
                        {
                            MessageBox.Show("Conta atualizada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!", "ATENÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

/*
 * TAB 03 
*/

//Método Sair
        private void btnSairCaixa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método popularGrid()
        public void popularGridCaixa()
        {
            dgrCaixa.DataSource = caixaDAO.listarTodos();
            if (dgrCaixa.Columns.Count > 0)
            {
                dgrCaixa.Columns[0].Width = 80;
                dgrCaixa.Columns[1].Width = 100;
                dgrCaixa.Columns[2].Width = 100;
                dgrCaixa.Columns[3].Width = 100;
                dgrCaixa.Columns[4].Width = 100;
                dgrCaixa.Columns[5].Width = 100;
                dgrCaixa.Columns[6].Width = 100;

                dgrCaixa.Columns[0].HeaderText = "Codigo";
                dgrCaixa.Columns[1].HeaderText = "Data";
                dgrCaixa.Columns[2].HeaderText = "Tipo";
                dgrCaixa.Columns[3].HeaderText = "Valor";
                dgrCaixa.Columns[4].HeaderText = "Finalidade";
                dgrCaixa.Columns[5].HeaderText = "Funcionario";
                dgrCaixa.Columns[6].HeaderText = "Saldo";
            }
        }

//Método popularGridCaixaRelatorio()
        public void popularGridCaixaRelatorio()
        {
            dgrCaixa.DataSource = caixaDAO.listarRelatorio();
            if (dgrCaixa.Columns.Count > 0)
            {
                dgrCaixa.Columns[0].Width = 100;
                dgrCaixa.Columns[1].Width = 100;
                dgrCaixa.Columns[2].Width = 100;
                dgrCaixa.Columns[3].Width = 100;
                dgrCaixa.Columns[4].Width = 100;

                dgrCaixa.Columns[0].HeaderText = "Data";
                dgrCaixa.Columns[1].HeaderText = "Tipo";
                dgrCaixa.Columns[2].HeaderText = "Valor";
                dgrCaixa.Columns[3].HeaderText = "Finalidade";
                dgrCaixa.Columns[4].HeaderText = "Saldo";
            }
        }

//Método cmbFuncionario_TextChanged()
        private void cmbFuncionarioCaixa_TextChanged(object sender, EventArgs e)
        {
            btnInserirCaixa.Enabled = true;
        }

//Metodo para inserir a data atual no textbox
        public void mostraData()
        {
            txtDataCaixa.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

//Método optEntrada_ChekedChanged
        private void optEntradaCaixa_CheckedChanged(object sender, EventArgs e)
        {
            cmbFuncionarioCaixa.Enabled = false;
            btnInserirCaixa.Enabled = true;
            txtFinalidadeCaixa.Enabled = false;
            txtDataCaixa.Enabled = false;
            mostraData();
        }

//Método optEntrada_ChekedChanged
        private void optSaidaCaixa_CheckedChanged(object sender, EventArgs e)
        {
            cmbFuncionarioCaixa.Enabled = true;
            txtFinalidadeCaixa.Enabled = true;
        }

//Método popularComboFuncionario()
        public void popularComboFuncionario()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            cmbFuncionarioCaixa.DataSource = funcionarioDAO.listarTodos();
            cmbFuncionarioCaixa.DisplayMember = "Nome";
            cmbFuncionarioCaixa.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbFuncionarioCaixa.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbFuncionarioCaixa.SelectedIndex = 0;
        }

//Método verificarBrancos()
        public bool verificarBrancosCaixa()
        {
            bool resposta;
            if (optEntradaCaixa.Checked)
            {
                resposta = true;
            }
            else
            {
                if (cmbFuncionarioCaixa.Text == "")
                {
                    resposta = false;
                }
                else
                {
                    resposta = true;
                }
            }
            return resposta;
        }

//Método Popular TextBox
        public void popularTextBoxCaixa()
        {
            txtDataCaixa.Text = caixaDAO.getData().ToString("dd/MM/yyyy");
            txtFinalidadeCaixa.Text = caixaDAO.getFinalidade();
            txtValorCaixa.Text = caixaDAO.getValor().ToString();
            cmbFuncionarioCaixa.Text = caixaDAO.getFuncionario().ToString();
            string tipo = caixaDAO.getTipo();
            
            if (tipo.Equals("entrada"))
            {
                optEntradaCaixa.Checked = true;
                optSaidaCaixa.Checked = false;
            }
            else if (tipo.Equals("saida"))
            {
                optSaidaCaixa.Checked = true;
                optEntradaCaixa.Checked = false;
            }
        }

//Método dgrCaixa_cellDoubleClick()
        private void dgrCaixa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrCaixa.Rows[e.RowIndex].Cells[0].Value.ToString());
                caixaDAO.preencheCamposCaixa(id);
                popularTextBoxCaixa();
                btnInserirCaixa.Enabled = false;
                btnAtualizarCaixa.Enabled = true;
                btnExcluirCaixa.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Operação Inválida","ERRO");
            }
        }

//Método Inserir
        private void btnInserirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCaixa())
                {
                    bool resposta = false;
                    
                    try
                    {
                        if (optEntradaCaixa.Checked)
                        {
                            caixaDAO.setData(Convert.ToDateTime(txtDataCaixa.Text));
                            caixaDAO.setValor(Convert.ToDouble(txtValorCaixa.Text));
                            resposta = caixaDAO.inserirEntradaCaixa();

                            fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataCaixa.Text));
                            fluxoBancarioDAO.setPagar(Convert.ToDouble(txtValorCaixa.Text));
                            fluxoBancarioDAO.inserirEntradaCaixa();
                        }
                        else if (optSaidaCaixa.Checked)
                        {
                            caixaDAO.setFinalidade(txtFinalidadeCaixa.Text);
                            caixaDAO.setFuncionario(cmbFuncionarioCaixa.Text);
                            caixaDAO.setData(Convert.ToDateTime(txtDataCaixa.Text));
                            caixaDAO.setValor(Convert.ToDouble(txtValorCaixa.Text));
                            resposta = caixaDAO.inserirSaidaCaixa();
                        }

                        if (resposta)
                        {
                            MessageBox.Show("Valor cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridCaixa();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação! Por favor, confira os campos");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os dados digitados", "ERRO");
            }
        }

//Método Atualizar
        private void btnAtualizarCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCaixa())
                {
                    bool resposta;
                    caixaDAO.setData(Convert.ToDateTime(txtDataCaixa.Text));
                    caixaDAO.setFinalidade(txtFinalidadeCaixa.Text);
                    caixaDAO.setFuncionario(cmbFuncionarioCaixa.Text);
                    caixaDAO.setValor(Convert.ToDouble(txtValorCaixa.Text));
                    
                    try
                    {
                        resposta = caixaDAO.atualizarCaixa(id);
                        limparCampos();
                        popularGridCaixa();
                        if (resposta)
                        {
                            MessageBox.Show("Valor atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!", "ATENÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

//Método Excluir
        private void btnExcluirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCaixa())
                {
                    bool resposta;
                    try
                    {
                        fluxoBancarioDAO.atualizarSaldoExcluir(id);
                        resposta = caixaDAO.excluirCaixa(id);

                        if (resposta)
                        {
                            MessageBox.Show("Valor excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridCaixa();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao excluir", "ERRO");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

//Método listar
        private void btnListarCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                popularGridCaixa();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao concluir a operação!");
            }
        }

//Método Relatório
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                popularGridCaixaRelatorio();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao concluir operação", "ERRO");
            }
        }

/*
 * TAB 04 
*/

//Método Sair
        private void btnSairCheques_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método verificarBrancos()
        public bool verificarBrancosCheques()
        {
            bool resposta;
            if (txtNumFolha.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método popularGridCheques()
        public void popularGridCheques()
        {
            dgrCheques.DataSource = chequesDAO.listarTodos();
            if (dgrCheques.Columns.Count > 0)
            {
                dgrCheques.Columns[0].Width = 100;
                dgrCheques.Columns[1].Width = 100;
                dgrCheques.Columns[2].Width = 100;
                dgrCheques.Columns[3].Width = 100;

                dgrCheques.Columns[0].HeaderText = "Nº do Cheque";
                dgrCheques.Columns[1].HeaderText = "Data";
                dgrCheques.Columns[2].HeaderText = "Valor";
                dgrCheques.Columns[3].HeaderText = "Finalidade";
            }
        }

//Método txtNumFolha_TextChanged()
        private void txtNumFolha_TextChanged(object sender, EventArgs e)
        {
            btnInserirCheque.Enabled = true;
        }

//Método dgrCheques_CellDoubleClick()
        private void dgrCheques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrCheques.Rows[e.RowIndex].Cells[0].Value.ToString());
                chequesDAO.preencheCamposCheques(id);
                popularTextBoxCheques();
                btnInserirCheque.Enabled = false;
                btnAtualizarCheques.Enabled = true;
                btnExcluirCheque.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Operação Inválida", "ERRO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxCheques()
        {
            txtDataCheque.Text = chequesDAO.getData().ToString("dd/MM/yyyy");
            txtFinalidadeCheque.Text = chequesDAO.getFinalidade();
            txtValorCheque.Text = chequesDAO.getValor().ToString();
            txtNumFolha.Text = chequesDAO.getNumCheque().ToString();
        }

//Método Inserir Cheque
        private void InserirCheque_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCheques())
                {
                    bool resposta;
                    chequesDAO.setData(Convert.ToDateTime(txtDataCheque.Text));
                    chequesDAO.setFinalidade(txtFinalidadeCheque.Text);
                    chequesDAO.setNumCheque(Convert.ToInt16(txtNumFolha.Text));
                    chequesDAO.setValor(Convert.ToDouble(txtValorCheque.Text));

                    try
                    {
                        resposta = chequesDAO.inserirCheque();

                        if (resposta)
                        {
                            //Criando uma conta a pagar
                            fluxoBancarioDAO.setCredor("Cheques");
                            fluxoBancarioDAO.setData(Convert.ToDateTime(txtDataCheque.Text));
                            fluxoBancarioDAO.setDescricao(txtFinalidadeCheque.Text);
                            fluxoBancarioDAO.setPagar(Convert.ToDouble(txtValorCheque.Text));
                            fluxoBancarioDAO.inserirContasAPagar();

                            MessageBox.Show("Cheque cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridCheques();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os dados digitados", "ERRO");
            }
        }

//Método Atualizar Cheques
        private void btnAtualizarCheques_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCheques())
                {
                    bool resposta;
                    chequesDAO.setData(Convert.ToDateTime(txtDataCheque.Text));
                    chequesDAO.setNumCheque(Convert.ToInt16(txtNumFolha.Text));
                    chequesDAO.setFinalidade(txtFinalidadeCheque.Text);
                    chequesDAO.setValor(Convert.ToDouble(txtValorCheque.Text));
                    try
                    {
                        resposta = chequesDAO.atualizarCheque(id);
                        limparCampos();
                        popularGridCheques();
                        if (resposta)
                        {
                            MessageBox.Show("Cheque atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!", "ATENÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

//Método Excluir Cheques
        private void btnExcluirCheque_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCheques())
                {
                    bool resposta;
                    try
                    {
                        resposta = chequesDAO.excluirCheque(id);

                        if (resposta)
                        {
                            MessageBox.Show("Cheque excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGridCheques();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao excluir", "ERRO");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, confira os campos", "ERRO");
            }
        }

//Método Listar Todos
        private void btnListarCheque_Click(object sender, EventArgs e)
        {
            try
            {
                popularGridCheques();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao concluir a operação!");
            }
        }

/*
 * TAB 05 
*/

        //Método btnLimpar_Click()
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dgrFluxoBancario.DataSource = null;
            dgrFluxoBancario.Columns.Clear();
            dgrFluxoBancario.Rows.Clear();
            dgrFluxoBancario.Refresh();
            cmbMesFluxoBancario.Text = "";
            lblSaldo.Text = "";
        }

        //Método btnBuscar_Click()
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string mes = cmbMesFluxoBancario.Text;
            int numMes = selecionaMes(mes);
            try
            {
                dgrFluxoBancario.DataSource = fluxoBancarioDAO.listarTodos(numMes);
                if (dgrFluxoBancario.Columns.Count > 0)
                {
                    dgrFluxoBancario.Columns[0].Width = 220;
                    dgrFluxoBancario.Columns[1].Width = 220;
                    dgrFluxoBancario.Columns[2].Width = 220;

                    dgrFluxoBancario.Columns[0].HeaderText = "Data";
                    dgrFluxoBancario.Columns[1].HeaderText = "Saída";
                    dgrFluxoBancario.Columns[2].HeaderText = "Entrada";

                    lblSaldo.Text = fluxoBancarioDAO.consultarSaldoAtual().ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO AO EXECUTAR CONSULTA", "ERRO NA EXECUÇÃO");
            }
        }

        //Método Sair
        private void btnSairFluxoBancario_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //Método popularGrid()
        public void popularGridFluxoBancario(string mes)
        {
            int numMes = selecionaMes(mes);
            dgrFluxoBancario.DataSource = fluxoBancarioDAO.listarTodos(numMes);
            if (dgrFluxoBancario.Columns.Count > 0)
            {
                dgrFluxoBancario.Columns[0].Width = 100;
                dgrFluxoBancario.Columns[1].Width = 100;
                dgrFluxoBancario.Columns[2].Width = 100;
                dgrFluxoBancario.Columns[3].Width = 100;

                dgrFluxoBancario.Columns[0].HeaderText = "Data";
                dgrFluxoBancario.Columns[1].HeaderText = "Saída";
                dgrFluxoBancario.Columns[2].HeaderText = "Entrada";
                dgrFluxoBancario.Columns[3].HeaderText = "Saldo da Conta";
            }
        }

        //Método Seleciona Mês
        public int selecionaMes(string mes)
        {
            int numMes = 1;

            if (mes.Equals("Janeiro"))
            {
                numMes = 1;
            }
            else if (mes.Equals("Fevereiro"))
            {
                numMes = 2;
            }
            else if (mes.Equals("Março"))
            {
                numMes = 3;
            }
            else if (mes.Equals("Abril"))
            {
                numMes = 4;
            }
            else if (mes.Equals("Maio"))
            {
                numMes = 5;
            }
            else if (mes.Equals("Junho"))
            {
                numMes = 6;
            }
            else if (mes.Equals("Julho"))
            {
                numMes = 7;
            }
            else if (mes.Equals("Agosto"))
            {
                numMes = 8;
            }
            else if (mes.Equals("Setembro"))
            {
                numMes = 9;
            }
            else if (mes.Equals("Outubro"))
            {
                numMes = 10;
            }
            else if (mes.Equals("Novembro"))
            {
                numMes = 11;
            }
            else if (mes.Equals("Dezembro"))
            {
                numMes = 12;
            }

            return numMes;
        }

/*
 * TAB 6
*/

//Método Consultar Saldo 
        public void consultarContaCorrente()
        {
            try
            {
                double saldo = fluxoBancarioDAO.consultarSaldoAtual();
                txtSaldoAtual.Text = saldo.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO AO EXECUTAR CONSULTA", "ERRO NA EXECUÇÃO");
            }
        }

//Método Page Click
        private void tabControl1_Click(object sender, EventArgs e)
        {
            consultarContaCorrente();
        }

//Método Sair
        private void btnSairContaCorrente_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}