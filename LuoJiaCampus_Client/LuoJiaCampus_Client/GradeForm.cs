using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gradeclass;

namespace STUDENTINFO
{
    public partial class GradeForm : Form
    {
        public string Year { get; set; }
        public string Type { get; set; }
        public string Term { get; set; }
        public GradeService gradeService = new GradeService();
        double countcredit = 0;
        double creditscore = 0;
        double creditpoint = 0;
        public string averageScore { get; set; }
        public string averagePoint { get; set; }
        public GradeForm()
        {
            InitializeComponent();
            yearcomboBox.SelectedIndex = 0;
            courseTcomboBox.SelectedIndex = 0;
            termcomboBox.SelectedIndex = 0;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(202, 217, 244);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(253, 138, 114);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 72, 157);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("造字工房悦圆演示版常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //databandings数据绑定
            dataGridView1.DataSource = gradeService.scores;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["计算"].Value = 0;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            gradeService.findcourcescore(yearcomboBox.Text, courseTcomboBox.Text, termcomboBox.Text);
            dataGridView1.DataSource = gradeService.scores;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            averageScore = (creditscore / countcredit).ToString();
            averagePoint = (creditpoint / countcredit).ToString();

            averStextBox.Text = averageScore;
            averPtextBox.Text = averagePoint;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["计算"].Value = 0;
            }
            creditscore = 0;
            creditpoint = 0;
            countcredit = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "计算" && e.RowIndex >= 0)
            {
                //获取DataGridView中CheckBox的Cell
                DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["计算"]);
                double score = 0;
                double credit = 0;
                double point = 0;
                //根据单击时，Cell的值进行处理。EditedFormattedValue和Value均可以
                //若单击时，CheckBox没有被勾上
                if (Convert.ToBoolean(dgvCheck.EditedFormattedValue) == false)
                {
                    dgvCheck.Value = true;
                    String numeber1 = dataGridView1.CurrentRow.Cells["成绩"].Value.ToString();
                    String numeber2 = dataGridView1.CurrentRow.Cells["学分"].Value.ToString();
                    score = double.Parse(numeber1);
                    if (score > 89) point = 4.0;
                    else if (score > 84) point = 3.7;
                    else if (score > 81) point = 3.3;
                    else if (score > 77) point = 3.0;
                    else if (score > 74) point = 2.7;
                    else if (score > 71) point = 2.3;
                    else if (score > 67) point = 2.0;
                    else if (score > 63) point = 1.5;
                    else if (score > 59) point = 1.0;
                    else point = 0;
                    credit = double.Parse(numeber2);
                    creditscore += score * credit;
                    creditpoint += point * credit;
                    countcredit += credit;
                }
                //若单击时，CheckBox已经被勾上
                else
                {
                    dgvCheck.Value = false;
                    String numeber1 = dataGridView1.CurrentRow.Cells["成绩"].Value.ToString();
                    String numeber2 = dataGridView1.CurrentRow.Cells["学分"].Value.ToString();
                    score = double.Parse(numeber1);
                    if (score > 89) point = 4.0;
                    else if (score > 84) point = 3.7;
                    else if (score > 81) point = 3.3;
                    else if (score > 77) point = 3.0;
                    else if (score > 74) point = 2.7;
                    else if (score > 71) point = 2.3;
                    else if (score > 67) point = 2.0;
                    else if (score > 63) point = 1.5;
                    else if (score > 59) point = 1.0;
                    else point = 0;
                    credit = double.Parse(numeber2);
                    creditscore -= score * credit;
                    creditpoint -= point * credit;
                    countcredit -= credit;
                }
            }
        }
    }
}
