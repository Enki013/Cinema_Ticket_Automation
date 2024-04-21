using System;
using System.Windows.Forms;

namespace SinemaTakip
{
    public partial class FilmEkle : Form
    {
        public FilmEkle()
        {
            InitializeComponent();
        }
        SinemaTableAdapters.Film_BilgileriTableAdapter film = new SinemaTableAdapters.Film_BilgileriTableAdapter();
        private void FilmEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa Return = new AnaSayfa();
            Return.Show();
        }

        private void btnAfisSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void btnFilmEkle_Click(object sender, EventArgs e)
        {
            try
            {
                film.FilmEkleme(txtFilmAdi.Text, txtYonetmen.Text, comboFilmTuru.Text, txtSure.Text, dateTimePicker1.Text, txtYapimYili.Text, pictureBox1.ImageLocation);
                MessageBox.Show("Film Kaydedildi.");
            }
            catch (Exception)
            {


                MessageBox.Show("Bu film daha önce kaydedildi.", "Uyarı");
            }




            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            comboFilmTuru.SelectedIndex = -1;

        }

        private void FilmEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
