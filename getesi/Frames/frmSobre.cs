using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace getesi.Frames
{
    public partial class frmSobre : Form
    {
        public frmSobre()
        {
            InitializeComponent();
        }

        private static frmSobre instance;

//Método getInstance()
        public static frmSobre getInstance()
        {
            if (instance == null)
            {
                instance = new frmSobre();
            }
            return instance;
        }

//Método Form Closing
        private void frmSobre_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
