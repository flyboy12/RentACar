using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class ArabaForm : Form
    {
        public ArabaForm()
        {
            InitializeComponent();
        }
        RentACarContainer conn = new RentACarContainer();

        private void button1_Click(object sender, EventArgs e)
        {
            //Ekle Güncelle Sil
            // işlem yapılacak alan
            if (comboBox1.SelectedIndex == 0)
            {
                Arabalar araba = new Arabalar();
                araba.Marka = textBox1.Text;
                araba.Model = textBox2.Text;
                araba.Ozellik = textBox3.Text;
                araba.KM= Convert.ToInt32(textBox4.Text);
                araba.GunlukTutar = Convert.ToDecimal(textBox5.Text);
                araba.BayiId = Convert.ToInt32(comboBox3.Text);
                araba.HGS = comboBox2.Text;
                conn.ArabalarSet.Add(araba);
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int arabaId = Convert.ToInt32(textBox1.Tag);
                Arabalar araba = conn.ArabalarSet.Where(x => x.ArabaId == arabaId).FirstOrDefault();
                araba.Marka = textBox1.Text;
                araba.Model = textBox2.Text;
                araba.Ozellik = textBox3.Text;
                araba.KM = Convert.ToInt32(textBox4.Text);
                araba.GunlukTutar = Convert.ToDecimal(textBox5.Text);
                araba.ArabaId = Convert.ToInt32(comboBox3.Text);
                araba.HGS = comboBox2.Text;
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int arabaId = Convert.ToInt32(textBox1.Tag);
                Arabalar araba = conn.ArabalarSet.Where(x => x.ArabaId == arabaId).FirstOrDefault();
                conn.ArabalarSet.Remove(araba);
                conn.SaveChanges();
            }
            TextBoxTemizleme();
            Listele();
        }
        void TextBoxTemizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
        private void ArabaForm_Load(object sender, EventArgs e)
        {
            Listele();
            comboBox3.DataSource = conn.BayilerSet.Select(x => x.BayiId).ToList();
            // Veri Listeleme 
            //ComboBox3 e Bayi ıdler veyaisimler listelenecek

        }
        void Listele() 
        {
        dataGridView1.DataSource = conn.ArabalarSet.ToList();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Veri atama
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            comboBox2.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
            comboBox3.Text = row.Cells[7].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfaForm anaSayfa = new AnaSayfaForm();
            anaSayfa.Show();
        }
    }
}
