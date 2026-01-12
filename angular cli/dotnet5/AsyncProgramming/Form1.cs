using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new TimePrinter().Print);
            thread.Start();

        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            int result =await new TimePrinter().PrintAsync();
            MessageBox.Show(result.ToString());
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            Task<int> result = new TimePrinter().PrintAsync();
            MessageBox.Show(result.ToString());
        }

      

        private void btnHello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello user ");
        }

        private void btnSync_Click_1(object sender, EventArgs e)
        {
            new TimePrinter().Print();
        }
    }
}
