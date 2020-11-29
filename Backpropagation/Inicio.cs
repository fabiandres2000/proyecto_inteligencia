using pruebaRed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backpropagation
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        public void fn_bar()
        {
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_bar();
        }
    }
}
