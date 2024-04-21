using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinemaTakip
{
    public partial class SeansListe : Form
    {
        public SeansListe()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Sinema_bileti;Integrated Security=True");
        DataTable tablo = new DataTable();
        private void seansListesi(string sql)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void SeansListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa Return = new AnaSayfa();
            Return.Show();
        }

        private void SeansListe_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            seansListesi("select *from Seans_Bilgileri where tarih like '" + dateTimePicker1.Text + "'");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();

            seansListesi("select *from Seans_Bilgileri where tarih like '" + dateTimePicker1.Text + "'");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();

            seansListesi("select *from Seans_Bilgileri");

        }
    }
}
