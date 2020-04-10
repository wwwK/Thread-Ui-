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

namespace Thread多线程调用Ui线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //下面总结来自 {https://blog.csdn.net/Fanbin168/article/details/39178427}
        // Action action //action是一个没有返回值，也没有参数的委托，相当于public delegate void action(),但还它也可以有带参数的，
        // Action<string> action  //action是有一个带参数，没有返回值的委托，相当于public delegate void action(string str); 
        // Func<string, int> func //func是一个带参数而且带返回值的委托，尖括号里的最后一个参数就是委托的返回值类型，它相当于public delegate int func(string str);
        // Func<int> func; //当这个func委托的尖括号里还有一个参数的时候，其实这个参数是委托的返回值类型，它相当于public delegate int func();

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //基础知识
          

            //action用法
            Form2 a2 = new Form2((x, ri) => { label1.Text = ri; });
            a2.ShowDialog();

            return;
            //多线程访问其他UI
            Thread td = new Thread(UpdateLabel2);
            td.Start("更新Label");

            

        }

        public delegate string setlab(string a);
        public setlab setlabDelP { get; set; }
        private void UpdateLabel2(object str)
        {
            if (label1.InvokeRequired)
            {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                //Action<string> actionDelegate = (x) => { this.label1.Text = x.ToString(); };
                // 或者
                Action<string> actionDelegate = delegate (string txt) { this.label1.Text = txt; };
                this.label1.Invoke(actionDelegate, str);
                //第二种
                setlabDelP = delegate (string txt) { return this.label1.Text = txt; };
                this.label1.Invoke(setlabDelP, str + "第二种");


            }
            else
            {
                this.label1.Text = str.ToString();
            }
        }
    }
}
