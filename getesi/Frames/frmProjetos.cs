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
    public partial class frmProjetos : Form
    {
        public frmProjetos()
        {
            InitializeComponent();
            popularComboClienteCadastroProjetos();
            popularComboResponsavelLevantamento();
            popularListViewFuncionarioViagens();
            popularComboVeiculoViagens();
        }
        private int id;
        private int num;
        ProjetosDAO projetosDAO = new ProjetosDAO();
        MedicaoDAO medicaoDAO = new MedicaoDAO();
        ViagemDAO viagemDAO = new ViagemDAO();
        LevantamentoDAO levantamentoDAO = new LevantamentoDAO();
        BombasDAO bombaDAO = new BombasDAO();
        ComunicacaoDAO comunicacaoDAO = new ComunicacaoDAO();
        DosadoresDAO dosadorDAO = new DosadoresDAO();
        PainelDAO painelDAO = new PainelDAO();
        PressaoDAO pressaoDAO = new PressaoDAO();
        ReservacaoDAO reservacaoDAO = new ReservacaoDAO();
        VazaoDAO vazaoDAO = new VazaoDAO();
        ClienteDAO cliente = new ClienteDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        VeiculoDAO veiculoDAO = new VeiculoDAO();
        private static frmProjetos instance;

//Método getInstance()
        public static frmProjetos getInstance()
        {
            if (instance == null)
            {
                instance = new frmProjetos();
            }
            return instance;
        }

//Método FormClosing
        private void frmProjetos_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

/*
 * TAB 01
*/
        
//Método popularComboClienteCadastroProjetos()
        public void popularComboClienteCadastroProjetos()
        {
            cmbClienteCadastroProjetos.DataSource = cliente.listarTodos();
            cmbClienteCadastroProjetos.DisplayMember = "Nome";
            cmbClienteCadastroProjetos.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbClienteCadastroProjetos.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbClienteCadastroProjetos.SelectedIndex = 0;
        }

//Método Limpar Cadastro de Projetos
        public void limparCadastroProjetos()
        {
            txtOpCadastroProjetos.Text = "";
            txtNumPontosCadastroProjetos.Text = "";
            cmbClienteCadastroProjetos.Text = "";
            txtInícioCadastroProjetos.Text = "";
            txtFimCadastroProjetos.Text = "";
            txtResumoCadastroProjetos.Text = "";
        }

//Método verificarBrancos()
        public bool verificarBrancosCadastroProjetos()
        {
            bool resposta;
            if ((cmbClienteCadastroProjetos.Text == "") && (txtOpCadastroProjetos.Text == ""))
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

  //Método popularGrid()
        public void popularGridCadastroProjetos()
        {
            dgrCadastroProjetos.DataSource = projetosDAO.listarTodos();
            if (dgrCadastroProjetos.Columns.Count > 0)
            {
                dgrCadastroProjetos.Columns[0].Width = 80;
                dgrCadastroProjetos.Columns[1].Width = 100;
                dgrCadastroProjetos.Columns[2].Width = 100;
                dgrCadastroProjetos.Columns[3].Width = 100;
                dgrCadastroProjetos.Columns[4].Width = 100;
                dgrCadastroProjetos.Columns[5].Width = 200;

                dgrCadastroProjetos.Columns[0].HeaderText = "OP";
                dgrCadastroProjetos.Columns[1].HeaderText = "Cliente";
                dgrCadastroProjetos.Columns[2].HeaderText = "Pontos";
                dgrCadastroProjetos.Columns[3].HeaderText = "Data de Início";
                dgrCadastroProjetos.Columns[4].HeaderText = "Data de Término";
                dgrCadastroProjetos.Columns[5].HeaderText = "Resumo";
            }
        }

//Método txtOp Text Changed
        private void txtOpCadastroProjetos_TextChanged(object sender, EventArgs e)
        {
            btnInserirCadastroProjetos.Enabled = true;
        }

//Método cell Double Click
        private void dgrCadastroProjetos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrCadastroProjetos.Rows[e.RowIndex].Cells[0].Value.ToString());
            projetosDAO.preencheCamposCadastroProjetos(id);
            popularTextBoxCadastroProjetos();
            btnInserirCadastroProjetos.Enabled = false;
            btnAtualizarCadastroProjetos.Enabled = true;
            btnExcluirCadastroProjetos.Enabled = true;
        }

//Método Popular TextBox
        public void popularTextBoxCadastroProjetos()
        {
            txtOpCadastroProjetos.Text = projetosDAO.getOp().ToString();
            txtNumPontosCadastroProjetos.Text = projetosDAO.getNumPontos().ToString();
            txtInícioCadastroProjetos.Text = projetosDAO.getInicio().ToString("dd/MM/yyyy");
            txtFimCadastroProjetos.Text = projetosDAO.getFim().ToString("dd/MM/yyyy");
            txtResumoCadastroProjetos.Text = projetosDAO.getResumo();
            cmbClienteCadastroProjetos.Text = projetosDAO.getCliente();
        }

//Método Botão Listar Todos
        private void btnListarCadastroProjetos_Click(object sender, EventArgs e)
        {
            popularGridCadastroProjetos();
        }

