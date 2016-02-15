using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using getesi.DAO;
using getesi.Report;

namespace getesi.Frames
{
    public partial class frmRelatórios : Form
    {
        public frmRelatórios()
        {
            InitializeComponent();
        }

        private static frmRelatórios instance;
        FluxoBancarioDAO fluxoBancarioDAO = new FluxoBancarioDAO();
        ViagemDAO viagemDAO = new ViagemDAO();
        ProjetosDAO projetosDAO = new ProjetosDAO();

//Método getInstance()
        public static frmRelatórios getInstance()
        {
            if (instance == null)
            {
                instance = new frmRelatórios();
            }
            return instance;
        }

//Método FormClosing
        private void frmRelatórios_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void frmRelatórios_Load(object sender, EventArgs e)
        {
            populaFluxo();
            //populaViagem();
            //populaProjeto();
            //populaFornecedor();
        }

        public void populaFluxo()
        {
            //criar um data table com dados no mesmo formato
            //que o DataTable do DataSet que foi criado
            DataTable dt = fluxoBancarioDAO.listarRelatorioSoma();
            dgr1.DataSource = dt;
            //criar objeto do crystalReport
            crvFluxoCaixa objRelatorio = new crvFluxoCaixa();
            try
            {
                //vincular dataTable como fonte de dados do relatório
                objRelatorio.SetDataSource(dt);
                //vincular o objeto do crystal no viewer do form
                crvFluxo.ReportSource = objRelatorio;
                crvFluxo.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        /*
        public void populaFornecedor()
        {
            //criar um data table com dados no mesmo formato
            //que o DataTable do DataSet que foi criado
            DataTable dt = fluxoBancarioDAO.listarRelatorioFornecedor_Gastos();

            //criar objeto do crystalReport
            crvFornecedor1 objRelatorio = new crvFornecedor1();

            //vincular dataTable como fonte de dados do relatório
            objRelatorio.SetDataSource(dt);

            //vincular o objeto do crystal no viewer do form
            crvForn.ReportSource = objRelatorio;
            crvForn.Refresh();
        }
          
        public void populaViagem()
        {
            //criar um data table com dados no mesmo formato
            //que o DataTable do DataSet que foi criado
            DataTable dt = viagemDAO.listarTodosRelatorio();

            //criar objeto do crystalReport
            crvViagem objRelatorio = new crvViagem();

            //vincular dataTable como fonte de dados do relatório
            objRelatorio.SetDataSource(dt);

            //vincular o objeto do crystal no viewer do form
            crvVia.ReportSource = objRelatorio;
            crvVia.Refresh();
        }
         
        public void populaProjeto()
        {
            //criar um data table com dados no mesmo formato
            //que o DataTable do DataSet que foi criado
            DataTable dt = projetosDAO.listarTodosRelatorio();

            //criar objeto do crystalReport
            crvProjeto objRelatorio = new crvProjeto();

            //vincular dataTable como fonte de dados do relatório
            objRelatorio.SetDataSource(dt);

            //vincular o objeto do crystal no viewer do form
            crvProj.ReportSource = objRelatorio;
            crvProj.Refresh();
        }
        */
    }
}
