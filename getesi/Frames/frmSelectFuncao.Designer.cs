namespace getesi
{
    partial class frmSelectFuncao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectFuncao));
            this.btnProjetos = new System.Windows.Forms.Button();
            this.btnCustos = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProjetos
            // 
            this.btnProjetos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjetos.Location = new System.Drawing.Point(191, 135);
            this.btnProjetos.Name = "btnProjetos";
            this.btnProjetos.Size = new System.Drawing.Size(125, 68);
            this.btnProjetos.TabIndex = 0;
            this.btnProjetos.Text = "Gerenciamento \r\n  de Projetos";
            this.btnProjetos.UseVisualStyleBackColor = true;
            this.btnProjetos.Click += new System.EventHandler(this.btnProjetos_Click);
            // 
            // btnCustos
            // 
            this.btnCustos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustos.Location = new System.Drawing.Point(26, 135);
            this.btnCustos.Name = "btnCustos";
            this.btnCustos.Size = new System.Drawing.Size(125, 68);
            this.btnCustos.TabIndex = 1;
            this.btnCustos.Text = " Centro \r\nde Custos";
            this.btnCustos.UseVisualStyleBackColor = true;
            this.btnCustos.Click += new System.EventHandler(this.btnCustos_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.Location = new System.Drawing.Point(356, 135);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(125, 68);
            this.btnEstoque.TabIndex = 2;
            this.btnEstoque.Text = " Controle\r\nde Estoque\r\n";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistorico.Location = new System.Drawing.Point(26, 12);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(455, 99);
            this.btnHistorico.TabIndex = 3;
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // frmSelectFuncao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(502, 227);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnCustos);
            this.Controls.Add(this.btnProjetos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectFuncao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GETESI - Gerenciamento Tecnologia e Sistemas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProjetos;
        private System.Windows.Forms.Button btnCustos;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnHistorico;
    }
}

