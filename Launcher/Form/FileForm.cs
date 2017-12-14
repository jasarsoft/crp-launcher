#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Jasarsoft.Columbia
{
    public partial class FileForm : Syncfusion.Windows.Forms.MetroForm
    {
        public FileForm(object data)
        {
            InitializeComponent();

            gridListControlFiles.DataSource = data;
        }

        public int FileMissed
        {
            set { labelMissed.Text = String.Format("Nedostajuæi: {0}", value); }
        }

        public int FileUnknown
        {
            set { labelUnknown.Text = String.Format("Nepoznatih: {0}", value); }
        }

        public int FileIncorrect
        {
            set { labelIncorrect.Text = String.Format("Nispravnih: {0}", value); }
        }

        public int FileTotal
        {
            set { labelTotal.Text = String.Format("Ukupno sve: {0}", value); }
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            gridListControlFiles.Grid.ColWidths[1] = 60;
            gridListControlFiles.Grid.ColWidths[2] = 340;
            gridListControlFiles.Grid.ColWidths[3] = 100;
            gridListControlFiles.Grid.ColWidths[4] = 100;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_MouseHover(object sender, EventArgs e)
        {
            this.buttonOK.BackColor = Color.IndianRed;
        }

        private void buttonOK_MouseLeave(object sender, EventArgs e)
        {
            this.buttonOK.BackColor = Color.Firebrick;
        }
    }
}
