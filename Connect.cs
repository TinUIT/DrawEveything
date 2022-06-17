using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawEveything
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        SocketManager socket = new SocketManager();

        private void btnCreate_Server_Click(object sender, EventArgs e)
        {
            socket.setIP(tbIP.Text);
            this.Hide();
            Server server = new Server(socket);
            server.ShowDialog();
            this.Close();
        }

        private void Connect_Shown(object sender, EventArgs e)
        {
            tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbIP.Text != null)
                {
                    socket.setIP(tbIP.Text);
                    if (socket.ConnectServer())
                    {
                        StartGame start = new StartGame(socket);
                        this.Hide();
                        start.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không connect", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
