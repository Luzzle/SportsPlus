//
//  SportsPlus - MainForm.cs
//  Created by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//

using System;
using System.Drawing;
using System.Windows.Forms;


namespace SportsPlus
{
    // MainForm Class - Inherits from class "Form"
    public partial class MainForm : Form
    {
        Loader loader;
        // Form Class Constructor
        public MainForm(Loader frmLoader) {     
            InitializeComponent();
            loader = frmLoader;
            
        }

        // Form Load Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            loader.CloseForm();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
