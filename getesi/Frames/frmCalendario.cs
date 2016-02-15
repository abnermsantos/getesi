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
    public partial class frmCalendario : Form
    {
        public frmCalendario()
        {
            InitializeComponent();
        }

        private static frmCalendario instance;

//Método getInstance()
        public static frmCalendario getInstance()
        {
            if (instance == null)
            {
                instance = new frmCalendario();
            }
            return instance;
        }

//Método Form Closing
        private void frmCalendario_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
