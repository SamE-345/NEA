namespace NewFrontend
{
    partial class Menu
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
            this.Friend_Search_Input = new System.Windows.Forms.TextBox();
            this.Friend_Label = new System.Windows.Forms.Label();
            this.Search_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Friend_Search_Input
            // 
            this.Friend_Search_Input.Location = new System.Drawing.Point(317, 62);
            this.Friend_Search_Input.Name = "Friend_Search_Input";
            this.Friend_Search_Input.Size = new System.Drawing.Size(132, 26);
            this.Friend_Search_Input.TabIndex = 0;
            // 
            // Friend_Label
            // 
            this.Friend_Label.AutoSize = true;
            this.Friend_Label.Location = new System.Drawing.Point(322, 27);
            this.Friend_Label.Name = "Friend_Label";
            this.Friend_Label.Size = new System.Drawing.Size(117, 20);
            this.Friend_Label.TabIndex = 1;
            this.Friend_Label.Text = "Search Friends";
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(345, 94);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(75, 61);
            this.Search_Button.TabIndex = 2;
            this.Search_Button.Text = "Search";
            this.Search_Button.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Friend_Label);
            this.Controls.Add(this.Friend_Search_Input);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Friend_Search_Input;
        private System.Windows.Forms.Label Friend_Label;
        private System.Windows.Forms.Button Search_Button;
    }
}