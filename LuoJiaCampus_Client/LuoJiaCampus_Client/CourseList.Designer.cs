namespace STUDENTINFO
{
    partial class CourseList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.yearlabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.课程号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.课程名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.课程类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学习类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.授课学院 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.主讲教师 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.专业 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学时 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.上课时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCalendar);
            this.panel1.Controls.Add(this.yearlabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 77);
            this.panel1.TabIndex = 0;
            // 
            // yearlabel
            // 
            this.yearlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearlabel.AutoSize = true;
            this.yearlabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yearlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.yearlabel.Location = new System.Drawing.Point(365, 31);
            this.yearlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yearlabel.Name = "yearlabel";
            this.yearlabel.Size = new System.Drawing.Size(93, 20);
            this.yearlabel.TabIndex = 5;
            this.yearlabel.Text = "详细课表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.课程号,
            this.课程名,
            this.课程类型,
            this.学习类型,
            this.授课学院,
            this.主讲教师,
            this.专业,
            this.学分,
            this.学时,
            this.上课时间});
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 342);
            this.dataGridView1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(399, 429);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "x";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(367, 429);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "共";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(425, 429);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "条记录";
            // 
            // 课程号
            // 
            this.课程号.DataPropertyName = "courseNum";
            this.课程号.HeaderText = "课程号";
            this.课程号.Name = "课程号";
            this.课程号.Width = 80;
            // 
            // 课程名
            // 
            this.课程名.DataPropertyName = "courseName";
            this.课程名.HeaderText = "课程名";
            this.课程名.Name = "课程名";
            this.课程名.Width = 170;
            // 
            // 课程类型
            // 
            this.课程类型.DataPropertyName = "courseType";
            this.课程类型.HeaderText = "课程类型";
            this.课程类型.Name = "课程类型";
            // 
            // 学习类型
            // 
            this.学习类型.DataPropertyName = "learnType";
            this.学习类型.HeaderText = "学习类型";
            this.学习类型.Name = "学习类型";
            this.学习类型.Width = 60;
            // 
            // 授课学院
            // 
            this.授课学院.DataPropertyName = "school";
            this.授课学院.HeaderText = "授课学院";
            this.授课学院.Name = "授课学院";
            this.授课学院.Width = 130;
            // 
            // 主讲教师
            // 
            this.主讲教师.DataPropertyName = "teacherName";
            this.主讲教师.HeaderText = "主讲教师";
            this.主讲教师.Name = "主讲教师";
            this.主讲教师.Width = 60;
            // 
            // 专业
            // 
            this.专业.DataPropertyName = "major";
            this.专业.HeaderText = "专业";
            this.专业.Name = "专业";
            this.专业.Width = 120;
            // 
            // 学分
            // 
            this.学分.DataPropertyName = "credits";
            this.学分.HeaderText = "学分";
            this.学分.Name = "学分";
            this.学分.Width = 30;
            // 
            // 学时
            // 
            this.学时.DataPropertyName = "learnTime";
            this.学时.HeaderText = "学时";
            this.学时.Name = "学时";
            this.学时.Width = 50;
            // 
            // 上课时间
            // 
            this.上课时间.DataPropertyName = "courseTime";
            this.上课时间.HeaderText = "上课时间";
            this.上课时间.Name = "上课时间";
            this.上课时间.Width = 240;
            // 
            // btnCalendar
            // 
            this.btnCalendar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.btnCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCalendar.FlatAppearance.BorderSize = 0;
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalendar.ForeColor = System.Drawing.Color.White;
            this.btnCalendar.Location = new System.Drawing.Point(707, 32);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(68, 25);
            this.btnCalendar.TabIndex = 8;
            this.btnCalendar.Text = "周历模式";
            this.btnCalendar.UseVisualStyleBackColor = false;
            // 
            // CourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "CourseList";
            this.Text = "CourseList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label yearlabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 课程号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 课程名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 课程类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学习类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 授课学院;
        private System.Windows.Forms.DataGridViewTextBoxColumn 主讲教师;
        private System.Windows.Forms.DataGridViewTextBoxColumn 专业;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学时;
        private System.Windows.Forms.DataGridViewTextBoxColumn 上课时间;
        private System.Windows.Forms.Button btnCalendar;
    }
}