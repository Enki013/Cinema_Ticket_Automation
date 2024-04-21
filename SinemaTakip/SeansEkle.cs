using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinemaTakip
{
    public partial class SeansEkle : Form
    {
        public SeansEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Sinema_bileti;Integrated Security=True");

        SinemaTableAdapters.Seans_BilgileriTableAdapter filmseansi = new SinemaTableAdapters.Seans_BilgileriTableAdapter();
        String seans = "";
        private void RadioButtonSeciliyse()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    seans = radioButton.Text;
                    break;
                }
            }

        }

        private void FilmVeSalonGoster(ComboBox combo, string sql, string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read() == true)
            {
                combo.Items.Add(reader[sql2].ToString());
            }
            baglanti.Close();

        }
        private void SeansEkle_Load(object sender, EventArgs e)
        {
            FilmVeSalonGoster(comboFilmAdi, "select *from Film_Bilgileri", "FilmAdi");
            FilmVeSalonGoster(comboSalon, "select *from Salon_Bilgileri", "SalonAdi");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RadioButtonSeciliyse();
            if (seans != "")
            {

                filmseansi.SeansEkleme(comboFilmAdi.Text, comboSalon.Text, dateTimePicker1.Text, seans);
                MessageBox.Show("Seans Ekleme işlemi tamamlandı.", "Kayit");

            }
            else if (seans == "")
            {
                MessageBox.Show("Seans Seçimi Yapılmadı.", "Uyarı");
            }
            comboSalon.Text = "";
            comboFilmAdi.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void SeansEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa Return = new AnaSayfa();

            Return.Show();



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;
            }
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (bugun == yeni)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                Tarihi_Karsilastir();
            }
            else if (yeni > bugun)
            {
                Tarihi_Karsilastir();
            }
            else if (yeni < bugun)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz.", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void Tarihi_Karsilastir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Seans_Bilgileri where SalonAdi='" + comboSalon.Text + "' and tarih='" + dateTimePicker1.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();
        }

        private void comboSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

        }
    }
}
