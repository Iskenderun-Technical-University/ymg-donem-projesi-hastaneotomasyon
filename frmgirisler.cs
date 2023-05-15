using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_hastane
{
    public partial class frmgirisler : Form
    {
        public frmgirisler()
        {
            InitializeComponent();
        }

        private void btnhastagirisi_Click(object sender, EventArgs e)
        {
            frmhastagiris fr = new frmhastagiris();
            fr.Show();
            this.Hide();
        }

        private void btndoktorgirisi_Click(object sender, EventArgs e)
        {
            frmdoktorgiris fr = new frmdoktorgiris();
            fr.Show();
            this.Hide();
        }

        private void btnsekretergirisi_Click(object sender, EventArgs e)
        {
            frmsekretergiris fr = new frmsekretergiris();
            fr.Show();
            this.Hide();
        }

        private void frmgirisler_Load(object sender, EventArgs e)
        {

        }
    }
}
