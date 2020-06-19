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
    public partial class UserForm : Form
    {
        public long id { get; set; }               //学号
        public short grade { get; set; }           //年级
        public string name { get; set; }           //姓名
        public string school { get; set; }         //学院
        public String gender { get; set; }         //性别
        public string major { get; set; }          //专业
        public string avatar { get; set; }         //头像存放路径

        public UserForm()
        {
            InitializeComponent();
        }
        public UserForm(User user) : this()
        {
            this.name = user.nmae;
            this.id = user.id;
            this.grade = user.grade;
            this.school = user.school;
            this.major = user.major;
            this.gender = user.gender;
        }

        private void pictureButton_Click(object sender, EventArgs e)//使用openFileDialog控件查看并获取图片路径
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                avatar = openFileDialog1.FileName;
            }
            pictureBox.ImageLocation = avatar;//修改图片路径
        }

        private void UserForm_Load(object sender, EventArgs e)//数据绑定
        {
            nameLabel.DataBindings.Add("Text",this,"name");
            idLabel.DataBindings.Add("Text", this, "id");
            genderLabel.DataBindings.Add("Text", this, "gender");
            gradeLabel.DataBindings.Add("Text", this, "grade");
            schoolLabel.DataBindings.Add("Text", this, "school");
            majorLabel.DataBindings.Add("Text", this, "major");
        }

    }
}
