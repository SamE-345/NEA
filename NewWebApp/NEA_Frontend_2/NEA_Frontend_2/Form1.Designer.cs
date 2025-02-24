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
            this.SuspendLayout();
            // 
            // U_Input
            // 
            this.U_Input.Location = new System.Drawing.Point(322, 66);
            this.U_Input.Name = "U_Input";
            this.U_Input.Size = new System.Drawing.Size(100, 26);
            this.U_Input.TabIndex = 0;
            // 
            // P_Input
            // 
            this.P_Input.Location = new System.Drawing.Point(322, 99);
            this.P_Input.Name = "P_Input";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.New_Account);
            this.Controls.Add(this.SignIn_Button);
            this.Controls.Add(this.P_Input);
            this.Controls.Add(this.U_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox U_Input;
        private System.Windows.Forms.TextBox P_Input;
        private System.Windows.Forms.Button SignIn_Button;
        private System.Windows.Forms.Button New_Account;
    }
}

