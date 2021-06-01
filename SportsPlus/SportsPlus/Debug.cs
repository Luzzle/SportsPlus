using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class Debug : Form
    {
        public Debug()
        {
            InitializeComponent();
        }

        private void Debug_Load(object sender, EventArgs e)
        {
            foreach (Event i in SportsPlus.eventDictionary.Values)
            {
                listBox1.Items.Add(i.Event_Name + ": " + i.Distance.ToString());
;           }

            foreach (Student i in SportsPlus.studentDictionary.Values)
            {
                listBox2.Items.Add(i.Name + " " + i.StudentHouse);
            }

            foreach (List<Log> i in SportsPlus.eventLogs.Values)
            {
                for (int k = 0; k < i.Count; k++)
                {
                    listBox3.Items.Add(i[k].studentDetails.Name + ": " + i[k].TD);
                }
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
