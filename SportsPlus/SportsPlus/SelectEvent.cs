//
//  SportsPlus - SelectEvent.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//


using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class SelectEvent : Form
    {

        // Private Variables
        MainForm mainForm;

        string selectedEventName = "";
        string selectedAge = "";

        public SelectEvent(MainForm main)
        {
            mainForm = main;
            InitializeComponent();
        }

        // Matchup the event ID to the Event Name
        private string FindEventID(string @event)
        {
            foreach(KeyValuePair<string, Event> i in SportsPlus.eventDictionary)
            {
                if (i.Value.Event_Name == selectedEventName)
                {
                    return i.Key;
                }
            }

            return null;
        }

        // Creates the event log form and passes through the appropriate information.
        private void button1_Click(object sender, EventArgs e)
        {
            string v = FindEventID(selectedEventName);

            if (v == null) { MessageBox.Show("An unknown error occured!"); return; }

            var f = new LogEvent(SportsPlus.eventDictionary[v], selectedAge, mainForm);
            f.Show();

            this.Close();
        }

        // Populates the combo boxes with the event list
        private void SelectEvent_Load(object sender, EventArgs e)
        {
            foreach (Event i in SportsPlus.eventDictionary.Values)
            {
                cbEvent.Items.Add(i.Event_Name);
            }

            cbEvent.SelectedIndex = 0;
            selectedEventName = cbEvent.SelectedItem.ToString();

            cbAge.SelectedIndex = 0;
        }

        // Changes the selectedEventName variable to the selected value.
        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEventName = cbEvent.SelectedItem.ToString();
        }

        private void cbAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAge = cbAge.SelectedItem.ToString();
        }
    }
}
