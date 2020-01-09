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

namespace WindowsFormsApp1
{
    public partial class Form : System.Windows.Forms.Form
    {
        int a = 0;
        Thread t;
        Boolean b;
        public Form()
        {
            InitializeComponent();

            this.button1.Click += BtnClick1;
            this.button2.Click += BtnClick2;
        }

        public void BtnClick1(object sender, EventArgs e)
        {
            if(b == true)
            {
                t.Abort();
                b = false;
                return;
            }
            t = new Thread(new ThreadStart(Calc));
            t.Start();
            b = true;
        }

        delegate void aCall(int a);

        private void Calc()
        {
            while (true)
            {
                txt_Message.Invoke(new aCall(setText), new object[] {a});
                a++;
                Thread.Sleep(500);
            }
        }

        private void setText(int a)
        {
            txt_Message.Text = a.ToString();
            txt_Message.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void BtnClick2(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(delegate ()
            {
                    string message = string.Empty;

                    message = string.Format(txt_Message.Text);
                    MessageBox.Show(message);
            }));
            thread.Start();

        }
    }
}
