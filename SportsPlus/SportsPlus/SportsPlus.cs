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

            loader.ChangeLoadingText("Loading Records...");
            LoadRecords();

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

            // Create blank records file
            if (!File.Exists(@"C:\SportsPlus\Records.csv")) { 
                FileStream fs = File.Create(@"C:\SportsPlus\Records.csv");
                fs.Close();
            }

            // Create blank records file
            if (!File.Exists(@"C:\SportsPlus\Events.csv")) {
                FileStream fs = File.Create(@"C:\SportsPlus\Events.csv");
                fs.Close();
            }

            // TODO: ADD THE REST OF THE CHECKS LATER

        }


        private static void LoadEvents()
        {
            string[] eventsList = File.ReadAllLines(@"C:\SportsPlus\Events.csv");

            if (eventsList.Length == 0)
            {
                MessageBox.Show("Please add events to the EventsList csv.", "Error Detected", MessageBoxButtons.OK);
                Environment.Exit(0);
            }

            for (int i = 0; i < eventsList.Length; i++)
            {
                string[] eventData = eventsList[i].Split(",");

                Event eventObj = new Event();
                eventObj.Event_Name = eventData[1];

                if (eventData[2] == "1")
                {
                    eventObj.Distance = true;
                }

                eventDictionary.Add(eventData[0], eventObj);
            }

        }

        private static void LoadRecords()
        {
            // TODO: LOAD RECORD INFORMATION FROM RECORDS CSV IN FORMAT [EVENT_ID,RECORD]
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
                studentObj.Name = studentData[1];
                studentObj.StudentHouse = studentData[2];
                studentObj.TotalPoints = 0;
                studentDictionary.Add(studentData[0], studentObj);
                
            }
        }

    }
}
