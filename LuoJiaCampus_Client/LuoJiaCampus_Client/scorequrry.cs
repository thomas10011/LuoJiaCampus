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
    public partial class scorequrry : Form
    {
        List<string> xData = new List<string>() { ">90", "80-90", "70-80", "60-70", "<60" };

        List<int> yData = new List<int>() { 0, 0, 0, 0, 0 };
        public scorequrry(CourseScore list1)
        {
            InitializeComponent();
            chart_paint(list1);
            this.SizeChanged += new Resize(this).Form1_Resize;
            this.textBox2.Text = list1.courseName;
            this.textBox3.Text = list1.teacherName;
            this.textBox4.Text = list1.courseType;
            this.textBox1.Text = list1.score.ToString();
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧 

            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。 

            chart1.Series[0].Points.DataBindXY(xData, yData);

        }
        public void chart_paint(CourseScore a)
        {
                if (a.score > 90) yData[0] += 1;
                else if (a.score > 80) yData[1] += 1;
                else if (a.score > 70) yData[2] += 1;
                else if (a.score > 60) yData[3] += 1;
                else yData[0] += 1;

        }


    }
}


