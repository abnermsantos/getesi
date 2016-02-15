/*
 * Tela utilizada apenas como uma breve apresentação da empresa.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace getesi.Frames
{
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        private static frmHistorico instance;

//Método getInstance()
        public static frmHistorico getInstance()
        {
            if (instance == null)
            {
                instance = new frmHistorico();
            }
            return instance;
        }

        private void frmHistorico_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
