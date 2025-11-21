namespace MinecraftConnectTool
{
    partial class Form2
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
            this.button1 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.switch1 = new AntdUI.Switch();
            this.button3 = new AntdUI.Button();
            this.divider1 = new AntdUI.Divider();
            this.button4 = new AntdUI.Button();
            this.alert1 = new AntdUI.Alert();
            this.button6 = new AntdUI.Button();
            this.button5 = new AntdUI.Button();
            this.task = new AntdUI.Alert();
            this.button8 = new AntdUI.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.button1.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Shape = AntdUI.TShape.Round;
            this.button1.Size = new System.Drawing.Size(110, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "清除缓存";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(197)))));
            this.button2.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("山海圆体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(-1, 341);
            this.button2.Name = "button2";
            this.button2.Radius = 0;
            this.button2.Size = new System.Drawing.Size(493, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "More >";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.richTextBox1.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(61, 309);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(189, 26);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "将Settings展示在任务栏中";
            // 
            // switch1
            // 
            this.switch1.Location = new System.Drawing.Point(-1, 303);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(56, 32);
            this.switch1.TabIndex = 3;
            this.switch1.Text = "switch1";
            this.switch1.UnCheckedText = "";
            this.switch1.CheckedChanged += new AntdUI.BoolEventHandler(this.switch1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.button3.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(247, 306);
            this.button3.Name = "button3";
            this.button3.Shape = AntdUI.TShape.Round;
            this.button3.Size = new System.Drawing.Size(171, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "生成1G缓存(测试用的)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // divider1
            // 
            this.divider1.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.divider1.Location = new System.Drawing.Point(-1, 280);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(486, 23);
            this.divider1.TabIndex = 6;
            this.divider1.Text = "实验性测试用功能";
            // 
            // button4
            // 
            this.button4.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.button4.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(424, 306);
            this.button4.Name = "button4";
            this.button4.Shape = AntdUI.TShape.Round;
            this.button4.Size = new System.Drawing.Size(48, 29);
            this.button4.TabIndex = 7;
            this.button4.Text = "大小";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // alert1
            // 
            this.alert1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alert1.Font = new System.Drawing.Font("山海圆体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alert1.Icon = AntdUI.TType.Info;
            this.alert1.Location = new System.Drawing.Point(139, 12);
            this.alert1.Name = "alert1";
            this.alert1.Radius = 20;
            this.alert1.Size = new System.Drawing.Size(333, 82);
            this.alert1.TabIndex = 9;
            this.alert1.Text = "ヾ(^▽^*)))点击此处查看奇怪的回声";
            this.alert1.Click += new System.EventHandler(this.alert1_Click);
            // 
            // button6
            // 
            this.button6.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.button6.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(12, 55);
            this.button6.Name = "button6";
            this.button6.Shape = AntdUI.TShape.Round;
            this.button6.Size = new System.Drawing.Size(110, 39);
            this.button6.TabIndex = 10;
            this.button6.Text = "回声次数";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.button5.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(12, 100);
            this.button5.Name = "button5";
            this.button5.Shape = AntdUI.TShape.Round;
            this.button5.Size = new System.Drawing.Size(110, 39);
            this.button5.TabIndex = 11;
            this.button5.Text = "优化网络";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // task
            // 
            this.task.BorderWidth = 1F;
            this.task.Cursor = System.Windows.Forms.Cursors.Hand;
            this.task.Font = new System.Drawing.Font("山海圆体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.task.Icon = AntdUI.TType.Info;
            this.task.Location = new System.Drawing.Point(-1, 371);
            this.task.Name = "task";
            this.task.Radius = 1;
            this.task.Size = new System.Drawing.Size(486, 41);
            this.task.TabIndex = 10;
            this.task.Text = "任务列表(当前页面正在进行的任务会显示在这里)";
            // 
            // button8
            // 
            this.button8.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.button8.BadgeAlign = AntdUI.TAlignFrom.Bottom;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Font = new System.Drawing.Font("山海圆体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.Location = new System.Drawing.Point(362, 100);
            this.button8.Name = "button8";
            this.button8.Shape = AntdUI.TShape.Round;
            this.button8.Size = new System.Drawing.Size(110, 39);
            this.button8.TabIndex = 13;
            this.button8.Text = "日志上传";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 414);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.task);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.alert1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.switch1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Settings_MCZLF";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Button button1;
        private AntdUI.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private AntdUI.Switch switch1;
        private AntdUI.Button button3;
        private AntdUI.Divider divider1;
        private AntdUI.Button button4;
        private AntdUI.Alert alert1;
        private AntdUI.Button button6;
        private AntdUI.Button button5;
        private AntdUI.Alert task;
        private AntdUI.Button button8;
    }
}