using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class LogEvent : Form
    {
        Event loadedEvent;
        string loadedAge;

        private int EntryOffset = 25;
        private int AthleteCount = 1;

        public LogEvent(Event @event, string Age)
        {
            loadedEvent = @event;
            loadedAge = Age;
            InitializeComponent();
        }

        private void LogEvent_Load(object sender, EventArgs e)
        {
            lblTitle.Text += loadedEvent.Event_Name + ": " + (loadedAge != "Opens" ? loadedAge + " yrs" : loadedAge);
            lblTD.Text = (loadedEvent.Distance ? "Distance" : "Time");
        }

        private void AddAthlete()
        {
            AthleteCount++;

            TextBox stuID = new TextBox();
            stuID.Name = "stuID" + AthleteCount;
            stuID.Size = new Size(100, 23);
            stuID.Location = new Point(12, 134 + EntryOffset);
            stuID.TextChanged += new EventHandler(this.stuCheckID);
            this.Controls.Add(stuID);

            TextBox stuName = new TextBox();
            stuName.Name = "stuName" + AthleteCount;
            stuName.Size = new Size(129, 23);
            stuName.Location = new Point(118, 134 + EntryOffset);
            stuName.ReadOnly = true;
            this.Controls.Add(stuName);

            TextBox stuHouse = new TextBox();
            stuHouse.Name = "stuHouse" + AthleteCount;
            stuHouse.Size = new Size(85, 23);
            stuHouse.Location = new Point(253, 134 + EntryOffset);
            stuHouse.ReadOnly = true;
            this.Controls.Add(stuHouse);

            TextBox stuTD = new TextBox();
            stuTD.Name = "stuTD" + AthleteCount;
            stuTD.Size = new Size(139, 23);
            stuTD.Location = new Point(344, 134 + EntryOffset);
            this.Controls.Add(stuTD);

            TextBox stuPlace = new TextBox();
            stuPlace.Name = "stuPlace" + AthleteCount;
            stuPlace.Size = new Size(53, 23);
            stuPlace.Location = new Point(489, 134 + EntryOffset);
            this.Controls.Add(stuPlace);

            TextBox stuPoints = new TextBox();
            stuPoints.Name = "stuPoints" + AthleteCount;
            stuPoints.Size = new Size(53, 23);
            stuPoints.Location = new Point(548, 134 + EntryOffset);
            this.Controls.Add(stuPoints);

            EntryOffset += 25;
        }


        private void btnAddAthlete_Click(object sender, EventArgs e)
        {
            // TO AVOID THE ANNOYING BUG
            this.VerticalScroll.Value = 0;

            AddAthlete();
        }

        protected void stuCheckID(object sender, EventArgs e)
        {
            TextBox tbStuID = sender as TextBox;
            int AthleteNo = int.Parse(tbStuID.Name.Substring(5));

            TextBox stuNameRef = this.Controls["stuName" + AthleteNo] as TextBox;
            TextBox stuHouseRef = this.Controls["stuHouse" + AthleteNo] as TextBox;

            if (SportsPlus.studentDictionary.ContainsKey(tbStuID.Text))
            {
                stuNameRef.Text = SportsPlus.studentDictionary[tbStuID.Text].Name;
                stuHouseRef.Text = SportsPlus.studentDictionary[tbStuID.Text].StudentHouse;
                return;
            }

            stuNameRef.Text = "";
            stuHouseRef.Text = "";
            
        }

        private void SaveEvent()
        {

            for (int i = 1; i <= AthleteCount; i++)
            {

                TextBox tbIDRef = this.Controls["stuID" + i] as TextBox;
                TextBox tbTDRef = this.Controls["stuTD" + i] as TextBox;
                TextBox tbPlaceRef = this.Controls["stuPlace" + i] as TextBox;
                TextBox tbPointsRef = this.Controls["stuPoints" + i] as TextBox;

                Student studentRef = SportsPlus.studentDictionary[tbIDRef.Text];

                Log newLog = new Log();
                newLog.studentDetails = studentRef;
                newLog.TD = int.Parse(tbTDRef.Text);
                newLog.Place = int.Parse(tbPlaceRef.Text);
                newLog.Points = int.Parse(tbPointsRef.Text);

                
            }

        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            SaveEvent();
        }
    }
}