//Método Inserir Cadastro Projetos
        private void btnInserirCadastroProjetos_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCadastroProjetos())
                {
                    bool resposta;
                    projetosDAO.setOp(Convert.ToInt16(txtOpCadastroProjetos.Text));
                    projetosDAO.setNumPontos(Convert.ToInt16(txtNumPontosCadastroProjetos.Text));
                    projetosDAO.setInicio(Convert.ToDateTime(txtInícioCadastroProjetos.Text));
                    projetosDAO.setFim(Convert.ToDateTime(txtFimCadastroProjetos.Text));
                    projetosDAO.setCliente(cmbClienteCadastroProjetos.Text);
                    projetosDAO.setResumo(txtResumoCadastroProjetos.Text);
                    
                    try
                    {
                        resposta = projetosDAO.inserirCadastroProjetos();

                        if (resposta)
                        {
                            MessageBox.Show("Projeto cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCadastroProjetos();
                            popularGridCadastroProjetos();
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

//Método Botão Atualizar
        private void btnAtualizarCadastroProjetos_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCadastroProjetos())
                {
                    bool resposta;
                    projetosDAO.setOp(Convert.ToInt16(txtOpCadastroProjetos.Text));
                    projetosDAO.setNumPontos(Convert.ToInt16(txtNumPontosCadastroProjetos.Text));
                    projetosDAO.setInicio(Convert.ToDateTime(txtInícioCadastroProjetos.Text));
                    projetosDAO.setFim(Convert.ToDateTime(txtFimCadastroProjetos.Text));
                    projetosDAO.setCliente(cmbClienteCadastroProjetos.Text);
                    projetosDAO.setResumo(txtResumoCadastroProjetos.Text);

                    try
                    {
                        resposta = projetosDAO.atualizarCadastroProjetos(id);
                        limparCadastroProjetos();
                        popularGridCadastroProjetos();
                        if (resposta)
                        {
                            MessageBox.Show("Cadastro atualizado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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

//Método Botã Excluir
        private void btnExcluirCadastroProjetos_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosCadastroProjetos())
                {
                    bool resposta;
                    try
                    {
                        resposta = projetosDAO.excluirCadastroProjetos(id);

                        if (resposta)
                        {
                            MessageBox.Show("Projeto excluido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparCadastroProjetos();
                            popularGridCadastroProjetos();
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
 * TAB 02
*/

//Variáveis Auxiliares para os Checked's
        bool r1, r2, r3, r4;

//Método optGeral Checked Changed
        private void optGeralCronogramas_CheckedChanged(object sender, EventArgs e)
        {
            if (r3)
            {
                grpGeralCronogramas.Visible = true;
                grpSemanalCronogramas.Visible = false;
            }
            else if (r4)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = false;
            }
            r1 = true;
        }

//Método optSemanal Checked Changed
        private void optSemanalCronogramas_CheckedChanged(object sender, EventArgs e)
        {
            if (r3)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = true;
            }
            else if (r4)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = false;
            }
            r2 = true;
        }

//Método optCadastrar Checked Changed
        private void optCadastrarCronograma_CheckedChanged(object sender, EventArgs e)
        {
            if (r1)
            {
                grpGeralCronogramas.Visible = true;
                grpSemanalCronogramas.Visible = false;
            }
            else if (r2)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = true;
            }
            r3 = true;
        }

//Método optDemaisOperações Checked Changed
        private void optDemaisOperacoesCronogramas_CheckedChanged(object sender, EventArgs e)
        {
            if (r1)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = false;
            }
            else if (r2)
            {
                grpGeralCronogramas.Visible = false;
                grpSemanalCronogramas.Visible = false;
            }
            r4 = true;
        }







/*
 * TAB 03
*/

//Método txtOp Text Changed
        private void txtOpMedicao_TextChanged(object sender, EventArgs e)
        {
            btnListarMedicao.Enabled = true;
            btnInserirMedicao.Enabled = true;
        }

//Método verificarBrancos()
        public bool verificarBrancosMedicao()
        {
            bool resposta;
            if ((txtOpMedicao.Text == "") && (txtNumeroMedicao.Text == ""))
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
        public void limparMedicao()
        {
            txtOpMedicao.Text = "";
            txtNumeroMedicao.Text = "";
            txtDataMedicao.Text = "";
            txtValorMedicao.Text = "";
            txtObservacaoMedicao.Text = "";
            txtDescricaoMedicao.Text = "";
        }

//Método popularGrid()
        public void popularGridMedicao()
        {
            dgrMedicao.DataSource = medicaoDAO.listarTodos();
            if (dgrMedicao.Columns.Count > 0)
            {
                dgrMedicao.Columns[0].Width = 80;
                dgrMedicao.Columns[1].Width = 100;
                dgrMedicao.Columns[2].Width = 100;
                dgrMedicao.Columns[3].Width = 100;
                dgrMedicao.Columns[4].Width = 100;
                dgrMedicao.Columns[5].Width = 200;

                dgrMedicao.Columns[0].HeaderText = "OP";
                dgrMedicao.Columns[1].HeaderText = "Medição";
                dgrMedicao.Columns[2].HeaderText = "Data";
                dgrMedicao.Columns[3].HeaderText = "Valor Total";
                dgrMedicao.Columns[4].HeaderText = "Observações";
                dgrMedicao.Columns[5].HeaderText = "Descrição";
            }
        }

//Método Cell Double Click
        private void dgrMedicao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrMedicao.Rows[e.RowIndex].Cells[0].Value.ToString());
            num = Convert.ToInt16(dgrMedicao.Rows[e.RowIndex].Cells[1].Value.ToString());
            medicaoDAO.preencheCamposMedicao(id, num);
            popularTextBoxMedicao();
            btnInserirMedicao.Enabled = false;
            btnAtualizarMedicao.Enabled = true;
            btnExcluirMedicao.Enabled = true;
        }

//Método Popular TextBox
        public void popularTextBoxMedicao()
        {
            txtOpMedicao.Text = medicaoDAO.getOp().ToString();
            txtNumeroMedicao.Text = medicaoDAO.getNumMedicao().ToString();
            txtDataMedicao.Text = medicaoDAO.getData().ToString("dd/MM/yyyy");
            txtValorMedicao.Text = medicaoDAO.getValor().ToString();
            txtObservacaoMedicao.Text = medicaoDAO.getObservacao();
            txtDescricaoMedicao.Text = medicaoDAO.getDescricao();
        }

//Método Botão Listar Todos
        private void btnListarMedicao_Click(object sender, EventArgs e)
        {
            popularGridMedicao();
        }

//Método Botão Inserir
        private void btnInserirMedicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosMedicao())
                {
                    bool resposta;
                    medicaoDAO.setOp(Convert.ToInt16(txtOpMedicao.Text));
                    medicaoDAO.setNumMedicao(Convert.ToInt16(txtNumeroMedicao.Text));
                    medicaoDAO.setData(Convert.ToDateTime(txtDataMedicao.Text));
                    medicaoDAO.setValor(Convert.ToDouble(txtValorMedicao.Text));
                    medicaoDAO.setObservacao(txtObservacaoMedicao.Text);
                    medicaoDAO.setDescricao(txtDescricaoMedicao.Text);

                    try
                    {
                        resposta = medicaoDAO.inserirMedicao();

                        if (resposta)
                        {
                            MessageBox.Show("Medição cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparMedicao();
                            popularGridMedicao();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor, Confira os campos", "ERRO NA EXECUÇÃO");
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

//Método Botão Atualizar
        private void btnAtualizarMedicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosMedicao())
                {
                    bool resposta;
                    medicaoDAO.setOp(Convert.ToInt16(txtOpMedicao.Text));
                    medicaoDAO.setNumMedicao(Convert.ToInt16(txtNumeroMedicao.Text));
                    medicaoDAO.setData(Convert.ToDateTime(txtDataMedicao.Text));
                    medicaoDAO.setValor(Convert.ToDouble(txtValorMedicao.Text));
                    medicaoDAO.setObservacao(txtObservacaoMedicao.Text);
                    medicaoDAO.setDescricao(txtDescricaoMedicao.Text);

                    try
                    {
                        resposta = medicaoDAO.atualizarMedicao(id, num);
                        limparMedicao();
                        popularGridMedicao();
                        if (resposta)
                        {
                            MessageBox.Show("Medição atualizada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!", "ATENÇÃO");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor, Confira os campos", "ERRO NA EXECUÇÃO");
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

//Método Botão Excluir
        private void btnExcluirMedicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosMedicao())
                {
                    bool resposta;
                    try
                    {
                        resposta = medicaoDAO.excluirMedicao(id, num);

                        if (resposta)
                        {
                            MessageBox.Show("Medição excluida com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparMedicao();
                            popularGridMedicao();
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
 * TAB 04
*/

//Método verificarBrancos()
        public bool verificarBrancosLevantamento()
        {
            bool resposta;
            if ((txtOpLevantamento.Text == "") && (txtNomeLocalLevantamentos.Text == ""))
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método popularComboFuncionárioResponsável()
        public void popularComboResponsavelLevantamento()
        {
            cmbResponsavelLevantamento.DataSource = funcionarioDAO.listarTodos();
            cmbResponsavelLevantamento.DisplayMember = "Nome";
            cmbResponsavelLevantamento.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbResponsavelLevantamento.DataSource;
            DataRow linha = dt.NewRow();
            linha[1] = "";
            dt.Rows.InsertAt(linha, 0);
            cmbResponsavelLevantamento.SelectedIndex = 0;
        }

//Método Limpar Campos
        public void limparLevantamento()
        {
            limparLevantamentoBombas();
            limparLevantamentoDosadores();
            limparLevantamentoLINK();
            limparLevantamentoPainel();
            limparLevantamentoPressao();
            limparLevantamentoReservacao();
            limparLevantamentoVazao();

            //Comum para todos
            txtOpLevantamento.Text = "";
            txtDataLevantamento.Text = "";
            cmbResponsavelLevantamento.Text = "";
            txtNomeLocalLevantamentos.Text = "";
            txtPontoReferenciaLevantamentos.Text = "";
            txtEnderecoLevantamentos.Text = "";
            txtObservacaoLevantamento.Text = "";
        }

//Método Limpar Campos LINK
        public void limparLevantamentoLINK()
        {
            optSimLink.Checked = false;
            optNaoLink.Checked = false;
            txtCoordenadaLinkLevantamento.Text = "";
            txtTrafegoLinkLevantamento.Text = "";
            txtVisadaLinkLevantamento.Text = "";
            txtDistanciaLinkLevantamento.Text = "";
            txtAlturaNecessariaLinkLevantamento.Text = "";
            optSimQtdAntenasLevantamento.Checked = false;
            optNaoQtdAntenasLevantamento.Checked = false;
            optModuloPonteiraLevantamento.Checked = false;
            optTuboTripeLevantamento.Checked = false;
            optSimEnergiaLevantamento.Checked = false;
            optNaoEnergiaLevantamento.Checked = false;
            optSimRadioPainelLevantamento.Checked = false;
            optNaoRadioPainelLevantamento.Checked = false;
            optSimInfraLink.Checked = false;
            optNaoInfraLink.Checked = false;
            txtDistanciaPainelLinkLevantamento.Text = "";
            txtExternaLinkLevantamento.Text = "";
            txtEnterradaLinkLevantamento.Text = "";
            trvEnterradaLinkLevantamento.CheckBoxes = false;
        }

//Método Limpar Campos PAINEL
        public void limparLevantamentoPainel()
        {
            txtQtdPainéisPainel.Text = "";
            optSimAbrigoPainel.Checked = false;
            optNaoAbrigoPainel.Checked = false;
            optModeloGrandePainel.Checked = false;
            optModeloPequenoPainel.Checked = false;
            optFerroMaterialPainel.Checked = false;
            optPlasticoMaterialPainel.Checked = false;
            optCaixaInstalacaoPainel.Checked = false;
            optPosteInstalacaoPainel.Checked = false;
            optCasaInstalacaoPainel.Checked = false;
            txtDistanciaEnergiaPainel.Text = "";
            txtEnterradaEnergiaPainel.Text = "";
            txtExternaEnergiaPainel.Text = "";
            trvEnterradaPainel.CheckBoxes = false;
            txtResponsavelSegurancaPainel.Text = "";
            optSimChavePainel.Checked = false;
            optNaoChavePainel.Checked = false;
            optSimAlarmePainel.Checked = false;
            optNaoAlarmePainel.Checked = false; 
        }
        
//Método Limpar Campos RESERVAÇÃO
        public void limparLevantamentoReservacao()
        {
            optSimReservacao.Checked = false;
            optNaoReservacao.Checked = false;
            opt1QuantidadeReservacao.Checked = false;
            opt2QuantidadeReservacao.Checked = false;
            opt1AutomatizarReservacao.Checked = false;
            opt2AutomatizarReservacao.Checked = false;
            txtAlturaReservacao.Text = "";
            txtColunaDaguaReservacao.Text = "";
            optElevadoTipoReservacao.Checked = false;
            optApoiadoTipoReservacao.Checked = false;
            optEnterradoTipoReservacao.Checked = false;
            optTacaModeloReservacao.Checked = false;
            optCharutoModeloReservacao.Checked = false;
            optSorveteModeloReservacao.Checked = false;
            optConcretoMaterialReservacao.Checked = false;
            optMetalicoMaterialReservacao.Checked = false;
            optSubmersivelReservacao.Checked = false;
            optUltrassomReservacao.Checked = false;
            optPressaoSensorReservacao.Checked = false;
            optSimInfraReservacao.Checked = false;
            optNaoInfraReservacao.Checked = false;
            optSimColarReservacao.Checked = false;
            optNaoColarReservacao.Checked = false;
            txtColarSensorReservacao.Text = "";
            txtOffsetSensorReservacao.Text = "";
            txtDistanciaInfraReservacao.Text = "";
            txtExternaInfraReservacao.Text = "";
            txtEnterradaInfraReservacao.Text = "";
            trvEnterradaInfraReservacao.CheckBoxes = false;
            txtAlturaNivel2Reservacao.Text = "";
            txtColunaDaguaNivel2Reservacao.Text = "";
            optElevadoNivel2Reservacao.Checked = false;
            optApoiadoNivel2Reservacao.Checked = false;
            optEnterradoNivel2Reservacao.Checked = false;
            optTacaNivel2Reservacao.Checked = false;
            optSorveteNivel2Reservacao.Checked = false;
            optCharutoNivel2Reservacao.Checked = false;
            optConcretoNivel2Reservacao.Checked = false;
            optMetalicoNivel2Reservacao.Checked = false;
            optSubmersivelNivel2Reservacao.Checked = false;
            optUltrassomNivel2Reservacao.Checked = false;
            optPressaoNivel2Reservacao.Checked = false;
            optSimInfraNivel2Reservacao.Checked = false;
            optNaoInfraNivel2Reservacao.Checked = false;
            txtDistanciaNivel2Reservacao.Text = "";
            txtExternaNivel2Reservacao.Text = "";
            txtEnterradaNivel2Reservacao.Text = "";
            trvEnterradaNivel2Reservacao.CheckBoxes = false;
        }

//Método Limpar Campos VAZÃO
        public void limparLevantamentoVazao()
        {
            optSimVazao.Checked = false;
            optNaoVazao.Checked = false;
            opt1QuantidadeVazao.Checked = false;
            opt2QuantidadeVazao.Checked = false;
            opt3QuantidadeVazao.Checked = false;
            opt4QuantidadeVazao.Checked = false;
            optInsercaoTipoVz01Vazao.Checked = false;
            optUltrassomTipoVz01Vazao.Checked = false;
            optTubulacaoVz01Vazao.Checked = false;
            optCalhaParshallVz01Vazao.Checked = false;
            optSimInfraVz01Vazao.Checked = false;
            optNaoInfraVz01Vazao.Checked = false;
            txtDiametroTuboVz01Vazao.Text = "";
            optAmiantoTuboVz01Vazao.Checked = false;
            optFerroTuboVz01Vazao.Checked = false;
            optPvcTuboVz01Vazao.Checked = false;
            optDeFofoTuboVz01Vazao.Checked = false;
            optSimPitoVz01Vazao.Checked = false;
            optNaoPitoVz01Vazao.Checked = false;
            txtGargantaCalhaVz01Vazao.Text = "";
            txtAlturaCalhaVz01Vazao.Text = "";
            txtVzMaximaCalhaVz01Vazao.Text = "";
            txtDistanciaInfraVz01Vazao.Text = "";
            txtExternaInfraVz01Vazao.Text = "";
            txtEnterradaInfraVz01Vazao.Text = "";
            trvEnterradaVz01Vazao.CheckBoxes = false;
            optInsercaoTipoVz02Vazao.Checked = false;
            optUltrassomTipoVz02Vazao.Checked = false;
            optTubulacaoVz02Vazao.Checked = false;
            optCalhaParshallVz02Vazao.Checked = false;
            optSimInfraVz02Vazao.Checked = false;
            optNaoInfraVz02Vazao.Checked = false;
            txtDiametroTuboVazao.Text = "";
            optAmiantoTuboVz02Vazao.Checked = false;
            optFerroTuboVz02Vazao.Checked = false;
            optPvcTuboVz02Vazao.Checked = false;
            optDeFofoTuboVz02Vazao.Checked = false;
            optSimPitoVz02Vazao.Checked = false;
            optNaoPitoVz02Vazao.Checked = false;
            txtGargantaCalhaVz2Vazao.Text = "";
            txtAlturaCalhaVz02Vazao.Text = "";
            txtVzMaximaVz02Vazao.Text = "";
            txtDistanciaInfraVz02Vazao.Text = "";
            txtExternaInfraVz02Vazao.Text = "";
            txtEnterradaInfraVz02Vazao.Text = "";
            trvEnterradaInfraVz02Vazao.CheckBoxes = false;
            optInsercaoTipoVz3Vazao.Checked = false;
            optUltrassomTipoVz3Vazao.Checked = false;
            optTuboVz3Vazao.Checked = false;
            optCalhaVz3Vazao.Checked = false;
            optSimInfraVz3Vazao.Checked = false;
            optNaoInfraVz3Vazao.Checked = false;
            txtDiametroTuboVz3Vazao.Text = "";
            optAmiantoTuboVz3Vazao.Checked = false;
            optFerroTuboVz3Vazao.Checked = false;
            optPvcTuboVz3Vazao.Checked = false;
            optDeFoFoTuboVz3Vazao.Checked = false;
            optSimPitoVz3Vazao.Checked = false;
            optNaoPitoVz3Vazao.Checked = false;
            txtGargantaCalhaVz3Vazao.Text = "";
            txtAlturaCalhaVz3Vazao.Text = "";
            txtVzMaximaCalhaVz3Vazao.Text = "";
            txtDistanciaInfraVz3Vazao.Text = "";
            txtExternaInfraVz3Vazao.Text = "";
            txtEnterradaInfraVz3Vazao.Text = "";
            trvEnterradaVz3Vazao.CheckBoxes = false;
            optInsercaoTipoVz4Vazao.Checked = false;
            optUltrassomTipoVz4Vazao.Checked = false;
            optTuboVz4Vazao.Checked = false;
            optCalhaVz4Vazao.Checked = false;
            optSimInfraVz4Vazao.Checked = false;
            optNaoInfraVz4Vazao.Checked = false;
            txtDiametroTuboVz4Vazao.Text = "";
            optAmiantoVz4Vazao.Checked = false;
            optFerroVz4Vazao.Checked = false;
            optPvcVz4Vazao.Checked = false;
            optDeFoFoVz4Vazao.Checked = false;
            optSimPitoVz4Vazao.Checked = false;
            optNaoPitoVz4Vazao.Checked = false;
            txtGargantaCalhaVz4Vazao.Text = "";
            txtAlturaCalhaVz4Vazao.Text = "";
            txtVzMaximaVz4Vazao.Text = "";
            txtDistanciaInfraVz4Vazao.Text = "";
            txtExternaInfraVz4Vazao.Text = "";
            txtEnterradaInfraVz4Vazao.Text = "";
            trvEnterradaVz4Vazao.CheckBoxes = false;
        }

//Método Limpar Campos PRESSÃO
        public void limparLevantamentoPressao()
        {
            optSimPressao.Checked = false;
            optNaoPressao.Checked = false;
            opt1QuantidadePressao.Checked = false;
            opt2QuantidadePressao.Checked = false;
            opt3QuantidadePressao.Checked = false;
            txtDiametroTuboPr1Pressao.Text = "";
            txtPrRedePr1Pressao.Text = "";
            optAmiantoPr1Pressao.Checked = false;
            optFerroPr1Pressao.Checked = false;
            optPvcPr1Pressao.Checked = false;
            optDeFoFoPr1Pressao.Checked = false;
            optSimColarPr1Pressao.Checked = false;
            optNaoColarPr1Pressao.Checked = false;
            optSimInfraPr1Pressao.Checked = false;
            optNaoInfraPr1Pressao.Checked = false;
            txtDistanciaInfraPr1Pressao.Text = "";
            txtExternaInfraPr1Pressao.Text = "";
            txtEnterradaInfraPr1Pressao.Text = "";
            trvEnterradaPr1Pressao.CheckBoxes = false;
            txtDiametroTuboPr2Pressao.Text = "";
            txtPrRedePr2Pressao.Text = "";
            optAmiantoPr2Pressao.Checked = false;
            optFerroPr2Pressao.Checked = false;
            optPvcPr2Pressao.Checked = false;
            optDeFoFoPr2Pressao.Checked = false;
            optSimColarPr2Pressao.Checked = false;
            optNaoColarPr2Pressao.Checked = false;
            optSimInfraPr2Pressao.Checked = false;
            optNaoInfraPr2Pressao.Checked = false;
            txtDistanciaInfraPr2Pressao.Text = "";
            txtExternaPr2Pressao.Text = "";
            txtEnterradaInfraPr2Pressao.Text = "";
            trvEnterradaPr2Pressao.CheckBoxes = false;
            txtDiametroTuboPr3Pressao.Text = "";
            txtPrRedePr3Pressao.Text = "";
            optAmiantoPr3Pressao.Checked = false;
            optFerroPr3Pressao.Checked = false;
            optPvcPr3Pressao.Checked = false;
            optDeFoFoPr3Pressao.Checked = false;
            optSimColarPr3Pressao.Checked = false;
            optNaoColarPr3Pressao.Checked = false;
            optSimInfraPr3Pressao.Checked = false;
            optNaoInfraPr3Pressao.Checked = false;
            txtDistanciaInfraPr3Pressao.Text = "";
            txtExternaInfraPr3Pressao.Text = "";
            txtEnterradaInfraPr3Pressao.Text = "";
            trvEnterradaPr3Pressao.CheckBoxes = false;
        }

//Método Limpar Campos BOMBAS
        public void limparLevantamentoBombas()
        {
            optSimBombas.Checked = false;
            optNaoBombas.Checked = false;
            opt1QuantidadeBombas.Checked = false;
            opt2QuantidadeBombas.Checked = false;
            opt3QuantidadeBombas.Checked = false;
            opt4QuantidadeBombas.Checked = false;
            opt5QuantidadeBombas.Checked = false;
            opt6QuantidadeBombas.Checked = false;
            optSimMultimedidorBombas.Checked = false;
            optNaoMultimedidorBombas.Checked = false;
            txtQuantidadeMultimedidorBombas.Text = "";
            optSimTcBombas.Checked = false;
            optNaoTcBombas.Checked = false;
            txtQuantidadeTcBombas.Text = "";
            optInversorB1Bombas.Checked = false;
            optSoftStarterB1Bombas.Checked = false;
            optDiretaB1Bombas.Checked = false;
            optEstrelaTrianguloB1Bombas.Checked = false;
            optCompensadoraB1Bombas.Checked = false;
            optSimIntervencaoB1Bombas.Checked = false;
            optNaoIntervencaoB1Bombas.Checked = false;
            optSimInfraB1Bombas.Checked = false;
            optNaoInfraB1Bombas.Checked = false;
            txtPotenciaB1Bombas.Text = "";
            txtModeloB1Bombas.Text = "";
            txtDistanciaInfraB1Bombas.Text = "";
            txtExternaInfraB1Bombas.Text = "";
            txtEnterradaInfraB1Bombas.Text = "";
            trvEnterradaInfraB1Bombas.CheckBoxes = false;
            optInversorB2Bombas.Checked = false;
            optSoftStarterB2Bombas.Checked = false;
            optDiretaB2Bombas.Checked = false;
            optEstrelaTrianguloB2Bombas.Checked = false;
            optCompensadoraB2Bombas.Checked = false;
            optSimIntervencaoB2Bombas.Checked = false;
            optNaoIntervencaoB2Bombas.Checked = false;
            optSimInfraB2Bombas.Checked = false;
            optNaoInfraB2Bombas.Checked = false;
            txtPotenciaB2Bombas.Text = "";
            txtModeloB2Bombas.Text = "";
            txtDistanciaInfraB2Bombas.Text = "";
            txtExternaInfraB2Bombas.Text = "";
            txtEnterradaInfraB2Bombas.Text = "";
            trvEnterradaB2Bombas.CheckBoxes = false;
            optInversorB3Bombas.Checked = false;
            optSoftStarterB3Bombas.Checked = false;
            optDiretaB3Bombas.Checked = false;
            optEstrelaTrianguloB3Bombas.Checked = false;
            optCompensadoraB3Bombas.Checked = false;
            optSimIntervencaoB3Bombas.Checked = false;
            optNaoIntervencaoB3Bombas.Checked = false;
            optSimInfraB3Bombas.Checked = false;
            optNaoInfraB3Bombas.Checked = false;
            txtPotenciaB3Bombas.Text = "";
            txtModeloB3Bombas.Text = "";
            txtDistanciaInfraB3Bombas.Text = "";
            txtExternaInfraB3Bombas.Text = "";
            txtEnterradaInfraB3Bombas.Text = "";
            trvEnterradaB3Bombas.CheckBoxes = false;
            optInversorB4Bombas.Checked = false;
            optSoftStarterB4Bombas.Checked = false;
            optDiretaB4Bombas.Checked = false;
            optEstrelaTrianguloB4Bombas.Checked = false;
            optCompensadoraB4Bombas.Checked = false;
            optSimIntervencaoB4Bombas.Checked = false;
            optNaoIntervencaoB4Bombas.Checked = false;
            optSimInfraB4Bombas.Checked = false;
            optNaoInfraB4Bombas.Checked = false;
            txtPotenciaB4Bombas.Text = "";
            txtModeloB4Bombas.Text = "";
            txtDistanciaInfraB4Bombas.Text = "";
            txtExternaInfraB4Bombas.Text = "";
            txtEnterradaInfraB4Bombas.Text = "";
            trvEnterradaB4Bombas.CheckBoxes = false;
            optInversorB5Bombas.Checked = false;
            optSoftStarterB5Bombas.Checked = false;
            optDiretaB5Bombas.Checked = false;
            optEstrelaTrianguloB5Bombas.Checked = false;
            optCompensadoraB5Bombas.Checked = false;
            optSimIntervencaoB5Bombas.Checked = false;
            optNaoIntervencaoB5Bombas.Checked = false;
            optSimInfraB5Bombas.Checked = false;
            optNaoInfraB5Bombas.Checked = false;
            txtPotenciaB5Bombas.Text = "";
            txtModeloB5Bombas.Text = "";
            txtDistanciaInfraB5Bombas.Text = "";
            txtExternaInfraB5Bombas.Text = "";
            txtEnterradaInfraB5Bombas.Text = "";
            trvEnterradaB5Bombas.CheckBoxes = false;
            optInversorB6Bombas.Checked = false;
            optSoftStarterB6Bombas.Checked = false;
            optDiretaB6Bombas.Checked = false;
            optEstrelaTrianguloB6Bombas.Checked = false;
            optCompensadoraB6Bombas.Checked = false;
            optSimIntervencaoB6Bombas.Checked = false;
            optNaoIntervencaoB6Bombas.Checked = false;
            optSimInfraB6Bombas.Checked = false;
            optNaoInfraB6Bombas.Checked = false;
            txtPotenciaB6Bombas.Text = "";
            txtModeloB6Bombas.Text = "";
            txtDistanciaInfraB6Bombas.Text = "";
            txtExternaInfraB6Bombas.Text = "";
            txtEnterradaInfraB6Bombas.Text = "";
            trvEnterradaB6Bombas.CheckBoxes = false;
        }

//Método Limpar Campos DOSADORES
        public void limparLevantamentoDosadores()
        {
            optSimDosadores.Checked = false;
            optNaoDosadores.Checked = false;
            txtDosagemCloroDosadores.Text = "";
            optAnalogicoCloroDosadores.Checked = false;
            optDigitalCloroDosadores.Checked = false;
            optSimInfraCloroDosadores.Checked = false;
            optNaoInfraCloroDosadores.Checked = false;
            txtDistanciaCloroDosadores.Text = "";
            txtExternaCloroDosadores.Text = "";
            txtEnterradaCloroDosadores.Text = "";
            trvEnterradaCloroDosadores.CheckBoxes = false;
            txtDosagemFluorDosadores.Text = "";
            optAnalogicoFluorDosadores.Checked = false;
            optDigitalFluorDosadores.Checked = false;
            optSimInfraFluorDosadores.Checked = false;
            optNaoInfraFluorDosadores.Checked = false;
            txtDistanciaPainelFluorDosadores.Text = "";
            txtExternaFluorDosadores.Text = "";
            txtEnterradaFluorDosadores.Text = "";
            trvEnterradaFluorDosadores.CheckBoxes = false;
        }

//Método Nome Local Text Changed
        private void txtNomeLocalLevantamentos_TextChanged(object sender, EventArgs e)
        {
            btnInserirLevantamento.Enabled = true;
        }

//Método Ler Campos
        public void lerCamposLevantamento()
        {
            levantamentoDAO.setData(Convert.ToDateTime(txtDataLevantamento.Text));
            levantamentoDAO.setEndereco(txtEnderecoLevantamentos.Text);
            levantamentoDAO.setLocal(txtNomeLocalLevantamentos.Text);
            levantamentoDAO.setObservacao(txtObservacaoLevantamento.Text);
            levantamentoDAO.setOp(Convert.ToInt16(txtOpLevantamento.Text));
            levantamentoDAO.setReferencia(txtPontoReferenciaLevantamentos.Text);
            levantamentoDAO.setResponsavel(cmbResponsavelLevantamento.Text);

            comunicacaoDAO.setAlturaNecessaria(txtAlturaNecessariaLinkLevantamento.Text);
            if (optSimLink.Checked)
                comunicacaoDAO.setComunicacao(true);
            else
                comunicacaoDAO.setComunicacao(false);
            
            comunicacaoDAO.setCoordenada(txtCoordenadaLinkLevantamento.Text);
            comunicacaoDAO.setDistanciaLink(txtDistanciaLinkLevantamento.Text);
            comunicacaoDAO.setDistanciaPainel(txtDistanciaPainelLinkLevantamento.Text);
            if (optSimEnergiaLevantamento.Checked)
                comunicacaoDAO.setEnergia(true);
            else
                comunicacaoDAO.setEnergia(false);

            comunicacaoDAO.setEnterrada(txtEnterradaLinkLevantamento.Text);
            comunicacaoDAO.setExterna(txtExternaLinkLevantamento.Text);
            if (optSimInfraLink.Checked)    
                comunicacaoDAO.setInfra(true);
            else
                comunicacaoDAO.setInfra(false);

            if (optSimQtdAntenasLevantamento.Checked)
                comunicacaoDAO.setQtdAntenas(true);
            else
                comunicacaoDAO.setQtdAntenas(false);

            if (optSimRadioPainelLevantamento.Checked)
                comunicacaoDAO.setRadioPainel(true);
            else
                comunicacaoDAO.setRadioPainel(false);

            if (optModuloPonteiraLevantamento.Checked)
                comunicacaoDAO.setSuporte(true);
            else
                comunicacaoDAO.setSuporte(false);

            comunicacaoDAO.setTrafego(txtTrafegoLinkLevantamento.Text);
            comunicacaoDAO.setVisada(txtVisadaLinkLevantamento.Text);

            if (optSimAbrigoPainel.Checked)
                painelDAO.setAbrigo(true);
            else
                painelDAO.setAbrigo(false);

            if (optSimAlarmePainel.Checked)
                painelDAO.setAlarme(true);
            else
                painelDAO.setAlarme(false);

            if (optSimChavePainel.Checked)
                painelDAO.setChave(true);
            else
                painelDAO.setChave(false);

            painelDAO.setDistanciaEnergia(txtDistanciaEnergiaPainel.Text);
            painelDAO.setEnterrada(txtEnterradaEnergiaPainel.Text);
            painelDAO.setExterna(txtExternaEnergiaPainel.Text);

            if (optCaixaInstalacaoPainel.Checked)
                painelDAO.setInstalacao(1);
            else if (optCasaInstalacaoPainel.Checked)
                painelDAO.setInstalacao(2);
            else if (optPosteInstalacaoPainel.Checked)
                painelDAO.setInstalacao(3);

            if (optFerroMaterialPainel.Checked)
                painelDAO.setMaterial(true);
            else
	            painelDAO.setMaterial(false);

            if (optModeloGrandePainel.Checked)
                painelDAO.setModelo(true);
            else
                painelDAO.setModelo(false);

            painelDAO.setQtdPaineis(txtQtdPainéisPainel.Text);
            painelDAO.setSeguranca(txtResponsavelSegurancaPainel.Text);

            reservacaoDAO.setAltura_1(txtAlturaReservacao.Text);
            reservacaoDAO.setAltura_2(txtAlturaNivel2Reservacao.Text);
                
            if (opt1AutomatizarReservacao.Checked)
                reservacaoDAO.setAutomatizar(1);
            else if (opt2AutomatizarReservacao.Checked)
                reservacaoDAO.setAutomatizar(2);

            if (optSimColarReservacao.Checked)
                reservacaoDAO.setColar_1(true);
            else
                reservacaoDAO.setColar_1(false);

            if (optSimColarNivel2Reservacao.Checked)
                reservacaoDAO.setColar_2(true);
            else
                reservacaoDAO.setColar_2(false);
            
            reservacaoDAO.setColarTamanho_1(txtColarSensorReservacao.Text);
            reservacaoDAO.setColarTamanho_2(txtColarNivel2Reservacao.Text);
            reservacaoDAO.setColuna_1(txtColunaDaguaReservacao.Text);
            reservacaoDAO.setColuna_2(txtColunaDaguaNivel2Reservacao.Text);
            reservacaoDAO.setDistanciaInfra_1(txtDistanciaInfraReservacao.Text);
            reservacaoDAO.setDistanciaInfra_2(txtDistanciaNivel2Reservacao.Text);
            reservacaoDAO.setEnterrada_1(txtEnterradaInfraReservacao.Text);
            reservacaoDAO.setEnterrada_2(txtEnterradaNivel2Reservacao.Text);
            reservacaoDAO.setExterna_1(txtExternaInfraReservacao.Text);
            reservacaoDAO.setExterna_2(txtExternaNivel2Reservacao.Text);
            if (optSimInfraReservacao.Checked)
                reservacaoDAO.setInfra_1(true);
            else
                reservacaoDAO.setInfra_1(false);

            if (optSimInfraNivel2Reservacao.Checked)
                reservacaoDAO.setInfra_2(true);
            else
                reservacaoDAO.setInfra_2(false);

            if (optConcretoMaterialReservacao.Checked)
                reservacaoDAO.setMaterial_1(1);
            else
                reservacaoDAO.setMaterial_1(2);

            if (optConcretoNivel2Reservacao.Checked)
                reservacaoDAO.setMaterial_2(1);
            else
                reservacaoDAO.setMaterial_2(2);

            if (optTacaModeloReservacao.Checked)
                reservacaoDAO.setModelo_1(1);
            else if (optSorveteModeloReservacao.Checked)
                reservacaoDAO.setModelo_1(2);
            else if (optCharutoModeloReservacao.Checked)    
                reservacaoDAO.setModelo_1(3);

            if (optTacaNivel2Reservacao.Checked)
                reservacaoDAO.setModelo_2(1);
            else if (optSorveteNivel2Reservacao.Checked)
                reservacaoDAO.setModelo_2(2);
            else if (optCharutoNivel2Reservacao.Checked)
                reservacaoDAO.setModelo_2(3);

            reservacaoDAO.setOffset_1(txtOffsetSensorReservacao.Text);
            reservacaoDAO.setOffset_2(txtOffsetNivel2Reservacao.Text);
            
            if (opt1QuantidadeReservacao.Checked)
                reservacaoDAO.setQuantidade(1);
            else
                reservacaoDAO.setQuantidade(2);

            if (optSimReservacao.Checked)
                reservacaoDAO.setReservacao(true);
            else
                reservacaoDAO.setReservacao(false);

            if (optSubmersivelReservacao.Checked)
                reservacaoDAO.setSensor_1(1);
            else if (optUltrassomReservacao.Checked)
                reservacaoDAO.setSensor_1(2);
            else if (optPressaoSensorReservacao.Checked)
                reservacaoDAO.setSensor_1(3);

            if (optSubmersivelNivel2Reservacao.Checked)
                reservacaoDAO.setSensor_2(1);
            else if (optUltrassomNivel2Reservacao.Checked)
                reservacaoDAO.setSensor_2(2);
            else if (optPressaoNivel2Reservacao.Checked)
                reservacaoDAO.setSensor_2(3);

            if (optElevadoTipoReservacao.Checked)
                reservacaoDAO.setTipo_1(1);
            else if (optApoiadoTipoReservacao.Checked)
                reservacaoDAO.setTipo_1(2);
            else if (optEnterradoTipoReservacao.Checked)
                reservacaoDAO.setTipo_1(3);

            if (optElevadoNivel2Reservacao.Checked)
                reservacaoDAO.setTipo_2(1);
            else if (optApoiadoNivel2Reservacao.Checked)
                reservacaoDAO.setTipo_2(2);
            else if (optEnterradoNivel2Reservacao.Checked)
                reservacaoDAO.setTipo_2(3);

            vazaoDAO.setAltura_1(txtAlturaCalhaVz01Vazao.Text);
            vazaoDAO.setAltura_2(txtAlturaCalhaVz02Vazao.Text);
            vazaoDAO.setAltura_3(txtAlturaCalhaVz3Vazao.Text);
            vazaoDAO.setAltura_4(txtAlturaCalhaVz4Vazao.Text);
            vazaoDAO.setDiametro_1(txtDiametroTuboVz01Vazao.Text);
            vazaoDAO.setDiametro_2(txtDiametroTuboVazao.Text);
            vazaoDAO.setDiametro_3(txtDiametroTuboVz3Vazao.Text);
            vazaoDAO.setDiametro_4(txtDiametroTuboVz4Vazao.Text);
            vazaoDAO.setDistanciaInfra_1(txtDistanciaInfraVz01Vazao.Text);
            vazaoDAO.setDistanciaInfra_2(txtDistanciaInfraVz01Vazao.Text);
            vazaoDAO.setDistanciaInfra_3(txtDistanciaInfraVz3Vazao.Text);
            vazaoDAO.setDistanciaInfra_4(txtDistanciaInfraVz4Vazao.Text);
            vazaoDAO.setEnterrada_1(txtEnterradaInfraVz01Vazao.Text);
            vazaoDAO.setEnterrada_2(txtEnterradaInfraVz02Vazao.Text);
            vazaoDAO.setEnterrada_3(txtEnterradaInfraVz3Vazao.Text);
            vazaoDAO.setEnterrada_4(txtEnterradaInfraVz4Vazao.Text);
            vazaoDAO.setExterna_1(txtExternaInfraVz01Vazao.Text);
            vazaoDAO.setExterna_2(txtExternaInfraVz02Vazao.Text);
            vazaoDAO.setExterna_3(txtExternaInfraVz3Vazao.Text);
            vazaoDAO.setExterna_4(txtExternaInfraVz4Vazao.Text);
            vazaoDAO.setGarganta_1(txtGargantaCalhaVz01Vazao.Text);
            vazaoDAO.setGarganta_2(txtGargantaCalhaVz2Vazao.Text);
            vazaoDAO.setGarganta_3(txtGargantaCalhaVz3Vazao.Text);
            vazaoDAO.setGarganta_4(txtGargantaCalhaVz4Vazao.Text);
            
            if (optSimInfraVz01Vazao.Checked)
                vazaoDAO.setInfra_1(true);
            else
                vazaoDAO.setInfra_1(false);

            if (optSimInfraVz02Vazao.Checked)
                vazaoDAO.setInfra_2(true);
            else
                vazaoDAO.setInfra_2(false);

            if (optSimInfraVz3Vazao.Checked)
                vazaoDAO.setInfra_3(true);
            else
                vazaoDAO.setInfra_3(false);

            if (optSimInfraVz4Vazao.Checked)
                vazaoDAO.setInfra_4(true);
            else
                vazaoDAO.setInfra_4(false);

            if (optSimPitoVz01Vazao.Checked)
                vazaoDAO.setPito_1(true);
            else
                vazaoDAO.setPito_1(false);

            if (optSimPitoVz02Vazao.Checked)
                vazaoDAO.setPito_2(true);
            else
                vazaoDAO.setPito_2(false);

            if (optSimPitoVz3Vazao.Checked)
                vazaoDAO.setPito_3(true);
            else
                vazaoDAO.setPito_3(false);

            if (optSimPitoVz4Vazao.Checked)
                vazaoDAO.setPito_4(true);
            else
                vazaoDAO.setPito_4(false);

            if (opt1QuantidadeVazao.Checked)
                vazaoDAO.setQuantidade(1);
            else if (opt2QuantidadeVazao.Checked)
                vazaoDAO.setQuantidade(2);
            else if (opt3QuantidadeVazao.Checked)
                vazaoDAO.setQuantidade(3);
            else if (opt4QuantidadeVazao.Checked)
                vazaoDAO.setQuantidade(4);

            if (optTubulacaoVz01Vazao.Checked)
                vazaoDAO.setTipoLocal_1(1);
            else
                vazaoDAO.setTipoLocal_1(2);

            if (optTubulacaoVz02Vazao.Checked)
                vazaoDAO.setTipoLocal_2(1);
            else
                vazaoDAO.setTipoLocal_2(2);

            if (optTuboVz3Vazao.Checked)
                vazaoDAO.setTipoLocal_3(1);
            else
                vazaoDAO.setTipoLocal_3(2);

            if (optTuboVz4Vazao.Checked)
                vazaoDAO.setTipoLocal_4(1);
            else
                vazaoDAO.setTipoLocal_4(2);

            if (optInsercaoTipoVz01Vazao.Checked)
                vazaoDAO.setTipoSensor_1(1);
            else
                vazaoDAO.setTipoSensor_1(2);

            if (optInsercaoTipoVz02Vazao.Checked)
                vazaoDAO.setTipoSensor_2(1);
            else
                vazaoDAO.setTipoSensor_2(2);

            if (optInsercaoTipoVz3Vazao.Checked)
                vazaoDAO.setTipoSensor_3(1);
            else
                vazaoDAO.setTipoSensor_3(2);

            if (optInsercaoTipoVz4Vazao.Checked)
                vazaoDAO.setTipoSensor_4(1);
            else
                vazaoDAO.setTipoSensor_4(2);

            if (optAmiantoTuboVz01Vazao.Checked)
                vazaoDAO.setTubo_1(1);
            else if (optFerroTuboVz01Vazao.Checked)
                vazaoDAO.setTubo_1(2);
            else if (optPvcTuboVz01Vazao.Checked)
                vazaoDAO.setTubo_1(3);
            else if (optDeFofoTuboVz01Vazao.Checked)
                vazaoDAO.setTubo_1(4);

            if (optAmiantoTuboVz02Vazao.Checked)
                vazaoDAO.setTubo_2(1);
            else if (optFerroTuboVz02Vazao.Checked)
                vazaoDAO.setTubo_2(2);
            else if (optPvcTuboVz02Vazao.Checked)
                vazaoDAO.setTubo_2(3);
            else if (optDeFofoTuboVz02Vazao.Checked)
                vazaoDAO.setTubo_2(4);

            if (optAmiantoTuboVz3Vazao.Checked)
                vazaoDAO.setTubo_3(1);
            else if (optFerroTuboVz3Vazao.Checked)
                vazaoDAO.setTubo_3(2);
            else if (optPvcTuboVz3Vazao.Checked)
                vazaoDAO.setTubo_3(3);
            else if (optDeFoFoTuboVz3Vazao.Checked)
                vazaoDAO.setTubo_3(4);

            if (optAmiantoVz4Vazao.Checked)
                vazaoDAO.setTubo_4(1);
            else if (optFerroVz4Vazao.Checked)
                vazaoDAO.setTubo_4(2);
            else if (optPvcVz4Vazao.Checked)
                vazaoDAO.setTubo_4(3);
            else if (optDeFoFoVz4Vazao.Checked)
                vazaoDAO.setTubo_4(4);

            if (optSimVazao.Checked)
                vazaoDAO.setVazao(true);
            else
                vazaoDAO.setVazao(false);

            vazaoDAO.setVzMaxima_1(txtVzMaximaCalhaVz01Vazao.Text);
            vazaoDAO.setVzMaxima_2(txtVzMaximaVz02Vazao.Text);
            vazaoDAO.setVzMaxima_3(txtVzMaximaCalhaVz3Vazao.Text);
            vazaoDAO.setVzMaxima_4(txtVzMaximaVz4Vazao.Text);

            if (optSimColarPr1Pressao.Checked)
                pressaoDAO.setColar_1(true);
            else
                pressaoDAO.setColar_1(false);

            if (optSimColarPr2Pressao.Checked)
                pressaoDAO.setColar_2(true);
            else
                pressaoDAO.setColar_2(false);

            if (optSimColarPr3Pressao.Checked)
                pressaoDAO.setColar_3(true);
            else
                pressaoDAO.setColar_3(false);

            pressaoDAO.setDiametro_1(txtDiametroTuboPr1Pressao.Text);
            pressaoDAO.setDiametro_2(txtDiametroTuboPr2Pressao.Text);
            pressaoDAO.setDiametro_3(txtDiametroTuboPr3Pressao.Text);
            pressaoDAO.setDistanciaInfra_1(txtDistanciaInfraPr1Pressao.Text);
            pressaoDAO.setDistanciaInfra_2(txtDistanciaInfraPr2Pressao.Text);
            pressaoDAO.setDistanciaInfra_3(txtDistanciaInfraPr3Pressao.Text);
            pressaoDAO.setEnterrada_1(txtEnterradaInfraPr1Pressao.Text);
            pressaoDAO.setEnterrada_2(txtEnterradaInfraPr2Pressao.Text);
            pressaoDAO.setEnterrada_3(txtEnterradaInfraPr3Pressao.Text);
            pressaoDAO.setExterna_1(txtExternaInfraPr1Pressao.Text);
            pressaoDAO.setExterna_2(txtExternaPr2Pressao.Text);
            pressaoDAO.setExterna_3(txtExternaInfraPr3Pressao.Text);
            
            if (optSimInfraPr1Pressao.Checked)
                pressaoDAO.setInfra_1(true);
            else
                pressaoDAO.setInfra_1(false);

            if (optSimInfraPr2Pressao.Checked)
                pressaoDAO.setInfra_2(true);
            else
                pressaoDAO.setInfra_2(false);

            if (optSimInfraPr3Pressao.Checked)
                pressaoDAO.setInfra_3(true);
            else
                pressaoDAO.setInfra_3(false);

            if (optSimPressao.Checked)
                pressaoDAO.setPressao(true);
            else
                pressaoDAO.setPressao(false);

            pressaoDAO.setPrRede_1(txtPrRedePr1Pressao.Text);
            pressaoDAO.setPrRede_2(txtPrRedePr2Pressao.Text);
            pressaoDAO.setPrRede_3(txtPrRedePr3Pressao.Text);
            
            if (opt1QuantidadePressao.Checked)
                pressaoDAO.setQuantidade(1);
            else if (opt2QuantidadePressao.Checked)
                pressaoDAO.setQuantidade(2);
            else if (opt3QuantidadePressao.Checked)
                pressaoDAO.setQuantidade(3);

            if (optAmiantoPr1Pressao.Checked)
                pressaoDAO.setTipoTubo_1(1);
            else if (optFerroPr1Pressao.Checked)
                pressaoDAO.setTipoTubo_1(2);
            else if (optPvcPr1Pressao.Checked)
                pressaoDAO.setTipoTubo_1(3);
            else if (optDeFoFoPr1Pressao.Checked)
                pressaoDAO.setTipoTubo_1(4);

            if (optAmiantoPr2Pressao.Checked)
                pressaoDAO.setTipoTubo_2(1);
            else if (optFerroPr2Pressao.Checked)
                pressaoDAO.setTipoTubo_2(2);
            else if (optPvcPr2Pressao.Checked)
                pressaoDAO.setTipoTubo_2(3);
            else if (optDeFoFoPr2Pressao.Checked)
                pressaoDAO.setTipoTubo_2(4);

            if (optAmiantoPr3Pressao.Checked)
                pressaoDAO.setTipoTubo_3(1);
            else if (optFerroPr3Pressao.Checked)
                pressaoDAO.setTipoTubo_3(2);
            else if (optPvcPr3Pressao.Checked)
                pressaoDAO.setTipoTubo_3(3);
            else if (optDeFoFoPr3Pressao.Checked)
                pressaoDAO.setTipoTubo_3(4);

            if (optInversorB1Bombas.Checked)
                bombaDAO.setAcionamento_1(1);
            else if (optSoftStarterB1Bombas.Checked)
                bombaDAO.setAcionamento_1(2);
            else if (optDiretaB1Bombas.Checked)
                bombaDAO.setAcionamento_1(3);
            else if (optEstrelaTrianguloB1Bombas.Checked)
                bombaDAO.setAcionamento_1(4);
            else if (optCompensadoraB1Bombas.Checked)
                bombaDAO.setAcionamento_1(5);

            if (optInversorB2Bombas.Checked)
                bombaDAO.setAcionamento_2(1);
            else if (optSoftStarterB2Bombas.Checked)
                bombaDAO.setAcionamento_2(2);
            else if (optDiretaB2Bombas.Checked)
                bombaDAO.setAcionamento_2(3);
            else if (optEstrelaTrianguloB2Bombas.Checked)
                bombaDAO.setAcionamento_2(4);
            else if (optCompensadoraB2Bombas.Checked)
                bombaDAO.setAcionamento_2(5);

            if (optInversorB3Bombas.Checked)
                bombaDAO.setAcionamento_3(1);
            else if (optSoftStarterB3Bombas.Checked)
                bombaDAO.setAcionamento_3(2);
            else if (optDiretaB3Bombas.Checked)
                bombaDAO.setAcionamento_3(3);
            else if (optEstrelaTrianguloB3Bombas.Checked)
                bombaDAO.setAcionamento_3(4);
            else if (optCompensadoraB3Bombas.Checked)
                bombaDAO.setAcionamento_3(5);

            if (optInversorB4Bombas.Checked)
                bombaDAO.setAcionamento_4(1);
            else if (optSoftStarterB4Bombas.Checked)
                bombaDAO.setAcionamento_4(2);
            else if (optDiretaB4Bombas.Checked)
                bombaDAO.setAcionamento_4(3);
            else if (optEstrelaTrianguloB4Bombas.Checked)
                bombaDAO.setAcionamento_4(4);
            else if (optCompensadoraB4Bombas.Checked)
                bombaDAO.setAcionamento_4(5);

            if (optInversorB5Bombas.Checked)
                bombaDAO.setAcionamento_5(1);
            else if (optSoftStarterB5Bombas.Checked)
                bombaDAO.setAcionamento_5(2);
            else if (optDiretaB5Bombas.Checked)
                bombaDAO.setAcionamento_5(3);
            else if (optEstrelaTrianguloB5Bombas.Checked)
                bombaDAO.setAcionamento_5(4);
            else if (optCompensadoraB5Bombas.Checked)
                bombaDAO.setAcionamento_5(5);

            if (optInversorB6Bombas.Checked)
                bombaDAO.setAcionamento_6(1);
            else if (optSoftStarterB6Bombas.Checked)
                bombaDAO.setAcionamento_6(2);
            else if (optDiretaB6Bombas.Checked)
                bombaDAO.setAcionamento_6(3);
            else if (optEstrelaTrianguloB6Bombas.Checked)
                bombaDAO.setAcionamento_6(4);
            else if (optCompensadoraB6Bombas.Checked)
                bombaDAO.setAcionamento_6(5);

            if (optSimBombas.Checked)
                bombaDAO.setBombas(true);
            else
                bombaDAO.setBombas(false);

            bombaDAO.setDistanciaInfra_1(txtDistanciaInfraB1Bombas.Text);
            bombaDAO.setDistanciaInfra_2(txtDistanciaInfraB2Bombas.Text);
            bombaDAO.setDistanciaInfra_3(txtDistanciaInfraB3Bombas.Text);
            bombaDAO.setDistanciaInfra_4(txtDistanciaInfraB4Bombas.Text);
            bombaDAO.setDistanciaInfra_5(txtDistanciaInfraB5Bombas.Text);
            bombaDAO.setDistanciaInfra_6(txtDistanciaInfraB6Bombas.Text);
            bombaDAO.setEnterrada_1(txtEnterradaInfraB1Bombas.Text);
            bombaDAO.setEnterrada_2(txtEnterradaInfraB2Bombas.Text);
            bombaDAO.setEnterrada_3(txtEnterradaInfraB3Bombas.Text);
            bombaDAO.setEnterrada_4(txtEnterradaInfraB4Bombas.Text);
            bombaDAO.setEnterrada_5(txtEnterradaInfraB5Bombas.Text);
            bombaDAO.setEnterrada_6(txtEnterradaInfraB6Bombas.Text);
            bombaDAO.setExterna_1(txtExternaInfraB1Bombas.Text);
            bombaDAO.setExterna_2(txtExternaInfraB2Bombas.Text);
            bombaDAO.setExterna_3(txtExternaInfraB3Bombas.Text);
            bombaDAO.setExterna_4(txtExternaInfraB4Bombas.Text);
            bombaDAO.setExterna_5(txtExternaInfraB5Bombas.Text);
            bombaDAO.setExterna_6(txtExternaInfraB6Bombas.Text);

            if (optSimInfraB1Bombas.Checked)
                bombaDAO.setInfra_1(true);
            else
                bombaDAO.setInfra_1(false);

            if (optSimInfraB2Bombas.Checked)
                bombaDAO.setInfra_2(true);
            else
                bombaDAO.setInfra_2(false);

            if (optSimInfraB3Bombas.Checked)
                bombaDAO.setInfra_3(true);
            else
                bombaDAO.setInfra_3(false);

            if (optSimInfraB4Bombas.Checked)
                bombaDAO.setInfra_4(true);
            else
                bombaDAO.setInfra_4(false);

            if (optSimInfraB5Bombas.Checked)
                bombaDAO.setInfra_5(true);
            else
                bombaDAO.setInfra_5(false);

            if (optSimInfraB6Bombas.Checked)
                bombaDAO.setInfra_6(true);
            else
                bombaDAO.setInfra_6(false);

            if (optSimIntervencaoB1Bombas.Checked)
                bombaDAO.setIntervencao_1(true);
            else
                bombaDAO.setIntervencao_1(false);

            if (optSimIntervencaoB2Bombas.Checked)
                bombaDAO.setIntervencao_2(true);
            else
                bombaDAO.setIntervencao_2(false);

            if (optSimIntervencaoB3Bombas.Checked)
                bombaDAO.setIntervencao_3(true);
            else
                bombaDAO.setIntervencao_3(false);

            if (optSimIntervencaoB4Bombas.Checked)
                bombaDAO.setIntervencao_4(true);
            else
                bombaDAO.setIntervencao_4(false);

            if (optSimIntervencaoB5Bombas.Checked)
                bombaDAO.setIntervencao_5(true);
            else
                bombaDAO.setIntervencao_5(false);

            if (optSimIntervencaoB6Bombas.Checked)
                bombaDAO.setIntervencao_6(true);
            else
                bombaDAO.setIntervencao_6(false);

            bombaDAO.setModelo_1(txtModeloB1Bombas.Text);
            bombaDAO.setModelo_2(txtModeloB2Bombas.Text);
            bombaDAO.setModelo_3(txtModeloB3Bombas.Text);
            bombaDAO.setModelo_4(txtModeloB4Bombas.Text);
            bombaDAO.setModelo_5(txtModeloB5Bombas.Text);
            bombaDAO.setModelo_6(txtModeloB6Bombas.Text);
            
            if (optSimMultimedidorBombas.Checked)
                bombaDAO.setMultimedidor(true);
            else
                bombaDAO.setMultimedidor(false);

            bombaDAO.setPotencia_1(txtPotenciaB1Bombas.Text);
            bombaDAO.setPotencia_2(txtPotenciaB2Bombas.Text);
            bombaDAO.setPotencia_3(txtPotenciaB3Bombas.Text);
            bombaDAO.setPotencia_4(txtPotenciaB4Bombas.Text);
            bombaDAO.setPotencia_5(txtPotenciaB5Bombas.Text);
            bombaDAO.setPotencia_6(txtPotenciaB6Bombas.Text);

            if (opt1QuantidadeBombas.Checked)
                bombaDAO.setQtdBombas(1);
            else if (opt2QuantidadeBombas.Checked)
                bombaDAO.setQtdBombas(2);
            else if (opt3QuantidadeBombas.Checked)
                bombaDAO.setQtdBombas(3);
            else if (opt4QuantidadeBombas.Checked)
                bombaDAO.setQtdBombas(4);
            else if (opt5QuantidadeBombas.Checked)
                bombaDAO.setQtdBombas(5);
            else if (opt6QuantidadeBombas.Checked)    
                bombaDAO.setQtdBombas(6);

            bombaDAO.setQtdMultimedidor(txtQuantidadeMultimedidorBombas.Text);
            bombaDAO.setQtdTc(txtQuantidadeTcBombas.Text);
            
            if (optSimTcBombas.Checked)
                bombaDAO.setTc(true);
            else
                bombaDAO.setTc(false);

            if (optAnalogicoCloroDosadores.Checked)
                dosadorDAO.setAnalDigCloro(true);
            else
                dosadorDAO.setAnalDigCloro(false);

            if (optAnalogicoFluorDosadores.Checked)
                dosadorDAO.setAnalDigFluor(true);
            else
                dosadorDAO.setAnalDigFluor(false);

            dosadorDAO.setDistanciaCloro(txtDistanciaCloroDosadores.Text);
            dosadorDAO.setDistanciaFluor(txtDistanciaPainelFluorDosadores.Text);
            
            if (optSimDosadores.Checked)
                dosadorDAO.setDosadores(true);
            else
                dosadorDAO.setDosadores(false);

            dosadorDAO.setDosagemCloro(txtDosagemCloroDosadores.Text);
            dosadorDAO.setDosagemFluor(txtDosagemFluorDosadores.Text);
            dosadorDAO.setEnterradaCloro(txtEnterradaCloroDosadores.Text);
            dosadorDAO.setEnterradaFluor(txtEnterradaFluorDosadores.Text);
            dosadorDAO.setExternaCloro(txtExternaCloroDosadores.Text);
            dosadorDAO.setExternaFluor(txtExternaFluorDosadores.Text);
            
            if (optSimInfraCloroDosadores.Checked)
                dosadorDAO.setInfraCloro(true);
            else
                dosadorDAO.setInfraCloro(false);

            if (optSimInfraFluorDosadores.Checked)
                dosadorDAO.setInfraFluor(true);
            else
                dosadorDAO.setInfraFluor(false);
        }

//Método Botão Inserir
        private void btnInserirLevantamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosLevantamento())
                {
                    bool resposta;
                    lerCamposLevantamento();
                    try
                    {
                        resposta = levantamentoDAO.inserirLevantamento();

                        if (resposta)
                        {
                            MessageBox.Show("Levantamento cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparLevantamento();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao concluir a operação!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor, Confira os campos", "ERRO NA EXECUÇÃO");
                    }
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios em branco!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO FATAL", "ERRO");
            }
        }








        /*
         * SUB-TAB 01
        */

//Método optSimInfra_Checked
        private void optSimInfraLink_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraLinkLevantamento.Visible = false;
        }

//Método optNaoInfra_Checked
        private void optNaoInfraLink_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraLinkLevantamento.Visible = true;
        }

//Método optSimLink_Checked
        private void optSimLink_CheckedChanged(object sender, EventArgs e)
        {
            grpLinkLevantamento.Visible = true;
        }

//Método optNaoLink_Checked
        private void optNaoLink_CheckedChanged(object sender, EventArgs e)
        {
            grpLinkLevantamento.Visible = false;
            limparLevantamentoLINK();
        }

        /*
         * SUB-TAB 02
        */
        
        /*
         * SUB-TAB 03
        */

//Método SimReservacao_CheckedChanged
        private void optSimReservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpReservatorios.Visible = true;
        }

//Método NaoReservacao_CheckedChanged
        private void optNaoReservacao_CheckedChanged(object sender, EventArgs e)
        {
            limparLevantamentoReservacao();
            grpReservatorios.Visible = false;
            btnProximo.Visible = false;
            btnAnterior.Visible = false;
            grpNivel01.Visible = false;
            grpNivel02.Visible = false;
        }

//Método Quantidade 1 CheckedChanged
        private void opt1QuantidadeReservacao_CheckedChanged(object sender, EventArgs e)
        {
            opt2AutomatizarReservacao.Enabled = false;
            opt1AutomatizarReservacao.Checked = true;
            btnAnterior.Visible = false;
            btnProximo.Visible = false;
        }

//Método Quantidade 2 Checked Changed
        private void opt2QuantidadeReservacao_CheckedChanged(object sender, EventArgs e)
        {
            opt2AutomatizarReservacao.Enabled = true;
        }

//Método Pressao Sensor Checked Changed
        private void optPressaoSensorReservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarTomadaReservacao.Visible = true;
        }

//Método Ultrassom Sensor Checked Changed
        private void optUltrassomReservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarTomadaReservacao.Visible = false;
        }

//Método Submersível Sensor Checked Changed
        private void optSubmersivelReservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarTomadaReservacao.Visible = false;
        }

//Método Sim Infra Checked Changed
        private void optSimInfraReservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraReservacao.Visible = false;
        }

//Método Não Infra Checked Changed
        private void optNaoInfraReservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraReservacao.Visible = true;
        }

//Método Sim Infra Checked Changed
        private void optSimInfraNivel2Reservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraNivel2Reservacao.Visible = false;
        }

//Método Não Infra Checked Changed
        private void optNaoInfraNivel2Reservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraNivel2Reservacao.Visible = true;
        }

//Método Automatizar 2 Checked Changed
        private void opt2AutomatizarReservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpNivel01.Visible = true;
            btnProximo.Visible = true;
        }

//Método Automatizar 1 Checked Changed
        private void opt1AutomatizarReservacao_CheckedChanged(object sender, EventArgs e)
        {
            grpNivel01.Visible = true;
            btnProximo.Visible = false;
            btnAnterior.Visible = false;
        }

//Método Botão Próximo
        private void btnProximo_Click(object sender, EventArgs e)
        {
            grpNivel01.Visible = false;
            grpNivel02.Visible = true;
            btnProximo.Visible = false;
            btnAnterior.Visible = true;
        }

//Método Botão Anterior
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            btnAnterior.Visible = false;
            btnProximo.Visible = true;
            grpNivel02.Visible = false;
            grpNivel01.Visible = true;
        }

