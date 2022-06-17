using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DrawEveything
{
    public partial class Login : Form
    {
        public Login(SocketManager socketmanager)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            socket = socketmanager;
            
        }

        SocketManager socket;

        public string SHA256(string plainText)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            sha256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));

            byte[] result = sha256.Hash;
            return byteToString(result);
        }

        public string byteToString(byte[] result)
        {
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != "" && tbUserName.Text != "")
            {
                SocketData login = new SocketData(tbUserName.Text, SHA256(tbPassword.Text));
                login.Status = "login";
                socket.Send(login);
                SocketData receive = (SocketData)socket.Receive();
                if (receive.Status == "Success")
                {
                    Player player = new Player(tbUserName.Text, login.Password);
                    this.Hide();
                    Room room = new Room(socket);
                    room.ShowDialog();
                    this.Close();
                }
                else if (receive.Status == "Exist")
                {
                    MessageBox.Show("User này đang hoạt động");
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập, vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username, Password");
            }

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartGame startGame = new StartGame(socket);
            startGame.ShowDialog();
            this.Close();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
