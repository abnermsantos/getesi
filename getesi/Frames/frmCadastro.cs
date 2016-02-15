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
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        VeiculoDAO veiculoDAO = new VeiculoDAO();
        FornecedorDAO fornecedorDAO = new FornecedorDAO();
        ClienteDAO clienteDAO = new ClienteDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        int id;
        private static frmCadastro instance;

//Método getInstance()
        public static frmCadastro getInstance()
        {
            if (instance == null)
            {
                instance = new frmCadastro();
            }
            return instance;
        }

//Método FormClosing
        private void frmCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

/*
 * TAB 1
*/

//Método popularGrid()
        public void popularGridFuncionario()
        {
            dgrFuncionario.DataSource = funcionarioDAO.listarTodos();
            if (dgrFornecedor.Columns.Count > 0)
            {
                dgrFuncionario.Columns[0].Width = 80;
                dgrFuncionario.Columns[1].Width = 100;
                dgrFuncionario.Columns[2].Width = 100;
                dgrFuncionario.Columns[3].Width = 100;
                dgrFuncionario.Columns[4].Width = 100;

                dgrFuncionario.Columns[1].HeaderText = "Codigo";
                dgrFuncionario.Columns[1].HeaderText = "Nome";
                dgrFuncionario.Columns[2].HeaderText = "CPF";
                dgrFuncionario.Columns[3].HeaderText = "RG";
                dgrFuncionario.Columns[4].HeaderText = "Celular";
            }
        }

