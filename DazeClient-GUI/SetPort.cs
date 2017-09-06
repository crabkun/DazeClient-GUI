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
    public partial class SetPort : Form
    {

        private MainForm mainForm;


        public SetPort(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Port.Text=="")
            {
                MessageBox.Show("端口不能为空", "错误");
                return;
            }
            if (mainForm.cfg.LocalPort != Port.Text)
            {
                mainForm.cfg.LocalPort = Port.Text;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetPort_Load(object sender, EventArgs e)
        {
            Port.Text = mainForm.cfg.LocalPort;
        }
    }
}
