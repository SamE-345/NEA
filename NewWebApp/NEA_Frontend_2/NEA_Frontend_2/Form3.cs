using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Frontend_2
{
    public partial class Form3 : Form
    {
        private static string _Username;
        private static string _Recipient;
        public Form3(string Username, string Recipient, bool Darkmode)
        {
            InitializeComponent();
            _Username = Username;
            _Recipient = Recipient;
            Colour(Darkmode);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Recipient_Name_Label.Text = _Recipient;
            Reload();
        }
        private void Reload()
        {
            Message_Space.Text = "";

            DB_Read Message_Read = new DB_Read(_Username);
            List<Message> Messages = Message_Read.Read_Messages(_Recipient);
            for (int i=0; i <5; i++)
            {
                Message_Space.Text += Messages[Messages.Count - i].Sender + ": " + Messages[Messages.Count - i].Text;
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_Username);
            this.Hide();
            form2.Show();
        }
        private void Colour(bool Darkmode)
        {
            if (Darkmode)
            {
                BackColor = Color.FromArgb(31, 31, 31);
                Message_Space.ForeColor = Color.White;
                Recipient_Name_Label.ForeColor = Color.White;
                Send_Button.BackColor = Color.FromArgb(31, 31, 31);
                Send_Button.ForeColor = Color.White;

            }
            else
            {
                BackColor = Color.White;
                Message_Space.ForeColor = Color.Black;
                Recipient_Name_Label.ForeColor = Color.Black;
                Send_Button.BackColor = Color.White;
                Send_Button.ForeColor = Color.Black;
            }
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            Refresh_Button.Enabled = false;
            Reload();
            Refresh_Button.Enabled = true;
        }

        private void Message_Space_Click(object sender, EventArgs e)
        {

        }
    }
}
