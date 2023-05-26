using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proje_hastane
{
    public partial class frmsekretergiris : Form
    {
        public frmsekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from Tbl_sekreter where SekreterTc=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmsekreterdetay fr = new frmsekreterdetay();
                fr.tcnumara = msktc.Text;
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("hatalı şifre veya tc");
            }
            bgl.baglanti().Close();
        }

        private void frmsekretergiris_Load(object sender, EventArgs e)
        {

        }
    }
}
