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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }
        SocketManager socket = new SocketManager();
        _Regex reg = new _Regex();
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            socket.Close();
            StartGame startGame = new StartGame();
            startGame.ShowDialog();
            this.Close();
        }

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

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
                tbRetypePassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                tbRetypePassword.UseSystemPasswordChar = true;
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            if(tbPassword.Text != "" && tbUserName.Text != "" && tbRetypePassword.Text != "")
            {
                if (!reg.Check_Format_User(tbUserName.Text))
                {
                    MessageBox.Show("Username sai định dạng");
                }
                if (!reg.Check_Format_Password(tbPassword.Text) || !reg.Check_Format_Password(tbRetypePassword.Text))
                {
                    MessageBox.Show("Password sai định dạng");
                }
                if (tbPassword.Text == tbRetypePassword.Text)
                {
                    socket.ConnectServer();
                    SocketData login = new SocketData(tbUserName.Text, SHA256(tbPassword.Text));
                    login.Status = "register";
                    socket.Send(login);
                    SocketData receive = (SocketData)socket.Receive();
                    if (receive.Status == "Success")
                    {
                        this.Hide();
                        socket.Close();
                        Room room = new Room();
                        room.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã có Username này. Vui lòng Username khác");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại Password");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username, Password");
            }
        }
    }
}
