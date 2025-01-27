namespace NEAFrontent
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserName_Input = new TextBox();
            UName_Label = new Label();
            PWord_Label = new Label();
            Password_Input = new TextBox();
            SignIn_button = new Button();
            New_Account = new Button();
            SuspendLayout();
            // 
            // UserName_Input
            // 
            UserName_Input.Location = new Point(314, 86);
            UserName_Input.Name = "UserName_Input";
            UserName_Input.Size = new Size(150, 31);
            UserName_Input.TabIndex = 0;
            // 
            // UName_Label
            // 
            UName_Label.AutoSize = true;
            UName_Label.Location = new Point(338, 47);
            UName_Label.Name = "UName_Label";
            UName_Label.Size = new Size(91, 25);
            UName_Label.TabIndex = 1;
            UName_Label.Text = "Username";
            // 
            // PWord_Label
            // 
            PWord_Label.AutoSize = true;
            PWord_Label.Location = new Point(342, 131);
            PWord_Label.Name = "PWord_Label";
            PWord_Label.Size = new Size(87, 25);
            PWord_Label.TabIndex = 2;
            PWord_Label.Text = "Password";
            // 
            // Password_Input
            // 
            Password_Input.Location = new Point(314, 159);
            Password_Input.Name = "Password_Input";
            Password_Input.PasswordChar = '*';
            Password_Input.Size = new Size(150, 31);
            Password_Input.TabIndex = 3;
            // 
            // SignIn_button
            // 
            SignIn_button.Location = new Point(314, 211);
            SignIn_button.Name = "SignIn_button";
            SignIn_button.Size = new Size(150, 34);
            SignIn_button.TabIndex = 4;
            SignIn_button.Text = "Sign in";
            SignIn_button.UseVisualStyleBackColor = true;
            SignIn_button.Click += SignIn_button_Click;
            // 
            // New_Account
            // 
            New_Account.Location = new Point(314, 251);
            New_Account.Name = "New_Account";
            New_Account.Size = new Size(150, 34);
            New_Account.TabIndex = 5;
            New_Account.Text = "New account";
            New_Account.UseVisualStyleBackColor = true;
            New_Account.Click += New_Account_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(834, 444);
            Controls.Add(New_Account);
            Controls.Add(SignIn_button);
            Controls.Add(Password_Input);
            Controls.Add(PWord_Label);
            Controls.Add(UName_Label);
            Controls.Add(UserName_Input);
            Name = "Form1";
            Text = "Signin_Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserName_Input;
        private Label UName_Label;
        private Label PWord_Label;
        private TextBox Password_Input;
        private Button SignIn_button;
        private Button New_Account;
    }
}
