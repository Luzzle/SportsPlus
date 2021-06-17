namespace SportsPlus
{
    partial class Debug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listEvents = new System.Windows.Forms.ListBox();
            this.listStudents = new System.Windows.Forms.ListBox();
            this.listLogs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listEvents
            // 
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Left;
            this.listEvents.FormattingEnabled = true;
            this.listEvents.ItemHeight = 15;
            this.listEvents.Location = new System.Drawing.Point(0, 0);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(366, 644);
            this.listEvents.TabIndex = 0;
            // 
            // listStudents
            // 
            this.listStudents.Dock = System.Windows.Forms.DockStyle.Left;
            this.listStudents.FormattingEnabled = true;
            this.listStudents.ItemHeight = 15;
            this.listStudents.Location = new System.Drawing.Point(366, 0);
            this.listStudents.Name = "listStudents";
            this.listStudents.Size = new System.Drawing.Size(366, 644);
            this.listStudents.TabIndex = 0;
            // 
            // listLogs
            // 
            this.listLogs.Dock = System.Windows.Forms.DockStyle.Left;
            this.listLogs.FormattingEnabled = true;
            this.listLogs.ItemHeight = 15;
            this.listLogs.Location = new System.Drawing.Point(732, 0);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(378, 644);
            this.listLogs.TabIndex = 0;
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 644);
            this.Controls.Add(this.listLogs);
            this.Controls.Add(this.listStudents);
            this.Controls.Add(this.listEvents);
            this.Name = "Debug";
            this.Text = "Debug";
            this.Load += new System.EventHandler(this.Debug_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.ListBox listStudents;
        private System.Windows.Forms.ListBox listLogs;
    }
}