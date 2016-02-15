namespace getesi.Frames
{
    partial class frmRelatórios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatórios));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.crvProj = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvFluxo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.crvForn = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvVia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dgr1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(649, 547);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.crvProj);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(641, 521);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Projetos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // crvProj
            // 
            this.crvProj.ActiveViewIndex = -1;
            this.crvProj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProj.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvProj.Location = new System.Drawing.Point(0, 0);
            this.crvProj.Name = "crvProj";
            this.crvProj.Size = new System.Drawing.Size(641, 521);
            this.crvProj.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvFluxo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fluxo de Caixa";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvFluxo
            // 
            this.crvFluxo.ActiveViewIndex = 0;
            this.crvFluxo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFluxo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvFluxo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvFluxo.Location = new System.Drawing.Point(3, 3);
            this.crvFluxo.Name = "crvFluxo";
            this.crvFluxo.ReportSource = this.reportDocument1;
            this.crvFluxo.Size = new System.Drawing.Size(635, 515);
            this.crvFluxo.TabIndex = 0;
            // 
            // reportDocument1
            // 
            this.reportDocument1.FileName = "rassdk://Z:/getesi/getesi/Report/crvFluxoCaixa";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crvForn);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(641, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fornecedor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // crvForn
            // 
            this.crvForn.ActiveViewIndex = -1;
            this.crvForn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvForn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvForn.Location = new System.Drawing.Point(0, 0);
            this.crvForn.Name = "crvForn";
            this.crvForn.Size = new System.Drawing.Size(641, 521);
            this.crvForn.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvVia);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Viagem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crvVia
            // 
            this.crvVia.ActiveViewIndex = -1;
            this.crvVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVia.Location = new System.Drawing.Point(3, 3);
            this.crvVia.Name = "crvVia";
            this.crvVia.Size = new System.Drawing.Size(635, 515);
            this.crvVia.TabIndex = 0;
            // 
            // dgr1
            // 
            this.dgr1.AllowUserToAddRows = false;
            this.dgr1.AllowUserToDeleteRows = false;
            this.dgr1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr1.Location = new System.Drawing.Point(655, 23);
            this.dgr1.Name = "dgr1";
            this.dgr1.ReadOnly = true;
            this.dgr1.Size = new System.Drawing.Size(371, 266);
            this.dgr1.TabIndex = 1;
            // 
            // frmRelatórios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1028, 548);
            this.Controls.Add(this.dgr1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelatórios";
            this.Text = "Relatórios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRelatórios_FormClosing);
            this.Load += new System.EventHandler(this.frmRelatórios_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgr1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvFluxo;
        //private Report.crvFluxoCaixa crvFluxoCaixa1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvForn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVia;
        private System.Windows.Forms.DataGridView dgr1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProj;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;

    }
}