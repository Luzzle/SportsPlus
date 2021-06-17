//
//  SportsPlus - Debug.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class Debug : Form
    {
        // Form Contructor - Non modified
        public Debug()
        {
            InitializeComponent();
        }


        // Load Function
        private void Debug_Load(object sender, EventArgs e)
        {
            // Loop through all events and add to Event Listbox
            foreach (Event i in SportsPlus.eventDictionary.Values)
            {
                listEvents.Items.Add(i.Event_Name + ": " + i.Distance.ToString());
;           }

            // Loop through all students and add to the Student Listbox
            foreach (Student i in SportsPlus.studentDictionary.Values)
            {
                listStudents.Items.Add(i.Name + " " + i.StudentHouse + ": " + i.TotalPoints.ToString());
            }

            // Loop through every single event log and add to the Logs Listbox
            foreach (List<Log> i in SportsPlus.eventLogs.Values)
            {
                for (int k = 0; k < i.Count; k++)
                {
                    listLogs.Items.Add(i[k].studentDetails.Name + ": " + i[k].TD);
                }
            }

        }

        
    }
}
