//
//  SportsPlus - MainForm.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
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
        public int MalloyPoints, KillianPoints, LaurentianPoints, DonovanPoints = 0;

        // Form Class Constructor
        public MainForm(Loader frmLoader) { 
            
            InitializeComponent();
            loader = frmLoader;
            
        }
        
        private void LoadEvents()
        {
            // Clear the placeholder items
            listEvents.Items.Clear();

            // Loop through each Event and Add to the listbox
            foreach (var i in SportsPlus.eventDictionary.Values)
            {
                listEvents.Items.Add(i.Event_Name);
            }
        }

        // Form Load Event
        private void MainForm_Load(object sender, EventArgs e)
        {
           // Close the loader
            loader.CloseForm();

            // Load Events into the listbox
            LoadEvents();

            // Load the house totals into the dashboard
            UpdateHousePoints();
        }

        // Form Closed Event
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Write Event Logs to Logs.csv
            WriteEventLogsToFile();

            // Write Points to Points.csv
            WritePointsToFile();

            // Exit
            Application.Exit();

        }

        private void btnLogEvent_Click(object sender, EventArgs e)
        {
            // Load the Select Event form
            var f = new SelectEvent(this);
            f.Show();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            // Load the Debug Menu
            var f = new Debug();
            f.Show();
        }
    
        private void WriteEventLogsToFile()
        {
            // Clear the file
            File.WriteAllText(@"C:\SportsPlus\Logs.csv", string.Empty);

            
            StreamWriter sw = new StreamWriter(@"C:\SportsPlus\Logs.csv", append: true);

            // Loop through each event in the Logs Dictionary
            foreach (KeyValuePair<string, List<Log>> i in SportsPlus.eventLogs)
            {
                // For each event, get the number of logs. Then for each write another line underneath it for each athlete.
                string eventLine = i.Key + "," + i.Value.Count;
                sw.WriteLine(eventLine);

                foreach (var k in i.Value)
                {
                    // CSV Format
                    string logLine = k.studentDetails.ID + "," + k.TD + "," + k.Place + "," + k.Points;
                    sw.WriteLine(logLine);
                }

            }

            sw.Close();
        }

        // Load the Generate Report Form
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ReportGenerator f = new ReportGenerator();
            f.Show();
        }

        
        private void WritePointsToFile()
        {
            // Clears the points CSV
            File.WriteAllText(@"C:\SportsPlus\Points.csv", string.Empty);
            StreamWriter sw = new StreamWriter(@"C:\SportsPlus\Points.csv", append: true);

            // For each student, write their student ID and total points to the CSV
            foreach (KeyValuePair<string, Student> i in SportsPlus.studentDictionary)
            {
                string pointsLine = i.Key + "," + i.Value.TotalPoints;
                sw.WriteLine(pointsLine);
            }

            sw.Close();
        }

        // Updates the house points on the dashboard
        public void UpdateHousePoints()
        {
            // For each student in the dictionary, check the house, then tally up the points accordingly.
            foreach (Student i in SportsPlus.studentDictionary.Values)
            {
                switch (i.StudentHouse)
                {
                    case "Malloy":
                        {
                            MalloyPoints += i.TotalPoints;
                            break;
                        }
                    case "Killian":
                        {
                            KillianPoints += i.TotalPoints;
                            break;
                        }
                    case "Laurentian":
                        {
                            LaurentianPoints += i.TotalPoints;
                            break;
                        }
                    case "Donovan":
                        {
                            DonovanPoints += i.TotalPoints;
                            break;
                        }
                }
            }

            // Write the totals to their respective lables.
            lblMalloyTotal.Text = MalloyPoints.ToString();
            lblKillianTotal.Text = KillianPoints.ToString();
            lblDonovanTotal.Text = DonovanPoints.ToString();
            lblLaurentianTotal.Text = LaurentianPoints.ToString();
        }

        // Resets the current carnival
        private void btnResetCarnival_Click(object sender, EventArgs e)
        {
            // Prompt the user to confirm.
            if (MessageBox.Show("Are you sure you would like to reset the carnival?", "SportsPlus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete both files, they will be regenerated as blank files when the program is restarted
                File.Delete(@"C:\SportsPlus\Points.csv"); 
                File.Delete(@"C:\SportsPlus\Logs.csv");
                                                
                MessageBox.Show("Carnival reset! Please restart the program.");
                Environment.Exit(0); // Ends the program
                return;
            }
            return;
        }
    }
}
