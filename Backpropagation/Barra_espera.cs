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
    public partial class Barra_espera : Form
    {
        public Barra_espera()
        {
            InitializeComponent();
        }

        private void Barra_espera_Load(object sender, EventArgs e)
        {

        }

        public void fn_bar()
        {
            progressBar1.Increment(1);
            label2.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_bar();
        }
    }
}
