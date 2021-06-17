
namespace SportsPlus
{
    partial class LogEvent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAthlete = new System.Windows.Forms.Button();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStuID = new System.Windows.Forms.Label();
            this.lblStuName = new System.Windows.Forms.Label();
            this.lblStuHouse = new System.Windows.Forms.Label();
            this.lblTD = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddAthlete);
            this.panel1.Controls.Add(this.btnSaveEvent);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 104);
            this.panel1.TabIndex = 0;
            // 
            // btnAddAthlete
            // 
            this.btnAddAthlete.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAddAthlete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAthlete.Location = new System.Drawing.Point(355, 38);
            this.btnAddAthlete.Name = "btnAddAthlete";
            this.btnAddAthlete.Size = new System.Drawing.Size(134, 40);
            this.btnAddAthlete.TabIndex = 2;
            this.btnAddAthlete.Text = "Add Athlete";
            this.btnAddAthlete.UseVisualStyleBackColor = false;
            this.btnAddAthlete.Click += new System.EventHandler(this.btnAddAthlete_Click);
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSaveEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEvent.Location = new System.Drawing.Point(495, 38);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(134, 40);
            this.btnSaveEvent.TabIndex = 1;
            this.btnSaveEvent.Text = "Save Event";
            this.btnSaveEvent.UseVisualStyleBackColor = false;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(24, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(458, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Log Event - ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStuID
            // 
            this.lblStuID.AutoSize = true;
            this.lblStuID.Location = new System.Drawing.Point(12, 116);
            this.lblStuID.Name = "lblStuID";
            this.lblStuID.Size = new System.Drawing.Size(62, 15);
            this.lblStuID.TabIndex = 1;
            this.lblStuID.Text = "Student ID";
            // 
            // lblStuName
            // 
            this.lblStuName.AutoSize = true;
            this.lblStuName.Location = new System.Drawing.Point(118, 116);
            this.lblStuName.Name = "lblStuName";
            this.lblStuName.Size = new System.Drawing.Size(83, 15);
            this.lblStuName.TabIndex = 4;
            this.lblStuName.Text = "Student Name";
            // 
            // lblStuHouse
            // 
            this.lblStuHouse.AutoSize = true;
            this.lblStuHouse.Location = new System.Drawing.Point(253, 116);
            this.lblStuHouse.Name = "lblStuHouse";
            this.lblStuHouse.Size = new System.Drawing.Size(85, 15);
            this.lblStuHouse.TabIndex = 6;
            this.lblStuHouse.Text = "Student House";
            // 
            // lblTD
            // 
            this.lblTD.AutoSize = true;
            this.lblTD.Location = new System.Drawing.Point(344, 116);
            this.lblTD.Name = "lblTD";
            this.lblTD.Size = new System.Drawing.Size(128, 15);
            this.lblTD.TabIndex = 8;
            this.lblTD.Text = "[Time / Distance Label]";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(489, 116);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(35, 15);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "Place";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(548, 116);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(40, 15);
            this.lblPoints.TabIndex = 12;
            this.lblPoints.Text = "Points";
            // 
            // LogEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(642, 659);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.lblTD);
            this.Controls.Add(this.lblStuHouse);
            this.Controls.Add(this.lblStuName);
            this.Controls.Add(this.lblStuID);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "LogEvent";
            this.Text = "Log Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogEvent_FormClosing);
            this.Load += new System.EventHandler(this.LogEvent_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveEvent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddAthlete;
        private System.Windows.Forms.Label lblStuID;
        private System.Windows.Forms.Label lblStuName;
        private System.Windows.Forms.Label lblStuHouse;
        private System.Windows.Forms.Label lblTD;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblPoints;
    }
}