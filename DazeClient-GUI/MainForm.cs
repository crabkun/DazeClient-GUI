using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DazeClient_GUI
{

    public partial class MainForm : Form
    {
        const string version = "1.0.0";
        public MainForm()
        {
            InitializeComponent();
        }
        public Config cfg;
        public DazeHelper dz;
        private int NowSelect = -1;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "DazeClient-GUI " + version;
            cfg = new Config();
            cfg.Servers = new Server[0];
            InitNotifyIcon();
            try
            {
                LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件GuiConfig.json加载失败，请修改正确或者直接把它删了。\n具体错误信息：" + ex.Message, "错误");
                System.Environment.Exit(0);
            }
            updateStatus = new UpdateStatus(UpdateStatusMethod);
            dz = new DazeHelper(this,cfg.LocalPort);
            LoadLastServer();
            dz.Run();
            SaveConfig();
            refreshList();
            ShowBalloonMsg("配置", "配置加载成功，一共" + cfg.Servers.Length.ToString() + "个服务器\n", 1000);
        }
        private void LoadConfig()
        {
            byte[] buf;
            FileStream file = null;
            try
            {
                file = new FileStream("GuiConfig.json", FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                cfg.LocalPort = "1080";
                return;
            }
            file.Seek(0, SeekOrigin.Begin);
            buf=new byte[file.Length];
            file.Read(buf, 0, (int)file.Length);
            file.Close();
            string json=System.Text.Encoding.UTF8.GetString(buf);
            cfg = JsonConvert.DeserializeObject<Config>(json);
            if(cfg == null){
                throw new Exception("unknown error");
            }
        }
        private void refreshList()
        {
            ServerList.Items.Clear();
            foreach(Server s in cfg.Servers)
            {
                ListViewItem item = new ListViewItem();
                item.Text = s.Name;
                item.SubItems.Add(s.Address);
                item.SubItems.Add(s.Port);
                item.SubItems.Add(s.Encryption);
                item.SubItems.Add(s.Obscure);
                ServerList.Items.Add(item);
            }
            try {
                ServerList.Items[NowSelect].BackColor = Color.LightGreen;
            } catch { }
        }
        private void LoadLastServer()
        {
            if (cfg.Servers.Length == 0)
            {
                cfg.LastServer = 0;
                return;
            }
            if (cfg.LastServer == 0 || cfg.LastServer>cfg.Servers.Length)
            {
                cfg.LastServer = 1;
            }
           
            dz.LastServer = cfg.Servers[cfg.LastServer - 1];
            currentServer.Text = "当前服务器：" + cfg.Servers[cfg.LastServer - 1].Name;
            NowSelect = cfg.LastServer-1;
            cfg.LastServer = NowSelect+1;
        }
        private void InitNotifyIcon()
        {
            notifyIcon.Icon = this.Icon;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Text = "DazeClient-GUI "+version;
            notifyIcon.Visible = true;
            notifyIcon.Click += ShowMainFrom;
        }
        public void ShowBalloonMsg(string title,string text,int time)
        {
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.ShowBalloonTip(time);
        }
        private void ShowMainFrom(object sender, EventArgs e)
        {
          
                this.Visible = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            ShowBalloonMsg("提示", "已经最小化到通知栏", 1000);
        }

        public void SaveConfig()
        {
            try
            {
                JsonSerializer js = JsonSerializer.Create(new JsonSerializerSettings());
                StringWriter tw = new StringWriter();
                JsonTextWriter jw = new JsonTextWriter(tw) {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                js.Serialize(jw, cfg);
                byte[] buf = System.Text.Encoding.UTF8.GetBytes(tw.ToString());
                FileStream file = new FileStream("GuiConfig.json", FileMode.Create);
                file.Seek(0, SeekOrigin.Begin);
                file.Write(buf, 0, buf.Length);
                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件GuiConfig.json保存失败。\n具体错误信息：" + ex.Message, "错误");
            }
        }
        public delegate void UpdateStatus(string msg);
        public UpdateStatus updateStatus;
        public void UpdateStatusMethod(string msg)
        {
            DazeClientStatus.Text = msg;
        }

        private void DazeRestart_Click(object sender, EventArgs e)
        {
            currentServer.Text = "当前服务器：未选择";
            dz.close();
            dz = new DazeHelper(this, cfg.LocalPort);
            LoadLastServer();
            dz.Run();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            dz.kill();
            System.Environment.Exit(0);
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("未选中需要使用的配置", "提示");
                return;
            }
            ApplyConfig(ServerList.SelectedIndices[0]);
        }
        private void ApplyConfig(int num)
        {
            if (dz.SetConfig(cfg.Servers[num]) == false)
            {
                MessageBox.Show("核心应用此配置失败，请检查配置或者稍后再试", "提示");
                return;
            }
                NowSelect = num;
                cfg.LastServer = num+1;
                SaveConfig();
                refreshList();
                currentServer.Text = "当前服务器：" + cfg.Servers[num].Name;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Server tmp = new Server();
            AddServer ad = new AddServer(dz.GetEncryption(),dz.GetObscuret(),ref tmp);
            if (ad.ShowDialog() == DialogResult.OK)
            {
                List<Server> tmplist = cfg.Servers.ToList();
                tmplist.Add(tmp);
                cfg.Servers = tmplist.ToArray();
                refreshList();
                SaveConfig();
                ApplyConfig(cfg.Servers.Length - 1);
            }
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("未选中需要使用的配置", "提示");
                return;
            }
            int sel = ServerList.SelectedIndices[0];
            Server tmp = cfg.Servers[sel];
            AddServer ed = new AddServer(dz.GetEncryption(), dz.GetObscuret(),ref tmp);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                cfg.Servers[sel] = tmp;
                refreshList();
                SaveConfig();
                ApplyConfig(sel);
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("未选中需要使用的配置", "提示");
                return;
            }
            if (MessageBox.Show("是否要删除？", "确定？", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int sel = ServerList.SelectedIndices[0];
            
            List<Server> tmplist = cfg.Servers.ToList();
            tmplist.RemoveAt(sel);

            Server old = cfg.Servers[NowSelect];
            NowSelect = tmplist.IndexOf(old);
            cfg.Servers = tmplist.ToArray();
            SaveConfig();
            refreshList();


        }

        private void SetPortButton_Click(object sender, EventArgs e)
        {
            SetPort sp = new SetPort(this);
            if(sp.ShowDialog() == DialogResult.OK){
                dz.SetProxy(cfg.LocalPort);
                SaveConfig();
            }
        }

        private void ToNotify_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
