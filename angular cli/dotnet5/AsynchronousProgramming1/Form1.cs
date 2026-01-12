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

namespace AsynchronousProgramming1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void async_result_Click(object sender, EventArgs e)
        {
            var r = await new TimePrinter().PrintAsyn();
            MessageBox.Show(r.ToString());
        }
        
        private void Task_Click(object sender, EventArgs e)
        {
            Task.Run(new TimePrinter().Print);
        }

        private void hello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello" + DateTime.Now.ToString("hh:mm:ss"));
        }

        private void sync_Click(object sender, EventArgs e)
        {
            new TimePrinter().Print();
        }

        private void thread_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new TimePrinter().Print);
            thread.Start();
        }

        private async Task async_ClickAsync(object sender, EventArgs e)
        {
            var r = await new TimePrinter().PrintAsyn();
            MessageBox.Show(r.ToString());

        }
    }
}
