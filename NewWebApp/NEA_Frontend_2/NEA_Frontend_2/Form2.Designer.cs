namespace NEA_Frontend_2
{
    partial class Form2
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
            this.Friend_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Sign_Out_Button = new System.Windows.Forms.Button();
            this.Name_label = new System.Windows.Forms.Label();
            this.Dark_Mode_Box = new System.Windows.Forms.CheckBox();
            this.Friends_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Friend_Box
            // 
            this.Friend_Box.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Friend_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Friend_Box.Location = new System.Drawing.Point(308, 205);
            this.Friend_Box.Name = "Friend_Box";
            this.Friend_Box.Size = new System.Drawing.Size(153, 19);
            this.Friend_Box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Friends";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(324, 230);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(128, 50);
            this.Search.TabIndex = 2;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Sign_Out_Button
            // 
            this.Sign_Out_Button.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Sign_Out_Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Sign_Out_Button.Location = new System.Drawing.Point(700, 121);
            this.Sign_Out_Button.Name = "Sign_Out_Button";
            this.Sign_Out_Button.Size = new System.Drawing.Size(76, 76);
            this.Sign_Out_Button.TabIndex = 4;
            this.Sign_Out_Button.Text = "Sign out";
            this.Sign_Out_Button.UseVisualStyleBackColor = false;
            this.Sign_Out_Button.Click += new System.EventHandler(this.Sign_Out_Button_Click);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(356, 38);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(0, 20);
            this.Name_label.TabIndex = 5;
            // 
            // Dark_Mode_Box
            // 
            this.Dark_Mode_Box.AutoSize = true;
            this.Dark_Mode_Box.Location = new System.Drawing.Point(675, 91);
            this.Dark_Mode_Box.Name = "Dark_Mode_Box";
            this.Dark_Mode_Box.Size = new System.Drawing.Size(113, 24);
            this.Dark_Mode_Box.TabIndex = 6;
            this.Dark_Mode_Box.Text = "Dark mode";
            this.Dark_Mode_Box.UseVisualStyleBackColor = true;
            this.Dark_Mode_Box.CheckedChanged += new System.EventHandler(this.Dark_Mode_Box_CheckedChanged);
            // 
            // Friends_Button
            // 
            this.Friends_Button.BackColor = System.Drawing.SystemColors.Highlight;
            this.Friends_Button.ForeColor = System.Drawing.SystemColors.Control;
            this.Friends_Button.Location = new System.Drawing.Point(700, 204);
            this.Friends_Button.Name = "Friends_Button";
            this.Friends_Button.Size = new System.Drawing.Size(75, 76);
            this.Friends_Button.TabIndex = 7;
            this.Friends_Button.Text = "Friends";
            this.Friends_Button.UseVisualStyleBackColor = false;
            this.Friends_Button.Click += new System.EventHandler(this.Friends_Button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Friends_Button);
            this.Controls.Add(this.Dark_Mode_Box);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.Sign_Out_Button);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Friend_Box);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Friend_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Sign_Out_Button;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.CheckBox Dark_Mode_Box;
        private System.Windows.Forms.Button Friends_Button;
    }
}