using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOODingManager
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string backupFolder = @"C:\FOODingBackupFolder"; // 백업 폴더 경로
            string backupFileName = $"backup_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.sql";
            string backupFilePath = Path.Combine(backupFolder, backupFileName);

            using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        mb.ExportToFile(backupFilePath);
                    }
                    MessageBox.Show("백업이 성공적으로 완료되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"백업 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQL 파일 (*.sql)|*.sql|모든 파일 (*.*)|*.*";
            openFileDialog.Title = "백업 파일 선택";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string restoreFilePath = openFileDialog.FileName;

                using (MySqlConnection conn = new MySqlConnection(Config.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ImportFromFile(restoreFilePath);
                        }
                        MessageBox.Show("복원이 성공적으로 완료되었습니다.");
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"복원 중 오류가 발생했습니다: {ex.Message}");
                    }
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
