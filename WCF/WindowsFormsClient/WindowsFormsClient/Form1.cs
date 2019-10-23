using System;
using System.Windows.Forms;
using WindowsFormsClient.ServiceReference1;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _obj = new MathServiceClient("NetTcpBinding_IMathService");
            label4.Text = _obj.Addition(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
        }
    }
}
