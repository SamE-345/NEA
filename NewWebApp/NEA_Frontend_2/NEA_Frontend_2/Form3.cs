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
        public Form3(string Username, string Recipient)
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Recipient_Name_Label.Text = _Recipient;
            DB_Read Message_Read = new DB_Read(_Username);
            List<Message> Messages = Message_Read.Read_Messages(_Recipient);
        }
    }
}
