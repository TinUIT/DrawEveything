using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace DrawEveything
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
            socket.ConnectServer();

            Thread thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();

            Thread threadr = new Thread(Receive);
            threadr.IsBackground = true;
            threadr.Start();
        }

        private void Send()
        {
            while (true)
            {
                SocketData getRoom = new SocketData();
                getRoom.Status = "getRoomPlayer";
                socket.Send(getRoom);

                if (join)
                {
                    //MessageBox.Show("end");
                    return;
                }
            }
        }

        private void Receive()
        {
            while (true)
            {
                try
                {
                    SocketData receive = (SocketData)socket.Receive();
                    if (receive.Status == "RoomPlayer")
                    {
                        lbRoom1.Text = "Có " + receive.NumberOfRoom1.ToString() + " người";
                        lbRoom2.Text = "Có " + receive.NumberOfRoom2.ToString() + " người";
                    }

                    if(receive.NumberOfRoom1 == 10)
                        btnRoom1.BackColor = Color.Red;
                    if (receive.NumberOfRoom2 == 10)
                        btnRoom2.BackColor = Color.Red;
                    if (join)
                    {
                        //MessageBox.Show("end");
                        return;
                    }
                }
                catch
                {
                    return;
                }            
            }
        }

        Player player = new Player();
        SocketManager socket = new SocketManager();
        bool join = false;
        private void btnRoom1_Click(object sender, EventArgs e)
        {
            join = true;
            socket.Close();
            Player player = new Player(1);
            this.Hide();
            FrmPlay room = new FrmPlay();
            room.ShowDialog();
            this.Close();
        }

        private void btnRoom2_Click(object sender, EventArgs e)
        {
            join = true;
            socket.Close();
            Player player = new Player(2);
            this.Hide();
            FrmPlay room = new FrmPlay();
            room.ShowDialog();
            this.Close();
        }
    }
}
