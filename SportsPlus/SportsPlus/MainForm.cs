//
//  SportsPlus - MainForm.cs
//  Created by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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
            this.Icon = Properties.Resources.SportsPlus___Logo;
            loader.CloseForm();
              
        }



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pictureBox1.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        
    }
}
