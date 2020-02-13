using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class FORMNGUON1 : Form
    {
        public FORMNGUON1()
        {
            InitializeComponent();
        }

        private void NGUON1_Click(object sender, EventArgs e)
        {
            Formnguon f1 = new Formnguon();
            f1.ShowDialog();
            this.Hide(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
