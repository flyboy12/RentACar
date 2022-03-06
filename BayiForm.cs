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
    public partial class BayiForm : Form
    {
        public BayiForm()
        {
            InitializeComponent();
        }
       RentACarContainer conn = new RentACarContainer();    
        private void label1_Click(object sender, EventArgs e)
        {
            //Geri
            AnaSayfaForm anaSayfaForm = new AnaSayfaForm();
            this.Hide();
            anaSayfaForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Çıkış
            Application.Exit();
        }
       void Listele()
        {
            dataGridView1.DataSource = conn.BayilerSet.ToList();
        }
        private void BayiForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void TextBoxTemizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //işlem gerçekleştirme
            if (comboBox1.SelectedIndex == 0)
            {
               Bayiler bayiler = new Bayiler();
                bayiler.Adi = textBox1.Text;
                bayiler.Yetkilisi = textBox2.Text;
                bayiler.BayiAdres =textBox3.Text;
                bayiler.BayiCiro = Convert.ToDecimal(textBox4.Text);
                bayiler.BayiTelefon = textBox5.Text;
                conn.BayilerSet.Add(bayiler);   
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex ==1)
            {
                int bayId = Convert.ToInt32(textBox1.Tag);
                Bayiler bayiler = conn.BayilerSet.Where(x=> x.BayiId == bayId).FirstOrDefault();
                bayiler.Adi = textBox1.Text;
                bayiler.Yetkilisi = textBox2.Text;
                bayiler.BayiAdres = textBox3.Text;
                bayiler.BayiCiro = Convert.ToDecimal(textBox4.Text);
                bayiler.BayiTelefon = textBox5.Text;
                conn.SaveChanges();
            }
            else if (comboBox1.SelectedIndex ==2)
            {
                int bayId = Convert.ToInt32(textBox1.Tag);
                Bayiler bayiler = conn.BayilerSet.Where(x => x.BayiId == bayId).FirstOrDefault();
                conn.BayilerSet.Remove(bayiler);
                conn.SaveChanges();
            }
            TextBoxTemizleme();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verileri textboxa getirme
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells[0].Value.ToString();
            textBox1.Text= row.Cells[1].Value.ToString();
            textBox2.Text= row.Cells[2].Value.ToString();
            textBox3.Text=row.Cells[3].Value.ToString();
            textBox4.Text= row.Cells[5].Value.ToString();
            textBox5.Text= row.Cells[4].Value.ToString();
        }
    }
}
