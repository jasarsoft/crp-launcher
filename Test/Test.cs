using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private string GetPassword()
        {
            string result = "";

            for (int i = 1, j = 1; i < 100; i *= 2, j *= 3)
            {
                result = String.Format("{0}{1}{2}", result, i, j);
            }

            return result;
        }

        private string GetPassword2()
        {
            long result = 1;

            for (int i = 1, j = i; i < 64; i++, j *= ++i)
            {
                result += i * j;
            }

            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetPassword2());
        }
    }
}
