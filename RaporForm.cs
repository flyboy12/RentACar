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
    public partial class RaporForm : Form
    {
        public RaporForm()
        {
            InitializeComponent();
        }
        RentACarContainer conn = new RentACarContainer();

        private void button1_Click(object sender, EventArgs e)
        {
            //Geri
            AnaSayfaForm ana = new AnaSayfaForm();
            ana.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sorgu = from o in conn.OdemelerSet
                        orderby o.OdemeTutar descending 
                        select o;
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sorgu = from m in conn.MusterilerSet
                        where m.MusteriAdres.ToLower() =="istanbul" 
                        select m;
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sorgu = from a in conn.ArabalarSet
                        join odeme in conn.OdemelerSet
                        on a.ArabaId equals odeme.ArabaId
                        select new
                        {
                            a.Marka,
                            a.Ozellik,
                            odeme.OdemeTarih,
                            odeme.OdemeTutar,
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sorgu = from b in conn.BayilerSet
                        group b by new { b.BayiAdres } into
                        bg select new
                        {
                            Marka = bg.Key.BayiAdres,
                            YetkiliSayısı = bg.Count(),
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sorgu = from m in conn.MusterilerSet
                        join odeme in conn.OdemelerSet
                        on m.MusteriId equals odeme.MusteriId
                        select new
                        {
                            m.AdSoyad,
                            odeme.ArabaId,
                            odeme.OdemeTutar,
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var sorgu = from a in conn.ArabalarSet
                        group a by new { a.Marka } into ag
                        select new {         
                        Marka= ag.Key.Marka,
                        Ortalama = ag.Average(y=> y.GunlukTutar),

            };
            dataGridView1.DataSource = sorgu.ToList();
        }
    }
}
