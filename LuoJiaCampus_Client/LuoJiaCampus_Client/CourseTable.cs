using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using compusDBManage;

namespace STUDENTINFO
{
    public partial class CourseTable : Form
    {
        public long ID { set; get; }
        public Form form = new Form();
        DataTable dt = new DataTable();
        public static Color color1 = Color.FromArgb(239, 133, 123);
        public static Color color2 = Color.FromArgb(247, 218, 130);
        public static Color color3 = Color.FromArgb(205, 187, 228);
        public CourseTable()
        {
            InitializeComponent();
        }
        public CourseTable(long id) : this()
        {
            ID = id;
            dtinitial();
            dtweek(10);
            this.dataGridView1.DataSource = dt;

        }
        private void dtinitial()
        {
            dt.Columns.Add("节次", typeof(string));
            dt.Columns.Add("一", typeof(string));
            dt.Columns.Add("二", typeof(string));
            dt.Columns.Add("三", typeof(string));
            dt.Columns.Add("四", typeof(string));
            dt.Columns.Add("五", typeof(string));
            dt.Columns.Add("六", typeof(string));
            dt.Columns.Add("日", typeof(string));

            for (int i = 0; i < 13; i++)
            {
                DataRow dr = dt.NewRow();

                dt.Rows.Add(dr);
            }

            dt.Rows[0][0] = "1";
            dt.Rows[1][0] = "2";
            dt.Rows[2][0] = "3";
            dt.Rows[3][0] = "4";
            dt.Rows[4][0] = "5";
            dt.Rows[5][0] = "6";
            dt.Rows[6][0] = "7";
            dt.Rows[7][0] = "8";
            dt.Rows[8][0] = "9";
            dt.Rows[9][0] = "10";
            dt.Rows[10][0] = "11";
            dt.Rows[11][0] = "12";
            dt.Rows[12][0] = "13";
        }
        private void dtweek(int WEEK)
        {
            Course course1 = new Course();
            List<Course> hhh = course1.queryAll(ID);
            foreach (Course course in hhh)
            {

                int weekday = 1;//星期
                int num;//开始节数
                int end;
                int weeknum1;
                int weeknum2;
                string weektype;
                string place;
                string pattern1 = @"(?<day>(Mon|Tue|Wed|Thu|Fir|Sat|Sun)):(?<weeknum1>(\d+))-(?<weeknum2>(\d+))周,(?<weektype>.?.?.?);(?<num>(\d+))-(?<end>(\d+))节(,?)(?<place>(.?.?.?.?.?.?.?.?))";
                Regex rx = new Regex(pattern1);
                Match x = rx.Match(course.courseTime);
                MatchCollection mc = rx.Matches(course.courseTime);
                foreach (Match m in mc)
                {
                    switch (m.Groups["day"].Value)

                    {

                        case "Mon": weekday = 1; break;

                        case "Tue": weekday = 2; break;

                        case "Wed": weekday = 3; break;

                        case "Thu": weekday = 4; break;

                        case "Fir": weekday = 5; break;

                        case "Sat": weekday = 6; break;

                        case "Sun": weekday = 7; break;

                        default: break;
                    }

                    weeknum1 = Int32.Parse(m.Groups["weeknum1"].Value);

                    weeknum2 = Int32.Parse(m.Groups["weeknum2"].Value);

                    weektype = m.Groups["weektype"].Value;

                    num = Int32.Parse(m.Groups["num"].Value);

                    end = Int32.Parse(m.Groups["end"].Value);

                    place = m.Groups["place"].Value;
                    if (WEEK <= weeknum2 && WEEK >= weeknum1)
                    {
                        if ((weektype == "每1周") || (weektype == "单周" && WEEK % 2 == 1) || (weektype == "双周" && WEEK % 2 == 0))
                        {
                            for (int i = num - 1; i < end; i++)
                            {
                                string sum = course.courseName + "\n" + course.teacherName + "\n" + place;
                                dt.Rows[i][weekday] = sum;
                            }
                        }
                    }

                }

            }
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

        private void btnList_Click(object sender, EventArgs e)
        {
            Openchildform(new CourseList(ID));
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // 对第1列相同单元格进行合并
            if ((e.ColumnIndex == 1|| e.ColumnIndex == 2 || e.ColumnIndex == 3 ||
                e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 ||
                e.ColumnIndex == 4 )&& e.RowIndex != -1&& e.RowIndex <= 12)
            {
                using
                    (
                    Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                    )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 清除单元格
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        // 画 Grid 边线（仅画单元格的底边线和右边线）
                        //   如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                        if ( e.Value.ToString() == DBNull.Value.ToString() ||(e.RowIndex < dataGridView1.Rows.Count - 2&&
                        dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString()))
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);
                        
                        // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                        if (e.Value != DBNull.Value)
                        {
                            int a = (e.RowIndex + e.ColumnIndex) % 3;
                            if (a == 0) e.Graphics.FillRectangle(new SolidBrush(color1), e.CellBounds);
                            else if (a == 1) e.Graphics.FillRectangle(new SolidBrush(color2), e.CellBounds);
                            else e.Graphics.FillRectangle(new SolidBrush(color3), e.CellBounds);
                            if (e.RowIndex > 0 && dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString())
                            {
                                    a = (a - 1) % 3;
                                    if (e.RowIndex - 1 > 0 && dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == dataGridView1.Rows[e.RowIndex - 2].Cells[e.ColumnIndex].Value.ToString())
                                    {
                                        a = (a - 1) % 3;
                                        if (e.RowIndex - 2 > 0 && dataGridView1.Rows[e.RowIndex - 2].Cells[e.ColumnIndex].Value.ToString() == dataGridView1.Rows[e.RowIndex - 3].Cells[e.ColumnIndex].Value.ToString())
                                        {
                                            a = (a - 1) % 3;
                                            if (e.RowIndex - 3 > 0 && dataGridView1.Rows[e.RowIndex - 3].Cells[e.ColumnIndex].Value.ToString() == dataGridView1.Rows[e.RowIndex - 4].Cells[e.ColumnIndex].Value.ToString())
                                            {
                                                a = (a - 1) % 3;
                                                if (e.RowIndex - 4 > 0 && dataGridView1.Rows[e.RowIndex - 4].Cells[e.ColumnIndex].Value.ToString() == dataGridView1.Rows[e.RowIndex - 5].Cells[e.ColumnIndex].Value.ToString())
                                                {
                                                    a = (a - 1) % 3;
                                                }
                                            }
                                        }
                                    }
                                while (a < 0) a += 3;
                                if (a == 0) e.Graphics.FillRectangle(new SolidBrush(color1), e.CellBounds);
                                else if (a == 1) e.Graphics.FillRectangle(new SolidBrush(color2), e.CellBounds);
                                else e.Graphics.FillRectangle(new SolidBrush(color3), e.CellBounds);
                            }

                            else
                            {
                                if (e.Value == DBNull.Value)
                                {}
                                else
                                {
                                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                      Brushes.Black, e.CellBounds.X + 2,
                                      e.CellBounds.Y + 5, StringFormat.GenericTypographic);
                                }
                                
                            }
                        }
                        e.Handled = true;
                    }
                }

            }
        }
        private void ExportExcels(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount - 2; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fileName = "课表";
            ExportExcels(fileName, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dtinitial();
            dtweek(Int32.Parse(comboBox1.Text));
            this.dataGridView1.DataSource = dt;
        }
    }
}