//Método Submersivel Checked Changed
        private void optSubmersivelNivel2Reservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarNivel2Reservacao.Visible = false;
        }

//Método Ultrassom Checked Changed
        private void optUltrassomNivel2Reservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarNivel2Reservacao.Visible = false;
        }

//Método Pressão Checked Changed
        private void optPressaoNivel2Reservacao_CheckedChanged(object sender, EventArgs e)
        {
            pnlColarNivel2Reservacao.Visible = true;
        }

        /*
         * SUB-TAB 04
        */

//Método Sim Checked Changed
        private void optSimVazao_CheckedChanged(object sender, EventArgs e)
        {
            grpQuantidadeVazao.Visible = true;
        }

//Método Não Checked Changed
        private void optNaoVazao_CheckedChanged(object sender, EventArgs e)
        {
            limparLevantamentoVazao();
            grpQuantidadeVazao.Visible = false;
            grpVazao01.Visible = false;
            grpVazao02.Visible = false;
            grpVazao03.Visible = false;
            grpVazao04.Visible = false;
            btnAnteriorVazao.Visible = false;
            btnProximoVazao.Visible = false;
        }

//Método Quantidade 1 Checked Changed
        private void opt1QuantidadeVazao_CheckedChanged(object sender, EventArgs e)
        {
            grpVazao01.Visible = true;
            grpVazao02.Visible = false;
            grpVazao03.Visible = false;
            grpVazao04.Visible = false;
            btnAnteriorVazao.Visible = false;
            btnProximoVazao.Visible = false;
        }

