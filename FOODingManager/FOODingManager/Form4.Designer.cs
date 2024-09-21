namespace FOODingManager
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnWarn = new System.Windows.Forms.Button();
            this.btnRemoveRev = new System.Windows.Forms.Button();
            this.btnRemoveMem = new System.Windows.Forms.Button();
            this.btnWarnCancel = new System.Windows.Forms.Button();
            this.btnAllReview = new System.Windows.Forms.Button();
            this.btnReportReview = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnF5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(831, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "리뷰 관리";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 335);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "전체 리뷰";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(788, 309);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 250);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상세 정보";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(496, 224);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(525, 350);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 250);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "신고 이력";
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 20);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(275, 189);
            this.dataGridView3.TabIndex = 1;
            // 
            // btnOut
            // 
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Location = new System.Drawing.Point(928, 577);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 6;
            this.btnOut.Text = "나가기";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnWarn
            // 
            this.btnWarn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWarn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWarn.Location = new System.Drawing.Point(21, 293);
            this.btnWarn.Name = "btnWarn";
            this.btnWarn.Size = new System.Drawing.Size(69, 57);
            this.btnWarn.TabIndex = 7;
            this.btnWarn.Text = "경고부여";
            this.btnWarn.UseVisualStyleBackColor = true;
            this.btnWarn.Click += new System.EventHandler(this.btnWarn_Click);
            // 
            // btnRemoveRev
            // 
            this.btnRemoveRev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemoveRev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRev.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRemoveRev.Location = new System.Drawing.Point(21, 356);
            this.btnRemoveRev.Name = "btnRemoveRev";
            this.btnRemoveRev.Size = new System.Drawing.Size(142, 61);
            this.btnRemoveRev.TabIndex = 8;
            this.btnRemoveRev.Text = "리뷰 삭제";
            this.btnRemoveRev.UseVisualStyleBackColor = true;
            this.btnRemoveRev.Click += new System.EventHandler(this.btnRemoveRev_Click);
            // 
            // btnRemoveMem
            // 
            this.btnRemoveMem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemoveMem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMem.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRemoveMem.Location = new System.Drawing.Point(21, 423);
            this.btnRemoveMem.Name = "btnRemoveMem";
            this.btnRemoveMem.Size = new System.Drawing.Size(142, 59);
            this.btnRemoveMem.TabIndex = 9;
            this.btnRemoveMem.Text = "회원 삭제";
            this.btnRemoveMem.UseVisualStyleBackColor = true;
            this.btnRemoveMem.Click += new System.EventHandler(this.btnRemoveMem_Click);
            // 
            // btnWarnCancel
            // 
            this.btnWarnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWarnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWarnCancel.Location = new System.Drawing.Point(93, 293);
            this.btnWarnCancel.Name = "btnWarnCancel";
            this.btnWarnCancel.Size = new System.Drawing.Size(70, 57);
            this.btnWarnCancel.TabIndex = 10;
            this.btnWarnCancel.Text = "경고취소";
            this.btnWarnCancel.UseVisualStyleBackColor = true;
            this.btnWarnCancel.Click += new System.EventHandler(this.btnWarnCancel_Click);
            // 
            // btnAllReview
            // 
            this.btnAllReview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAllReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllReview.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAllReview.Location = new System.Drawing.Point(21, 31);
            this.btnAllReview.Name = "btnAllReview";
            this.btnAllReview.Size = new System.Drawing.Size(142, 66);
            this.btnAllReview.TabIndex = 11;
            this.btnAllReview.Text = "전체 리뷰 조회";
            this.btnAllReview.UseVisualStyleBackColor = true;
            this.btnAllReview.Click += new System.EventHandler(this.btnAllReview_Click);
            // 
            // btnReportReview
            // 
            this.btnReportReview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReportReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportReview.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReportReview.Location = new System.Drawing.Point(21, 122);
            this.btnReportReview.Name = "btnReportReview";
            this.btnReportReview.Size = new System.Drawing.Size(142, 68);
            this.btnReportReview.TabIndex = 12;
            this.btnReportReview.Text = "신고 리뷰 조회";
            this.btnReportReview.UseVisualStyleBackColor = true;
            this.btnReportReview.Click += new System.EventHandler(this.btnReportReview_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnWarnCancel);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnWarn);
            this.groupBox4.Controls.Add(this.btnRemoveRev);
            this.groupBox4.Controls.Add(this.btnReportReview);
            this.groupBox4.Controls.Add(this.btnRemoveMem);
            this.groupBox4.Controls.Add(this.btnAllReview);
            this.groupBox4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(818, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 494);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "리뷰 관리";
            // 
            // btnF5
            // 
            this.btnF5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnF5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnF5.Location = new System.Drawing.Point(816, 575);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(23, 23);
            this.btnF5.TabIndex = 13;
            this.btnF5.Text = "×";
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1019, 606);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnWarn;
        private System.Windows.Forms.Button btnRemoveRev;
        private System.Windows.Forms.Button btnRemoveMem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnWarnCancel;
        private System.Windows.Forms.Button btnAllReview;
        private System.Windows.Forms.Button btnReportReview;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnF5;
    }
}