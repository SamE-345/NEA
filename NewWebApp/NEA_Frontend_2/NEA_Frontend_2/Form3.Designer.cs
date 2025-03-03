namespace NEA_Frontend_2
{
    partial class Form3
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Recipient_Name_Label = new System.Windows.Forms.Label();
            this.Message_Space = new System.Windows.Forms.Label();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Location = new System.Drawing.Point(319, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 26);
            this.textBox1.TabIndex = 0;
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(319, 365);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(167, 37);
            this.Send_Button.TabIndex = 1;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Recipient_Name_Label
            // 
            this.Recipient_Name_Label.AutoSize = true;
            this.Recipient_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recipient_Name_Label.Location = new System.Drawing.Point(345, 9);
            this.Recipient_Name_Label.Name = "Recipient_Name_Label";
            this.Recipient_Name_Label.Size = new System.Drawing.Size(103, 37);
            this.Recipient_Name_Label.TabIndex = 2;
            this.Recipient_Name_Label.Text = "Name";
            this.Recipient_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message_Space
            // 
            this.Message_Space.AutoSize = true;
            this.Message_Space.Location = new System.Drawing.Point(254, 56);
            this.Message_Space.MinimumSize = new System.Drawing.Size(300, 250);
            this.Message_Space.Name = "Message_Space";
            this.Message_Space.Size = new System.Drawing.Size(300, 250);
            this.Message_Space.TabIndex = 3;
            this.Message_Space.Click += new System.EventHandler(this.Message_Space_Click);
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(661, 47);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 34);
            this.Back_Button.TabIndex = 4;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Location = new System.Drawing.Point(661, 87);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(75, 41);
            this.Refresh_Button.TabIndex = 5;
            this.Refresh_Button.Text = "Refresh";
            this.Refresh_Button.UseVisualStyleBackColor = true;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Refresh_Button);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Message_Space);
            this.Controls.Add(this.Recipient_Name_Label);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.textBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Label Recipient_Name_Label;
        private System.Windows.Forms.Label Message_Space;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button Refresh_Button;
    }
}