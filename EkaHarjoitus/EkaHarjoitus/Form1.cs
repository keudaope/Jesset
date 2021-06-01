using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkaHarjoitus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PainaMinuaBt_Click(object sender, EventArgs e)
        {
            TulosteLB.Text = "Hei " + NimiTB.Text + ". Hauska tavata";
            NimiTB.Text = "Syötä uusi nimi";
        }
    }
}
