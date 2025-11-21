using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;



namespace MinecraftConnectTool
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        //修改updateverison
        public static readonly string version = "0.0.5.200";//测试提交
        private void Form1_Load(object sender, EventArgs e)
        {
            Probe.EnablePopup = false;
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "MCZLFAPP", "Temp", "Probe")))
                _ = Probe.SendAsync();
            log("0.0.5即将停止支持，0.0.6现已支持Windows7用户，建议更新至0.0.6\n停止支持后，仅接收必要的安全更新");
            progressBar1.Visible = false;
            bool isFontInstalled = IsFontInstalled("山海圆体");
            if (isFontInstalled)
            {
                button6.Hide(); 
            }
            if (Process.GetProcessesByName("main").Length > 0)
            {
                ShowCloseButton();
            }
            string userName = Environment.UserName;
            string greeting = GetGreetingMessage(userName);
            AntdUI.Message.open(new AntdUI.Message.Config(this, (greeting), AntdUI.TType.Info)
            {
                AutoClose = 3,
                ClickClose = true,
                Align = TAlignFrom.Bottom,
                Radius = 25
            });
            if (IsWindows7OrLower())
            {
                //button7.Enabled = false;
            }


            //alert
            string gonggao = $"感谢您使用Minecraft Connect Tool\n群聊 690625244       《欢迎加入ヾ(≧▽≦*)o\n仅供Minecraft联机及其他合法用途拓展使用,违法使用作者不负任何责任\n============================================================================================================\n当前版本为Minecraft Connect Tool {version}";
            log(gonggao);
            this.Text = $"Minecraft Connect Tool {version}";
            //检查系统版本
            bool ifwin7 = IsWindows7OrLower();
            //messageconfig
            AntdUI.Config.ShowInWindowByMessage = true;
            //syscheck
            if (ifwin7)
            {
            log("警告:当前系统版本为Windows7或更低版本,已停止支持，在当前系统版本下可能无法使用Tools某些功能，且可能出现意外崩溃，请勿报告为bug");
            AntdUI.Notification.error((Form)this, "增强提醒*", $"当前系统版本不受支持,建议您升级至Windows10", align: AntdUI.TAlignFrom.BR,autoClose: 0);
            }
            else
            {
            log("systemok");
            }
            //AntdUI.Config.ShowInWindow = true;
            //AntdUI.Config.NoticeWindowOffsetXY = 5;
            log("温馨提示:如果不点击右下角关闭按钮，核心会继续在后台运行~");
            AntdUI.Notification.info((Form)this, "info", "欢迎使用新版Minecraft Connect Tool~", align: AntdUI.TAlignFrom.BR);
            AntdUI.Notification.success((Form)this, "info", "成功的加载了ToastNotification3", align: AntdUI.TAlignFrom.BR);
            CloudAlert().ConfigureAwait(false);
        }
        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }
        private FormFloatButton floatButtonOpen;
        private FormFloatButton floatButtonJoin;
        //OPEN
        private async void P2PMode_Click(object sender, EventArgs e)
        {
            log("检查P2PMode核心中..");
            {
                string localName = Environment.MachineName;
                Random random = new Random();
                int randomPort = random.Next(1, 65536);
                string tempDirectory = Path.GetTempPath();
                string customDirectory = Path.Combine(tempDirectory, "MCZLFAPP", "Temp");
                Directory.CreateDirectory(customDirectory);
                Directory.SetCurrentDirectory(customDirectory);
                //清理运行垃圾
                if (File.Exists("config.json")) File.Delete("config.json");
                if (File.Exists("config.json0")) File.Delete("config.json0");
                //增强提醒
                string tsm = $"{localName}{randomPort}";
                if (tsm.Length <= 8)
                {
                    int threeDigitRandom = random.Next(100, 1000);
                    tsm += threeDigitRandom.ToString(); // 将三位数随机数追加到tsm后面
                    log("提示码不满足要求,已自动加入三位随机数字");
                }
                MessageBox.Show($"您的提示码为{tsm}\n已复制入剪切板中,快去粘贴给小伙伴吧", "增强提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AntdUI.Notification.info(Program.MainForm, "增强提醒", $"您的提示码为{tsm}\n已复制入剪切板中,快去粘贴给小伙伴吧", align: AntdUI.TAlignFrom.BR);
                string url;
                if (Environment.Is64BitOperatingSystem)
                {
                    url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/main.exe";
                    // url = "https://mczlf.loft.games/ConnectTool/main.exe";
                }
                else
                {
                    //    url = "https://mczlf.loft.games/ConnectTool/main32.exe";
                    url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/main32.exe";
                }
                //string url = "https://mczlf.loft.games/ConnectTool/main.exe";
                string fileName = "main.exe";
                string fileMd5 = "886c8ef10288d546fe254b531870318d";
                string fileMd532 = "e8f1007a43eb520eecf9c0fade0300b0";
                bool needsDownload = false;

                if (File.Exists(fileName))
                {
                    string md5Hash = GetFileMD5Hash(fileName);
                    if (md5Hash == fileMd5)
                    {
                        log("64位核心已存在且安全校验通过");
                    }
                    else
                    {
                        if (md5Hash == fileMd532)
                        {
                            log("32位核心已存在且安全校验通过");
                            needsDownload = false;
                        }
                        else
                        {
                            if (md5Hash == null)
                            {
                                log("出现错误，进程终止");
                                return;
                            }
                            else
                            {
                                log("核心不存在或安全校验不通过,重新Download中");
                                needsDownload = true;
                            }
                        }
                    }
                }
                else
                {
                    log("核心不存在或安全校验不通过,重新Download中");
                    needsDownload = true;
                }
                //Download
                if (needsDownload)
                {
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    // 下载
                    log("Downloader启动");
                    using (var unityClient = new HttpClient())
                    using (var response = await unityClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        long totalBytes = response.Content.Headers.ContentLength ?? 0;
                        long downloadedBytes = 0;

                        using (var httpStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Write, bufferSize: 8192, useAsync: true))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await httpStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                downloadedBytes += bytesRead;

                                if (totalBytes > 0)
                                {
                                    int progress = (int)((downloadedBytes * 100) / totalBytes);
                                    progressBar1.Value = progress;
                                }
                            }
                        }
                    }
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    log("Task:下载核心中..");
                }
                //清除状态
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                log("复制邀请信息中..");
                Clipboard.SetText($"邀请你加入我的Minecraft联机房间！提示码为 {tsm}");
                log($"您的提示码为 {tsm}");
                // 构造启动参数
                string arguments = $"-node {tsm} -token 17073157824633806511";
                if (checkBox1.Checked)
                {
                    // 如果勾选了 checkbox1，则显示原版启动窗口
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        UseShellExecute = true
                    });
                }
                else
                {
                Process process = new Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false; // 关闭外壳程序以支持重定向
                process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
                process.StartInfo.RedirectStandardError = true; // 重定向错误输出
                process.StartInfo.CreateNoWindow = true; // 不显示窗口

                // 捕获输出并写入 RichTextBox
                process.OutputDataReceived += (processSender, outputEventArgs) =>
                {
                    if (!string.IsNullOrEmpty(outputEventArgs.Data))
                    {
                        log(outputEventArgs.Data); // 将输出内容记录到 RichTextBox
                    }
                };

                process.ErrorDataReceived += (processSender, errorEventArgs) =>
                {
                    if (!string.IsNullOrEmpty(errorEventArgs.Data))
                    {
                        log(errorEventArgs.Data); // 将错误内容记录到 RichTextBox
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                AntdUI.Message.info(this, "已尝试启动进程,日志内容将输出至右侧哦", autoClose: 5);
                log("已尝试启动进程~");
                P2PMode.Badge = "运行中";
                floatButtonOpen = FloatButton.open(new FloatButton.Config(this, new FloatButton.ConfigBtn[]
                {
            new FloatButton.ConfigBtn("CloseButton", MinecraftConnectTool.Properties.Resources.close) // 使用资源图片
            {
                Text = "关闭", // 按钮文本（可选）
                Tooltip = "关闭P2P核心-all", // 悬浮提示
                Round = true, // 圆角样式
                Type = TTypeMini.Primary, // 按钮类型
                Radius = 6, // 圆角大小
                Badge = null, // 不显示徽标
                Enabled = true, // 是否启用
                Loading = false // 不显示加载动画
            }
                }, (button) => // 点击回调
                {
                    stopp2p();
                })
                {
                    Align = TAlign.BR, // 对齐方式：右下角
                    Vertical = true, // 垂直方向
                    TopMost = false, // 置顶
                    MarginX = 24, // X轴偏移
                    MarginY = 24, // Y轴偏移//96的话刚好在上面
                    Gap = 10 // 按钮间距
                });}
            }
        }


        //Test菜单
        private void button2_Click(object sender, EventArgs e)
        {
            AntdUI.Drawer.open(new AntdUI.Drawer.Config(this, new status() { Size = new Size(750, 229) })
            {
                Align = TAlignMini.Bottom, // 设置抽屉在右侧打开
                Mask = true,              // 是否显示遮罩层
                MaskClosable = true,      // 是否可以通过点击遮罩层关闭抽屉
                DisplayDelay = 0          // 延迟显示时间（毫秒）
            });
            return;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        // Log区域
        // Log调用方法 log("日志内容");
        private void log(string message)
        {
            var replacements = new Dictionary<string, string>
    {
        { "17073157824633806511", "MinecraftConnectTool" },
        { "旧词2", "新词2" },
        { "旧词3", "新词3" }
    };
            foreach (var pair in replacements)
            {
                message = Regex.Replace(message, @"\b" + Regex.Escape(pair.Key) + @"\b", pair.Value);
            }
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => log(message)));
            }
            else
            {
                richTextBox1.AppendText(message + Environment.NewLine);
                richTextBox1.ScrollToCaret();
            }
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {
            //检查是否有未填写
            if (string.IsNullOrEmpty(port) && string.IsNullOrEmpty(user))
            {
                AntdUI.Message.warn(this, "你好像没有填写或确认[提示码]和[端口]哦", autoClose: 5);
                log("port与user无赋值内容");
                return;
            }
            else if (string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(user))
            {
                AntdUI.Message.warn(this, "你好像没有填写或确认[端口]哦", autoClose: 5);
                log("port无赋值内容");
                return;
            }
            else if (!string.IsNullOrEmpty(port) && string.IsNullOrEmpty(user))
            {
                AntdUI.Message.warn(this, "你好像没有填写或确认[提示码]哦", autoClose: 5);
                log("user无赋值内容");
                return;
            }
            else
            {
                log("User&Port OK");
            }
            //正常启动
            //获取默认Node
            string localName = Environment.MachineName;
            Random random = new Random();
            int randomPort = random.Next(1, 65536);
            string tempDirectory = Path.GetTempPath();
            string customDirectory = Path.Combine(tempDirectory, "MCZLFAPP", "Temp");
            Directory.CreateDirectory(customDirectory);
            Directory.SetCurrentDirectory(customDirectory);
            //清理运行垃圾
            if (File.Exists("config.json")) File.Delete("config.json");
            if (File.Exists("config.json0")) File.Delete("config.json0");
            //增强提醒
            MessageBox.Show($"您的加入地址为127.0.0.1:{randomPort}\n已复制入剪切板中,快去和小伙伴一起玩吧", "增强提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AntdUI.Notification.info((Form)this, "增强提醒", $"您的加入地址为127.0.0.1:{randomPort}\n已复制入剪切板中,快去和小伙伴一起玩吧", align: AntdUI.TAlignFrom.BR);
            string url;
            if (Environment.Is64BitOperatingSystem)
            {
                url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/main.exe";
                // url = "https://mczlf.loft.games/ConnectTool/main.exe";
            }
            else
            {
                //    url = "https://mczlf.loft.games/ConnectTool/main32.exe";
                url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/main32.exe";
            }
            //string url = "https://mczlf.loft.games/ConnectTool/main.exe";
            string fileName = "main.exe";
            string fileMd5 = "886c8ef10288d546fe254b531870318d";
            string fileMd532 = "e8f1007a43eb520eecf9c0fade0300b0";
            bool needsDownload = false;

            if (File.Exists(fileName))
            {
                string md5Hash = GetFileMD5Hash(fileName);
                if (md5Hash == fileMd5)
                {
                    log("64位核心已存在且安全校验通过");
                }
                else
                {
                    if (md5Hash == fileMd532)
                    {
                        log("32位核心已存在且安全校验通过");
                        needsDownload = false;
                    }
                    else
                    {
                        if (md5Hash == null)
                        {
                            log("出现错误，进程终止");
                            return;
                        }
                        else
                        {
                            log("核心不存在或安全校验不通过,重新Download中");
                            needsDownload = true;
                        }
                    }
                }
            }
            else
            {
                log("核心不存在或安全校验不通过,重新Download中");
                needsDownload = true;
            }
            //Download
            if (needsDownload)
            {
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                // 下载
                log("Downloader启动");
                using (var unityClient = new HttpClient())
                using (var response = await unityClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    long totalBytes = response.Content.Headers.ContentLength ?? 0;
                    long downloadedBytes = 0;

                    using (var httpStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Write, bufferSize: 8192, useAsync: true))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;

                        while ((bytesRead = await httpStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            downloadedBytes += bytesRead;

                            if (totalBytes > 0)
                            {
                                int progress = (int)((downloadedBytes * 100) / totalBytes);
                                progressBar1.Value = progress;
                            }
                        }
                    }
                }
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                log("Task:下载核心中..");
            }
            //清除状态
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            log("构造启动参数中..");
            log("复制加入信息中..");
            Clipboard.SetText($"127.0.0.1:{randomPort}");
            log($"加入地址127.0.0.1:{randomPort}");
            // 构造启动参数
            string arguments = $"-node {localName} -appname Minecraft{randomPort} -peernode {user} -dstip 127.0.0.1 -dstport {port} -srcport {randomPort} -token 17073157824633806511";
            if (checkBox1.Checked)
            {
                // 如果勾选了 checkbox1，则显示原版启动窗口
                Process.Start(new ProcessStartInfo()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = true
                });
            }
            else
            {
                Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false; // 关闭外壳程序以支持重定向
            process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            process.StartInfo.RedirectStandardError = true; // 重定向错误输出
            process.StartInfo.CreateNoWindow = true; // 不显示窗口

            // 捕获输出并写入 RichTextBox
            process.OutputDataReceived += (processSender, outputEventArgs) =>
            {
                if (!string.IsNullOrEmpty(outputEventArgs.Data))
                {
                    log(outputEventArgs.Data); // 将输出内容记录到 RichTextBox
                }
            };

            process.ErrorDataReceived += (processSender, errorEventArgs) =>
            {
                if (!string.IsNullOrEmpty(errorEventArgs.Data))
                {
                    log(errorEventArgs.Data); 
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            AntdUI.Message.info(this, "已尝试启动进程,日志内容将输出至右侧哦", autoClose: 5);
            log("已尝试启动");
            button1.Badge = "运行中";
            floatButtonJoin = FloatButton.open(new FloatButton.Config(this, new FloatButton.ConfigBtn[]
                {
            new FloatButton.ConfigBtn("CloseButton", MinecraftConnectTool.Properties.Resources.close) // 使用资源图片
            {
                Text = "关闭", // 按钮文本（可选）
                Tooltip = "关闭P2P核心-all", // 悬浮提示
                Round = true, // 圆角样式
                Type = TTypeMini.Primary, // 按钮类型
                Radius = 6, // 圆角大小
                Badge = null, // 不显示徽标
                Enabled = true, // 是否启用
                Loading = false // 不显示加载动画
            }
                }, (button) => // 点击回调
                {
                    stopp2p();
                })
            {
                Align = TAlign.BR, // 对齐方式：右下角
                Vertical = true, // 垂直方向
                TopMost = false, // 置顶
                MarginX = 24, // X轴偏移
                MarginY = 24, // Y轴偏移
                Gap = 10 // 按钮间距
            });}
        }
        //P2PJoin

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField2.Text = "";
        }


        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField3.Text = "";
        }
        //Set提示码
        private string user; //定义提示码变量

        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                // 获取文本框中的内容并赋值给变量提示码
                string text1 = materialSingleLineTextField2.Text;
                if (string.IsNullOrWhiteSpace(text1) || text1.Equals("输入提示码"))
                {
                AntdUI.Message.warn(this, "你好像什么都没有写哦(提示码)", autoClose: 5);
                text1 = "输入提示码";
                }
                else
                {
                user = materialSingleLineTextField2.Text;
                log($"目标提示码为 {user}");
                log($"变量赋值完成：user= {user}");
                }
                //MessageBox.Show($"提示码已设置为：{user}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string port; //定义port变量
        private void button3_Click(object sender, EventArgs e)
        {
            {
                string text2 = materialSingleLineTextField3.Text;
                if (string.IsNullOrWhiteSpace(text2) || text2.Equals("输入目标端口"))
                {
                AntdUI.Message.warn(this, "你好像什么都没有写哦(端口)", autoClose: 5);
                    text2 = "输入目标端口";
                }
                else
                {
                    if (int.TryParse(text2, out int number))
                    {
                        if (number >= 1 && number <= 65535)
                        {
                        port = materialSingleLineTextField3.Text;
                        log($"目标端口为 {port}");
                        log($"变量赋值完成：port= {port}");
                        }
                        else
                        {
                         AntdUI.Message.error(this, "端口超出范围(1~65535)", autoClose: 5);
                        log("端口超出范围");
                        }
                    }
                }
            }
        }

        private void TopText_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public static string GetFileMD5Hash(string filePath)
        {
            try
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    MD5 md5 = MD5.Create();
                    byte[] hashValue = md5.ComputeHash(stream);

                    // 将字节数组转换为十六进制字符串
                    StringBuilder hex = new StringBuilder(hashValue.Length * 2);
                    foreach (byte b in hashValue)
                    {
                        hex.AppendFormat("{0:x2}", b);
                    }
                    return hex.ToString();
                }
            }
            catch (Exception ex)
            {
                {
                    AntdUI.Modal.open(new AntdUI.Modal.Config(Program.MainForm, $"Oops,出了点小问题", "计算MD5时发现问题,可能是杀毒软件给拦了,要不咱重新试试？\n错误信息：" + ex, AntdUI.TType.Warn)
                    {
                        CloseIcon = true,
                        CancelText = null,
                        Draggable = false,
                        OkText = "好的"
                    });
                }
                return null;
                //                throw new Exception("Error computing MD5 hash for file " + filePath, ex);
            }
        }


        //checkupate
        private int clickCount = 0;
        private DateTime lastClickTime = DateTime.MinValue;
        string updatelogurl;
        string url;
        private async void button4_Click(object sender, EventArgs e)
        {
            TimeSpan timeSinceLastClick = DateTime.Now - lastClickTime;
            if (timeSinceLastClick.TotalSeconds > 60)
            {
                clickCount = 0;
            }
            if (clickCount < 4)
            {
                clickCount++; 
                lastClickTime = DateTime.Now;
                try
            {
                string cloudVersion = await FetchCloudVersionAsync();
                log($"云版本号:{cloudVersion}");
                //校验
                if (version == cloudVersion)
                {
                log("当前已是最新版本");
                }
                else
                {
                        if (IsWindows7OrLower())
                        { updatelogurl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/005/005Updatelog"; }
                        else { updatelogurl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/updatelog6"; }    
                using (HttpClient client = new HttpClient())
                {
                HttpResponseMessage response = await client.GetAsync(updatelogurl);
                string updatelog = await response.Content.ReadAsStringAsync();
                        AntdUI.Message.info(this, $"发现新版本~(≧▽≦)/~\n新版本为{cloudVersion}", autoClose: 5);
                        DialogResult result = MessageBox.Show($"检测到了新版本信号!~(≧▽≦)/~\n新版本为{cloudVersion},是否立即更新?\n新版本更新日志\n{updatelog}", "UpdaterV3", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                            {
                                if (result == DialogResult.OK)
                                {
                                    SaveFileDialog fileDialog = new SaveFileDialog();
                                    fileDialog.Filter = "可执行文件 (*.exe)|*.exe";
                                    fileDialog.FileName = $"MinecraftConnectTool_{cloudVersion}";
                                    fileDialog.RestoreDirectory = true;
                                    if (fileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        string savePath = fileDialog.FileName;
                                        using (WebClient webClient = new WebClient())
                                        {
                                                if (IsWindows7OrLower())
                                                { url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/005/Latest.exe"; }
                                                else { url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/006/Latest.exe"; }
                                            try
                                            {
                                                webClient.DownloadFile(url, savePath);
                                            AntdUI.Message.success(this, "文件下载完成!ヾ(≧▽≦*)o", autoClose: 5);
                                            //MessageBox.Show("文件下载完成！");//这种是真难看
                                            }
                                            catch (Exception ex)
                                            {
                                            //MessageBox.Show($"文件下载失败：{ex.Message}");
                                            AntdUI.Message.open(new AntdUI.Message.Config(this, $"下载失败o(TヘTo)\n原因:{ex.Message}", AntdUI.TType.Error)
                                            {
                                            AutoClose = 5,
                                            ClickClose = true
                                            });
                                            log($"文件下载失败：{ex.Message}");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        log("用户取消了操作");
                                    }
                                    fileDialog.Dispose();
                                }
                                else
                                {
                                    log("用户取消了操作");
                                }
                            }
                        }
                        else
                        {
                            log("用户取消了操作");
                        }
                    }

                }
                }
                catch (Exception ex)
                {
                    AntdUI.Message.open(new AntdUI.Message.Config(this, $"发生错误: {ex.Message}", AntdUI.TType.Error)
                    {
                        AutoClose = 5,
                        ClickClose = true
                    });
                    //MessageBox.Show($"发生错误: {ex.Message}", "Warn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                log("Warn:Wow,太快了(っ °Д °;)っ)");
                AntdUI.Notification.error((Form)this, "INFO", "要不慢点呗＞﹏＜", align: AntdUI.TAlignFrom.BR);
              //AlertForm.ShowAlert("咱就是说,慢点呗,不急", AlertType.Error, direction: ShowDirection.BottomRight);
            }
        }
        // 异步方法用于获取云版本
        string cloudver;
        private async Task<string> FetchCloudVersionAsync()
        {
            if (IsWindows7OrLower())
            { cloudver = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/005/version005"; }
            else
            { cloudver = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/version006.txt"; }    
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(cloudver);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // 处理请求失败的情况
                    return string.Empty;
                }
            }
        }

        private void alert1_Click(object sender, EventArgs e)
        {

        }

        private void alert1_Click_1(object sender, EventArgs e)
        {

        }
        private async Task CloudAlert()
        {
            string url = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/cloudalert";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string cloudalert = await client.GetStringAsync(url);
                    log(cloudalert);
                }
            }
            catch (Exception ex)
            {
                AntdUI.Message.error(this, $"获取云公告失败,原因:" + ex.Message, autoClose: 5);
                log("获取云公告内容失败：" + ex.Message);
            }
        }
        private string GetGreetingMessage(string userName)
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 12)
            {
                return $"上午好,{userName}";
            }
            else if (hour >= 12 && hour < 14)
            {
                return $"中午好,{userName}";
            }
            else if (hour >= 14 && hour < 18)
            {
                return $"下午好,{userName}";
            }
            else
            {
                return $"晚上好,{userName}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AntdUI.Drawer.open(new AntdUI.Drawer.Config(this, new Form2() { Size = new Size(500, 400) })
            {
                Align = TAlignMini.Right,
                Mask = true,             
                MaskClosable = true,   
                DisplayDelay = 0          
            });
        }

        //外调用判断字体
        private bool IsFontInstalled(string fontName)
        {
            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                foreach (FontFamily fontFamily in fontsCollection.Families)
                {
                    if (fontFamily.Name == fontName)
                    {
                        return true; // 字体已安装
                    }
                }
            }
            return false; // 字体未安装
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Loading = true;
            string fontUrl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/shanhaiyuanti.ttf";
            string tempDir = Path.Combine(Path.GetTempPath(), "MCZLFAPP", "Temp");
            string fontFilePath = Path.Combine(tempDir, "shanhaiyuanti.ttf");

            try
            {
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }
                using (var client = new WebClient())
                {
                    client.DownloadFile(fontUrl, fontFilePath);
                }
                Process.Start(new ProcessStartInfo(fontFilePath)
                {
                    UseShellExecute = true
                });
                button6.Loading = false;
                AntdUI.Message.info(this, "请点击新窗口左上角的【安装】按钮完成安装", autoClose: 10);
                AntdUI.Notification.info((Form)this, "增强提醒", $"请点击新窗口左上角的【安装】按钮完成安装", align: AntdUI.TAlignFrom.BR, autoClose: 10);
            }
            catch (Exception ex)
            {
                AntdUI.Message.error(this, $"发生错误：{ex.Message}", autoClose: 10);            }
        }
        public static class Alert
        {
            // 显示信息
            public static void Info(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Info, Color.Black, Color.White, text);
            }
            // 显示警告
            public static void Warn(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Warn, Color.Red, Color.White, text);
            }
            // 显示错误
            public static void Error(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Error, Color.Red, Color.White, text);
            }
            public static void Success(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Success, Color.Black, Color.White, text);
            }
            // 全局设置 Alert 控件的属性
            private static void SetAlertProperties(AntdUI.Alert alert, AntdUI.TType icon, Color foreColor, Color backColor, string text)
            {
                alert.Icon = icon;
                alert.Text = text;
                alert.ForeColor = foreColor;
                alert.BackColor = backColor;
                alert.BorderWidth = 1F;
                alert.Radius = 15;
            }
        }
        public void stopp2p()
        {
            Process[] processes = Process.GetProcessesByName("main");
            foreach (Process process in processes)
            {
                try
                {
                    process.Kill(); // 强制结束进程
                    process.WaitForExit(); // 等待进程完全退出
                    if (floatButtonOpen != null)
                    {
                        floatButtonOpen.Close();
                        floatButtonOpen = null;
                    }

                    if (floatButtonJoin != null)
                    {
                        floatButtonJoin.Close();
                        floatButtonJoin = null;
                    }
                    log("进程已结束~");
                    AntdUI.Message.info(this, $"已结束进程", autoClose: 5);
                    P2PMode.Badge = null;
                    button1.Badge = null;
                }
                catch (Exception ex)
                {
                AntdUI.Message.error(this, $"无法关闭进程: {ex.Message}", autoClose: 15);
                }
            }

            if (processes.Length == 0)
            {
                AntdUI.Message.error(this, "未找到进程", autoClose: 15); 
            }
        }
        public void ShowCloseButton()
        {
            floatButtonOpen = FloatButton.open(new FloatButton.Config(this, new FloatButton.ConfigBtn[]
            {
        new FloatButton.ConfigBtn("CloseButton", MinecraftConnectTool.Properties.Resources.close) // 使用资源图片
        {
            Text = "关闭", // 按钮文本（可选）
            Tooltip = "关闭P2P核心-all", // 悬浮提示
            Round = true, // 圆角样式
            Type = TTypeMini.Primary, // 按钮类型
            Radius = 6, // 圆角大小
            Badge = null, // 不显示徽标
            Enabled = true, // 是否启用
            Loading = false // 不显示加载动画
        }
            }, (button) => // 点击回调
            {
                stopp2p();
            })
            {
                Align = TAlign.BR, // 对齐方式：右下角
                Vertical = true, // 垂直方向
                TopMost = false, // 置顶
                MarginX = 24, // X轴偏移
                MarginY = 24, // Y轴偏移
                Gap = 10 // 按钮间距
            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsWindows7OrLower())
            {
                log("Oops,0.0.6不支持Windows7哦~0.0.5将持续更新~");
                AntdUI.Message.info(this, "Oops,0.0.6不支持Windows7哦~0.0.5将持续更新~", autoClose: 5);
                return;
            }
            {
                // 弹窗询问用户是否更新
                DialogResult result = MessageBox.Show(
                    "是否更新到0.0.6最新版本？",
                    "更新提示",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    using (System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string downloadUrl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/MinecraftConnectTool.exe";
                            string destinationPath = System.IO.Path.Combine(folderDialog.SelectedPath, "Latest.exe");
                            Thread downloadThread = new Thread(() => DownloadFileAsync(downloadUrl, destinationPath));
                            downloadThread.IsBackground = true;
                            downloadThread.Start();
                        }
                    }
                }
            }
        }
        private void DownloadFileAsync(string url, string destinationPath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error != null)
                        {
                            progressBar1.Visible = false;
                            MessageBox.Show("下载失败：" + e.Error.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            progressBar1.Visible = false;
                            MessageBox.Show("文件下载完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    };

                    client.DownloadProgressChanged += (sender, e) =>
                    {
                        progressBar1.Visible = true;
                    this.Invoke(new Action(() => progressBar1.Value = e.ProgressPercentage));
                    };

                    client.DownloadFileAsync(new Uri(url), destinationPath);
                }
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                MessageBox.Show("下载失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
private bool IsWindows7OrLower()
        {
            OperatingSystem os = Environment.OSVersion;
            Version osVersion = os.Version;
            if (os.Platform == PlatformID.Win32NT && osVersion.Major <= 6 && osVersion.Minor <= 1)
            {
                return true;
            }
            return false;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string tempDirectory = Path.GetTempPath();
            string customDirectory = Path.Combine(tempDirectory, "MCZLFAPP", "Temp");
            Directory.CreateDirectory(customDirectory);
            Directory.SetCurrentDirectory(customDirectory);
            string fileName = "main.exe";
            string fileMd5 = "886c8ef10288d546fe254b531870318d";
            string fileMd532 = "e8f1007a43eb520eecf9c0fade0300b0";
            bool needsDownload = false;

            if (File.Exists(fileName))
            {
                string md5Hash = GetFileMD5Hash(fileName);
                if (md5Hash == fileMd5)
                {
                    log("64位核心已存在且安全校验通过");
                }
                else
                {
                    if (md5Hash == fileMd532)
                    {
                        log("32位核心已存在且安全校验通过");
                        needsDownload = false;
                    }
                    else
                    {
                        log("核心不存在或安全校验不通过,重新Download中");
                        needsDownload = true;
                    }

                }
            }
            else
            {
                log("核心不存在或安全校验不通过,重新Download中");
                needsDownload = true;
            }
            if (needsDownload)
            {
                string downloadUrl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/CoreDownloader.exe";
                string tempPath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "MCZLFAPP", "Temp");
                string filePath = Path.Combine(tempPath, "CoreDownloader.exe");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(downloadUrl, filePath);
                    }
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"下载或打开文件时出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void alert1_Click_2(object sender, EventArgs e)
        {
            Process.Start("https://mct.mczlf.loft.games/function/download");
            alert1.Visible = false;
        }

        private void divider2_Click(object sender, EventArgs e)
        {

        }
    }
}