//Método Quantidade 2 Checked Changed
        private void opt2QuantidadeVazao_CheckedChanged(object sender, EventArgs e)
        {
            grpVazao01.Visible = true;
            grpVazao02.Visible = false;
            grpVazao03.Visible = false;
            grpVazao04.Visible = false;
            btnProximoVazao.Visible = true;
            btnAnterior.Visible = false;
        }

//Método Quantidade 3 Checked Changed
        private void opt3QuantidadeVazao_CheckedChanged(object sender, EventArgs e)
        {
            grpVazao01.Visible = true;
            grpVazao02.Visible = false;
            grpVazao03.Visible = false;
            grpVazao04.Visible = false;
            btnProximoVazao.Visible = true;
            btnAnterior.Visible = false;
        }

//Método Quantidade 4 Checked Changed
        private void opt4QuantidadeVazao_CheckedChanged(object sender, EventArgs e)
        {
            grpVazao01.Visible = true;
            grpVazao02.Visible = false;
            grpVazao03.Visible = false;
            grpVazao04.Visible = false;
            btnProximoVazao.Visible = true;
            btnAnterior.Visible = false;
        }

//Método Botão Próximo
        private void btnProximoVazao_Click(object sender, EventArgs e)
        {
            if (opt2QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = false;
                    grpVazao02.Visible = true;
                    grpVazao01.Visible = false;
                }
                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = false;
                    btnProximoVazao.Visible = true;
                    grpVazao02.Visible = false;
                    grpVazao01.Visible = true;
                }
            }
            else if (opt3QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao02.Visible = true;
                    grpVazao01.Visible = false;
                }
                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao03.Visible = true;
                    grpVazao02.Visible = false;
                }
                else if (grpVazao03.Visible == true)
                {
                    btnAnterior.Visible = true;
                    btnProximo.Visible = false;
                }
            }
            else if (opt4QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao02.Visible = true;
                    grpVazao01.Visible = false;
                }
                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao03.Visible = true;
                    grpVazao02.Visible = false;
                }
                else if (grpVazao03.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao04.Visible = true;
                    grpVazao03.Visible = false;
                }
                else if (grpVazao04.Visible == true)
                {
                    btnAnterior.Visible = true;
                    btnProximo.Visible = false;
                }
            }
        }

