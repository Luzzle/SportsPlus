//
//  SportsPlus - LogEvent.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class LogEvent : Form
    {
        // Private Varibales
        Event loadedEvent;
        string loadedAge;
        MainForm mainForm;

        private int EntryOffset = 0;
        private int AthleteCount = 0;

        // Form constructor
        public LogEvent(Event @event, string Age, MainForm main)
        {
            loadedEvent = @event;
            loadedAge = Age;
            mainForm = main;
            InitializeComponent();
        }

        // Load event
        private void LogEvent_Load(object sender, EventArgs e)
        {
            // Loads the title and other information
            lblTitle.Text += loadedEvent.Event_Name + ": " + (loadedAge != "Opens" ? loadedAge + " yrs" : loadedAge);
            lblTD.Text = (loadedEvent.Distance ? "Distance" : "Time");


            // Checks for existing athlete logs, otherwise creates a blank list.
            if (!SportsPlus.eventLogs.ContainsKey(loadedEvent.ID))
            {
                List<Log> emptyList = new List<Log>();
                SportsPlus.eventLogs.Add(loadedEvent.ID, emptyList);
            };

            // Initializes the event
            InitializeEvent();

        }

        private void InitializeEvent()
        {

            // If no athletes exist, creates a blank entry.
            if (SportsPlus.eventLogs[loadedEvent.ID].Count == 0)
            {
                EmptyAthlete();
                return;
            }
            
            // Otherwise loops through all athletes and creates the relevant information.
            foreach (var record in SportsPlus.eventLogs[loadedEvent.ID])
            {
                AddAthlete(record);
            }

            // Removes points from the existing athletes, will be readded with the modified points later, to ensure no points are added twice. Isolated this events points.
            for (int i = 1; i <= AthleteCount; i++)
            {

                string id = (this.Controls["stuID" + i] as TextBox).Text;
                int points = int.Parse((this.Controls["stuPoints" + i] as TextBox).Text);

                SportsPlus.studentDictionary[id].TotalPoints -= points;

            }
                                
        }

        // Creates an empty athlete.
        private void EmptyAthlete()
        {
            AthleteCount++;

            createIDTB();
            createNameTB();
            createHouseTB();
            createTDTB();
            createPlaceTB();
            createPointsTB();

            EntryOffset += 25;
        }

        // Adds an athlete based off existing information.
        private void AddAthlete(Log logInfo)
        {

            AthleteCount++;

            createIDTB(logInfo.studentDetails.ID);
            createNameTB(logInfo.studentDetails.Name);
            createHouseTB(logInfo.studentDetails.StudentHouse);
            createTDTB(logInfo.TD.ToString());
            createPlaceTB(logInfo.Place.ToString());
            createPointsTB(logInfo.Points.ToString());

            EntryOffset += 25;
        }

        private void btnAddAthlete_Click(object sender, EventArgs e)
        {
            // TO AVOID THE ANNOYING PANEL BUG
            this.VerticalScroll.Value = 0;

            EmptyAthlete();
        }

        // Checks if the students information is in the dictionary and autofills the relevant textboxes if necessary. Run on TextChanged of the ID Textbox
        protected void stuCheckID(object sender, EventArgs e)
        {
            // Gathers the relevant info surrounding the athlete record being created.
            TextBox tbStuID = sender as TextBox;
            int AthleteNo = int.Parse(tbStuID.Name.Substring(5));
            
            // Name and House textbox references.
            TextBox stuNameRef = this.Controls["stuName" + AthleteNo] as TextBox;
            TextBox stuHouseRef = this.Controls["stuHouse" + AthleteNo] as TextBox;

            // If the student exists, fill out the relevant information
            if (SportsPlus.studentDictionary.ContainsKey(tbStuID.Text))
            {
                stuNameRef.Text = SportsPlus.studentDictionary[tbStuID.Text].Name;
                stuHouseRef.Text = SportsPlus.studentDictionary[tbStuID.Text].StudentHouse;
                return;
            }

            // Otherwise leave it blank
            stuNameRef.Text = "";
            stuHouseRef.Text = "";

        }

        // Saves the relevant event information to the Logs Dictionary, will be written to file on event close.
        private void SaveEvent()
        {
            SportsPlus.eventLogs[loadedEvent.ID].Clear();

            // Loops over all athletes in the event
            for (int i = 1; i <= AthleteCount; i++)
            {

                // Gathers the relevant textbox references
                TextBox tbIDRef = this.Controls["stuID" + i] as TextBox;
                TextBox tbTDRef = this.Controls["stuTD" + i] as TextBox;
                TextBox tbPlaceRef = this.Controls["stuPlace" + i] as TextBox;
                TextBox tbPointsRef = this.Controls["stuPoints" + i] as TextBox;

                // Gets the student object associated with the ID.
                Student studentRef = SportsPlus.studentDictionary[tbIDRef.Text];

                // Creates the log object
                Log newLog = new Log();
                newLog.studentDetails = studentRef;
                newLog.TD = int.Parse(tbTDRef.Text);
                newLog.Place = int.Parse(tbPlaceRef.Text);
                newLog.Points = int.Parse(tbPointsRef.Text);

                // Updates the students points
                SportsPlus.studentDictionary[tbIDRef.Text].TotalPoints += int.Parse(tbPointsRef.Text);
                
                // Writes the log to the dictionary
                SportsPlus.eventLogs[loadedEvent.ID].Add(newLog);
            }

            // Update the House Points totals on the MainForm.
            mainForm.UpdateHousePoints();

        }

        // Run the SaveEvent Function (Runs on Form Close).
        private void btnSaveEvent_Click(object sender, EventArgs e)
        {

            this.Close();
            
        }

        //
        // WARNING: BELOW IS CODE REGARDING TO THE CREATION OF THE RELEVANT TEXTBOXES
        // THEY FOLLOW THE SAME FORMAT, EACH TEXTBOX IS ADDED AT A SPECIFIC X COORDINATE, WITH THE Y COORDINATES BEING OFFSETTED BASED OFF THE NUMBER OF ATHLETES.
        // THE ID TEXTBOX CONTAINS A TEXTCHANGED EVENT TO CHECK THE IDS (stuCheckID())
        //
        private void createIDTB(string Text = "")
        {
            TextBox stuID = new TextBox();
            stuID.Name = "stuID" + AthleteCount;
            stuID.Size = new Size(100, 23);
            stuID.Location = new Point(12, 134 + EntryOffset);
            stuID.Text = Text;
            stuID.TextChanged += new EventHandler(this.stuCheckID);
            this.Controls.Add(stuID);

        }

        private void createNameTB(string Text = "")
        {
            TextBox stuName = new TextBox();
            stuName.Name = "stuName" + AthleteCount;
            stuName.Size = new Size(129, 23);
            stuName.Location = new Point(118, 134 + EntryOffset);
            stuName.ReadOnly = true;
            stuName.Text = Text;
            this.Controls.Add(stuName);
        }

        private void createHouseTB(string Text = "")
        {
            TextBox stuHouse = new TextBox();
            stuHouse.Name = "stuHouse" + AthleteCount;
            stuHouse.Size = new Size(85, 23);
            stuHouse.Location = new Point(253, 134 + EntryOffset);
            stuHouse.ReadOnly = true;
            stuHouse.Text = Text;
            this.Controls.Add(stuHouse);
        }

        private void createTDTB(string Text = "")
        {
            TextBox stuTD = new TextBox();
            stuTD.Name = "stuTD" + AthleteCount;
            stuTD.Size = new Size(139, 23);
            stuTD.Location = new Point(344, 134 + EntryOffset);
            stuTD.Text = Text;
            this.Controls.Add(stuTD);
        }

        private void createPlaceTB(string Text = "")
        {
            TextBox stuPlace = new TextBox();
            stuPlace.Name = "stuPlace" + AthleteCount;
            stuPlace.Size = new Size(53, 23);
            stuPlace.Location = new Point(489, 134 + EntryOffset);
            stuPlace.Text = Text;
            this.Controls.Add(stuPlace);
        }

        private void createPointsTB(string Text = "")
        {
            TextBox stuPoints = new TextBox();
            stuPoints.Name = "stuPoints" + AthleteCount;
            stuPoints.Size = new Size(53, 23);
            stuPoints.Location = new Point(548, 134 + EntryOffset);
            stuPoints.Text = Text;
            this.Controls.Add(stuPoints);
        }

        private void LogEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveEvent();
            }catch (Exception ex)
            {
                MessageBox.Show("Please fill out all fields correctly!");
                e.Cancel = true;
                return;
            }
        }
    }


    
}

