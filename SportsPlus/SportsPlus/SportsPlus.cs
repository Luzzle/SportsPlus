using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace SportsPlus
{

    static class SportsPlus
    {
        public static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

        static string STUDENT_PLACEHOLDER_STRING = "This is a placeholder file, please replace with a csv of your schools students in the format [Student ID, Student Name, Student House";

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
            
            if (!Directory.Exists(@"C:\SportsPlus\")) Directory.CreateDirectory(@"C:\SportsPlus\");
            
            if (!File.Exists(@"C:\SportsPlus\Students.csv")) {
                FileStream studentsList = File.Create(@"C:\SportsPlus\Students.csv");
                studentsList.Close();
                File.WriteAllText(@"C:\SportsPlus\Students.csv", STUDENT_PLACEHOLDER_STRING);
            }

            if (!File.Exists(@"C:\SportsPlus\Records.txt")) File.Create(@"C:\SportsPlus\Records.txt");
            

        }


        private static void LoadEvents()
        {

        }

        private static void LoadRecords()
        {

        }

        private static void LoadStudents()
        {
            string[] studentsList = File.ReadAllLines(@"C:\SportsPlus\Students.csv");
            
            if (studentsList.Length == 0)
            {
                DialogResult result = MessageBox.Show("There was an unkown error, would you like to reset the students list?", "Error detected", MessageBoxButtons.YesNo);
                
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            MessageBox.Show(@"SportsPlus will now close. Please reopen the application.", "Notification");
                            File.Delete(@"C:\SportsPlus\Students.csv");
                            Environment.Exit(0);
                            break;
                        }

                    case DialogResult.No:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
                
            }

            if (studentsList[0] == STUDENT_PLACEHOLDER_STRING)
            {
                MessageBox.Show(@"Please replace the placeholder Studentslist csv at C:\SportsPlus\Students.csv before you can use the program!");
                Environment.Exit(0);
            }

           for (int i = 0; i < studentsList.Length; i++)
            {
                string[] studentData = studentsList[i].Split(",");

                Student studentObj = new Student();
                studentObj.Name = studentData[1];
                studentObj.studentHouse = studentData[2];
                studentObj.TotalPoints = 0;
                studentDictionary.Add(studentData[0], studentObj);
                
            }
        }

    }
}
