//
//  SportsPlus - ReportGenerator.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//

using System;
using System.IO;
using System.Windows.Forms;

namespace SportsPlus
{
    public partial class ReportGenerator : Form
    {
        // Private Variables
        string path = "";

        public ReportGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog, set the output path to the result
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                path = path + @"\House Champions.txt";
                textBox2.Text = path;
            }
        }

        // Generates the House Champions Document
        private void GenerateHouseChampions(string Path)
        {
            
            if (path == "")
            {
                MessageBox.Show("Please select a path for the document!");
                return;
            }

            // Local Variables
            string malloyChampID = "";
            string killianChampID = "";
            string laurChampID = "";
            string donovanChampID = "";

            int malloyMax = 0;
            int killianMax = 0;
            int laurMax = 0;
            int donovanMax = 0;

            // Loop through each student, SEARCHING (hint hint) for the maximum value in each house, setting the appropriate StudentID for each.
            foreach (Student i in SportsPlus.studentDictionary.Values)
            {
                switch (i.StudentHouse)
                {
                    case "Malloy":
                        {
                            if (i.TotalPoints > malloyMax)
                            {
                                malloyChampID = i.ID;
                                malloyMax = i.TotalPoints;
                            }
                            break;
                        }
                    case "Killian":
                        {
                            if (i.TotalPoints > killianMax)
                            {
                                killianChampID = i.ID;
                                killianMax = i.TotalPoints;
                            }
                            break;
                        }

                    case "Laurentian":
                        {
                            if (i.TotalPoints > laurMax)
                            {
                                laurChampID = i.ID;
                                laurMax = i.TotalPoints;
                            }
                            break;
                        }

                    case "Donovan":
                        {
                            if (i.TotalPoints > donovanMax)
                            {
                                donovanChampID = i.ID;
                                donovanMax = i.TotalPoints;
                            }
                            break;
                        }

                }
                

            }

            

            // Write all the data to the file at the specified path.
            StreamWriter sw = new StreamWriter(Path);
            sw.WriteLine("ST GREGORYS COLLEGE - HOUSE CHAMPIONS");
            sw.WriteLine("Malloy - " + (malloyChampID == "" ? "No Points Awarded to House" : SportsPlus.studentDictionary[malloyChampID].Name));
            sw.WriteLine("Killian - " + (killianChampID == "" ? "No Points Awarded to House" : SportsPlus.studentDictionary[killianChampID].Name));
            sw.WriteLine("Laurentian - " + (laurChampID == "" ? "No Points Awarded to House" : SportsPlus.studentDictionary[laurChampID].Name));
            sw.WriteLine("Donovan - " + (donovanChampID == "" ? "No Points Awarded to House" : SportsPlus.studentDictionary[donovanChampID].Name));

            sw.Close();

            MessageBox.Show("House Champions report generated to selected path!");

        }

        private void ReportGenerator_Load(object sender, EventArgs e)
        {
            // Set the default combobox item
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Generate the appropriate report, more to be developed later.
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        GenerateHouseChampions(path);
                        break;
                    }
            }

        }
    }
}
