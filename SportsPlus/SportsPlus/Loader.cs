//
//  SportsPlus - Loader.cs
//  Developed by Cristian Lustri
//  Copyright 2021 - All Rights Reserved
//  Source Code Licenced under the M.I.T License - https://opensource.org/licenses/MIT
//

using System;
using System.Windows.Forms;


namespace SportsPlus
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
        }

        // Sets the loader loading text.
        public void ChangeLoadingText(string text)
        {
            this.LoadingLabel.Text = text;
            this.LoadingLabel.Location =  new System.Drawing.Point((this.Size.Width / 2 - LoadingLabel.Size.Width / 2), LoadingLabel.Location.Y);
        }

       public void CloseForm()
        {
            this.Close();
        }
        
        // Form load event
        private void Loader_Load(object sender, EventArgs e)
        {
            // Centers the picturebox.
            this.pictureBox1.Location = new System.Drawing.Point((this.Size.Width / 2 - pictureBox1.Size.Width / 2), pictureBox1.Location.Y);
            
            // Initializes the program
            SportsPlus.Initialize(this);
            
            // Load the mainform
            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }


    }
}
