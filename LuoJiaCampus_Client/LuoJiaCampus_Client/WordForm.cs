using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENTINFO
{
    public partial class WordForm : Form
    {
        public WordForm(List<string> da,int t)
        {
            InitializeComponent();

            int x = 30;
            int y = 20;

            foreach (var item in da)
            {
                panel1.Controls.Add(Label(item, x, y, 500, 30));
                y += 30;
            }
            
        }

        private Label Label(string content, int x, int y, int sizeX, int sizeY)
        {
            Label label = new Label();
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Text = content;
            label.Location = new Point(x, y);
            label.Size = new Size(sizeX, sizeY);
            label.Font = new Font("微软雅黑", 12);
            label.ForeColor = Color.Black;
            label.AutoSize = false;
            label.Parent = this;
            return label;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
