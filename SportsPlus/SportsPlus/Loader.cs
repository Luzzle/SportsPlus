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

        public void SetLoadProgress(int progress)
        {
            this.ProgressBar.Value = progress;
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            SportsPlus.Initialize(this);
        }


    }
}