//Método Botão Anterior
        private void btnAnteriorVazao_Click(object sender, EventArgs e)
        {
            if (opt2QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnteriorVazao.Visible = false;
                    btnProximoVazao.Visible = true;
                }

                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = false;
                    btnProximoVazao.Visible = true;
                    grpVazao01.Visible = true;
                    grpVazao02.Visible = false;
                }
            }
            else if (opt3QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnterior.Visible = false;
                    btnProximo.Visible = true;
                }

                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = false;
                    btnProximoVazao.Visible = true;
                    grpVazao01.Visible = true;
                    grpVazao02.Visible = false;
                }
                else if (grpVazao03.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = false;
                    grpVazao02.Visible = true;
                    grpVazao03.Visible = false;
                }
            }
            else if (opt4QuantidadeVazao.Checked)
            {
                if (grpVazao01.Visible == true)
                {
                    btnAnterior.Visible = false;
                    btnProximo.Visible = true;
                }

                else if (grpVazao02.Visible == true)
                {
                    btnAnteriorVazao.Visible = false;
                    btnProximoVazao.Visible = true;
                    grpVazao01.Visible = true;
                    grpVazao02.Visible = false;
                }
                else if (grpVazao03.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = true;
                    grpVazao02.Visible = true;
                    grpVazao03.Visible = false;
                }
                else if (grpVazao04.Visible == true)
                {
                    btnAnteriorVazao.Visible = true;
                    btnProximoVazao.Visible = false;
                    grpVazao03.Visible = true;
                    grpVazao04.Visible = false;
                }
            }
        }

