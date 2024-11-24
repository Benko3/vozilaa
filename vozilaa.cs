using Vozila;

namespace VOZILA
{
    public partial class Form1 : Form
    {
        private List<Vozilo> vozila;
        private object cboKriterij;
        private object listaVozila;

        public Form1()
        {
            InitializeComponent();
            vozila = new List<Vozilo>();
            comboBoxSortiraj.Items.AddRange(new string[] { "Marka", "Model", "GodinaProizvodnje", "Kilometraza" });
            comboBoxSortiraj.SelectedIndex = 0;
        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            string marka = txtMarka.Text;
            string model = txtModel.Text;
            int godinaProizvodnje;
            int kilometraza;
            if (!int.TryParse(txtGodinaProizvodnje.Text, out godinaProizvodnje) || godinaProizvodnje <= 0)
            {
                MessageBox.Show("Unesite validnu godinu proizvodnje.");
                return;
            }

            if (!int.TryParse(txtKilometraza.Text, out kilometraza) || kilometraza < 0)
            {
                MessageBox.Show("Unesite validnu kilometražu.");
                return;
            }

            txtMarka.Clear();
            txtModel.Clear();
            txtGodinaProizvodnje.Clear();
            txtKilometraza.Clear();
        }

        private object GetCboKriterij()
        {
            return cboKriterij;
        }

        private void btnSortiraj_Click(object sender, EventArgs e, object cboKriterij)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnObrisiVozilo_Click(object sender, EventArgs e)
        {
            if (listBoxVozila.SelectedItem != null)
            {
                Vozilo voziloZaBrisanje = (Vozilo)listBoxVozila.SelectedItem;
                vozila.Remove(voziloZaBrisanje);
                listBoxVozila.Items.Remove(voziloZaBrisanje);
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            string filePath = "vozila.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var vozilo in vozila)
                {
                    writer.WriteLine($"{vozilo.Marka},{vozilo.Model},{vozilo.GodinaProizvodnje},{vozilo.Kilometraza}");
                }
            }
            MessageBox.Show("Podaci su uspješno spremljeni.");
        }
    }
}
