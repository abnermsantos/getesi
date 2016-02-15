/*
 * Classe utilizada para ser a interface do estoque para o usuario. Possui um estilo de "abas", sendo no total 3.
 * Cada "ABA" possui seus métodos específicos separados por comentários no código. Os métodos são de fácil compreenção
 * e estão com os comentários necessários para localização e entendimento.
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
    public partial class frmEstoque : Form
    {
        EstoqueDAO objEstoque = new EstoqueDAO();
        int id; 

//Construtor da Classe
        public frmEstoque()
        {
            InitializeComponent();
            mostraData();
            popularComboFornecedor();
        }

        private static frmEstoque instance;

//Método getInstance()
        public static frmEstoque getInstance()
        {
            if (instance == null)
            {
                instance = new frmEstoque();
            }
            return instance;
        }

//Método FormClosing
        private void frmEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

//Método limparCampos()
        private void limparCampos()
        {
            txtCodEntrada.Text = "";
            txtCodigo.Text = "";
            txtCodSaida.Text = "";
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtNomeEntrada.Text = "";
            txtNomeSaida.Text = "";
            txtQtdEntrada.Text = "";
            txtQtdExistente.Text = "";
            txtQtdMinima.Text = "";
            txtQtdSaida.Text = "";
            txtValor.Text = "";
        }

//Metodo para inserir a data atual no textbox
        public void mostraData()
        {
            txtData.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtDataSaida.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

/*
 * INICIO DA TAB 1 
*/

//Método Listar todos
        private void btnListarMateriais_Click(object sender, EventArgs e)
        {
            popularGrid();
        }

//Método popularGrid()
        public void popularGrid()
        {
            dgrMaterial.DataSource = objEstoque.listarTodos();
            if (dgrMaterial.DataSource.Equals(null))
            {
                btnAtualizar.Enabled = false;
            }
            if (dgrMaterial.Columns.Count > 0)
            {
                dgrMaterial.Columns[0].Width = 80;
                dgrMaterial.Columns[1].Width = 100;
                dgrMaterial.Columns[2].Width = 100;
                dgrMaterial.Columns[3].Width = 100;
                dgrMaterial.Columns[4].Width = 100;
                dgrMaterial.Columns[5].Width = 100;
                dgrMaterial.Columns[6].Width = 100;

                dgrMaterial.Columns[0].HeaderText = "Código";
                dgrMaterial.Columns[1].HeaderText = "Nome";
                dgrMaterial.Columns[2].HeaderText = "Quantidade Estoque";
                dgrMaterial.Columns[3].HeaderText = "Quantidade Mínima";
                dgrMaterial.Columns[4].HeaderText = "Descrição";
                dgrMaterial.Columns[5].HeaderText = "Valor";
                dgrMaterial.Columns[6].HeaderText = "Fornecedor";
            }
        }

//Metodo Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método txtNome_TextChanged()
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            dgrMaterial.DataSource = objEstoque.listarTodos(nome);

            btnInserir.Enabled = true;
        }
        
//Método verificarBrancos()
        public bool verificarBrancos()
        {
            bool resposta;
            if (txtNome.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método popularComboFornecedor()
        public void popularComboFornecedor()
        {
            FornecedorDAO fornecedor = new FornecedorDAO();
            cmbFornecedor.DataSource = fornecedor.listarTodos();
            cmbFornecedor.DisplayMember = "Nome";
            cmbFornecedor.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbFornecedor.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbFornecedor.SelectedIndex = 0;
        }

//Método dgrMaterial_CellDoubleClick()
        private void dgrMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrMaterial.Rows[e.RowIndex].Cells[0].Value.ToString());
            objEstoque.preencheCampos(id);
            popularTextBox();
            btnInserir.Enabled = false;
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
        }

//Método popularTextBox()
        private void popularTextBox()
        {
            txtCodigo.Text = Convert.ToString(id);
            txtNome.Text = objEstoque.getNome();
            txtDescricao.Text = objEstoque.getDescricao();
            txtQtdExistente.Text = objEstoque.getAtual().ToString();
            txtQtdMinima.Text = objEstoque.getMinimo().ToString();
            txtValor.Text = objEstoque.getValor().ToString();
            cmbFornecedor.Text = objEstoque.getFornecedor();
        }

