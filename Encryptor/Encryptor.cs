using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jasarsoft.StringEncryptor
{
    public partial class Encryptor : Form
    {
        public Encryptor()
        {
            InitializeComponent();
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            StringCipher sc = new StringCipher();

            sc.Password = txtPassword.Text;
            txtOutput.Text = sc.Decrypt(txtInput.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.Text = "11234982716813224364729";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringCipher sc = new StringCipher();

            sc.Password = txtPassword.Text;
            txtOutput.Text = sc.Encrypt(txtInput.Text); 
        }
    }
}
