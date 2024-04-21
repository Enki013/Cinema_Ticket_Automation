using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinemaTakip
{
    public partial class SatisListe : Form
    {
        public SatisListe()
        {
            InitializeComponent();
        }

        SinemaTableAdapters.SatisBilgileriTableAdapter SatisListesi = new SinemaTableAdapters.SatisBilgileriTableAdapter();

        private void SatisListe_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            AnaSayfa Return = new AnaSayfa();

            Return.Show();
        }
        private void LoadData(DateTime filterDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Sinema_bileti;Integrated Security=True"))
                {
                    connection.Open();

                    // SQL sorgunuzu burada oluşturun, DateTime değeriyle filtreleyin
                    string query = "SELECT * FROM SatisBilgileri WHERE SatisTarihi = @filterDate";

                    // SqlCommand ve SqlDataAdapter oluşturun
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // @filterDate parametresini ekle
                        command.Parameters.AddWithValue("@filterDate", filterDate);

                        // SqlDataAdapter ile verileri yükle
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView'in veri kaynağını ata
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void SatisListe_Load(object sender, EventArgs e)
        {



            dataGridView1.DataSource = SatisListesi.SatisListesi2();
            ToplamUcretHesapla();
        }

        private void ToplamUcretHesapla()
        {
            dataGridView1.DataSource = SatisListesi.SatisListesi2();
            int ucrettoplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ucrettoplam += Convert.ToInt32(dataGridView1.Rows[i].Cells["ucret"].Value);
            }
            lblToplamSatis.Text = "Toplam Satış=" + ucrettoplam + "TL";
        }
        private void lblToplamSatis_Click(object sender, EventArgs e)
        {

        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{ // DateTime değeri
        //    DateTime filterDate = dateTimePicker1.Value;

        //    // DataGridView için veri kaynağını yükle
        //    LoadData(filterDate);

        //    //dataGridView1.DataSource = dataTable;
        //    ToplamUcretHesapla();
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
