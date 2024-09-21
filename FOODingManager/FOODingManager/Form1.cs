using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOODingManager
{
    public partial class Form1 : Form
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "1234";
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(AdminPassword);
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick(); 
                }
            };
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == AdminUsername && VerifyPassword(password, hashedPassword))
            {
                MessageBox.Show("로그인 성공");
                OpenAdmin();
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호가 다릅니다.");
                System.Threading.Thread.Sleep(2000);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        private void OpenAdmin()
        {
            Form2 adminView = new Form2();
            adminView.Show();
            this.Hide();
        }

        private void mainOut_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}