namespace NEA_Frontend_2
{
    partial class Form1
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
            this.U_Input = new System.Windows.Forms.TextBox();
            this.P_Input = new System.Windows.Forms.TextBox();
            this.SignIn_Button = new System.Windows.Forms.Button();
            this.New_Account = new System.Windows.Forms.Button();
            this.Remove_Later = new System.Windows.Forms.Button();
            this.Forgot_PWord_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Attempts_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // U_Input
            // 
            this.U_Input.Location = new System.Drawing.Point(322, 57);
            this.U_Input.Name = "U_Input";
            this.U_Input.Size = new System.Drawing.Size(100, 26);
            this.U_Input.TabIndex = 0;
            // 
            // P_Input
            // 
            this.P_Input.Location = new System.Drawing.Point(322, 110);
            this.P_Input.Name = "P_Input";
            this.P_Input.PasswordChar = '*';
            this.P_Input.Size = new System.Drawing.Size(100, 26);
            this.P_Input.TabIndex = 1;
            // 
            // SignIn_Button
            // 
            this.SignIn_Button.Location = new System.Drawing.Point(306, 142);
            this.SignIn_Button.Name = "SignIn_Button";
            this.SignIn_Button.Size = new System.Drawing.Size(137, 47);
            this.SignIn_Button.TabIndex = 2;
            this.SignIn_Button.Text = "Sign in";
            this.SignIn_Button.UseVisualStyleBackColor = true;
            this.SignIn_Button.Click += new System.EventHandler(this.SignIn_Button_Click);
            // 
            // New_Account
            // 
            this.New_Account.Location = new System.Drawing.Point(306, 195);
            this.New_Account.Name = "New_Account";
            this.New_Account.Size = new System.Drawing.Size(137, 36);
            this.New_Account.TabIndex = 3;
            this.New_Account.Text = "Create Account";
            this.New_Account.UseVisualStyleBackColor = true;
            this.New_Account.Click += new System.EventHandler(this.New_Account_Click);
            // 
            // Remove_Later
            // 
            this.Remove_Later.Location = new System.Drawing.Point(585, 66);
            this.Remove_Later.Name = "Remove_Later";
            this.Remove_Later.Size = new System.Drawing.Size(75, 103);
            this.Remove_Later.TabIndex = 4;
            this.Remove_Later.Text = "Skip";
            this.Remove_Later.UseVisualStyleBackColor = true;
            this.Remove_Later.Click += new System.EventHandler(this.Remove_Later_Click);
            // 
            // Forgot_PWord_Button
            // 
            this.Forgot_PWord_Button.Location = new System.Drawing.Point(306, 226);
            this.Forgot_PWord_Button.Name = "Forgot_PWord_Button";
            this.Forgot_PWord_Button.Size = new System.Drawing.Size(137, 58);
            this.Forgot_PWord_Button.TabIndex = 5;
            this.Forgot_PWord_Button.Text = "Forgotten Password";
            this.Forgot_PWord_Button.UseVisualStyleBackColor = true;
            this.Forgot_PWord_Button.Click += new System.EventHandler(this.Forgot_PWord_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(332, 87);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(78, 20);
            this.Password_Label.TabIndex = 7;
            this.Password_Label.Text = "Password";
            // 
            // Attempts_Label
            // 
            this.Attempts_Label.AutoSize = true;
            this.Attempts_Label.Location = new System.Drawing.Point(306, 291);
            this.Attempts_Label.Name = "Attempts_Label";
            this.Attempts_Label.Size = new System.Drawing.Size(0, 20);
            this.Attempts_Label.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Attempts_Label);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Forgot_PWord_Button);
            this.Controls.Add(this.Remove_Later);
            this.Controls.Add(this.New_Account);
            this.Controls.Add(this.SignIn_Button);
            this.Controls.Add(this.P_Input);
            this.Controls.Add(this.U_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox U_Input;
        private System.Windows.Forms.TextBox P_Input;
        private System.Windows.Forms.Button SignIn_Button;
        private System.Windows.Forms.Button New_Account;
        private System.Windows.Forms.Button Forgot_PWord_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Button Remove_Later;
        private System.Windows.Forms.Label Attempts_Label;
    }
}

