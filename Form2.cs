using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;

namespace MinecraftConnectTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            AntdUI.Config.ShowInWindowByMessage = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "确认操作", "您确定要执行此操作吗？", TType.Info)
            {
                // 设置按钮文本
                OkText = "确认",
                CancelText = null,
                // 设置确认按钮的回调
                OnOk = config =>
                {
                    DeleteTempFolderContents();
                    return true;
                },
                // 设置自定义按钮的回调（用于处理取消逻辑）
                Btns = new AntdUI.Modal.Btn[]
                            {
                    new AntdUI.Modal.Btn("cancel", "取消", AntdUI.TTypeMini.Default)
                            },
                OnBtns = btn =>
                {
                    if (btn.Name == "cancel")
                    {
                        //no
                        return true;
                    }
                    return false; // 返回 false 表示不关闭弹窗，true 表示关闭弹窗
                }
            });
        }
        private void DeleteTempFolderContents()
        {
            try
            {
                // 获取 %temp% 路径
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                string targetFolder = Path.Combine(tempPath, "MCZLFAPP", "Temp");

                // 检查目标文件夹是否存在
                if (Directory.Exists(targetFolder))
                {
                    // 删除文件夹内的所有文件和子文件夹
                    foreach (string file in Directory.GetFiles(targetFolder, "*.*", SearchOption.AllDirectories))
                    {
                        File.SetAttributes(file, FileAttributes.Normal); // 确保文件不是只读
                        File.Delete(file);
                    }

                    foreach (string folder in Directory.GetDirectories(targetFolder, "*.*", SearchOption.AllDirectories))
                    {
                        Directory.Delete(folder, true);
                    }

                    AntdUI.Message.success(this, $"清除成功~", autoClose: 5);
                    Application.Restart();
                }
                else
                {
                    AntdUI.Message.info(this, $"缓存为空,无需清理哦~", autoClose: 5);
                }
            }
            catch (Exception ex)
            {
                AntdUI.Message.error(this, $"清除失败,请手动清除,原因:" + ex.Message, autoClose: 5);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config((Form)this, "特殊编译：否\nP2P版本:3.19.0_M", AntdUI.TType.Info)
            {
                OnButtonStyle = (id, btn) =>
                {
                    btn.BackExtend = "135, #6253E1, #04BEFE";
                },
                CancelText = null,
                OkText = "知道了"
            });
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private Random random2 = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            int randomInt = random2.Next(1, 99999999);
            try
            {
                // 获取系统临时目录
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                string targetDirectory = Path.Combine(tempPath, "MCZLFAPP", "Temp");

                // 确保目标目录存在
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // 文件路径
                string filePath = Path.Combine(targetDirectory, $"EmptyFile.dat_{randomInt}");

                // 创建一个1GB大小的空文件
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    fs.SetLength(1024 * 1024 * 1024); // 1GB = 1024MB * 1024KB * 1024B
                }

                MessageBox.Show($"成功创建1GB的空文件：{filePath}", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取系统临时目录
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                string targetDirectory = Path.Combine(tempPath, "MCZLFAPP", "Temp");

                // 检查目标目录是否存在
                if (!Directory.Exists(targetDirectory))
                {
                    MessageBox.Show($"目录不存在：{targetDirectory}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 计算文件夹大小
                long folderSize = GetDirectorySize(targetDirectory);

                // 显示结果
                MessageBox.Show($"文件夹大小：{folderSize / (1024.0 * 1024.0):F2} MB", "文件夹大小统计", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 递归计算文件夹大小
        private long GetDirectorySize(string directoryPath)
        {
            long size = 0;

            // 获取文件夹中的所有文件
            string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            return size;
        }
        public static class Alert
        {
            // 显示信息提示
            public static void Info(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Info, Color.Black, Color.White, text);
            }

            // 显示警告提示
            public static void Warn(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Warn, Color.Red, Color.White, text);
            }

            // 显示错误提示
            public static void Error(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Error, Color.Red, Color.White, text);
            }
            public static void Success(AntdUI.Alert alert, string text)
            {
                SetAlertProperties(alert, AntdUI.TType.Success, Color.Black, Color.White, text);
            }

            // 内部方法：设置 Alert 控件的属性
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
        private string tempFilePath;
        private string configFilePath;
        private string apiUrl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/005/saying";
        private async void alert1_Click(object sender, EventArgs e)
        {
            string tempDirectory = Path.GetTempPath(); // 获取系统的临时目录路径
            string customDirectory = Path.Combine(tempDirectory, "MCZLFAPP", "Temp");
            tempFilePath = Path.Combine(customDirectory, "saying.txt");
            configFilePath = Path.Combine(customDirectory, "config_sayingGetCount.ini");

            int requestCount = GetRequestCount();
            try
            {
                // 是否更新缓存if (requestCount % 次数 == 0)
                if (requestCount % 10 == 0)
                {
                    await DownloadFileAsync(apiUrl, tempFilePath);
                }

                // 从本地文件中随机读取一行
                string saying = await ReadRandomLineAsync(tempFilePath);
                if (!string.IsNullOrEmpty(saying))
                {
                    alert1.Loop = saying.Length >= 23 ? true : false;
                    Alert.Info(alert1, saying);
                }
                if (requestCount >= 100)
                {
                    Alert.Error(alert1, "可恶,快撑不住了");
                    await Task.Delay(10000);
                    Alert.Success(alert1, "看广告复活成功！(￣o￣) . z Z");
                    if (File.Exists(configFilePath))
                    {
                        File.Delete(configFilePath);
                        if (File.Exists(tempFilePath))
                        {
                            File.Delete(tempFilePath);
                        }
                    }
                }
                else
                {
                    SaveRequestCount(requestCount + 1);
                }
            }
            catch (Exception ex)
            {
            AntdUI.Message.error(this, $"获取失败：{ex.Message}", autoClose: 5);
            }
        }

        private async Task DownloadFileAsync(string url, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    byte[] fileBytes = await response.Content.ReadAsByteArrayAsync(); // 获取文件内容
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // 确保目录存在
                    File.WriteAllBytes(filePath, fileBytes); // 保存文件到本地
                }
                else
                {
                    throw new Exception("下载文件失败");
                }
            }
        }

        private async Task<string> ReadRandomLineAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }

                if (lines.Count > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(lines.Count); // 随机选择一行
                    return lines[randomIndex];
                }
                else
                {
                    throw new InvalidOperationException("文件为空");
                }
            }
            else
            {
                throw new FileNotFoundException("文件未找到", filePath);
            }
        }

        private int GetRequestCount()
        {
            // 如果配置文件不存在，则初始化为0
            if (!File.Exists(configFilePath))
            {
                SaveRequestCount(0);
                return 0;
            }
            // 从配置文件中读取请求次数
            string content = File.ReadAllText(configFilePath);
            if (int.TryParse(content, out int count))
            {
                return count;
            }
            else
            {
                // 如果内容不是有效数字，则初始化为0
                SaveRequestCount(0);
                return 0;
            }
        }
        private void SaveRequestCount(int count)
        {
            // 确保目录存在
            Directory.CreateDirectory(Path.GetDirectoryName(configFilePath));
            // 将请求次数保存到配置文件
            File.WriteAllText(configFilePath, count.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Path.GetTempPath(), "MCZLFAPP", "Temp", "config_sayingGetCount.ini");
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                AntdUI.Message.info(this, $"你已经听过 {content} 次了", autoClose: 5);            }
            else
            {
                AntdUI.Message.error(this, "你还没有听过,或者刚刚复活了~", autoClose: 5);
            }
        }
        //MD5计算模块
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
                throw new Exception("Error computing MD5 hash for file " + filePath, ex);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string url = "https://gitee.com/linfon18/SunLogin2/raw/master/360DNS.exe";
            string tempDir = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "MCZLFAPP", "Temp");
            string destinationPath = Path.Combine(tempDir, "360DNS.exe");
            string expectedMd5 = "a0c67c45b118e9706cadb771b3014528";
            bool needsDownload = false;
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            if (File.Exists(destinationPath))
            {
                string md5Hash = GetFileMD5Hash(destinationPath);
                if (md5Hash == expectedMd5)
                {
                    Alert.Info(task, "文件已存在且安全校验通过,已尝试启动");
                }
                else
                {
                    Alert.Error(task, "文件存在但安全校验不通过,重新下载中");
                    needsDownload = true;
                }
            }
            else
            {
                Alert.Error(task, "文件不存在,重新下载中");
                needsDownload = true;
            }

            if (needsDownload)
            {
                // 覆盖下载
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(url, destinationPath);
                    }
                    Alert.Success(alert1, "文件下载完成");
                }
                catch (Exception ex)
                {
                    Alert.Error(alert1, $"文件下载失败: {ex.Message}");
                }
            }

            if (File.Exists(destinationPath))
            {
            Alert.Success(task, "启动！✪ ω ✪");
            try
            {
                Process.Start(destinationPath);
            }
            catch (System.ComponentModel.Win32Exception win32Exception)
            {
                // 捕获 Win32 异常，例如文件未找到、权限不足等
                MessageBox.Show($"无法启动程序：{win32Exception.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                // 捕获其他类型的异常
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }

        private void switch1_CheckedChanged(object sender, BoolEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Alert.Success(task, "嘿咻~浏览器启动！✪ ω ✪");
            this.Close();
            //启动网页的代码(还没写)
        }

        private void button8_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}