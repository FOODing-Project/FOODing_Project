using Google.Protobuf.WellKnownTypes;
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

namespace FOODingManager
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadAllReviews();
            LoadReportCount();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

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
        private void btnAllReview_Click(object sender, EventArgs e)
        {
            LoadAllReviews();
        }
                
        private void LoadAllReviews()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT rev.rno as 리뷰No, 
                                            rev.rdate as 작성날짜, 
                                            mem.mid as 작성자ID, 
                                            sto.sname as 가게명, 
                                            rev.rstar as 별점, 
                                            rev.rcomm as 리뷰_내용                                            
                                        FROM review_t rev                                         
                                        JOIN member_t mem ON rev.mno = mem.mno
                                        JOIN store_t sto ON rev.sno = sto.sno";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.ReadOnly = true;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 열 사이즈 자동 조절
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"리뷰정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }

        private void btnReportReview_Click(object sender, EventArgs e)
        {
            LoadReportReviews();
        }
        private void LoadReportReviews()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT rev.rno as 리뷰No,
                                                    rrp.rrdate as 신고된날짜,                                                      
                                                    revMem.mid as 작성자ID,
                                                    sto.sname as 가게명,                                                     
                                                    rev.rstar as 별점, 
                                                    rev.rcomm as 리뷰_내용, 
                                                    rep.rptype as 사유
                                        FROM reviewreport_t rrp
                                        JOIN report_t rep ON rrp.rpno = rep.rpno
                                        JOIN review_t rev ON rrp.rno = rev.rno
                                        JOIN member_t mem ON rrp.mno = mem.mno
                                        JOIN member_t revMem ON rev.mno = revMem.mno
                                        JOIN store_t sto ON rev.sno = sto.sno
                                        WHERE (revMem.mid, rev.rcomm) IN 
                                        (   SELECT DISTINCT revMem.mid, rev.rcomm
                                            FROM reviewreport_t rrp 
                                            JOIN report_t rep ON rrp.rpno = rep.rpno
                                            JOIN review_t rev ON rrp.rno = rev.rno
                                            JOIN member_t revMem ON rev.mno = revMem.mno
                                        )";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.Columns["리뷰No"].Visible = false;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"리뷰정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedReviewNum = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["리뷰No"].Value);
                LoadReviewDetails(selectedReviewNum);
                LoadReportDetails(selectedReviewNum);
                
            }
        }
        private void LoadReviewDetails(int rNum)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT rrp.rno as 리뷰No,
                                                    revMem.mid as ID, 
                                                    revMem.mnick as 닉네임,
                                                    revMem.mwarning as 경고, 
                                                    revMem.mdate as 가입날짜,
                                                    COUNT(*) as 신고수,
                                                    rev.adelete as 관리자삭제
                                        FROM review_t rev 
                                        JOIN reviewreport_t rrp ON rev.rno = rrp.rno
                                        JOIN report_t rep ON rrp.rpno = rep.rpno
                                        JOIN member_t mem ON rrp.mno = mem.mno
                                        JOIN member_t revMem ON rev.mno = revMem.mno
                                        JOIN store_t revSto ON rev.sno = revSto.sno 
                                        WHERE rrp.rno = @리뷰 
                                        GROUP BY revMem.mno,
                                                rrp.rno,
                                                revMem.mid, 
                                                revMem.mnick,
                                                revMem.mwarning, 
                                                revMem.mdate,
                                                rev.adelete";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@리뷰", rNum);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                    dataGridView2.ReadOnly = true;
                    dataGridView2.Columns["리뷰No"].Visible = false;

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"리뷰 상세정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }
        private void LoadReportDetails(int rNum)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT rep.rptype as 사유, 
                                            COUNT(*) as 횟수
                                     FROM reviewreport_t rrp 
                                     JOIN report_t rep ON rrp.rpno = rep.rpno                                        
                                     WHERE rrp.rno = @리뷰
                                     GROUP BY rep.rptype";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@리뷰", rNum);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView3.DataSource = table;
                    dataGridView3.ReadOnly = true;

                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"리뷰신고 상세정보를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }
        
        private void LoadReportCount()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT (SELECT COUNT(*) as 횟수
                                             FROM reviewreport_t WHERE rno) AS ReportCount;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int ReportCount = Convert.ToInt32(reader["ReportCount"]);

                            label3.Text = "총 신고 수 : " + ReportCount + " 회";
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"총 신고 횟수를 불러오지 못했습니다: {ex.Message}");
                }
            }
        }

        private void btnWarn_Click(object sender, EventArgs e)
        {
            mWarning();
        }

        private void mWarning()
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {

                try
                {
                    conn.Open();

                    if (dataGridView2.CurrentCell != null)
                    {
                        int selectedReviewNum = Convert.ToInt32(dataGridView2.CurrentRow.Cells["리뷰No"].Value);


                        string query = @"UPDATE member_t 
                                        SET mwarning = mwarning + 1 
                                        WHERE mno = (SELECT mno FROM review_t WHERE rno = @리뷰No)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@리뷰No", selectedReviewNum);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("회원을 경고 하였습니다.");
                        }
                        else
                        {
                            MessageBox.Show("경고 업데이트에 실패했습니다. 트랜잭션이 롤백되었습니다.");
                        }


                        LoadReviewDetails(selectedReviewNum);
                        LoadReportReviews();
                        
                        
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show($"경고할 회원을 선택하세요. 오류: {ex.Message}");
                }
                
            }
        }

        private void btnWarnCancel_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    if (dataGridView2.CurrentCell != null)
                    {
                        int selectedReviewNum = Convert.ToInt32(dataGridView2.CurrentRow.Cells["리뷰No"].Value);

                        string query = @"UPDATE member_t 
                                        SET mwarning = mwarning - 1 
                                        WHERE mno = (SELECT mno FROM review_t WHERE rno = @리뷰No)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@리뷰No", selectedReviewNum);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("회원을 경고 취소 하였습니다.");

                        LoadReviewDetails(selectedReviewNum);
                        LoadReportReviews();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"경고 취소할 회원을 선택하세요. 오류: {ex.Message}");
                }
            }
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
        }

        private void btnRemoveRev_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    if (dataGridView2.CurrentCell != null)
                    {
                        int selectedReviewNum = Convert.ToInt32(dataGridView2.CurrentRow.Cells["리뷰No"].Value);

                        /*string checkQuery = @"SELECT adelete FROM review_t WHERE rno = @리뷰No";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@리뷰No", selectedReviewNum);
                        object result = checkCmd.ExecuteScalar();

                        checkCmd.ExecuteNonQuery();

                        if (result != null && result != DBNull.Value)
                        {
                            int adeleteValue = Convert.ToInt32(result);

                            if (adeleteValue >= 2)
                            {
                                MessageBox.Show("이미 삭제된 리뷰입니다.");
                                return; // 삭제 작업을 중단합니다.
                            }
                        }
                        else
                        {
                            // result가 null 또는 DBNull일 때의 처리
                            MessageBox.Show("리뷰 번호에 해당하는 데이터를 찾을 수 없습니다.");
                            return;
                        }*/

                        DialogResult dialogResult = MessageBox.Show($"{selectedReviewNum}번의 리뷰를 삭제 하시겠습니까?", "리뷰 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            
                            // review_t에서 리뷰 삭제 카운트
                            string query = @"UPDATE review_t SET adelete = IFNULL(adelete, 0) + 1 WHERE rno = @리뷰No";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@리뷰No", selectedReviewNum);

                            cmd.ExecuteNonQuery();

                            
                            MessageBox.Show("리뷰 삭제를 완료하였습니다.");

                            LoadReviewDetails(selectedReviewNum);
                            LoadReportReviews();
                        }                                            
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"삭제할 리뷰를 선택하세요. 오류: {ex.Message}");
                }
            }
        }

        private void btnRemoveMem_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();

                    if (dataGridView2.CurrentCell != null)
                    {                        
                        string selectedReviewMem = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                                                
                        DialogResult result = MessageBox.Show($"{selectedReviewMem} 회원을 삭제 하시겠습니까?", "회원 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {                            
                            string deleteReviewReportsQuery = @"DELETE rrp
                                                                FROM reviewreport_t rrp
                                                                JOIN review_t rev ON rrp.rno = rev.rno
                                                                JOIN member_t mem ON rev.mno = mem.mno
                                                                WHERE mem.mid = @ID";
                            MySqlCommand deleteReviewReportsCmd = new MySqlCommand(deleteReviewReportsQuery, conn);
                            deleteReviewReportsCmd.Parameters.AddWithValue("@ID", selectedReviewMem);
                            deleteReviewReportsCmd.ExecuteNonQuery();
                                                        
                            string deleteReviewsQuery = @"DELETE rev
                                                        FROM review_t rev
                                                        JOIN member_t mem ON rev.mno = mem.mno
                                                        WHERE mem.mid = @ID";
                            MySqlCommand deleteReviewsCmd = new MySqlCommand(deleteReviewsQuery, conn);
                            deleteReviewsCmd.Parameters.AddWithValue("@ID", selectedReviewMem);
                            deleteReviewsCmd.ExecuteNonQuery();

                            string deleteMemberQuery = "DELETE FROM member_t WHERE mid = @ID";
                            MySqlCommand deleteMemberCmd = new MySqlCommand(deleteMemberQuery, conn);
                            deleteMemberCmd.Parameters.AddWithValue("@ID", selectedReviewMem);
                            deleteMemberCmd.ExecuteNonQuery();

                            MessageBox.Show("회원 삭제를 완료하였습니다.");

                            LoadReportReviews();

                            dataGridView2.DataSource = null;
                            dataGridView3.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 삭제 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
