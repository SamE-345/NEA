namespace NEAFrontent
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
            Menu_Label = new Label();
            SuspendLayout();
            // 
            // Menu_Label
            // 
            Menu_Label.AutoSize = true;
            Menu_Label.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            Menu_Label.Location = new Point(287, 24);
            Menu_Label.Name = "Menu_Label";
            Menu_Label.Size = new Size(385, 45);
            Menu_Label.TabIndex = 0;
            Menu_Label.Text = "Select friend to message";
            Menu_Label.Click += label1_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(967, 539);
            Controls.Add(Menu_Label);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Menu_Label;
    }
}