namespace NewFrontend
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
            this.UName_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PWord_Input = new System.Windows.Forms.TextBox();
            this.SignIn_Button = new System.Windows.Forms.Button();
            this.CreateAccount_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UName_Input
            // 
            this.UName_Input.Location = new System.Drawing.Point(299, 97);
            this.UName_Input.Name = "UName_Input";
            this.UName_Input.Size = new System.Drawing.Size(164, 26);
            this.UName_Input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // PWord_Input
            // 
            this.PWord_Input.Location = new System.Drawing.Point(299, 130);
            this.PWord_Input.Name = "PWord_Input";
            this.PWord_Input.Size = new System.Drawing.Size(164, 26);
            this.PWord_Input.TabIndex = 2;
            // 
            // SignIn_Button
            // 
            this.SignIn_Button.Location = new System.Drawing.Point(299, 162);
            this.SignIn_Button.Name = "SignIn_Button";
            this.SignIn_Button.Size = new System.Drawing.Size(164, 49);
            this.SignIn_Button.TabIndex = 3;
            this.SignIn_Button.Text = "Sign in";
            this.SignIn_Button.UseVisualStyleBackColor = true;
           
            // 
            // CreateAccount_Button
            // 
            this.CreateAccount_Button.Location = new System.Drawing.Point(299, 217);
            this.CreateAccount_Button.Name = "CreateAccount_Button";
            this.CreateAccount_Button.Size = new System.Drawing.Size(164, 42);
            this.CreateAccount_Button.TabIndex = 4;
            this.CreateAccount_Button.Text = "Create account";
            this.CreateAccount_Button.UseVisualStyleBackColor = true;
            this.CreateAccount_Button.Click += new System.EventHandler(this.CreateAccount_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateAccount_Button);
            this.Controls.Add(this.SignIn_Button);
            this.Controls.Add(this.PWord_Input);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UName_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UName_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PWord_Input;
        private System.Windows.Forms.Button SignIn_Button;
        private System.Windows.Forms.Button CreateAccount_Button;
    }
}