//Método Vazao 1 optSimInfra Checked Changed
        private void optSimInfraVz01Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz01Vazao.Visible = false;
        }

//Método Vazao 1 optNaoInfra Checked Changed
        private void optNaoInfraVz01Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz01Vazao.Visible = true;
        }

//Método Vazao 1 opt Calha Parshall Checked Changed
        private void optCalhaParshallVz01Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz01Vazao.Visible = false;
            grpCalhaParshallVz01Vazao.Visible = true;
            optUltrassomTipoVz01Vazao.Checked = true;
            optInsercaoTipoVz01Vazao.Enabled = false;
        }

//Método Vazao 1 opt Tubulação Checked Changed
        private void optTubulacaoVz01Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz01Vazao.Visible = true;
            grpCalhaParshallVz01Vazao.Visible = false;
            optInsercaoTipoVz01Vazao.Enabled = true;
        }

//Método Vazao 2 optSimInfra Checked Changed
        private void optSimInfraVz02Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz02Vazao.Visible = false;
        }

//Método Vazao 2 optNaoInfra Checked Changed
        private void optNaoInfraVz02Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz02Vazao.Visible = true;
        }

//Método Vazao 2 optTubo Checked Changed
        private void optTubulacaoVz02Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpCalhaParshallVz02Vazao.Visible = false;
            grpTubulacaoVz02Vazao.Visible = true;
            optInsercaoTipoVz02Vazao.Enabled = true;
        }

