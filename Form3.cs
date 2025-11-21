using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MinecraftConnectTool
{
    public partial class status : Form
    {
        public status()
        {
            InitializeComponent();
            AddClipboardFormatListener(this.Handle); // 添加剪贴板监听
        }
        private string code = string.Empty; // 用于存储提取的提示码
        private bool isListening = false; // 控制是否解析剪贴板内容

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                AntdUI.Modal.open(new AntdUI.Modal.Config(Program.MainForm, "Oops,出了点小问题", "计算MD5时发现问题,可能是杀毒软件给拦了,要不咱重新试试？", AntdUI.TType.Warn)
                {
                    CancelText = null,
                    OkText = "好的"
                });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AntdUI.Drawer.open(new AntdUI.Drawer.Config(this, new Form2() { Size = new Size(500, 400) })
            {
                Align = TAlignMini.Right, // 设置抽屉在右侧打开
                Mask = true,              // 是否显示遮罩层
                MaskClosable = true,      // 是否可以通过点击遮罩层关闭抽屉
                DisplayDelay = 0          // 延迟显示时间（毫秒）
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AntdUI.Notification.error((Form)this, "增强提醒*", $"当前系统版本不受支持,建议您升级至Windows10", align: AntdUI.TAlignFrom.BR, autoClose: 0);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;
            Version win7Version = new Version(6, 1);
            if (os.Version <= win7Version)
            {
                MessageBox.Show("不支持的系统版本", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AntdUI.Notification.error((Form)this, "增强提醒*", $"当前系统版本不受支持,建议您升级至Windows10", align: AntdUI.TAlignFrom.BR, autoClose: 0);
            }
            else
            {
                MessageBox.Show("支持的系统版本", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置默认文件类型、初始目录等选项（可选）
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(); // 从我的文档开始

            // 显示对话框，如果用户选择了一个文件并点击了确定，则继续操作
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("ok", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("被取消", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private int correctAnswer;
        private void button7_Click(object sender, EventArgs e)
        {
            // 生成一个简单的数学问题
            GenerateMathProblem();

            // 弹出输入框，让用户输入数学问题的答案
            string userInput = Prompt("请输入数学问题的答案：");

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("未输入答案，无法上传日志！");
                return;
            }

            // 使用Task.Run来运行异步验证方法
            Task.Run(async () =>
            {
                bool isValid = await ValidateVerificationCodeAsync(userInput);
                if (isValid)
                {
                    // 验证通过，上传日志
                    await UploadLogAsync();
                }
                else
                {
                    // 验证失败，更新UI
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("答案错误，无法上传日志！");
                    }));
                }
            });
        }

        // 生成一个简单的数学问题
        private void GenerateMathProblem()
        {
            Random random = new Random();
            int num1 = random.Next(1, 10); // 生成一个1到9的随机数
            int num2 = random.Next(1, 10); // 生成一个1到9的随机数

            // 随机选择 '+' 或 '-' 运算符
            char operation = (random.Next(2) == 0) ? '+' : '-';

            // 确保减法运算不会产生负数
            if (operation == '-' && num1 < num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }

            // 计算正确答案
            correctAnswer = operation == '+' ? num1 + num2 : num1 - num2;

            // 显示数学问题
            MessageBox.Show($"数学问题：{num1} {operation} {num2} = ?");
        }

        // 弹出输入框的方法
        private string Prompt(string message)
        {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog,
                Text = "日志上传验证",
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            };

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label()
            {
                Left = 50,
                Top = 20,
                Text = message
            };

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox()
            {
                Left = 50,
                Top = 50,
                Width = 200
            };

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button()
            {
                Text = "确认",
                Left = 150,
                Width = 100,
                Top = 80
            };

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            prompt.ShowDialog();

            return textBox.Text.Trim(); // 去除多余空格
        }

        // 验证答案的方法
        private async Task<bool> ValidateVerificationCodeAsync(string userInput)
        {
            // 模拟异步操作
            await Task.Delay(100); // 确保方法是异步的
            if (int.TryParse(userInput, out int userAnswer))
            {
                return userAnswer == correctAnswer;
            }
            return false;
        }

        // 上传日志的方法
        private async Task UploadLogAsync()
        {
            // 收集系统信息
            string cpuInfo = GetCpuInfo();
            string windowsVersion = GetWindowsVersion();
            string curlVersion = GetCurlVersion();
            string logtime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // 生成随机数字
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999); // 生成一个4位随机数字
            MessageBox.Show($"日志编号：{logtime} {randomNumber},请发送给开发人员", "上传结果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 创建日志数据
            var logData = new
            {
                Timestamp = logtime,
                RandomNumber = randomNumber,
                CpuModel = cpuInfo,
                WindowsVersion = windowsVersion,
                CurlVersion = curlVersion
            };

            // 将日志数据序列化为 JSON
            string jsonData = JsonConvert.SerializeObject(logData);

            // 上传 JSON 数据
            bool uploadSuccess = await UploadJsonAsync(jsonData);

            if (uploadSuccess)
            {
                MessageBox.Show("日志上传成功！", "上传成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("日志上传失败，请检查网络或服务器！", "上传失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCpuInfo()
        {
            // 使用 WMI 查询 CPU 信息
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                return obj["Name"]?.ToString() ?? "Unknown";
            }
            return "Unknown";
        }

        private string GetWindowsVersion()
        {
            // 获取 Windows 版本信息
            return Environment.OSVersion.VersionString;
        }

        private string GetCurlVersion()
        {
            // 调用 curl --version 命令获取版本信息
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "curl",
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length > 0)
                    {
                        return lines[0];
                    }
                }
            }
            catch
            {
                return "Curl未安装或无法访问";
            }

            return "Unknown";
        }

        private async Task<bool> UploadJsonAsync(string jsonData)
        {
            string serverUrl = "https://mczlf.loft.games/api/uploadlog.php"; // 服务端地址
            using (HttpClient client = new HttpClient())
            {
                // 设置请求头，指定内容类型为 JSON
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // 创建 JSON 内容
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    // 发送 POST 请求
                    HttpResponseMessage response = await client.PostAsync(serverUrl, content);

                    // 检查响应状态
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"服务器响应：{responseContent}", "上传结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"上传失败，服务器响应：{response.ReasonPhrase}", "上传失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"上传失败，异常信息：{ex.Message}", "上传失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private FormFloatButton floatButtonOpen;
        private void button8_Click(object sender, EventArgs e)
        {
            {
                // 创建悬浮按钮
                floatButtonOpen = FloatButton.open(new FloatButton.Config(this, new FloatButton.ConfigBtn[]
                {
            new FloatButton.ConfigBtn("CloseButton", MinecraftConnectTool.Properties.Resources.close) // 使用资源图片
            {
                Text = "关闭", // 按钮文本（可选）
                Tooltip = "关闭P2P核心", // 悬浮提示
                Round = true, // 圆角样式
                Type = TTypeMini.Primary, // 按钮类型
                Radius = 6, // 圆角大小
                Badge = null, // 不显示徽标
                Enabled = true, // 是否启用
                Loading = false // 不显示加载动画
            }
                }, (button) => // 点击回调
                {
                    MessageBox.Show($"点击了关闭按钮：{button.Text}");
                })
                {
                    Align = TAlign.BR, // 对齐方式：右下角
                    Vertical = true, // 垂直方向
                    TopMost = true, // 置顶
                    MarginX = 24, // X轴偏移
                    MarginY = 24, // Y轴偏移
                    Gap = 10 // 按钮间距
                });
            }
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_CLIPBOARDUPDATE = 0x031D; // 剪贴板更新消息
            if (m.Msg == WM_CLIPBOARDUPDATE && isListening)
            {
                CheckClipboardContent(); // 检查剪贴板内容
            }
            base.WndProc(ref m);
        }

        private void CheckClipboardContent()
        {
            if (Clipboard.ContainsText()) // 确保剪贴板中有文本内容
            {
                string clipboardText = Clipboard.GetText();
                if (TryExtractCode(clipboardText, out string extractedCode))
                {
                    code = extractedCode; // 提取的提示码赋值给变量 code
                    ShowMessage($"提取到的提示码: {code}", "提示码提取成功");
                }
            }
        }

        private bool TryExtractCode(string text, out string code)
        {
            // 使用正则表达式匹配提示码（假设提示码为字母和数字的组合）
            string pattern = @"提示码为\s+([A-Za-z0-9\-]+)";
            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                code = match.Groups[1].Value; // 提取匹配的提示码
                return true;
            }
            code = string.Empty;
            return false;
        }

        private void ShowMessage(string message, string caption = "剪贴板监听")
        {
            // 使用 MessageBox 显示信息，图标为感叹号
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonInhibit_Click(object sender, EventArgs e)
        {
            isListening = false; // 禁用剪贴板监听
            ShowMessage("剪贴板监听已禁用", "监听状态");
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            isListening = true; // 恢复剪贴板监听
            ShowMessage("剪贴板监听已恢复", "监听状态");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveClipboardFormatListener(this.Handle); // 移除剪贴板监听
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool AddClipboardFormatListener(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hWnd);

        private void button10_Click(object sender, EventArgs e)
        {
            isListening = false; // 禁用剪贴板监听
            ShowMessage("剪贴板监听已禁用", "监听状态");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            isListening = true; // 恢复剪贴板监听
            ShowMessage("剪贴板监听已恢复", "监听状态");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ShowMessage("您可以使用[升级尝鲜]进行更新~", "info");
        }
    }
}

