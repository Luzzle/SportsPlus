namespace SportsPlus
{
    partial class SelectEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAge = new System.Windows.Forms.ComboBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Event: ";
            // 
            // cbEvent
            // 
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(81, 59);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(257, 23);
            this.cbEvent.TabIndex = 2;
            this.cbEvent.SelectedIndexChanged += new System.EventHandler(this.cbEvent_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Age Group:";
            // 
            // cbAge
            // 
            this.cbAge.FormattingEnabled = true;
            this.cbAge.Items.AddRange(new object[] {
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "Opens"});
            this.cbAge.Location = new System.Drawing.Point(81, 97);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(257, 23);
            this.cbAge.TabIndex = 2;
            this.cbAge.SelectedIndexChanged += new System.EventHandler(this.cbAge_SelectedIndexChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnContinue.Location = new System.Drawing.Point(12, 126);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(326, 45);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 179);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SelectEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Event";
            this.Load += new System.EventHandler(this.SelectEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAge;
        private System.Windows.Forms.Button btnContinue;
    }
}