//Método Vazao 2 optCalha Checked Changed
        private void optCalhaParshallVz02Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpCalhaParshallVz02Vazao.Visible = true;
            grpTubulacaoVz02Vazao.Visible = false;
            optInsercaoTipoVz02Vazao.Enabled = false;
            optUltrassomTipoVz02Vazao.Checked = true;
        }

//Método Vazao 3 optSimInfra Checked Changed
        private void optSimInfraVz3Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz3Vazao.Visible = false;
        }

//Método Vazao 3 optNaoInfra Checked Changed
        private void optNaoInfraVz3Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz3Vazao.Visible = true;
        }

//Método Vazao 3 optTubo Checked Changed
        private void optTuboVz3Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz3Vazao.Visible = true;
            grpCalhaVz3Vazao.Visible = false;
            optInsercaoTipoVz3Vazao.Enabled = true;
        }

//Método Vazao 3 optCalha Checked Changed
        private void optCalhaVz3Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz3Vazao.Visible = false;
            grpCalhaVz3Vazao.Visible = true;
            optInsercaoTipoVz3Vazao.Enabled = false;
            optUltrassomTipoVz3Vazao.Checked = true;
        }

//Método Vazao 4 optSim Infra Checked Changed
        private void optSimInfraVz4Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz4Vazao.Visible = false;
        }

//Método Vazao 4 optNao Infra Checked Changed
        private void optNaoInfraVz4Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraVz4Vazao.Visible = true;
        }

//Método Vazao 4 optTubulacao Checked Changed
        private void optTuboVz4Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz4Vazao.Visible = true;
            grpCalhaVz4Vazao.Visible = false;
            optInsercaoTipoVz4Vazao.Enabled = true;
        }

//Método Vazao 4 optCalha Checked Changed
        private void optCalhaVz4Vazao_CheckedChanged(object sender, EventArgs e)
        {
            grpTubulacaoVz4Vazao.Visible = false;
            grpCalhaVz4Vazao.Visible = true;
            optInsercaoTipoVz4Vazao.Enabled = false;
            optUltrassomTipoVz4Vazao.Checked = true;
        }

        /*
         * SUB-TAB 05
        */

//Método Sim Pressão Checked Changed
        private void optSimPressao_CheckedChanged(object sender, EventArgs e)
        {
            grpQuantidadePressao.Visible = true;
        }

//Método Não Pressão Checked Changed
        private void optNaoPressao_CheckedChanged(object sender, EventArgs e)
        {
            limparLevantamentoPressao();
            grpQuantidadePressao.Visible = false;
            btnProximoPressao.Visible = false;
            btnAnteriorPressao.Visible = false;
            grpPressao01.Visible = false;
            grpPressao02.Visible = false;
            grpPressao03.Visible = false;
        }

//Método Pressão 1 Sim Infra Checked Changed
        private void optSimInfraPr1Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr1Pressao.Visible = false;
        }

//Método Pressão 1 Não Infra Checked Changed
        private void optNaoInfraPr1Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr1Pressao.Visible = true;
        }

//Método Pressão 2 Sim Infra Checked Changed
        private void optSimInfraPr2Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr2Pressao.Visible = false;
        }

//Método Pressão 2 Não Infra Checked Changed
        private void optNaoInfraPr2Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr2Pressao.Visible = true;
        }

//Método Pressão 3 Sim Infra Checked Changed
        private void optSimInfraPr3Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr3Pressao.Visible = false;
        }

//Método Pressão 3 Não Infra Checked Changed
        private void optNaoInfraPr3Pressao_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraPr3Pressao.Visible = true;
        }

//Método Botão Próximo
        private void btnProximoPressao_Click(object sender, EventArgs e)
        {
            if (opt1QuantidadePressao.Checked)
            {
                btnAnteriorPressao.Visible = false;
                btnProximoPressao.Visible = false;
            }
            else if (opt2QuantidadePressao.Checked)
            {
                if (grpPressao01.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = false;
                    grpPressao01.Visible = false;
                    grpPressao02.Visible = true;
                }
                else if (grpPressao02.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = false;
                }
            }
            else if (opt3QuantidadePressao.Checked)
            {
                if (grpPressao01.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = true;
                    grpPressao01.Visible = false;
                    grpPressao02.Visible = true;
                }
                else if (grpPressao02.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = false;
                    grpPressao02.Visible = false;
                    grpPressao03.Visible = true;
                }
                else if (grpPressao03.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = false;
                }
            }
        }

//Método Botão Anterior
        private void btnAnteriorPressao_Click(object sender, EventArgs e)
        {
            if (opt1QuantidadePressao.Checked)
            {
                btnAnteriorPressao.Visible = false;
                btnProximoPressao.Visible = false;
            }
            else if (opt2QuantidadePressao.Checked)
            {
                if (grpPressao01.Visible == true)
                {
                    btnAnteriorPressao.Visible = false;
                    btnProximoPressao.Visible = true;
                }
                else if (grpPressao02.Visible == true)
                {
                    btnAnteriorPressao.Visible = false;
                    btnProximoPressao.Visible = true;
                    grpPressao01.Visible = true;
                    grpPressao02.Visible = false;
                }
            }
            else if (opt3QuantidadePressao.Checked)
            {
                if (grpPressao01.Visible == true)
                {
                    btnAnteriorPressao.Visible = false;
                    btnProximoPressao.Visible = true;
                }
                else if (grpPressao02.Visible == true)
                {
                    btnAnteriorPressao.Visible = false;
                    btnProximoPressao.Visible = true;
                    grpPressao01.Visible = true;
                    grpPressao02.Visible = false;
                }
                else if (grpPressao03.Visible == true)
                {
                    btnAnteriorPressao.Visible = true;
                    btnProximoPressao.Visible = true;
                    grpPressao02.Visible = true;
                    grpPressao03.Visible = false;
                }
            }
        }

//Método Quantidade 1 Checked Changed
        private void opt1QuantidadePressao_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorPressao.Visible = false;
            btnProximoPressao.Visible = false;
            grpPressao01.Visible = true;
            grpPressao02.Visible = false;
            grpPressao03.Visible = false;
        }

//Método Quantidade 2 Checked Changed
        private void opt2QuantidadePressao_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorPressao.Visible = false;
            btnProximoPressao.Visible = true;
            grpPressao01.Visible = true;
            grpPressao02.Visible = false;
            grpPressao03.Visible = false;
        }

//Método Quantidade 3 Checked Changed
        private void opt3QuantidadePressao_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorPressao.Visible = false;
            btnProximoPressao.Visible = true;
            grpPressao01.Visible = true;
            grpPressao02.Visible = false;
            grpPressao03.Visible = false;
        }

        /*
         * SUB-TAB 06
        */

//Método Sim Bombas
        private void optSimBombas_CheckedChanged(object sender, EventArgs e)
        {
            grpQuantidadeBombas.Visible = true;
            grpMedicaoEnergiaBombas.Visible = true;
        }

//Método Não Bombas
        private void optNaoBombas_CheckedChanged(object sender, EventArgs e)
        {
            grpQuantidadeBombas.Visible = false;
            grpMedicaoEnergiaBombas.Visible = false;
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = false;
            grpBomba01.Visible = false;
            grpBomba02.Visible = false;
            grpBomba03.Visible = false;
            grpBomba04.Visible = false;
            grpBomba05.Visible = false;
            grpBomba06.Visible = false;
            limparLevantamentoBombas();
        }

//Método Quantidade 1 Bombas Checked Changed
        private void opt1QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = false;
            grpBomba01.Visible = true;
        }

//Método Quantidade 2 Bombas Checked Changed
        private void opt2QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = true;
            grpBomba01.Visible = true;
        }

//Método Quantidade 3 Bombas Checked Changed
        private void opt3QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = true;
            grpBomba01.Visible = true;
        }

//Método Quantidade 4 Bombas Checked Changed
        private void opt4QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = true;
            grpBomba01.Visible = true;
        }

//Método Quantidade 5 Bombas Checked Changed
        private void opt5QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = true;
            grpBomba01.Visible = true;
        }

//Método Quantidade 6 Bombas Checked Changed
        private void opt6QuantidadeBombas_CheckedChanged(object sender, EventArgs e)
        {
            btnAnteriorBombas.Visible = false;
            btnProximoBombas.Visible = true;
            grpBomba01.Visible = true;
        }

//Método Botão Próximo
        private void btnProximoBombas_Click(object sender, EventArgs e)
        {
            if (opt1QuantidadeBombas.Checked)
            {
                btnAnteriorBombas.Visible = false;
                btnProximoBombas.Visible = false;
                grpBomba01.Visible = true;
                grpBomba02.Visible = false;
                grpBomba03.Visible = false;
            }
            else if (opt2QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                    grpBomba01.Visible = false;
                    grpBomba02.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                }
            }
            else if (opt3QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = false;
                    grpBomba02.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                    grpBomba02.Visible = false;
                    grpBomba03.Visible = true;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                }
            }
            else if (opt4QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = false;
                    grpBomba02.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = false;
                    grpBomba03.Visible = true;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                    grpBomba03.Visible = false;
                    grpBomba04.Visible = true;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                }
            }
            else if (opt5QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = false;
                    grpBomba02.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = false;
                    grpBomba03.Visible = true;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba03.Visible = false;
                    grpBomba04.Visible = true;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                    grpBomba04.Visible = false;
                    grpBomba05.Visible = true;
                }
                else if (grpBomba05.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                }
            }
            else if (opt6QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = false;
                    grpBomba02.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = false;
                    grpBomba03.Visible = true;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba03.Visible = false;
                    grpBomba04.Visible = true;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba04.Visible = false;
                    grpBomba05.Visible = true;
                }
                else if (grpBomba05.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                    grpBomba05.Visible = false;
                    grpBomba06.Visible = true;
                }
                else if (grpBomba06.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = false;
                }
            }
        }

//Botão Anterior
        private void btnAnteriorBombas_Click(object sender, EventArgs e)
        {
            if (opt1QuantidadeBombas.Checked)
            {
                btnAnteriorBombas.Visible = false;
                btnProximoBombas.Visible = false;
                grpBomba01.Visible = true;
            }
            else if (opt2QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = true;
                    grpBomba02.Visible = false;
                }
            }
            else if (opt3QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = true;
                    grpBomba02.Visible = false;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = true;
                    grpBomba03.Visible = false;
                }
            }
            else if (opt4QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = true;
                    grpBomba02.Visible = false;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = true;
                    grpBomba03.Visible = false;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba03.Visible = true;
                    grpBomba04.Visible = false;
                }
            }
            else if (opt5QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = true;
                    grpBomba02.Visible = false;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = true;
                    grpBomba03.Visible = false;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba03.Visible = true;
                    grpBomba04.Visible = false;
                }
                else if (grpBomba05.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba04.Visible = true;
                    grpBomba05.Visible = false;
                }
            }
            else if (opt6QuantidadeBombas.Checked)
            {
                if (grpBomba01.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                }
                else if (grpBomba02.Visible == true)
                {
                    btnAnteriorBombas.Visible = false;
                    btnProximoBombas.Visible = true;
                    grpBomba01.Visible = true;
                    grpBomba02.Visible = false;
                }
                else if (grpBomba03.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba02.Visible = true;
                    grpBomba03.Visible = false;
                }
                else if (grpBomba04.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba03.Visible = true;
                    grpBomba04.Visible = false;
                }
                else if (grpBomba05.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba04.Visible = true;
                    grpBomba05.Visible = false;
                }
                else if (grpBomba06.Visible == true)
                {
                    btnAnteriorBombas.Visible = true;
                    btnProximoBombas.Visible = true;
                    grpBomba05.Visible = true;
                    grpBomba06.Visible = false;
                }
            }
        }

//Método Bomba 1 Sim Infra Checked Changed
        private void optSimInfraB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB1Bombas.Visible = false;
        }

//Método Bomba 1 Não Infra Checked Changed
        private void optNaoInfraB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB1Bombas.Visible = true;
        }

//Método Bomba 1 Inversor Checked Changed
        private void optInversorB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB1Bombas.Enabled = true;
        }

