#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jasarsoft.Columbia.Launcher
{
    public partial class LoginForm : Syncfusion.Windows.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(string name)
        {
            InitializeComponent();

            this.textboxName.Text = name;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.textboxPassword.Text != this.textboxAuthentic.Text)
            {
                MessageTitle title = new MessageTitle();
                string text = "Unesene lozinke se ne poklapaju!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}
