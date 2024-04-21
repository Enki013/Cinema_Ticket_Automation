using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinemaTakip
{
    public partial class SalonEkle : Form
    {
        public SalonEkle()
        {
            InitializeComponent();
        }

        private void SalonEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa Return = new AnaSayfa();
            Return.Show();
        }
        SinemaTableAdapters.Salon_BilgileriTableAdapter salon = new SinemaTableAdapters.Salon_BilgileriTableAdapter();

        private void btnSalonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                salon.SalonEkleme(txtSalonAdi.Text);
                MessageBox.Show("Salon eklendi.", "Kayıt");
            }
            catch (SqlException)
            {

                MessageBox.Show("Salon Adı zaten kayıtlı.");
            }
            txtSalonAdi.Clear();
        }
    }
}
