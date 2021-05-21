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

        public void ChangeLoadingText(string text)
        {
            this.LoadingLabel.Text = text;
            this.LoadingLabel.Location =  new System.Drawing.Point((this.Size.Width / 2 - LoadingLabel.Size.Width / 2), LoadingLabel.Location.Y);
        }

       public void CloseForm()
        {
            this.Close();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Location = new System.Drawing.Point((this.Size.Width / 2 - pictureBox1.Size.Width / 2), pictureBox1.Location.Y);
            SportsPlus.Initialize(this);
            MainForm mainForm = new MainForm(this);
            mainForm.Show();
        }


    }
}
