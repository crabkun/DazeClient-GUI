using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using static DazeClient_GUI.MainForm;

namespace DazeClient_GUI
{
    public class DazeHelper
    {
        int pid;
        int retry;
        bool WillClose;
        Process p;
        Socket s;
        Socket client;
        string exitcode="";
        string LocalPort;
        int ControlPort;
        MainForm mainForm;
        public Server LastServer;
        public DazeHelper(MainForm mf, string lp) {
            mainForm = mf;
            LocalPort = lp;
        }
        public void StartControlServer()
        {
            Random rd = new Random();
            ControlPort = rd.Next(50000, 60000);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(new IPEndPoint(ip, ControlPort));
            s.Listen(1);
            Thread AcceptThread = new Thread(Accept);
            AcceptThread.Start();
        }
        private void Accept()
        {
            try
            {
                client = s.Accept();
                if (LastServer != null)
                {
                    SetConfig(LastServer);
                }
                SetProxy(LocalPort);
            }
            catch{}
        }
        public void Run()
        {
            kill();
            this.StartControlServer();
            p = new Process();
            p.StartInfo.FileName = "DazeClient.exe";
            
            p.StartInfo.Arguments = "-control-address 127.0.0.1:"+ControlPort.ToString();
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.CreateNoWindow = true;
            try
            {
                if (p.Start() == false)
                {
                    throw new Exception("执行DazeClient.exe失败");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("DazeClient.exe执行失败！建议你尝试更换最新版DazeClient核心。错误原因：" + e.Message);
                p = null;
                mainForm.BeginInvoke(mainForm.updateStatus, "未启动");
                return;
            }
            pid = p.Id;
            Thread monitor = new Thread(monitorProcess);
            monitor.Start();
        }

        private void monitorProcess()
        {
            p.WaitForExit();
            mainForm.BeginInvoke(mainForm.updateStatus, "异常关闭");
            if (WillClose == true)
            {
                return;
            }
            exitcode += p.ExitCode.ToString() + ",";
            if (++retry == 5)
            {
                MessageBox.Show("DazeClient核心已异常关闭超过5次，请手动重启核心，建议你尝试更换最新版DazeClient核心。\n异常代码：" + exitcode);
                return;
            }
            Run();
        }
        public void kill()
        {
            try {
                if (p != null && !p.HasExited)
                {
                    p.Kill();
                    p = null;
                }
                if (client != null)
                {
                    client.Close();
                    client = null;
                }
                if (s != null)
                {
                    s.Close();
                    s = null;
                }
            }
            catch { }        
        }
        public bool SetConfig(Server cfg)
        {
            LastServer = cfg;
            string json = JsonConvert.SerializeObject(LastServer);
            string ret = sendCommand("SET SERVER "+ json.Replace(" ", ""));
            if (ret == "OK"){
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetProxy(string port)
        {
            string ret = sendCommand("SET PORT " + port);
            if (ret == "OK")
            {
                mainForm.BeginInvoke(mainForm.updateStatus, "工作中");
                return true;
            }
            else
            {
                mainForm.BeginInvoke(mainForm.updateStatus, "端口错误");
                MessageBox.Show("本地HTTP/SOCKS5代理端口监听失败！请重新设置端口或者关闭冲突程序。", "错误");
                return false;
            }
        }
        public string sendCommand(string cmd)
        {
            if (client == null)
            {
                return "";
            }
            try
            {
                client.Send(System.Text.Encoding.UTF8.GetBytes(cmd + "\n"));
                byte[] buf = new byte[1024];
                int n = client.Receive(buf)-1;
                return System.Text.Encoding.UTF8.GetString(buf.Take(n).ToArray());
            }
            catch
            {
                kill();
                return "";
            }
        }
        public void close()
        {
            WillClose = true;
            kill();
        }
        public string[] GetEncryption()
        {
            string ret = sendCommand("GET ENCRYPTION");
            if(ret == "" || ret == "UNKNOWN"){
                return null;
            }
            return ret.Split('|');
        }
        public string[] GetObscuret()
        {
            string ret = sendCommand("GET OBSCURE");
            if (ret == "" || ret == "UNKNOWN")
            {
                return null;
            }
            return ret.Split('|');
        }
    }
}
