//
//  SportsPlus - MainForm.cs
//  Created by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//

using System;
using System.Resources;
using System.Collections.Generic;
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

        private void LoadEvents()
        {
            listBox1.Items.Clear();
            foreach (var i in SportsPlus.eventDictionary.Values)
            {
                listBox1.Items.Add(i.Event_Name);
            }
        }

        // Form Load Event
        private void MainForm_Load(object sender, EventArgs e)
        {
           
            loader.CloseForm();
            LoadEvents();
              
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
        
    }
}
