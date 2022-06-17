using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawEveything
{
    public partial class StartGame : Form
    {
        public StartGame(SocketManager socketManager)
        {
            InitializeComponent();
            socket = socketManager;
        }
        SocketManager socket;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login(socket);
            login.ShowDialog();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register(socket);
            register.ShowDialog();
            this.Close();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            this.Hide();
            DrawEverything.Guide guide = new DrawEverything.Guide();
            guide.ShowDialog();
            this.Show();
        }
    }
}
