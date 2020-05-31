namespace STUDENTINFO
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.toolButton = new FontAwesome.Sharp.IconButton();
            this.wordButton = new FontAwesome.Sharp.IconButton();
            this.courceButton = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.collegebox = new System.Windows.Forms.TextBox();
            this.numberbox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.childformdesk = new System.Windows.Forms.Panel();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.toolButton);
            this.MenuPanel.Controls.Add(this.wordButton);
            this.MenuPanel.Controls.Add(this.courceButton);
            this.MenuPanel.Controls.Add(this.panel4);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 39);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(201, 598);
            this.MenuPanel.TabIndex = 1;
            // 
            // toolButton
            // 
            this.toolButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolButton.FlatAppearance.BorderSize = 0;
            this.toolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.toolButton.Font = new System.Drawing.Font("方正字迹-吕建德字体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolButton.ForeColor = System.Drawing.Color.White;
            this.toolButton.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.toolButton.IconColor = System.Drawing.Color.White;
            this.toolButton.IconSize = 26;
            this.toolButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolButton.Location = new System.Drawing.Point(0, 483);
            this.toolButton.Name = "toolButton";
            this.toolButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.toolButton.Rotation = 0D;
            this.toolButton.Size = new System.Drawing.Size(201, 90);
            this.toolButton.TabIndex = 3;
            this.toolButton.Text = "工具箱";
            this.toolButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolButton.UseVisualStyleBackColor = true;
            this.toolButton.Click += new System.EventHandler(this.toolButton_Click);
            // 
            // wordButton
            // 
            this.wordButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.wordButton.FlatAppearance.BorderSize = 0;
            this.wordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wordButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.wordButton.Font = new System.Drawing.Font("方正字迹-吕建德字体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordButton.ForeColor = System.Drawing.Color.White;
            this.wordButton.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.wordButton.IconColor = System.Drawing.Color.White;
            this.wordButton.IconSize = 26;
            this.wordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wordButton.Location = new System.Drawing.Point(0, 393);
            this.wordButton.Name = "wordButton";
            this.wordButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.wordButton.Rotation = 0D;
            this.wordButton.Size = new System.Drawing.Size(201, 90);
            this.wordButton.TabIndex = 2;
            this.wordButton.Text = "新鲜事";
            this.wordButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.wordButton.UseVisualStyleBackColor = true;
            this.wordButton.Click += new System.EventHandler(this.wordButton_Click);
            // 
            // courceButton
            // 
            this.courceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.courceButton.FlatAppearance.BorderSize = 0;
            this.courceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courceButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.courceButton.Font = new System.Drawing.Font("方正字迹-吕建德字体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.courceButton.ForeColor = System.Drawing.Color.White;
            this.courceButton.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.courceButton.IconColor = System.Drawing.Color.White;
            this.courceButton.IconSize = 26;
            this.courceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courceButton.Location = new System.Drawing.Point(0, 303);
            this.courceButton.Name = "courceButton";
            this.courceButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.courceButton.Rotation = 0D;
            this.courceButton.Size = new System.Drawing.Size(201, 90);
            this.courceButton.TabIndex = 1;
            this.courceButton.Text = "课程表";
            this.courceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.courceButton.UseVisualStyleBackColor = true;
            this.courceButton.Click += new System.EventHandler(this.courceButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.collegebox);
            this.panel4.Controls.Add(this.numberbox);
            this.panel4.Controls.Add(this.namebox);
            this.panel4.Controls.Add(this.picture);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 303);
            this.panel4.TabIndex = 0;
            // 
            // collegebox
            // 
            this.collegebox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.collegebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.collegebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.collegebox.Font = new System.Drawing.Font("中山行书百年纪念版", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.collegebox.ForeColor = System.Drawing.Color.White;
            this.collegebox.Location = new System.Drawing.Point(3, 236);
            this.collegebox.Name = "collegebox";
            this.collegebox.ReadOnly = true;
            this.collegebox.Size = new System.Drawing.Size(201, 24);
            this.collegebox.TabIndex = 4;
            this.collegebox.Text = "计算机学院";
            this.collegebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numberbox
            // 
            this.numberbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numberbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.numberbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberbox.Font = new System.Drawing.Font("方正硬笔行书简体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numberbox.ForeColor = System.Drawing.Color.White;
            this.numberbox.Location = new System.Drawing.Point(3, 200);
            this.numberbox.Name = "numberbox";
            this.numberbox.ReadOnly = true;
            this.numberbox.Size = new System.Drawing.Size(201, 21);
            this.numberbox.TabIndex = 3;
            this.numberbox.Text = "2018302110253";
            this.numberbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // namebox
            // 
            this.namebox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.namebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.namebox.Font = new System.Drawing.Font("中山行书百年纪念版", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.namebox.ForeColor = System.Drawing.Color.White;
            this.namebox.Location = new System.Drawing.Point(0, 170);
            this.namebox.Name = "namebox";
            this.namebox.ReadOnly = true;
            this.namebox.Size = new System.Drawing.Size(201, 24);
            this.namebox.TabIndex = 6;
            this.namebox.Text = "蒋海澜";
            this.namebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picture
            // 
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.Location = new System.Drawing.Point(0, 26);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(201, 125);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1009, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 598);
            this.panel2.TabIndex = 3;
            // 
            // childformdesk
            // 
            this.childformdesk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.childformdesk.BackColor = System.Drawing.Color.White;
            this.childformdesk.Location = new System.Drawing.Point(201, 39);
            this.childformdesk.Name = "childformdesk";
            this.childformdesk.Size = new System.Drawing.Size(808, 573);
            this.childformdesk.TabIndex = 4;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.CloseButton.IconColor = System.Drawing.Color.White;
            this.CloseButton.IconSize = 30;
            this.CloseButton.Location = new System.Drawing.Point(993, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Rotation = 0D;
            this.CloseButton.Size = new System.Drawing.Size(29, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("中山行书百年纪念版", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "珞珈校园";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 39);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1034, 637);
            this.Controls.Add(this.childformdesk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainFrm";
            this.Text = "Form2";
            this.MenuPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MenuPanel;
        private FontAwesome.Sharp.IconButton toolButton;
        private FontAwesome.Sharp.IconButton wordButton;
        private FontAwesome.Sharp.IconButton courceButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel childformdesk;
        private FontAwesome.Sharp.IconButton CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TextBox collegebox;
        private System.Windows.Forms.TextBox numberbox;
        private System.Windows.Forms.TextBox namebox;
    }
}