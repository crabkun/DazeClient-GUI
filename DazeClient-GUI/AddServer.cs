using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DazeClient_GUI
{
    public partial class AddServer : Form
    {
        string[] EncryptionArr;
        string[] ObscureArr;
        Server newcfg;
        public AddServer(string[] e,string[] ob,ref Server cfg)
        {
            newcfg = cfg;
            EncryptionArr = e;
            ObscureArr = ob;
            InitializeComponent();
        }

        private void AddServer_Load(object sender, EventArgs e)
        {
            if (EncryptionArr != null)
            {
                foreach(string tmp in EncryptionArr)
                {
                    Encryption.Items.Add(tmp);
                }
                Encryption.Sorted = true;
            }
            if (ObscureArr != null)
            {
                foreach (string tmp in ObscureArr)
                {
                    Obscure.Items.Add(tmp);
                }
                Obscure.Sorted = true;
            }
            ServerName.Text=newcfg.Name;
            Address.Text = newcfg.Address;
            Port.Text=newcfg.Port;
            Username.Text = newcfg.Username;
            Password.Text = newcfg.Password;
            Encryption.Text = newcfg.Encryption;
            EncryptionParam.Text=newcfg.EncryptionParam;
            Obscure.Text = newcfg.Obscure;
            ObscureParam.Text=newcfg.ObscureParam;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(
                ServerName.Text=="" ||
                Address.Text=="" ||
                Port.Text==""||
                Encryption.Text==""||
                Obscure.Text==""
              )
            {
                MessageBox.Show("名称、IP、端口、加密方式、伪装方式都不能为空", "错误");
                return;
            }
            newcfg.Name = ServerName.Text;
            newcfg.Address = Address.Text;
            newcfg.Port = Port.Text;
            newcfg.Username = Username.Text;
            newcfg.Password = Password.Text;
            newcfg.Encryption = Encryption.Text;
            newcfg.EncryptionParam = EncryptionParam.Text;
            newcfg.Obscure = Obscure.Text;
            newcfg.ObscureParam = ObscureParam.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
