using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class SelectEvent : Form
    {

        string selectedEventName = "";
        string selectedAge = "";

        public SelectEvent()
        {
            InitializeComponent();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            string v = FindEventID(selectedEventName);

            if (v == null) { MessageBox.Show("An unknown error occured!"); return; }

            var f = new LogEvent(SportsPlus.eventDictionary[v], selectedAge);
            f.Show();

            this.Close();
        }

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
