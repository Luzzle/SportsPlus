﻿using System;
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
        public LogEvent(Event @event, string Age)
        {
            loadedEvent = @event;
            loadedAge = Age;
            InitializeComponent();
        }

        private void LogEvent_Load(object sender, EventArgs e)
        {
            lblTitle.Text += loadedEvent.Event_Name;
            lblAge.Text += loadedAge;
        }
    }
}
