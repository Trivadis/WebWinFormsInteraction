namespace WinFormsFrontend
{
    partial class OldAppForm
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
            this.StartWebButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PersonLabel = new System.Windows.Forms.Label();
            this.PersonTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FristnameTextBox = new System.Windows.Forms.TextBox();
            this.LastnameTextBox = new System.Windows.Forms.TextBox();
            this.NotificationLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartWebButton
            // 
            this.StartWebButton.Location = new System.Drawing.Point(12, 12);
            this.StartWebButton.Name = "StartWebButton";
            this.StartWebButton.Size = new System.Drawing.Size(250, 50);
            this.StartWebButton.TabIndex = 0;
            this.StartWebButton.Text = "Start New WebApp";
            this.StartWebButton.UseVisualStyleBackColor = true;
            this.StartWebButton.Click += new System.EventHandler(this.StartWebButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(538, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(250, 50);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PersonLabel
            // 
            this.PersonLabel.AutoSize = true;
            this.PersonLabel.Location = new System.Drawing.Point(12, 119);
            this.PersonLabel.Name = "PersonLabel";
            this.PersonLabel.Size = new System.Drawing.Size(151, 25);
            this.PersonLabel.TabIndex = 2;
            this.PersonLabel.Text = "Active Person:";
            // 
            // PersonTextBox
            // 
            this.PersonTextBox.Location = new System.Drawing.Point(169, 116);
            this.PersonTextBox.Name = "PersonTextBox";
            this.PersonTextBox.ReadOnly = true;
            this.PersonTextBox.Size = new System.Drawing.Size(619, 31);
            this.PersonTextBox.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(169, 301);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 68);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FristnameTextBox
            // 
            this.FristnameTextBox.Location = new System.Drawing.Point(169, 200);
            this.FristnameTextBox.Name = "FristnameTextBox";
            this.FristnameTextBox.Size = new System.Drawing.Size(327, 31);
            this.FristnameTextBox.TabIndex = 5;
            this.FristnameTextBox.Visible = false;
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(169, 246);
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.Size = new System.Drawing.Size(327, 31);
            this.LastnameTextBox.TabIndex = 6;
            this.LastnameTextBox.Visible = false;
            // 
            // NotificationLabel
            // 
            this.NotificationLabel.Location = new System.Drawing.Point(14, 405);
            this.NotificationLabel.Name = "NotificationLabel";
            this.NotificationLabel.Size = new System.Drawing.Size(774, 32);
            this.NotificationLabel.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(324, 301);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(140, 68);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OldAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.NotificationLabel);
            this.Controls.Add(this.LastnameTextBox);
            this.Controls.Add(this.FristnameTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PersonTextBox);
            this.Controls.Add(this.PersonLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StartWebButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OldAppForm";
            this.Text = "Old App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OldAppForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartWebButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label PersonLabel;
        private System.Windows.Forms.TextBox PersonTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox FristnameTextBox;
        private System.Windows.Forms.TextBox LastnameTextBox;
        private System.Windows.Forms.Label NotificationLabel;
        private System.Windows.Forms.Button CancelButton;
    }
}

