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
    public partial class Form4 : Form
    {
        private static string _Username;
        public Form4()
        {
            InitializeComponent();

        }
        private void Change_Friendship(CheckBox box)
        {
            if (box.Checked)
            {
                // Add friend
                DB_Write dB_Write = new DB_Write(_Username);
                dB_Write.Add_Friend(box.Text);
            }
            else
            {
                // Remove friend
                DB_Write dB_Write = new DB_Write(_Username);
                dB_Write.Remove_Friend(box.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }
        private void Light_Mode()
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //DB_Read dB_Read = new DB_Read(_Username);
            //List<string> Friends = dB_Read.Find_Friends();
            List<string> Friends = new List<string>();
            Friends.Add("Friend1");
            Friends.Add("Friend2");
            Friends.Add("Friend3");
            
            for (int i = 0; i < Friends.Count; i++)
            {
                CheckBox Friend = new CheckBox();
                Friend.Text = Friends[i];
                Friend.Location = new Point(64, 100 + (i * 24));
                Friend.Size = new Size(114, 24);
                Friend.Checked = true;
               // Friend.CheckedChanged += (object sender,EventArgs e) => Change_Friendship(Friend);
                Friend.Show();
                this.Controls.Add(Friend);
            }
            
        }
    }
}
