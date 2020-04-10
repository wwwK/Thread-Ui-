using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread多线程调用Ui线程
{
    public partial class Form2 : Form
    {
        Action<string,string> st;
        public Form2(Action<string,string> _st)
        {
        
            InitializeComponent();
            st = _st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st?.Invoke(textBox1.Text, DateTime.Now.ToString());
            this.Close();
        }
    }
}
