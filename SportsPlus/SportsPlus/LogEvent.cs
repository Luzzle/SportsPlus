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

        int btnOffset = 0;

        Event loadedEvent;
        string loadedAge;
        public LogEvent(Event @event, string Age)
        {
            loadedEvent = @event;
            loadedAge = Age;
            InitializeComponent();
        }

        private void LogEvent_Load(object sender, EventArgs e)
        {
            lblTitle.Text += loadedEvent.Event_Name;
            //lblAge.Text += loadedAge;
        }

        private void btnChangeEvent_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Location = new Point(24, 59 + btnOffset);
            btn.Size = new Size(60, 23);
            panel2.Controls.Add(btn);

            btnOffset += btn.Size.Height + 1;
        }
    }
}
