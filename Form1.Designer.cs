namespace MinecraftConnectTool
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.P2PMode = new AntdUI.Button();
            this.select = new AntdUI.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new AntdUI.Button();
            this.TopText = new System.Windows.Forms.RichTextBox();
            this.materialSingleLineTextField3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Divider1 = new AntdUI.Divider();
            this.divider2 = new AntdUI.Divider();
            this.button4 = new AntdUI.Button();
            this.button5 = new AntdUI.Button();
            this.button6 = new AntdUI.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button8 = new AntdUI.Button();
            this.label1 = new AntdUI.Label();
            this.alert1 = new AntdUI.Alert();
            this.SuspendLayout();
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(12, 409);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(603, 23);
            this.materialSingleLineTextField1.TabIndex = 0;
            this.materialSingleLineTextField1.Text = "请勿多开核心,避免出现意料之外的错误！点击右下角的关闭按钮即可关闭所有核心";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            this.materialSingleLineTextField1.Click += new System.EventHandler(this.materialSingleLineTextField1_Click);
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(22, 230);
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(172, 23);
            this.materialSingleLineTextField2.TabIndex = 1;
            this.materialSingleLineTextField2.Text = "输入提示码";
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            this.materialSingleLineTextField2.Click += new System.EventHandler(this.materialSingleLineTextField2_Click);
            // 
            // P2PMode
            // 
            this.P2PMode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.P2PMode.Location = new System.Drawing.Point(22, 85);
            this.P2PMode.Name = "P2PMode";
            this.P2PMode.Radius = 5;
            this.P2PMode.Shape = AntdUI.TShape.Round;
            this.P2PMode.Size = new System.Drawing.Size(172, 78);
            this.P2PMode.TabIndex = 2;
            this.P2PMode.Text = "开启联机房间";
            this.P2PMode.Click += new System.EventHandler(this.P2PMode_Click);
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(713, 409);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(56, 23);
            this.select.TabIndex = 3;
            this.select.Text = "Test";
            this.select.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(222, 97);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(547, 306);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(22, 314);
            this.button1.Name = "button1";
            this.button1.Radius = 5;
            this.button1.Shape = AntdUI.TShape.Round;
            this.button1.Size = new System.Drawing.Size(172, 77);
            this.button1.TabIndex = 6;
            this.button1.Text = "加入联机房间";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TopText
            // 
            this.TopText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TopText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TopText.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.TopText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TopText.Location = new System.Drawing.Point(203, 1);
            this.TopText.Multiline = false;
            this.TopText.Name = "TopText";
            this.TopText.ReadOnly = true;
            this.TopText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TopText.Size = new System.Drawing.Size(320, 32);
            this.TopText.TabIndex = 7;
            this.TopText.Text = "选择一种方式进行联机ヾ(≧▽≦*)o";
            this.TopText.TextChanged += new System.EventHandler(this.TopText_TextChanged);
            // 
            // materialSingleLineTextField3
            // 
            this.materialSingleLineTextField3.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.materialSingleLineTextField3.Depth = 0;
            this.materialSingleLineTextField3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialSingleLineTextField3.Hint = "";
            this.materialSingleLineTextField3.Location = new System.Drawing.Point(22, 282);
            this.materialSingleLineTextField3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField3.Name = "materialSingleLineTextField3";
            this.materialSingleLineTextField3.PasswordChar = '\0';
            this.materialSingleLineTextField3.SelectedText = "";
            this.materialSingleLineTextField3.SelectionLength = 0;
            this.materialSingleLineTextField3.SelectionStart = 0;
            this.materialSingleLineTextField3.Size = new System.Drawing.Size(172, 23);
            this.materialSingleLineTextField3.TabIndex = 8;
            this.materialSingleLineTextField3.Text = "输入目标端口";
            this.materialSingleLineTextField3.UseSystemPasswordChar = false;
            this.materialSingleLineTextField3.Click += new System.EventHandler(this.materialSingleLineTextField3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(621, 412);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "使用旧版方式";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "√";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "√";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Divider1
            // 
            this.Divider1.Location = new System.Drawing.Point(-2, 188);
            this.Divider1.Name = "Divider1";
            this.Divider1.Size = new System.Drawing.Size(218, 23);
            this.Divider1.TabIndex = 12;
            this.Divider1.Text = "加入联机房间";
            // 
            // divider2
            // 
            this.divider2.Location = new System.Drawing.Point(-2, 56);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(218, 23);
            this.divider2.TabIndex = 13;
            this.divider2.Text = "开启联机房间";
            this.divider2.Click += new System.EventHandler(this.divider2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(685, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 44);
            this.button4.TabIndex = 14;
            this.button4.Text = "检查更新";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(213)))), ((int)(((byte)(229)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(637, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 44);
            this.button5.TabIndex = 15;
            this.button5.Text = "设置";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(213)))), ((int)(((byte)(229)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(581, 51);
            this.button6.Name = "button6";
            this.button6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button6.Size = new System.Drawing.Size(98, 44);
            this.button6.TabIndex = 16;
            this.button6.Text = "安装字体";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(203, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(320, 10);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.Location = new System.Drawing.Point(685, 51);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 44);
            this.button8.TabIndex = 19;
            this.button8.Text = "下载核心";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-1, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "LTS";
            // 
            // alert1
            // 
            this.alert1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alert1.Icon = AntdUI.TType.Warn;
            this.alert1.Location = new System.Drawing.Point(222, 55);
            this.alert1.Name = "alert1";
            this.alert1.Size = new System.Drawing.Size(353, 35);
            this.alert1.TabIndex = 21;
            this.alert1.Text = "0.0.5生命周期即将结束,请升级至0.0.6";
            this.alert1.Click += new System.EventHandler(this.alert1_Click_2);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(781, 434);
            this.Controls.Add(this.alert1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.divider2);
            this.Controls.Add(this.Divider1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.materialSingleLineTextField3);
            this.Controls.Add(this.TopText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.select);
            this.Controls.Add(this.P2PMode);
            this.Controls.Add(this.materialSingleLineTextField2);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCZLF Connect Tool 0.0.5.XXX (版本获取失败)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private AntdUI.Button P2PMode;
        private AntdUI.Button select;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private AntdUI.Button button1;
        private System.Windows.Forms.RichTextBox TopText;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private AntdUI.Divider Divider1;
        private AntdUI.Divider divider2;
        private AntdUI.Button button4;
        private AntdUI.Button button5;
        private AntdUI.Button button6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private AntdUI.Button button8;
        private AntdUI.Label label1;
        private AntdUI.Alert alert1;
    }
}

