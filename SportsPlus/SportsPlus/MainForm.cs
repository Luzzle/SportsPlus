//
//  SportsPlus - MainForm.cs
//  Created by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//

using System;
using System.IO;
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

            WriteEventLogsToFile();
            Application.Exit();

        }

        private void btnLogEvent_Click(object sender, EventArgs e)
        {
            var f = new SelectEvent();
            f.Show();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            var f = new Debug();
            f.Show();
        }
    
        private void WriteEventLogsToFile()
        {
            File.WriteAllText(@"C:\SportsPlus\Logs.csv", string.Empty);

            StreamWriter sw = new StreamWriter(@"C:\SportsPlus\Logs.csv", append: true);

            foreach (KeyValuePair<string, List<Log>> i in SportsPlus.eventLogs)
            {
                MessageBox.Show(i.Value.Count.ToString());

                string eventLine = i.Key + "," + i.Value.Count;
                sw.WriteLine(eventLine);

                foreach (var k in i.Value)
                {
                    string logLine = k.studentDetails.ID + "," + k.TD + "," + k.Place + "," + k.Points;
                    sw.WriteLine(logLine);
                }

            }

            sw.Close();
        }
    }
}
