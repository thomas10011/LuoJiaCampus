namespace STUDENTINFO
{
    partial class GradeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.courseScoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yearcomboBox = new System.Windows.Forms.ComboBox();
            this.courseTcomboBox = new System.Windows.Forms.ComboBox();
            this.termcomboBox = new System.Windows.Forms.ComboBox();
            this.yearlabel = new System.Windows.Forms.Label();
            this.courseTlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.averStextBox = new System.Windows.Forms.TextBox();
            this.averPtextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradePointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.计算 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseScoreBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useridDataGridViewTextBoxColumn,
            this.courseidDataGridViewTextBoxColumn,
            this.courseNameDataGridViewTextBoxColumn,
            this.score,
            this.credits,
            this.gradePointDataGridViewTextBoxColumn,
            this.courseTypeDataGridViewTextBoxColumn,
            this.teacherNameDataGridViewTextBoxColumn,
            this.schoolDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.termDataGridViewCheckBoxColumn,
            this.计算});
            this.dataGridView1.DataSource = this.courseScoreBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("造字工房悦圆演示版常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(944, 380);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // courseScoreBindingSource
            // 
            this.courseScoreBindingSource.DataSource = typeof(compusDBManage.CourseScore);
            // 
            // yearcomboBox
            // 
            this.yearcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearcomboBox.BackColor = System.Drawing.Color.White;
            this.yearcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yearcomboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.yearcomboBox.FormattingEnabled = true;
            this.yearcomboBox.Items.AddRange(new object[] {
            "全部",
            "2018",
            "2019",
            "2020"});
            this.yearcomboBox.Location = new System.Drawing.Point(189, 34);
            this.yearcomboBox.Name = "yearcomboBox";
            this.yearcomboBox.Size = new System.Drawing.Size(101, 23);
            this.yearcomboBox.TabIndex = 1;
            // 
            // courseTcomboBox
            // 
            this.courseTcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.courseTcomboBox.BackColor = System.Drawing.Color.White;
            this.courseTcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courseTcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseTcomboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.courseTcomboBox.FormattingEnabled = true;
            this.courseTcomboBox.Items.AddRange(new object[] {
            "全部",
            "公共必修",
            "通识教育选修",
            "专业必修",
            "专业选修",
            "专业教育必修",
            "公共基础必修"});
            this.courseTcomboBox.Location = new System.Drawing.Point(398, 34);
            this.courseTcomboBox.Name = "courseTcomboBox";
            this.courseTcomboBox.Size = new System.Drawing.Size(151, 23);
            this.courseTcomboBox.TabIndex = 2;
            // 
            // termcomboBox
            // 
            this.termcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.termcomboBox.BackColor = System.Drawing.Color.White;
            this.termcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.termcomboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.termcomboBox.FormattingEnabled = true;
            this.termcomboBox.Items.AddRange(new object[] {
            "全部",
            "1",
            "2"});
            this.termcomboBox.Location = new System.Drawing.Point(632, 34);
            this.termcomboBox.Name = "termcomboBox";
            this.termcomboBox.Size = new System.Drawing.Size(121, 23);
            this.termcomboBox.TabIndex = 3;
            // 
            // yearlabel
            // 
            this.yearlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearlabel.AutoSize = true;
            this.yearlabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yearlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.yearlabel.Location = new System.Drawing.Point(89, 37);
            this.yearlabel.Name = "yearlabel";
            this.yearlabel.Size = new System.Drawing.Size(39, 15);
            this.yearlabel.TabIndex = 4;
            this.yearlabel.Text = "学年";
            // 
            // courseTlabel
            // 
            this.courseTlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.courseTlabel.AutoSize = true;
            this.courseTlabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.courseTlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.courseTlabel.Location = new System.Drawing.Point(305, 37);
            this.courseTlabel.Name = "courseTlabel";
            this.courseTlabel.Size = new System.Drawing.Size(71, 15);
            this.courseTlabel.TabIndex = 5;
            this.courseTlabel.Text = "课程类型";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(567, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "学期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.yearlabel);
            this.panel1.Controls.Add(this.termcomboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.yearcomboBox);
            this.panel1.Controls.Add(this.courseTlabel);
            this.panel1.Controls.Add(this.courseTcomboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 88);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(789, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(163, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "学分平均分";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(395, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "学分绩点";
            // 
            // averStextBox
            // 
            this.averStextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.averStextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.averStextBox.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.averStextBox.Location = new System.Drawing.Point(289, 497);
            this.averStextBox.Name = "averStextBox";
            this.averStextBox.Size = new System.Drawing.Size(87, 18);
            this.averStextBox.TabIndex = 10;
            // 
            // averPtextBox
            // 
            this.averPtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.averPtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.averPtextBox.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.averPtextBox.Location = new System.Drawing.Point(494, 497);
            this.averPtextBox.Name = "averPtextBox";
            this.averPtextBox.Size = new System.Drawing.Size(100, 18);
            this.averPtextBox.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(622, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "计算";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(741, 490);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 35);
            this.button3.TabIndex = 13;
            this.button3.Text = "导出成绩单";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "userid";
            this.useridDataGridViewTextBoxColumn.HeaderText = "userid";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            this.useridDataGridViewTextBoxColumn.Visible = false;
            // 
            // courseidDataGridViewTextBoxColumn
            // 
            this.courseidDataGridViewTextBoxColumn.DataPropertyName = "courseid";
            this.courseidDataGridViewTextBoxColumn.HeaderText = "courseid";
            this.courseidDataGridViewTextBoxColumn.Name = "courseidDataGridViewTextBoxColumn";
            this.courseidDataGridViewTextBoxColumn.Visible = false;
            // 
            // courseNameDataGridViewTextBoxColumn
            // 
            this.courseNameDataGridViewTextBoxColumn.DataPropertyName = "courseName";
            this.courseNameDataGridViewTextBoxColumn.HeaderText = "courseName";
            this.courseNameDataGridViewTextBoxColumn.Name = "courseNameDataGridViewTextBoxColumn";
            // 
            // score
            // 
            this.score.DataPropertyName = "score";
            this.score.HeaderText = "score";
            this.score.Name = "score";
            // 
            // credits
            // 
            this.credits.DataPropertyName = "credits";
            this.credits.HeaderText = "credits";
            this.credits.Name = "credits";
            // 
            // gradePointDataGridViewTextBoxColumn
            // 
            this.gradePointDataGridViewTextBoxColumn.DataPropertyName = "gradePoint";
            this.gradePointDataGridViewTextBoxColumn.HeaderText = "gradePoint";
            this.gradePointDataGridViewTextBoxColumn.Name = "gradePointDataGridViewTextBoxColumn";
            // 
            // courseTypeDataGridViewTextBoxColumn
            // 
            this.courseTypeDataGridViewTextBoxColumn.DataPropertyName = "courseType";
            this.courseTypeDataGridViewTextBoxColumn.HeaderText = "courseType";
            this.courseTypeDataGridViewTextBoxColumn.Name = "courseTypeDataGridViewTextBoxColumn";
            // 
            // teacherNameDataGridViewTextBoxColumn
            // 
            this.teacherNameDataGridViewTextBoxColumn.DataPropertyName = "teacherName";
            this.teacherNameDataGridViewTextBoxColumn.HeaderText = "teacherName";
            this.teacherNameDataGridViewTextBoxColumn.Name = "teacherNameDataGridViewTextBoxColumn";
            // 
            // schoolDataGridViewTextBoxColumn
            // 
            this.schoolDataGridViewTextBoxColumn.DataPropertyName = "school";
            this.schoolDataGridViewTextBoxColumn.HeaderText = "school";
            this.schoolDataGridViewTextBoxColumn.Name = "schoolDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // termDataGridViewCheckBoxColumn
            // 
            this.termDataGridViewCheckBoxColumn.DataPropertyName = "Term";
            this.termDataGridViewCheckBoxColumn.HeaderText = "Term";
            this.termDataGridViewCheckBoxColumn.Name = "termDataGridViewCheckBoxColumn";
            this.termDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // 计算
            // 
            this.计算.HeaderText = "计算";
            this.计算.Name = "计算";
            this.计算.ReadOnly = true;
            // 
            // GradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 537);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.averPtextBox);
            this.Controls.Add(this.averStextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "GradeForm";
            this.Text = "GradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseScoreBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox yearcomboBox;
        private System.Windows.Forms.ComboBox courseTcomboBox;
        private System.Windows.Forms.ComboBox termcomboBox;
        private System.Windows.Forms.Label yearlabel;
        private System.Windows.Forms.Label courseTlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox averStextBox;
        private System.Windows.Forms.TextBox averPtextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource courseScoreBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradePointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn termDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 计算;
    }
}