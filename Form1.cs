using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; // 추가된 namespace
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();

            this.btn_Name.Click += BtnClick_Text;
            this.button1.Click += BtnClick2;
        }

        public void BtnClick_Text(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(Calc));
            thread1.Start();
   }

        delegate void aCall(int a);

        private void Calc()
        {
            int a = 0;
            while (true)
            {
                txt_Message.Invoke(new aCall(setText), new object[] {a});
                a++;
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
            //Thread thread = new Thread(new ThreadStart(delegate ()
            //{
                    string message = string.Empty;

                    message = string.Format(txt_Message.Text);
                    MessageBox.Show(message);
            //}));
            //thread.Start();

        }
    }
}
