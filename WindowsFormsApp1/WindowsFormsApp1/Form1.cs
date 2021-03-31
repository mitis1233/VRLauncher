using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //VR
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false; //必要引數
            process.StartInfo.CreateNoWindow = true;
            System.IO.Directory.SetCurrentDirectory("E:\\Game\\Steam\\steamapps\\common\\SteamVR\\bin\\win64");
            process.StartInfo.FileName = "vrmonitor.exe";
            process.Start();
        }

        private void button2_Click(object sender, EventArgs e) //FBT VR
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false; //必要引數
            process.StartInfo.CreateNoWindow = true;
            System.IO.Directory.SetCurrentDirectory("C:\\K2EX");
            process.StartInfo.FileName = "KinectV1Process.exe";
            process.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        private enum CommandShow : int { SW_HIDE = 0, SW_SHOWNORMAL = 1, SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2, SW_SHOWMAXIMIZED = 3, SW_MAXIMIZE = 3, SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5, SW_MINIMIZE = 6, SW_SHOWMINNOACTIVE = 7, SW_SHOWNA = 8, SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10, SW_FORCEMINIMIZE = 11, SW_MAX = 11 };
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        private void button3_Click(object sender, EventArgs e) //Game
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false; //必要引數
            process.StartInfo.RedirectStandardInput = true;//傳入引數設定
            process.StartInfo.CreateNoWindow = true;
            System.IO.Directory.SetCurrentDirectory("E:\\Game\\Steam\\steamapps\\common\\VRChat");
            process.StartInfo.FileName = "VRChat.exe";
            process.StartInfo.Arguments = "-screen-width 720 -screen-height 400";
            process.Start();

            Thread.Sleep(3000);
            IntPtr Handle = FindWindow("Chrome_WidgetWin_1", "Oculus");
            ShowWindow((int)Handle, (int)CommandShow.SW_MINIMIZE);
            Handle = FindWindow(null, "SteamVR 狀態");
            ShowWindow((int)Handle, (int)CommandShow.SW_MINIMIZE);
            Handle = FindWindow(null, "VRChat");
            ShowWindow((int)Handle, (int)CommandShow.SW_MINIMIZE);
            Process[] p = Process.GetProcessesByName("chrome");
            if (p.Length > 0)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    int hwnd = p[i].MainWindowHandle.ToInt32();
                    ShowWindow(hwnd, (int)CommandShow.SW_MINIMIZE);
                    ShowWindow(hwnd, (int)CommandShow.SW_MAXIMIZE);
                }
            }
            p = null;
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}
