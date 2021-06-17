//
//  SportsPlus - SportsPlus.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//


using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace SportsPlus
{

    static class SportsPlus
    {
        // Create Student Dictionary, accessed by all files.
        public static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
        public static Dictionary<string, Event> eventDictionary = new Dictionary<string, Event>();
        public static Dictionary<string, List<Log>> eventLogs = new Dictionary<string, List<Log>>();

        static string STUDENT_PLACEHOLDER_STRING = "This is a placeholder file, please replace with a csv of your schools students in the format [Student ID, Student Name, Student House]";
        
        // Initializer Function, calls all the below functions and modifies the loader text to communicate to the user.
        public static void Initialize(Loader loader)
        {
           
            loader.ChangeLoadingText("Checking Files...");
            CheckFiles();

            loader.ChangeLoadingText("Loading Students...");
            LoadStudents();
       
            loader.ChangeLoadingText("Loading Events...");
            LoadEvents();

            loader.ChangeLoadingText("Loading Points...");
            LoadPoints();

            loader.ChangeLoadingText("Loaded!");
            
        }

        private static void CheckFiles()
        {

            // Checks to make sure all important files exist, if not create placeholder files which are checked later on.
            if (!Directory.Exists(@"C:\SportsPlus\")) Directory.CreateDirectory(@"C:\SportsPlus\");

            if (!File.Exists(@"C:\SportsPlus\Students.csv")) {
                // Create the new studentsList file and write the placeholder string to the file. 
                FileStream studentsList = File.Create(@"C:\SportsPlus\Students.csv");
                studentsList.Close();
                File.WriteAllText(@"C:\SportsPlus\Students.csv", STUDENT_PLACEHOLDER_STRING);
            }

            // Create blank Points file
            if (!File.Exists(@"C:\SportsPlus\Points.csv")) { 
                FileStream fs = File.Create(@"C:\SportsPlus\Points.csv");
                fs.Close();
            }

            // Create blank Events file
            if (!File.Exists(@"C:\SportsPlus\Events.csv")) {
                FileStream fs = File.Create(@"C:\SportsPlus\Events.csv");
                fs.Close();
            }
            
            // Create blank Logs File
            if (!File.Exists(@"C:\SportsPlus\Logs.csv"))
            {
                FileStream fs = File.Create(@"C:\SportsPlus\Logs.csv");
                fs.Close();
            }

            

        }


        // Loads the events CSV into the dictionary.
        private static void LoadEvents()
        {
            
            string[] eventsList = File.ReadAllLines(@"C:\SportsPlus\Events.csv");

            // Checks to make sure there are events in the CSV
            if (eventsList.Length == 0)
            {
                MessageBox.Show("Please add events to the EventsList csv.", "Error Detected", MessageBoxButtons.OK);
                Environment.Exit(0);
            }

            // Loops through each event
            for (int i = 0; i < eventsList.Length; i++)
            {
                string[] eventData = eventsList[i].Split(",");
                
                // Create the new Event Object
                Event eventObj = new Event();
                eventObj.ID = eventData[0];
                eventObj.Event_Name = eventData[1];

                if (eventData[2] == "1")
                {
                    eventObj.Distance = true;
                }

                eventDictionary.Add(eventData[0], eventObj);
            }
            
            // Loads the logs CSV
            string[] eventLogs = File.ReadAllLines(@"C:\SportsPlus\Logs.csv");


            for (int i = 0; i < eventLogs.Length; i++)
            {

                string[] lineSplit = eventLogs[i].Split(",");
                int logCount = 0;

                // Creates the list of logs
                List<Log> LogList = new List<Log>();
    
                // Checks if the line begins with EA, if so it is an event and proceed to load in the athletes.
                if (lineSplit[0].StartsWith("EA"))
                {
                    logCount = int.Parse(lineSplit[1]);

                    // Loop through each log
                    for (int k = 1; k <= logCount; k++)
                    {
                        string[] logEntry = eventLogs[i + k].Split(",");

                        Student studentRef = SportsPlus.studentDictionary[logEntry[0]];

                        // Create the log object and push it to the list
                        Log newLog = new Log();
                        newLog.studentDetails = studentRef;
                        newLog.TD = int.Parse(logEntry[1]);
                        newLog.Place = int.Parse(logEntry[2]);
                        newLog.Points = int.Parse(logEntry[3]);

                        LogList.Add(newLog);
                    }

                    // Create the entry in the dictionary
                    SportsPlus.eventLogs.Add(lineSplit[0], LogList);

                }

                

            }

        }

        private static void LoadPoints()
        {
            // Load the points CSV.
            string[] pointsList = File.ReadAllLines(@"C:\SportsPlus\Points.csv");

            // For each entry, add the appropriate point data to each student.
            for (int i = 0; i < pointsList.Length; i++)
            {

                string[] pointData = pointsList[i].Split(",");

                SportsPlus.studentDictionary[pointData[0]].TotalPoints = int.Parse(pointData[1]);


            }
        }

        private static void LoadStudents()
        {
            // Create array of all students
            string[] studentsList = File.ReadAllLines(@"C:\SportsPlus\Students.csv");
            
            // There should never be an instance of this, but if the file is empty allow the user to reset to the placeholder state.
            if (studentsList.Length == 0)
            {
                // Show a messagebox and record the result.
                DialogResult result = MessageBox.Show("There was an unkown error, would you like to reset the students list?", "Error detected", MessageBoxButtons.YesNo);
                
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            // Delete the file and regenerate it
                            MessageBox.Show(@"SportsPlus will now close. Please reopen the application.", "Notification");
                            File.Delete(@"C:\SportsPlus\Students.csv");
                            Environment.Exit(0);
                            break;
                        }

                    case DialogResult.No:
                        {
                            // Quit the application
                            Environment.Exit(0);
                            break;
                        }
                }
                
            }

            if (studentsList[0] == STUDENT_PLACEHOLDER_STRING)
            {
                // Prompt the user to replace the file with the csv provided by the school
                MessageBox.Show(@"Please replace the placeholder Students List csv at C:\SportsPlus\Students.csv before you can use the program!");
                Environment.Exit(0);
            }

           for (int i = 0; i < studentsList.Length; i++)
            {
                // Split the record from the csv
                string[] studentData = studentsList[i].Split(",");

                // Create the new student class and apphend it to the dictionary.
                Student studentObj = new Student();
                studentObj.ID = studentData[0];
                studentObj.Name = studentData[1];
                studentObj.StudentHouse = studentData[2];
                studentObj.TotalPoints = 0;
                studentDictionary.Add(studentData[0], studentObj);
                
            }
        }

    }
}
