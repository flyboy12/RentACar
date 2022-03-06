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
    public partial class AnaSayfaForm : Form
    {
        public AnaSayfaForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {            //Bayilere Gidiş
            BayiForm    bayi = new BayiForm();
            bayi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {         //   Arabalara Gidis

            ArabaForm   araba = new ArabaForm();
            araba.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Müşterilere ve işlemlere Gidiş
            MusteriVeIslemForm mus = new MusteriVeIslemForm();
            mus.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RaporForm raporForm = new RaporForm();
            raporForm.Show();
            this.Hide();
        }
    }
}
