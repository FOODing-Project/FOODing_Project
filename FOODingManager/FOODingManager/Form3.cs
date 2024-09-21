using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FOODingManager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
                                
            this.MaximizeBox = true;
            this.MinimizeBox = true;
                        
            this.MinimumSize = new Size(300, 200); 
            this.MaximumSize = new Size(1024, 768);
            
            LoadAllMembers();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            tBoxSearch.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.PerformClick();
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


        private void LoadAllMembers()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT mno as 회원No, 
                                            mid as ID,                                             
                                        CASE WHEN mtype = 0 THEN '손님' 
                                             WHEN mtype = 1 THEN '사장님'                                              
                                        ELSE '알수없음' 
                                        END AS 회원유형, 
                                            mname as 이름, 
                                            mnick as 닉네임, 
                                            mbirth as 생년월일, 
                                            mphone as 전화번호, 
                                            memail as 이메일, 
                                            maddr as 주소, 
                                            mdate as 가입날짜 
                                        FROM member_t";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.ReadOnly = true;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedMemberNum = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["회원No"].Value);
                LoadMemberDetails(selectedMemberNum);
            }
        }

        private void LoadMemberDetails(int memberNum)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT mno as 회원No, 
                                            mid as ID,
                                            mpass as 비밀번호,
                                        CASE WHEN mtype = 0 THEN '손님' 
                                                WHEN mtype = 1 THEN '사장님'                                              
                                        ELSE '알수없음' 
                                        END AS 회원유형, 
                                            mname as 이름, 
                                            mnick as 닉네임, 
                                            mbirth as 생년월일, 
                                            mphone as 전화번호, 
                                            memail as 이메일, 
                                            maddr as 주소, 
                                            mdate as 가입날짜
                                        FROM member_t WHERE mno = @회원No";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@회원No", memberNum);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;

                    dataGridView2.Columns["회원No"].ReadOnly = true;
                    dataGridView2.Columns["회원유형"].ReadOnly = true;
                    dataGridView2.Columns["생년월일"].ReadOnly = true;
                    dataGridView2.Columns["가입날짜"].ReadOnly = true;                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"선택된 회원 정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAllMembers();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = tBoxSearch.Text;
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT mno as 회원No, 
                                            mid as ID,                                     
                                        CASE WHEN mtype = 0 THEN '손님' 
                                                WHEN mtype = 1 THEN '사장님'                                              
                                        ELSE '알수없음' 
                                        END AS 회원유형, 
                                            mname as 이름, 
                                            mnick as 닉네임, 
                                            mbirth as 생년월일, 
                                            mphone as 전화번호, 
                                            memail as 이메일, 
                                            maddr as 주소, 
                                            mdate as 가입날짜
                                     FROM member_t 
                                     WHERE mid LIKE @searchText 
                                        OR mnick LIKE @searchText 
                                        OR mname LIKE @searchText 
                                        OR (CASE WHEN mtype = 0 THEN '손님' 
                                             WHEN mtype = 1 THEN '사장님' 
                                             ELSE '알수없음' 
                                             END) LIKE @searchText
                                        OR mbirth LIKE @searchText
                                        OR mphone LIKE @searchText
                                        OR memail LIKE @searchText
                                        OR maddr LIKE @searchText";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"검색 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            SaveInfo();
            LoadAllMembers();
        }

        private void SaveInfo()
        {
            

            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    // dataGridView2에서 선택된 행 가져오기
                    if (dataGridView2.CurrentRow != null)
                    {
                        int selectedMemberId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["회원No"].Value);
                        string mofId = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                        string mofPass = dataGridView2.CurrentRow.Cells["비밀번호"].Value.ToString();
                        string mofName = dataGridView2.CurrentRow.Cells["이름"].Value.ToString();
                        string mofNick = dataGridView2.CurrentRow.Cells["닉네임"].Value.ToString();
                        string mofBirth = dataGridView2.CurrentRow.Cells["생년월일"].Value.ToString();
                        string mofPhone = dataGridView2.CurrentRow.Cells["전화번호"].Value.ToString();
                        string mofEmail = dataGridView2.CurrentRow.Cells["이메일"].Value.ToString();
                        string mofAddr = dataGridView2.CurrentRow.Cells["주소"].Value.ToString();

                        // 업데이트 쿼리 작성
                        string query = @"
                            UPDATE member_t SET mid = @ID, mpass = @비밀번호, mname = @이름, mnick = @닉네임, mphone = @전화번호, memail = @이메일, maddr = @주소
                            WHERE mno = @회원No";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@회원No", selectedMemberId);
                        cmd.Parameters.AddWithValue("@ID", mofId);
                        cmd.Parameters.AddWithValue("@비밀번호", mofPass);
                        cmd.Parameters.AddWithValue("@이름", mofName);
                        cmd.Parameters.AddWithValue("@닉네임", mofNick);
                        cmd.Parameters.AddWithValue("@전화번호", mofPhone);
                        cmd.Parameters.AddWithValue("@이메일", mofEmail);
                        cmd.Parameters.AddWithValue("@주소", mofAddr);

                        // 쿼리 실행
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("회원 수정 정보가 성공적으로 저장되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("수정할 회원을 선택하세요.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 정보를 저장하지 못했습니다: {ex.Message}");
                }
            }
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo();
        }

        private void DeleteInfo()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    if (dataGridView2.CurrentRow != null)
                    {
                        int selectedMemberId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["회원No"].Value);

                        DialogResult result = MessageBox.Show($"{selectedMemberId}번의 회원정보를 삭제 하시겠습니까?", "리뷰 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            string deleteReviewReportsQuery = @"DELETE rrp
                                                                FROM reviewreport_t rrp
                                                                JOIN review_t rev ON rrp.rno = rev.rno
                                                                JOIN member_t mem ON rev.mno = mem.mno
                                                                WHERE mem.mno = @회원No";
                            MySqlCommand deleteReviewReportsCmd = new MySqlCommand(deleteReviewReportsQuery, conn);
                            deleteReviewReportsCmd.Parameters.AddWithValue("@회원No", selectedMemberId);
                            deleteReviewReportsCmd.ExecuteNonQuery();

                            string deleteReviewsQuery = @"DELETE rev
                                                        FROM review_t rev
                                                        JOIN member_t mem ON rev.mno = mem.mno
                                                        WHERE mem.mno = @회원No";
                            MySqlCommand deleteReviewsCmd = new MySqlCommand(deleteReviewsQuery, conn);
                            deleteReviewsCmd.Parameters.AddWithValue("@회원No", selectedMemberId);
                            deleteReviewsCmd.ExecuteNonQuery();

                            string query = @"DELETE FROM member_t WHERE mno = @회원No";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@회원No",selectedMemberId);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("회원 정보가 성공적으로 삭제되었습니다.");
                            dataGridView2.DataSource = null;
                            LoadAllMembers();
                            }
                            else if (result == DialogResult.No)
                            {

                            }
                    }
                    else
                    {
                        MessageBox.Show("삭제할 회원을 선택하세요.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 정보를 삭제하지 못했습니다: {ex.Message}");
                }
            }        
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
