using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace FOODingManager
{
    public partial class Form2 : Form
    {        
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            RefreshScreen();
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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();     // 어플리케이션 전체 종료
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void 리뷰관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        public void RefreshScreen()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                conn.Open();

                try
                {
                    string query = @"
                        SELECT 
                            (SELECT COUNT(*) FROM member_t) AS memberCount, 
                            (SELECT COUNT(*) FROM member_t WHERE mtype = 1) AS ownerCount,
                            (SELECT COUNT(*) FROM member_t WHERE mtype = 0) AS userCount,
                            (SELECT COUNT(*) FROM store_t) AS storeCount,
                            (SELECT COUNT(*) FROM group_table) AS groupCount,                            
                            (SELECT COUNT(*) FROM review_t) AS reviewCount,                            
                            (SELECT COUNT(*) FROM member_t WHERE mdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newMemberCount,
                            (SELECT COUNT(*) FROM member_t WHERE mdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newOwnerCount,
                            (SELECT COUNT(*) FROM member_t WHERE mdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newUserCount,
                            (SELECT COUNT(*) FROM group_table WHERE gdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newGroupCount,
                            (SELECT COUNT(*) FROM review_t WHERE rdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newReviewCount,
                            (SELECT COUNT(*) FROM reviewreport_t rr LEFT JOIN review_t r ON rr.rno = r.rno WHERE r.adelete IS NULL OR r.adelete = 0) AS repCount,
                            (SELECT COUNT(DISTINCT r.rno) FROM review_t r INNER JOIN reviewreport_t rr ON r.rno = rr.rno) AS rrCount,
                            (SELECT COUNT(*) FROM member_t m LEFT JOIN review_t r ON m.mno = r.mno WHERE m.mwarning >=1) AS mrCount,
                            (SELECT COUNT(*) FROM review_t WHERE adelete >= 1) AS revRmoveCount
                            ;";
                            // (SELECT COUNT(*) FROM group_table WHERE mdate >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)) AS newGroupCount

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int memberCount = Convert.ToInt32(reader["memberCount"]);
                            int ownerCount = Convert.ToInt32(reader["ownerCount"]);
                            int userCount = Convert.ToInt32(reader["userCount"]);
                            int storeCount = Convert.ToInt32(reader["storeCount"]);
                            int groupCount = Convert.ToInt32(reader["groupCount"]);
                            int reviewCount = Convert.ToInt32(reader["reviewCount"]);
                            
                            int newMemberCount = Convert.ToInt32(reader["newMemberCount"]);
                            int newOwnerCount = Convert.ToInt32(reader["newOwnerCount"]);
                            int newUserCount = Convert.ToInt32(reader["newUserCount"]);
                            int newGroupCount = Convert.ToInt32(reader["newGroupCount"]);
                            int newReviewCount = Convert.ToInt32(reader["newReviewCount"]);
                            
                            int repCount = Convert.ToInt32(reader["repCount"]);
                            int rrCount = Convert.ToInt32(reader["rrCount"]);
                            int mrCount = Convert.ToInt32(reader["mrCount"]);
                            int revRmoveCount = Convert.ToInt32(reader["revRmoveCount"]);

                            label1.Text = "전체 회원 수 : " + memberCount +" 명";
                            label2.Text = "사장님 수 : " + ownerCount + " 명";
                            label3.Text = "일반회원 수 : " + userCount + " 명";
                            label4.Text = "가게 수 : " + storeCount + " 개";
                            label5.Text = "모임 수 : " + groupCount + " 개";
                            label6.Text = "리뷰 작성 수 : " + reviewCount + " 개";                            
                            
                            label7.Text = "신규 회원 수 : " + newMemberCount + " 명";
                            label8.Text = "신규 사장님 수 : " + newOwnerCount + " 명";
                            label9.Text = "신규 일반회원 수 : " + newUserCount + " 명";
                            label10.Text = "신규 모임 수 : " + newGroupCount + " 개";                            
                            label11.Text = "신규 리뷰 수 : "+ newReviewCount + " 명";                            
                            
                            label12.Text = "리뷰 신고 수 : "+ repCount + " 개";                            
                            label13.Text = "신고받은 리뷰 수 : "+ rrCount + " 개";                            
                            label14.Text = "경고받은 회원 수 : "+ mrCount + " 명";                            
                            label15.Text = "관리자 삭제된 리뷰 수 : "+ revRmoveCount + " 개";                            
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Failed to load member count: {ex.Message}");
                }              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 백업복원ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
