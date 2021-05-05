using System;
using System.Collections.Generic;
using System.Text;

using System.IO;



namespace SportsPlus
{
    static class SportsPlus
    {

        public static void Initialize(Loader loader)
        {
            loader.SetLoadProgress(20);
            loader.ChangeLoadingText("Checking Files...");
            CheckFiles();

            loader.SetLoadProgress(40);
            loader.ChangeLoadingText("Loading Students...");
            LoadStudents();

            loader.SetLoadProgress(60);
            loader.ChangeLoadingText("Loading Events...");
            LoadEvents();

            loader.SetLoadProgress(80);
            loader.ChangeLoadingText("Loading Records...");
            LoadRecords();

            loader.SetLoadProgress(100);
            loader.ChangeLoadingText("Loaded!");

        }

        private static void CheckFiles()
        { 
            
            if (!Directory.Exists(@"C:\SportsPlus\")) Directory.CreateDirectory(@"C:\SportsPlus\");
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

        }

    }
}