//Método Bomba 1 Soft-Starter Checked Changed
        private void optSoftStarterB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB1Bombas.Enabled = true;
        }

//Método Bomba 1 Partida Direta Checked Changed
        private void optDiretaB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB1Bombas.Enabled = false;
        }

//Método Bomba 1 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB1Bombas.Enabled = false;
        }

//Método Bomba 1 Compensadora Checked Changed
        private void optCompensadoraB1Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB1Bombas.Enabled = false;
        }

//Método Bomba 2 Sim Infra Checked Changed
        private void optSimInfraB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB2Bombas.Visible = false;
        }

//Método Bomba 2 Não Infra Checked Changed
        private void optNaoInfraB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB2Bombas.Visible = true;
        }

//Método Bomba 2 Inversor Checked Changed
        private void optInversorB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB2Bombas.Enabled = true;
        }

//Método Bomba 2 Soft-Starter Checked Changed
        private void optSoftStarterB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB2Bombas.Enabled = true;
        }

//Método Bomba 2 Partida Direta Checked Changed
        private void optDiretaB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB2Bombas.Enabled = false;
        }

//Método Bomba 2 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB2Bombas.Enabled = false;
        }

//Método Bomba 2 Compensadora Checked Changed
        private void optCompensadoraB2Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB2Bombas.Enabled = false;
        }

//Método Bomba 3 Sim Infra Checked Changed
        private void optSimInfraB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB3Bombas.Visible = false;
        }

//Método Bomba 3 Não Infra Checked Changed
        private void optNaoInfraB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB3Bombas.Visible = true;
        }

//Método Bomba 3 Inversor Checked Changed
        private void optInversorB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB3Bombas.Enabled = true;
        }

//Método Bomba 3 Soft-Starter Checked Changed
        private void optSoftStarterB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB3Bombas.Enabled = true;
        }

//Método Bomba 3 Partida Direta Checked Changed
        private void optDiretaB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB3Bombas.Enabled = false;
        }

//Método Bomba 3 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB3Bombas.Enabled = false;
        }

//Método Bomba 3 Compensadora Checked Changed
        private void optCompensadoraB3Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB3Bombas.Enabled = false;
        }

//Método Bomba 4 Sim Infra Checked Changed
        private void optSimInfraB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB4Bombas.Visible = false;
        }

//Método Bomba 4 Não Infra Checked Changed
        private void optNaoInfraB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB4Bombas.Visible = true;
        }

//Método Bomba 4 Inversor Checked Changed
        private void optInversorB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB4Bombas.Enabled = true;
        }

//Método Bomba 4 Soft-Starter Checked Changed
        private void optSoftStarterB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB4Bombas.Enabled = true;
        }

//Método Bomba 4 Partida Direta Checked Changed
        private void optDiretaB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB4Bombas.Enabled = false;
        }

//Método Bomba 4 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB4Bombas.Enabled = false;
        }

//Método Bomba 4 Compensadora Checked Changed
        private void optCompensadoraB4Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB4Bombas.Enabled = false;
        }

//Método Bomba 5 Sim Infra Checked Changed
        private void optSimInfraB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB5Bombas.Visible = false;
        }

//Método Bomba 5 Não Infra Checked Changed
        private void optNaoInfraB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB5Bombas.Visible = true;
        }

//Método Bomba 5 Inversor Checked Changed
        private void optInversorB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB5Bombas.Enabled = true;
        }

//Método Bomba 5 Soft-Starter Checked Changed
        private void optSoftStarterB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB5Bombas.Enabled = true;
        }

//Método Bomba 5 Partida Direta Checked Changed
        private void optDiretaB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB5Bombas.Enabled = false;
        }

//Método Bomba 5 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB5Bombas.Enabled = false;
        }

//Método Bomba 5 Compensadora Checked Changed
        private void optCompensadoraB5Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB5Bombas.Enabled = false;
        }

//Método Bomba 6 Sim Infra Checked Changed
        private void optSimInfraB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB6Bombas.Visible = false;
        }

//Método Bomba 6 Não Infra Checked Changed
        private void optNaoInfraB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraB6Bombas.Visible = true;
        }

//Método Bomba 6 Inversor Checked Changed
        private void optInversorB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB6Bombas.Enabled = true;
        }

//Método Bomba 6 Soft-Starter Checked Changed
        private void optSoftStarterB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB6Bombas.Enabled = true;
        }

//Método Bomba 6 Partida Direta Checked Changed
        private void optDiretaB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB6Bombas.Enabled = false;
        }

//Método Bomba 6 Estrela-Triângulo Checked Changed
        private void optEstrelaTrianguloB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB6Bombas.Enabled = false;
        }

//Método Bomba 6 Compensadora Checked Changed
        private void optCompensadoraB6Bombas_CheckedChanged(object sender, EventArgs e)
        {
            txtModeloB6Bombas.Enabled = false;
        }
        
        /*
         * SUB-TAB 07
        */

//Método SimDosadores_CheckedChanged
        private void optSimDosadores_CheckedChanged(object sender, EventArgs e)
        {
            grpCloroDosadores.Visible = true;
            grpFluorDosadores.Visible = true;
        }

//Método NãoDosadores_CheckedChanged
        private void optNaoDosadores_CheckedChanged(object sender, EventArgs e)
        {
            limparLevantamentoDosadores();
            grpCloroDosadores.Visible = false;
            grpFluorDosadores.Visible = false;
        }

//Método SimInfraFluor_CheckedChanged
        private void optSimInfraFluorDosadores_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraFluorDosadores.Visible = false;
        }

//Método NãoInfraFluor_CheckedChanged
        private void optNaoInfraFluorDosadores_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraFluorDosadores.Visible = true;
        }

//Método SimInfraCloro_CheckedChanged
        private void optSimInfraCloroDosadores_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraCloroDosadores.Visible = false;
        }

//Método NaoInfraCloro_CheckedChanged        
        private void optNaoInfraCloroDosadores_CheckedChanged(object sender, EventArgs e)
        {
            grpInfraCloroDosadores.Visible = true;
        }

        /*
         * SUB-TAB 08
        */


/*
 * TAB 05
*/

//Método Limpar Campos
        public void limparViagens()
        {
            txtOpViagens.Text = "";
            txtDataViagens.Text = "";
            txtCombustívelViagens.Text = "";
            txtPedagioViagens.Text = "";
            txtOutrosViagens.Text = "";
            txtRefeicaoViagens.Text = "";
            txtMateriaisViagens.Text = "";
            txtTarefaViagens.Text = "";
            cmbVeiculoViagens.Text = "";
            ltvEquipeViagens.Text = "";
        }

//Método verificarBrancos()
        public bool verificarBrancosViagens()
        {
            bool resposta;
            if ((txtOpViagens.Text == "") && (txtDataViagens.Text == ""))
            {
                resposta = false;
            }
            else
            {
                resposta = true;
            }
            return resposta;
        }

//Método popular List View
        public void popularListViewFuncionarioViagens()
        {
            ltvEquipeViagens.DataSource = funcionarioDAO.listarTodos();
            ltvEquipeViagens.DisplayMember = "Nome";
            ltvEquipeViagens.ValueMember = "Nome";
            DataTable dt = (DataTable)ltvEquipeViagens.DataSource;
            DataRow linha = dt.NewRow();
            dt.Rows.InsertAt(linha, 0);
            ltvEquipeViagens.SelectedIndex = 0;
        }

//Método popular Combo Veiculo
        public void popularComboVeiculoViagens()
        {
            cmbVeiculoViagens.DataSource = veiculoDAO.listarTodos();
            cmbVeiculoViagens.DisplayMember = "Nome";
            cmbVeiculoViagens.ValueMember = "Nome";
            DataTable dt = (DataTable)cmbVeiculoViagens.DataSource;
            DataRow linha = dt.NewRow();
            dt.Rows.InsertAt(linha, 0);
            cmbVeiculoViagens.SelectedIndex = 0;
        }

//Método Cell Double Click
        private void dgrViagens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dgrViagens.Rows[e.RowIndex].Cells[0].Value.ToString());
            viagemDAO.preencheCamposViagens(id);
            popularTextBoxViagens();
            btnInserirViagem.Enabled = false;
            btnAtualizarViagem.Enabled = true;
            btnExcluirViagem.Enabled = true;
        }

//Método Popular TextBox
        public void popularTextBoxViagens()
        {
            txtOpViagens.Text = viagemDAO.getOp().ToString();
            txtDataViagens.Text = viagemDAO.getData().ToString("dd/MM/yyyy");
            txtCombustívelViagens.Text = viagemDAO.getCombustivel().ToString();
            txtRefeicaoViagens.Text = viagemDAO.getRefeicao().ToString();
            txtPedagioViagens.Text = viagemDAO.getPedagio().ToString();
            txtOutrosViagens.Text = viagemDAO.getOutros().ToString();
            txtMateriaisViagens.Text = viagemDAO.getMateriais();
            txtTarefaViagens.Text = viagemDAO.getTarefa();
            cmbVeiculoViagens.Text = viagemDAO.getVeiculo();
            //ltvEquipeViagens.Text = viagemDAO.getEquipe();
        }

//Método popularGrid()
        public void popularGridViagens()
        {
            dgrViagens.DataSource = viagemDAO.listarTodos();
            if (dgrMedicao.Columns.Count > 0)
            {
                dgrViagens.Columns[0].Width = 80;
                dgrViagens.Columns[1].Width = 80;
                dgrViagens.Columns[2].Width = 100;
                dgrViagens.Columns[3].Width = 100;
                dgrViagens.Columns[4].Width = 320;

                dgrViagens.Columns[0].HeaderText = "Código";
                dgrViagens.Columns[1].HeaderText = "OP";
                dgrViagens.Columns[2].HeaderText = "Data";
                dgrViagens.Columns[3].HeaderText = "Veiculo";
                dgrViagens.Columns[4].HeaderText = "Tarefa";
            }
        }

//Método txtOP Text Changed
        private void txtOpViagens_TextChanged(object sender, EventArgs e)
        {
            btnInserirViagem.Enabled = true;
        }

//Método Botão Listar 
        private void btnListarViagens_Click(object sender, EventArgs e)
        {
            popularGridViagens();
        }

//Método Botão Inserir
        private void btnInserirViagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosViagens())
                {
                    bool resposta;
                    viagemDAO.setOp(Convert.ToInt16(txtOpViagens.Text));
                    viagemDAO.setVeiculo(cmbVeiculoViagens.Text);
                    viagemDAO.setData(Convert.ToDateTime(txtDataViagens.Text));
                    viagemDAO.setRefeicao(Convert.ToDouble(txtRefeicaoViagens.Text));
                    viagemDAO.setCombutivel(Convert.ToDouble(txtCombustívelViagens.Text));
                    viagemDAO.setPedagio(Convert.ToDouble(txtPedagioViagens.Text));
                    viagemDAO.setOutros(Convert.ToDouble(txtOutrosViagens.Text));
                    viagemDAO.setTarefa(txtTarefaViagens.Text);
                    viagemDAO.setMateriais(txtMateriaisViagens.Text);

                    try
                    {
                        resposta = viagemDAO.inserirViagem();

                        if (resposta)
                        {
                            MessageBox.Show("Viagem cadastrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparViagens();
                            popularGridViagens();
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

//Método Botão Atualizar
        private void btnAtualizarViagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosViagens())
                {
                    bool resposta;
                    viagemDAO.setOp(Convert.ToInt16(txtOpViagens.Text));
                    viagemDAO.setVeiculo(cmbVeiculoViagens.Text);
                    viagemDAO.setData(Convert.ToDateTime(txtDataViagens.Text));
                    viagemDAO.setRefeicao(Convert.ToDouble(txtRefeicaoViagens.Text));
                    viagemDAO.setCombutivel(Convert.ToDouble(txtCombustívelViagens.Text));
                    viagemDAO.setPedagio(Convert.ToDouble(txtPedagioViagens.Text));
                    viagemDAO.setOutros(Convert.ToDouble(txtOutrosViagens.Text));
                    viagemDAO.setTarefa(txtTarefaViagens.Text);
                    viagemDAO.setMateriais(txtMateriaisViagens.Text);

                    try
                    {
                        resposta = viagemDAO.atualizarViagens(id);
                        limparViagens();
                        popularGridViagens();
                        if (resposta)
                        {
                            MessageBox.Show("Viagem atualizada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
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

//Método Botão Excluir
        private void btnExcluirViagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarBrancosViagens())
                {
                    bool resposta;
                    try
                    {
                        resposta = viagemDAO.excluirViagens(id);

                        if (resposta)
                        {
                            MessageBox.Show("Viagem excluida com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.None);
                            limparViagens();
                            popularGridViagens();
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