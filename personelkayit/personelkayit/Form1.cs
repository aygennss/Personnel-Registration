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

namespace personelkayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=AYGEN\\MSSQLSERVERR;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");

        void Temizle()
        {
            textad.Text = " ";
            textsoyad.Text = " ";
            textsehir.Text = " ";
            textid.Text = " ";
            textmeslek.Text = " ";
            textmaas.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textad.Focus();


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabanıDataSet.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
            label8.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", textad.Text);
            komut.Parameters.AddWithValue("@p2", textsoyad.Text);
            komut.Parameters.AddWithValue("@p3", textsehir.Text);
            komut.Parameters.AddWithValue("@p4", textmaas.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", textmeslek.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("personel eklendi");
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textsehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textmaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Personel where PersonelId=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", textid.Text);
            sil.ExecuteNonQuery();
            
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Personel set PerAd=@p1, PerSoyad=@p2, PerSehir=@p3, PerMaas=@p4, PerDurum=@p5, PerMeslek=@p6 where PersonelId=@p7", baglanti);
            guncelle.Parameters.AddWithValue("p1", textad.Text);
            guncelle.Parameters.AddWithValue("p2", textsoyad.Text);
            guncelle.Parameters.AddWithValue("p3", textsehir.Text);
            guncelle.Parameters.AddWithValue("p4", textmaas.Text);
            guncelle.Parameters.AddWithValue("p5", label8.Text);
            guncelle.Parameters.AddWithValue("p6", textmeslek.Text);
            guncelle.Parameters.AddWithValue("p7", textid.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("güncellendi");
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