//Método btnAtualizar_Click()
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    objEstoque.setNome(txtNome.Text);
                    objEstoque.setFornecedor(cmbFornecedor.Text);
                    objEstoque.setDescricao(txtDescricao.Text);
                    objEstoque.setValor(Convert.ToDouble(txtValor.Text));
                    objEstoque.setAtual(Convert.ToInt16(txtQtdExistente.Text));
                    objEstoque.setMinimo(Convert.ToInt16(txtQtdMinima.Text));
                    try
                    {
                        resposta = objEstoque.atualizarProduto(id);
                        limparCampos();
                        popularGrid();
                        if (resposta)
                        {
                            MessageBox.Show("Produto atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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
//Método btnInserir_Click_1()
        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    objEstoque.setCodigo(Convert.ToInt16(txtCodigo.Text));
                    objEstoque.setNome(txtNome.Text);
                    objEstoque.setDescricao(txtDescricao.Text);
                    objEstoque.setValor(Convert.ToDouble(txtValor.Text));
                    objEstoque.setFornecedor(cmbFornecedor.Text);
                    objEstoque.setAtual(Convert.ToInt16(txtQtdExistente.Text));
                    objEstoque.setMinimo(Convert.ToInt16(txtQtdMinima.Text));
                    
                    try
                    {
                        resposta = objEstoque.inserir();

                        if (resposta)
                        {
                            MessageBox.Show("Produto cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGrid();
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

//Método btnExcluir_Click()
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos())
                {
                    bool resposta;
                    try
                    {
                        resposta = objEstoque.excluir(id);

                        if (resposta)
                        {
                            MessageBox.Show("Produto excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCampos();
                            popularGrid();
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
 * INICIO DA TAB 2 
*/
        
//Método popularGrid2()
        public void popularGrid2()
        {
            dgrProdutosEntrada.DataSource = objEstoque.listarTodos();
            if (dgrProdutosEntrada.Columns.Count > 0)
            {
                dgrProdutosEntrada.Columns[0].Width = 80;
                dgrProdutosEntrada.Columns[1].Width = 100;
                dgrProdutosEntrada.Columns[2].Width = 100;
                dgrProdutosEntrada.Columns[3].Width = 100;
                dgrProdutosEntrada.Columns[4].Width = 100;
                dgrProdutosEntrada.Columns[5].Width = 100;
                dgrProdutosEntrada.Columns[6].Width = 100;

                dgrProdutosEntrada.Columns[0].HeaderText = "Código";
                dgrProdutosEntrada.Columns[1].HeaderText = "Nome";
                dgrProdutosEntrada.Columns[2].HeaderText = "Quantidade Mínima";
                dgrProdutosEntrada.Columns[3].HeaderText = "Quantidade Estoque";
                dgrProdutosEntrada.Columns[4].HeaderText = "Descrição";
                dgrProdutosEntrada.Columns[5].HeaderText = "Valor";
                dgrProdutosEntrada.Columns[6].HeaderText = "Fornecedor";
            }
        }
        
//Metodo Sair
        private void btnSairEntrada_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//Método txtNomeEntrada_TextChanged()
        private void txtNomeEntrada_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNomeEntrada.Text;
            dgrProdutosEntrada.DataSource = objEstoque.listarTodos(nome);
        }

//Método txtQtdEntrada_TextChanged()
        private void txtQtdEntrada_TextChanged(object sender, EventArgs e)
        {
            btnInserirEntrada.Enabled = true;
        }

//Método verificarBrancos2()
        public bool verificarBrancos2()
        {
            bool resposta;
            if (txtNomeEntrada.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método dgrProdutosEntrada_CellDoubleClick()
        private void dgrProdutosEntrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrProdutosEntrada.Rows[e.RowIndex].Cells[0].Value.ToString());
            objEstoque.preencheCampos(id);
            popularTextBox2();
            btnInserirEntrada.Enabled = true;
        }

//Método popularTextBox2()
        private void popularTextBox2()
        {
            txtCodEntrada.Text = Convert.ToString(id);
            txtNomeEntrada.Text = objEstoque.getNome();
            txtQtdEntrada.Text = Convert.ToString(objEstoque.getQuantidade());
        }

//Método btnInserirEntrada_Click()
        private void btnInserirEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos2())
                {
                    bool resposta;
                    objEstoque.setCodigo(Convert.ToInt16(txtCodEntrada.Text));
                    objEstoque.setNome(txtNomeEntrada.Text);
                    objEstoque.setData(Convert.ToDateTime(txtData.Text));
                    objEstoque.setQuantidade(Convert.ToInt16(txtQtdEntrada.Text));
                    try
                    {
                        bool res;
                        resposta = objEstoque.inserirEntrada();
                        res = objEstoque.somaQtdEstoque();
                        resposta = objEstoque.atualizarQuantidade(id);
                        if (!res)
                        {
                            MessageBox.Show("Valor de entrada menor do que 1(um)!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            if (resposta)
                            {

                                MessageBox.Show("Entrada cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                                limparCampos();
                                popularGrid2();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao concluir a operação!");
                            }
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
/*
 * INICIO DA TAB 3 
*/
       
//Método popularGrid3()
        public void popularGrid3()
        {
            dgrProdutosEntrada.DataSource = objEstoque.listarTodos();
            if (dgrProdutosEntrada.Columns.Count > 0)
            {
                dgrProdutosEntrada.Columns[0].Width = 80;
                dgrProdutosEntrada.Columns[1].Width = 100;
                dgrProdutosEntrada.Columns[2].Width = 100;
                dgrProdutosEntrada.Columns[3].Width = 100;
                dgrProdutosEntrada.Columns[4].Width = 100;
                dgrProdutosEntrada.Columns[5].Width = 100;
                dgrProdutosEntrada.Columns[6].Width = 100;

                dgrProdutosEntrada.Columns[0].HeaderText = "Código";
                dgrProdutosEntrada.Columns[1].HeaderText = "Nome";
                dgrProdutosEntrada.Columns[2].HeaderText = "Quantidade Mínima";
                dgrProdutosEntrada.Columns[3].HeaderText = "Quantidade Estoque";
                dgrProdutosEntrada.Columns[4].HeaderText = "Descrição";
                dgrProdutosEntrada.Columns[5].HeaderText = "Valor";
                dgrProdutosEntrada.Columns[6].HeaderText = "Fornecedor";
            }
        }

//Método popularTextBox3()
        private void popularTextBox3()
        {
            txtCodSaida.Text = Convert.ToString(id);
            txtNomeSaida.Text = objEstoque.getNome();
            txtQtdSaida.Text = Convert.ToString(objEstoque.getQuantidade());
        }

//Metodo Sair
        private void btnSairSaidaMat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

//Método verificarBrancos3()
        public bool verificarBrancos3()
        {
            bool resposta;
            if (txtNomeSaida.Text == "")
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método txtNomeSaida_TextChanged()
        private void txtNomeSaida_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNomeSaida.Text;
            dgrProdutosSaida.DataSource = objEstoque.listarTodos(nome);
        }

//Método txtQtdSaida_TextChanged()
        private void txtQtdSaida_TextChanged(object sender, EventArgs e)
        {
            btnInserirSaida.Enabled = true;
        }

//Método dgrProdutosSaida_CellDoubleClick()
        private void dgrProdutosSaida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrProdutosSaida.Rows[e.RowIndex].Cells[0].Value.ToString());
            objEstoque.preencheCampos(id);
            popularTextBox3();
            btnInserirSaida.Enabled = true;
        }

//Método btnInserirSaida_Click1()
        private void btnInserirSaida_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancos3())
                {
                    bool resposta;
                    objEstoque.setCodigo(Convert.ToInt16(txtCodSaida.Text));
                    objEstoque.setNome(txtNomeSaida.Text);
                    objEstoque.setData(Convert.ToDateTime(txtDataSaida.Text));
                    objEstoque.setQuantidade(Convert.ToInt16(txtQtdSaida.Text));
                    try
                    {
                        bool res;
                        resposta = objEstoque.inserirSaida();
                        res = objEstoque.subtraiQtdEstoque();
                        resposta = objEstoque.atualizarQuantidade(id);
                        if (!res)
                        {
                            MessageBox.Show("Valor de saída maior que estoque atual!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            if (resposta)
                            {

                                MessageBox.Show("Saída cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                                limparCampos();
                                popularGrid3();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao concluir a operação!");
                            }
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
    }
}