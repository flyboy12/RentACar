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
    public partial class MusteriVeIslemForm : Form
    {
        public MusteriVeIslemForm()
        {
            InitializeComponent();
        }
         RentACarContainer conn = new RentACarContainer();
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfaForm ana = new AnaSayfaForm();
            ana.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox1.Items.Clear();
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            comboBox3.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            listBox1.Items.Clear();
          int musId = Convert.ToInt32(row.Cells[0].Value.ToString());
            var odemeler = conn.OdemelerSet.Where(o => o.MusteriId == musId).ToList();
            for (int i = 0; i < odemeler.Count; i++)
            {
              listBox1.Items.Add("Ödenecek Tutar : "+odemeler[i].OdemeTutar.ToString());
              listBox1.Items.Add("Ödeme Tarihi : " + odemeler[i].OdemeTarih.ToString().Substring(0,10));
              listBox1.Items.Add("\n");
            }

            //Müşteri Bilgileri boxlara gelecek ve o müşterilerinin tahsilat bilgileri varsa onlar listelenecek
        } //Odenecek Tutarını listboxa 
        void Listele()
        {
            if (tabControl1.SelectedIndex ==0)
            {
                dataGridView1.DataSource = conn.MusterilerSet.ToList();
            }
            else if (tabControl1.SelectedIndex ==1)
            {
                dataGridView2.DataSource = conn.OdemelerSet.ToList();
            }
        }
        private void MusteriVeIslemForm_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            Listele();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // combobox1 e göre müşteri bilgi işlemleri
            if (comboBox1.SelectedIndex == 0)
            {
                Musteriler mus = new Musteriler();
                mus.AdSoyad = textBox1.Text;
                mus.Telefon = textBox2.Text;
                mus.TCKimlikNo = textBox3.Text;
                mus.EhliyetDurumu = comboBox3.Text;
                mus.MusteriAdres = textBox4.Text;
                conn.MusterilerSet.Add(mus);
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int musId = Convert.ToInt32(textBox1.Tag);
                Musteriler mus = conn.MusterilerSet.Where(x => x.MusteriId == musId).FirstOrDefault();
                mus.AdSoyad = textBox1.Text;
                mus.Telefon = textBox2.Text;
                mus.TCKimlikNo = textBox3.Text;
                mus.EhliyetDurumu = comboBox3.Text;
                mus.MusteriAdres = textBox4.Text;
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int musId = Convert.ToInt32(textBox1.Tag);
                Musteriler mus = conn.MusterilerSet.Where(x => x.MusteriId == musId).FirstOrDefault();
                conn.MusterilerSet.Remove(mus);
                conn.SaveChanges();
            }
            MusteriTextBoxTemizleme();
            Listele();
        }
       void MusteriTextBoxTemizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox3.Text ="";
        }
        void OdemeTextBoxTemizleme()
        {
            textBox9.Clear();
            textBox10.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // combobox2 ye göre ödeme işlemleri
            if (comboBox2.SelectedIndex == 0)
            {
                Odemeler odeme = new Odemeler();
                odeme.ArabaId = Convert.ToInt32(comboBox4.Text);
                odeme.MusteriId = Convert.ToInt32(comboBox5.Text);
                odeme.OdemeTarih = Convert.ToDateTime(dateTimePicker1.Text);
                odeme.OdemeTutar = Convert.ToDecimal(textBox9.Text);
                odeme.VadeFarki = Convert.ToDouble(textBox10.Text);
                conn.OdemelerSet.Add(odeme);
                conn.SaveChanges();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                int odemeId = Convert.ToInt32(textBox9.Tag);
                Odemeler odeme = conn.OdemelerSet.Where(x => x.OdemeId == odemeId).FirstOrDefault();
                odeme.ArabaId = Convert.ToInt32(comboBox4.Text);
                odeme.MusteriId = Convert.ToInt32(comboBox5.Text);
                odeme.OdemeTarih = Convert.ToDateTime(dateTimePicker1.Text);
                odeme.OdemeTutar = Convert.ToDecimal(textBox9.Text);
                odeme.VadeFarki = Convert.ToDouble(textBox10.Text);
                conn.SaveChanges();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                int odemeId = Convert.ToInt32(textBox9.Tag);
                Odemeler odeme = conn.OdemelerSet.Where(x => x.OdemeId == odemeId).FirstOrDefault();
                conn.OdemelerSet.Remove(odeme);
                conn.SaveChanges();
            }
            OdemeTextBoxTemizleme();
            Listele();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0 sa müşterilerin verisi gelecek  1 ise tahsilatların verisi gelecek 
            //1 e tıklandığında araba no musteri No boxların içine listelenerek gelecek
            if(tabControl1.SelectedIndex == 0)
            {
                groupBox2.Visible = false;
                groupBox1.Visible = true;
                OdemeTextBoxTemizleme();


            }
            else if (tabControl1.SelectedIndex == 1)
            {
                groupBox1.Visible = false;
                comboBox4.DataSource = conn.ArabalarSet.Select(x => x.ArabaId).ToList();
                comboBox5.DataSource = conn.MusterilerSet.Select(x => x.MusteriId).ToList();
                groupBox2.Visible = true;
                MusteriTextBoxTemizleme();
            }
            Listele();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //ödeme Bilgileri tabcontroller2 deki boxlara gidecek
            DataGridViewRow row = dataGridView2.CurrentRow;
            textBox9.Tag = row.Cells[0].Value.ToString();
            textBox9.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            textBox10.Text = row.Cells[3].Value.ToString();
            comboBox4.Text = row.Cells[4].Value.ToString();
            comboBox5.Text = row.Cells[5].Value.ToString();
        }
    }
}
