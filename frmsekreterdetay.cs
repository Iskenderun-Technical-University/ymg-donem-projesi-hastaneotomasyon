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
namespace Proje_hastane {

    public partial class frmsekreterdetay : Form
    {
        public string tcnumara;
        
        sqlbaglantisi bgl = new sqlbaglantisi();    
        public frmsekreterdetay()
        {
            InitializeComponent();
        }

        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnumara;
           
            //ad soyad
            SqlCommand komut1 = new SqlCommand("select SekreterAdSoyad from tbl_sekreter where SekreterTc=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();


            }
            bgl.baglanti().Close();

            //branşları datagride çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //doktorları listeye aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (Doktorad+' '+ DoktorSoyad)as 'doktorlar', DoktorBrans  from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;

            //branşı comboxa aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {


                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into  tbl_Randevular(RandevuTarih,Randevusaat,Randevubranş,RandevuDoktor)values(@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("randevu oluşturuldu!");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from tbl_doktorlar where Doktorbrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {


                cmbdoktor.Items.Add(dr[0] + "   " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru) values(@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rchduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("duyuru oluşturuldu!");
        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            frmdoktorpaneli fr = new frmdoktorpaneli();
            fr.Show();
            this.Hide();
        }

        private void btnbranspanel_Click(object sender, EventArgs e)
        {
            frmbranspaneli fr = new frmbranspaneli();
            fr.Show();
            this.Hide();
        }

        private void btnliste_Click(object sender, EventArgs e)
        {
            frmrandevulistesi fr = new frmrandevulistesi();
            fr.Show();
            this.Hide();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
        }

        private void duyurular_Click(object sender, EventArgs e)
        {
            frmduyurular fr = new frmduyurular();
            fr.Show();
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