//Método verificarBrancos()
        public bool verificarBrancosFuncionario()
        {
            bool resposta;
            if (txtNomeFuncionario.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método Limpar Campos
        public void limparFuncionario()
        {
            txtNomeFuncionario.Text = "";
            txtCpfFuncionario.Text = "";
            txtRgFuncionario.Text = "";
            txtCelularFuncionario.Text = "";
            txtTelefoneFuncionario.Text = "";
            cmbSexoFuncionario.Text = "";
            txtAdmissaoFuncionario.Text = "";
            txtNascimentoFuncionario.Text = "";
            txtCargoFuncionario.Text = "";
            txtSalarioFuncionario.Text = "";
            txtRuaFuncionario.Text = "";
            txtNumeroFuncionario.Text = "";
            txtBairroFuncionario.Text = "";
            txtCepFuncionario.Text = "";
            txtCidadeFuncionario.Text = "";
            cmbUfFuncionario.Text = "";
        }

//Método txtNome Text Changed
        private void txtNomeFuncionario_TextChanged(object sender, EventArgs e)
        {
            btnInserirFuncionario.Enabled = true;
        }

//Método Cell Double Click
        private void dgrFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrFuncionario.Rows[e.RowIndex].Cells[0].Value.ToString());
                funcionarioDAO.preencheCamposFuncionario(id);
                popularTextBoxFuncionario();
                btnInserirFuncionario.Enabled = false;
                btnAtualizarFuncionario.Enabled = true;
                btnExcluirFuncionario.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("OPERAÇÃO INVÁLIDA", "ATEÇÃO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxFuncionario()
        {
            txtNomeFuncionario.Text = funcionarioDAO.getNome();
            txtCpfFuncionario.Text = funcionarioDAO.getCpf();
            txtRgFuncionario.Text = funcionarioDAO.getRg();
            txtCelularFuncionario.Text = funcionarioDAO.getCelular();
            txtTelefoneFuncionario.Text = funcionarioDAO.getTelefone();
            cmbSexoFuncionario.Text = funcionarioDAO.getSexo();
            txtAdmissaoFuncionario.Text = funcionarioDAO.getAdmissao().ToString();
            txtNascimentoFuncionario.Text = funcionarioDAO.getDataNasc().ToString();
            txtCargoFuncionario.Text = funcionarioDAO.getCargo();
            txtSalarioFuncionario.Text = funcionarioDAO.getSalario().ToString();
            txtRuaFuncionario.Text = funcionarioDAO.getRua();
            txtNumeroFuncionario.Text = funcionarioDAO.getNumero().ToString();
            txtBairroFuncionario.Text = funcionarioDAO.getBairro();
            txtCepFuncionario.Text = funcionarioDAO.getCep();
            txtCidadeFuncionario.Text = funcionarioDAO.getCidade();
            cmbUfFuncionario.Text = funcionarioDAO.getUf();
        }

//Método Listar Todos
        private void btnListarFuncionario_Click(object sender, EventArgs e)
        {
            popularGridFuncionario();
        }

//Método Inserir
        private void btnInserirFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFuncionario())
                {
                    bool resposta;
                    funcionarioDAO.setNome(txtNomeFuncionario.Text);
                    funcionarioDAO.setCpf(txtCpfFuncionario.Text);
                    funcionarioDAO.setRg(txtRgFuncionario.Text);
                    funcionarioDAO.setSexo(cmbSexoFuncionario.Text);
                    funcionarioDAO.setCelular(txtCelularFuncionario.Text);
                    funcionarioDAO.setTelefone(txtTelefoneFuncionario.Text);
                    funcionarioDAO.setAdmissao(Convert.ToDateTime(txtAdmissaoFuncionario.Text));
                    funcionarioDAO.setDataNasc(Convert.ToDateTime(txtNascimentoFuncionario.Text)); 
                    funcionarioDAO.setCargo(txtCargoFuncionario.Text);
                    funcionarioDAO.setSalario(Convert.ToDouble(txtSalarioFuncionario.Text));
                    funcionarioDAO.setRua(txtRuaFuncionario.Text);
                    funcionarioDAO.setNumero(Convert.ToInt16(txtNumeroFuncionario.Text));
                    funcionarioDAO.setBairro(txtBairroFuncionario.Text);
                    funcionarioDAO.setCep(txtCepFuncionario.Text);
                    funcionarioDAO.setCidade(txtCidadeFuncionario.Text);
                    funcionarioDAO.setUf(cmbUfFuncionario.Text);

                    try
                    {
                        resposta = funcionarioDAO.inserirFuncionario();

                        if (resposta)
                        {
                            MessageBox.Show("Funcionario cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparFuncionario();
                            popularGridFuncionario();
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

//Método Atualizar
        private void btnAtualizarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFuncionario())
                {
                    bool resposta;
                    funcionarioDAO.setNome(txtNomeFuncionario.Text);
                    funcionarioDAO.setCpf(txtCpfFuncionario.Text);
                    funcionarioDAO.setRg(txtRgFuncionario.Text);
                    funcionarioDAO.setSexo(cmbSexoFuncionario.Text);
                    funcionarioDAO.setCelular(txtCelularFuncionario.Text);
                    funcionarioDAO.setTelefone(txtTelefoneFuncionario.Text);
                    funcionarioDAO.setAdmissao(Convert.ToDateTime(txtAdmissaoFuncionario.Text));
                    funcionarioDAO.setDataNasc(Convert.ToDateTime(txtNascimentoFuncionario.Text));
                    funcionarioDAO.setCargo(txtCargoFuncionario.Text);
                    funcionarioDAO.setSalario(Convert.ToDouble(txtSalarioFuncionario.Text));
                    funcionarioDAO.setRua(txtRuaFuncionario.Text);
                    funcionarioDAO.setNumero(Convert.ToInt16(txtNumeroFuncionario.Text));
                    funcionarioDAO.setBairro(txtBairroFuncionario.Text);
                    funcionarioDAO.setCep(txtCepFuncionario.Text);
                    funcionarioDAO.setCidade(txtCidadeFuncionario.Text);
                    funcionarioDAO.setUf(cmbUfFuncionario.Text);

                    try
                    {
                        resposta = funcionarioDAO.atualizarFuncionario(id);
                        limparFuncionario();
                        popularGridFuncionario();
                        if (resposta)
                        {
                            MessageBox.Show("Funcionário atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void btnExcluirFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFuncionario())
                {
                    bool resposta;
                    try
                    {
                        resposta = funcionarioDAO.excluirFuncionario(id);

                        if (resposta)
                        {
                            MessageBox.Show("Funcionário excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparFuncionario();
                            popularGridFuncionario();
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

/*
 * TAB 2
*/

//Método popularGrid()
        public void popularGridCliente()
        {
            dgrCliente.DataSource = clienteDAO.listarTodos();
            if (dgrFornecedor.Columns.Count > 0)
            {
                dgrCliente.Columns[0].Width = 80;
                dgrCliente.Columns[1].Width = 100;
                dgrCliente.Columns[2].Width = 100;
                dgrCliente.Columns[3].Width = 100;
                dgrCliente.Columns[4].Width = 100;

                dgrCliente.Columns[1].HeaderText = "Codigo";
                dgrCliente.Columns[1].HeaderText = "Nome";
                dgrCliente.Columns[2].HeaderText = "CNPJ";
                dgrCliente.Columns[3].HeaderText = "IE";
                dgrCliente.Columns[4].HeaderText = "Contato";
            }
        }

//Método verificarBrancos()
        public bool verificarBrancosCliente()
        {
            bool resposta;
            if (txtNomeCliente.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método Limpar Campos
        public void limparCliente()
        {
            txtNomeCliente.Text = "";
            txtCnpjCliente.Text = "";
            txtIeCliente.Text = "";
            txtContatoCliente.Text = "";
            txtEmailCliente.Text = "";
            txtSiteCliente.Text = "";
            txtTelefoneCliente.Text = "";
            txtRuaCliente.Text = "";
            txtNumeroCliente.Text = "";
            txtBairroCliente.Text = "";
            txtCepCliente.Text = "";
            txtCidadeCliente.Text = "";
            cmbUfCliente.Text = "";
        }

//Método txtNome Text Changed
        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            btnInserirCliente.Enabled = true;
        }

//Método Cell Double Click
        private void dgrCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrCliente.Rows[e.RowIndex].Cells[0].Value.ToString());
                clienteDAO.preencheCamposCliente(id);
                popularTextBoxCliente();
                btnInserirCliente.Enabled = false;
                btnAtualizarCliente.Enabled = true;
                btnExcluirCliente.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("OPERAÇÃO INVÁLIDA","ATEÇÃO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxCliente()
        {
            txtNomeCliente.Text = clienteDAO.getNome();
            txtCnpjCliente.Text = clienteDAO.getCnpj();
            txtIeCliente.Text = clienteDAO.getIe();
            txtContatoCliente.Text = clienteDAO.getContato();
            txtEmailCliente.Text = clienteDAO.getEmail();
            txtSiteCliente.Text = clienteDAO.getSite();
            txtTelefoneCliente.Text = clienteDAO.getTelefone();
            txtRuaCliente.Text = clienteDAO.getRua();
            txtNumeroCliente.Text = clienteDAO.getNumero().ToString();
            txtBairroCliente.Text = clienteDAO.getBairro();
            txtCepCliente.Text = clienteDAO.getCep();
            txtCidadeCliente.Text = clienteDAO.getCidade();
            cmbUfCliente.Text = clienteDAO.getUf();
        }

//Método Listar Todos
        private void btnListarCliente_Click(object sender, EventArgs e)
        {
            popularGridCliente();
        }

//Método Inserir 
        private void btnInserirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCliente())
                {
                    bool resposta;
                    clienteDAO.setNome(txtNomeCliente.Text);
                    clienteDAO.setCnpj(txtCnpjCliente.Text);
                    clienteDAO.setIe(txtIeCliente.Text);
                    clienteDAO.setContato(txtContatoCliente.Text);
                    clienteDAO.setTelefone(txtTelefoneCliente.Text);
                    clienteDAO.setEmail(txtEmailCliente.Text);
                    clienteDAO.setSite(txtSiteCliente.Text);
                    clienteDAO.setRua(txtRuaCliente.Text);
                    clienteDAO.setNumero(Convert.ToInt16(txtNumeroCliente.Text));
                    clienteDAO.setBairro(txtBairroCliente.Text);
                    clienteDAO.setCep(txtCepCliente.Text);
                    clienteDAO.setCidade(txtCidadeCliente.Text);
                    clienteDAO.setUf(cmbUfCliente.Text);

                    try
                    {
                        resposta = clienteDAO.inserirCliente();

                        if (resposta)
                        {
                            MessageBox.Show("Cliente cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCliente();
                            popularGridCliente();
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

//Método Atualizar
        private void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCliente())
                {
                    bool resposta;
                    clienteDAO.setNome(txtNomeCliente.Text);
                    clienteDAO.setCnpj(txtCnpjCliente.Text);
                    clienteDAO.setIe(txtIeCliente.Text);
                    clienteDAO.setContato(txtContatoCliente.Text);
                    clienteDAO.setTelefone(txtTelefoneCliente.Text);
                    clienteDAO.setEmail(txtEmailCliente.Text);
                    clienteDAO.setSite(txtSiteCliente.Text);
                    clienteDAO.setRua(txtRuaCliente.Text);
                    clienteDAO.setNumero(Convert.ToInt16(txtNumeroCliente.Text));
                    clienteDAO.setBairro(txtBairroCliente.Text);
                    clienteDAO.setCep(txtCepCliente.Text);
                    clienteDAO.setCidade(txtCidadeCliente.Text);
                    clienteDAO.setUf(cmbUfCliente.Text);
                    
                    try
                    {
                        resposta = clienteDAO.atualizarCliente(id);
                        limparCliente();
                        popularGridCliente();
                        if (resposta)
                        {
                            MessageBox.Show("Cliente atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCliente())
                {
                    bool resposta;
                    try
                    {
                        resposta = clienteDAO.excluirCliente(id);

                        if (resposta)
                        {
                            MessageBox.Show("Cliente excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCliente();
                            popularGridCliente();
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

/*
 * TAB 3
*/

//Método popularGrid()
        public void popularGridFornecedor()
        {
            dgrFornecedor.DataSource = fornecedorDAO.listarTodos();
            if (dgrFornecedor.Columns.Count > 0)
            {
                dgrFornecedor.Columns[0].Width = 80;
                dgrFornecedor.Columns[1].Width = 100;
                dgrFornecedor.Columns[2].Width = 100;
                dgrFornecedor.Columns[3].Width = 100;
                dgrFornecedor.Columns[4].Width = 100;

                dgrFornecedor.Columns[1].HeaderText = "Codigo";
                dgrFornecedor.Columns[1].HeaderText = "Nome";
                dgrFornecedor.Columns[2].HeaderText = "CNPJ";
                dgrFornecedor.Columns[3].HeaderText = "IE";
                dgrFornecedor.Columns[4].HeaderText = "Contato";
            }
        }

//Método verificarBrancos()
        public bool verificarBrancosFornecedor()
        {
            bool resposta;
            if (txtNomeFornecedor.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método Limpar Campos
        public void limparFornecedor()
        {
            txtNomeFornecedor.Text = "";
            txtCnpjFornecedor.Text = "";
            txtIeFornecedor.Text = "";
            txtContatoFornecedor.Text = "";
            txtEmailFornecedor.Text = "";
            txtSiteFornecedor.Text = "";
            txtTelefoneFornecedor.Text = "";
            txtRuaFornecedor.Text = "";
            txtNumeroFornecedor.Text = "";
            txtBairroFornecedor.Text = "";
            txtCepFornecedor.Text = "";
            txtCidadeFornecedor.Text = "";
            cmbUfFornecedor.Text = "";
        }

//Método txtNome Text Changed
        private void txtNomeFornecedor_TextChanged(object sender, EventArgs e)
        {
            btnInserirFornecedor.Enabled = true;
        }

//Método Cell Double Click
        private void dgrFornecedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrFornecedor.Rows[e.RowIndex].Cells[0].Value.ToString());
                fornecedorDAO.preencheCamposFornecedor(id);
                popularTextBoxFornecedor();
                btnInserirFornecedor.Enabled = false;
                btnAtualizarFornecedor.Enabled = true;
                btnExcluirFornecedor.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("OPERAÇÃO INVÁLIDA","ATEÇÃO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxFornecedor()
        {
            txtNomeFornecedor.Text = fornecedorDAO.getNome();
            txtCnpjFornecedor.Text = fornecedorDAO.getCnpj();
            txtIeFornecedor.Text = fornecedorDAO.getIe();
            txtContatoFornecedor.Text = fornecedorDAO.getContato();
            txtEmailFornecedor.Text = fornecedorDAO.getEmail();
            txtSiteFornecedor.Text = fornecedorDAO.getSite();
            txtTelefoneFornecedor.Text = fornecedorDAO.getTelefone();
            txtRuaFornecedor.Text = fornecedorDAO.getRua();
            txtNumeroFornecedor.Text = fornecedorDAO.getNumero().ToString();
            txtBairroFornecedor.Text = fornecedorDAO.getBairro();
            txtCepFornecedor.Text = fornecedorDAO.getCep();
            txtCidadeFornecedor.Text = fornecedorDAO.getCidade();
            cmbUfFornecedor.Text = fornecedorDAO.getUf();
        }

//Método Listar Todos
        private void btnListarFornecedor_Click(object sender, EventArgs e)
        {
            popularGridFornecedor();
        }

//Método Inserir
        private void btnInserirFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFornecedor())
                {
                    bool resposta;
                    fornecedorDAO.setNome(txtNomeFornecedor.Text);
                    fornecedorDAO.setCnpj(txtCnpjFornecedor.Text);
                    fornecedorDAO.setIe(txtIeFornecedor.Text);
                    fornecedorDAO.setContato(txtContatoFornecedor.Text);
                    fornecedorDAO.setTelefone(txtTelefoneFornecedor.Text);
                    fornecedorDAO.setEmail(txtEmailFornecedor.Text);
                    fornecedorDAO.setSite(txtSiteFornecedor.Text);
                    fornecedorDAO.setRua(txtRuaFornecedor.Text);
                    fornecedorDAO.setNumero(Convert.ToInt16(txtNumeroFornecedor.Text));
                    fornecedorDAO.setBairro(txtBairroFornecedor.Text);
                    fornecedorDAO.setCep(txtCepFornecedor.Text);
                    fornecedorDAO.setCidade(txtCidadeFornecedor.Text);
                    fornecedorDAO.setUf(cmbUfFornecedor.Text);

                    try
                    {
                        resposta = fornecedorDAO.inserirFornecedor();

                        if (resposta)
                        {
                            MessageBox.Show("Fornecedor cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparFornecedor();
                            popularGridFornecedor();
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

//Método Atualizar
        private void btnAtualizarFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFornecedor())
                {
                    bool resposta;
                    fornecedorDAO.setNome(txtNomeFornecedor.Text);
                    fornecedorDAO.setCnpj(txtCnpjFornecedor.Text);
                    fornecedorDAO.setIe(txtIeFornecedor.Text);
                    fornecedorDAO.setContato(txtContatoFornecedor.Text);
                    fornecedorDAO.setTelefone(txtTelefoneFornecedor.Text);
                    fornecedorDAO.setEmail(txtEmailFornecedor.Text);
                    fornecedorDAO.setSite(txtSiteFornecedor.Text);
                    fornecedorDAO.setRua(txtRuaFornecedor.Text);
                    fornecedorDAO.setNumero(Convert.ToInt16(txtNumeroFornecedor.Text));
                    fornecedorDAO.setBairro(txtBairroFornecedor.Text);
                    fornecedorDAO.setCep(txtCepFornecedor.Text);
                    fornecedorDAO.setCidade(txtCidadeFornecedor.Text);
                    fornecedorDAO.setUf(cmbUfFornecedor.Text);

                    try
                    {
                        resposta = fornecedorDAO.atualizarFornecedor(id);
                        limparFornecedor();
                        popularGridFornecedor();
                        if (resposta)
                        {
                            MessageBox.Show("Fornecedor atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void btnExcluirFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosFornecedor())
                {
                    bool resposta;
                    try
                    {
                        resposta = fornecedorDAO.excluirFornecedor(id);

                        if (resposta)
                        {
                            MessageBox.Show("Fornecedor excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparFornecedor();
                            popularGridFornecedor();
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

/*
 * TAB 4
*/

//Método popularGrid()
        public void popularGridVeiculo()
        {
            dgrVeiculo.DataSource = veiculoDAO.listarTodos();
            if (dgrUsuario.Columns.Count > 0)
            {
                dgrVeiculo.Columns[0].Width = 80;
                dgrVeiculo.Columns[1].Width = 100;
                dgrVeiculo.Columns[2].Width = 100;
                dgrVeiculo.Columns[3].Width = 100;
                dgrVeiculo.Columns[4].Width = 100;

                dgrUsuario.Columns[1].HeaderText = "Codigo";
                dgrUsuario.Columns[1].HeaderText = "Placa";
                dgrUsuario.Columns[2].HeaderText = "Nome";
                dgrUsuario.Columns[3].HeaderText = "Fabricante";
                dgrUsuario.Columns[4].HeaderText = "Ano";
            }
        }

//Método verificarBrancos()
        public bool verificarBrancosVeiculo()
        {
            bool resposta;
            if ((txtPlacaVeiculo.Text == "") && (txtNomeVeiculo.Text == ""))
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método Limpar Campos
        public void limparVeiculo()
        {
            txtNomeVeiculo.Text = "";
            txtPlacaVeiculo.Text = "";
            cmbFabricanteVeiculo.Text = "";
            cmbAnoVeiculo.Text = "";
        }

//Método txtPlaca Text Changed
        private void txtPlacaVeiculo_TextChanged(object sender, EventArgs e)
        {
            btnInserirVeiculo.Enabled = true;
        }

//Método Cell Double Click
        private void dgrVeiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrVeiculo.Rows[e.RowIndex].Cells[0].Value.ToString());
                veiculoDAO.preencheCamposVeiculo(id);
                popularTextBoxVeiculo();
                btnInserirVeiculo.Enabled = false;
                btnAtualizarVeiculo.Enabled = true;
                btnExcluirVeiculo.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("OPERAÇÃO INVÁLIDA", "ATEÇÃO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxVeiculo()
        {
            txtNomeVeiculo.Text = veiculoDAO.getNome();
            cmbFabricanteVeiculo.Text = veiculoDAO.getFabricante();
            txtPlacaVeiculo.Text = veiculoDAO.getPlaca();
            cmbAnoVeiculo.Text = veiculoDAO.getAno().ToString();
        }

//Método Listar
        private void btnListarVeiculo_Click(object sender, EventArgs e)
        {
            popularGridVeiculo();
        }

//Método Inserir
        private void btnInserirVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosVeiculo())
                {
                    bool resposta;
                    veiculoDAO.setNome(txtNomeVeiculo.Text);
                    veiculoDAO.setFabricante(cmbFabricanteVeiculo.Text);
                    veiculoDAO.setPlaca(txtPlacaVeiculo.Text);
                    veiculoDAO.setAno(Convert.ToInt16(cmbAnoVeiculo.Text));

                    try
                    {
                        resposta = veiculoDAO.inserirVeiculo();

                        if (resposta)
                        {
                            MessageBox.Show("Veiculo cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparVeiculo();
                            popularGridVeiculo();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro" , "ERRO NA EXECUÇÃO");
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
        private void btnAtualizarVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosVeiculo())
                {
                    bool resposta;
                    veiculoDAO.setNome(txtNomeVeiculo.Text);
                    veiculoDAO.setFabricante(cmbFabricanteVeiculo.Text);
                    veiculoDAO.setPlaca(txtPlacaVeiculo.Text);
                    veiculoDAO.setAno(Convert.ToInt16(cmbAnoVeiculo.Text));

                    try
                    {
                        resposta = veiculoDAO.atualizarVeiculo(id);
                        limparVeiculo();
                        popularGridVeiculo();
                        if (resposta)
                        {
                            MessageBox.Show("Veiculo atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void btnExcluirVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosVeiculo())
                {
                    bool resposta;
                    try
                    {
                        resposta = veiculoDAO.excluirVeiculo(id);

                        if (resposta)
                        {
                            MessageBox.Show("Veiculo excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparVeiculo();
                            popularGridVeiculo();
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

/*
 * TAB 5
*/

//Método popularGrid()
        public void popularGridUsuario()
        {
            dgrUsuario.DataSource = usuarioDAO.listarTodos();
            if (dgrUsuario.Columns.Count > 0)
            {
                dgrUsuario.Columns[0].Width = 80;
                dgrUsuario.Columns[1].Width = 100;
                dgrUsuario.Columns[2].Width = 100;
                dgrUsuario.Columns[3].Width = 100;

                dgrUsuario.Columns[1].HeaderText = "Codigo";
                dgrUsuario.Columns[1].HeaderText = "Usuario";
                dgrUsuario.Columns[2].HeaderText = "Senha";
                dgrUsuario.Columns[3].HeaderText = "Categoria";
            }
        }

//Método verificarBrancos()
        public bool verificarBrancosUsuario()
        {
            bool resposta;
            if ((txtLogin.Text == "") && (txtSenha.Text == "") && (cmbCategoria.Text == ""))
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método Limpar Campos
        public void limparUsuario()
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
            cmbCategoria.Text = "";
        }

//Método cmbCategoria Select Index Changed
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInserirUsuario.Enabled = true;
        }

//Método Cell Double Click
        private void dgrUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt16(dgrUsuario.Rows[e.RowIndex].Cells[0].Value.ToString());
                usuarioDAO.preencheCamposUsuario(id);
                popularTextBoxUsuario();
                btnInserirUsuario.Enabled = false;
                btnAtualizarUsuario.Enabled = true;
                btnExcluirUsuario.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("OPERAÇÃO INVÁLIDA", "ATEÇÃO");
            }
        }

//Método Popular TextBox
        public void popularTextBoxUsuario()
        {
            txtLogin.Text = usuarioDAO.getUsuario();
            txtSenha.Text = usuarioDAO.getSenha();
            cmbCategoria.Text = usuarioDAO.getCategoria().ToString();
        }

//Método Listar Todos
        private void btnListarUsuario_Click(object sender, EventArgs e)
        {
            popularGridUsuario();
        }

//Método Inserir
        private void btnInserirUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosUsuario())
                {
                    bool resposta;
                    usuarioDAO.setUsuario(txtLogin.Text);
                    usuarioDAO.setSenha(txtSenha.Text);
                    usuarioDAO.setCategoria(Convert.ToInt16(cmbCategoria.Text));

                    try
                    {
                        resposta = usuarioDAO.inserirUsuario();

                        if (resposta)
                        {
                            MessageBox.Show("Usuario cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparUsuario();
                            popularGridUsuario();
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

//Método Atualizar
        private void btnAtualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosUsuario())
                {
                    bool resposta;
                    usuarioDAO.setUsuario(txtLogin.Text);
                    usuarioDAO.setSenha(txtSenha.Text);
                    usuarioDAO.setCategoria(Convert.ToInt16(cmbCategoria.Text));
                    
                    try
                    {
                        resposta = usuarioDAO.atualizarUsuario(id);
                        limparUsuario();
                        popularGridUsuario();
                        if (resposta)
                        {
                            MessageBox.Show("Usuario atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosUsuario())
                {
                    bool resposta;
                    try
                    {
                        resposta = usuarioDAO.excluirUsuario(id);

                        if (resposta)
                        {
                            MessageBox.Show("Usuario excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparUsuario();
                            popularGridUsuario();
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
    }
}
