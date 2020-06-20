using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using compusDBManage;

namespace STUDENTINFO
{
    public partial class CourseList : Form
    {
        public long ID { set; get; }
        public Form form = new Form();
        public Course a = new Course();
        public CourseList()
        {
            InitializeComponent();
        }
        public CourseList(long id):this()
        {
            ID = id;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(202, 217, 244);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(253, 138, 114);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("造字工房悦圆演示版常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 72, 157);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("造字工房悦圆演示版常规体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridView1.ScrollBars = ScrollBars.None;


            //databandings数据绑定
            dataGridView1.DataSource = a.queryAll(id);
            label3.Text = dataGridView1.Rows.Count.ToString();
        }
        private void Openchildform(Form childform)
        {
            if (form != null)
            {
                form.Close();
            }
            form = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            Controls.Clear();
            Controls.Add(childform);
            Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            Openchildform(new CourseTable(ID));
        }
    }
}
