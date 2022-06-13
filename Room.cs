using System;
using System.Windows.Forms;
using System.Threading;

namespace DrawEveything
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
            socket.ConnectServer();

            
            thread.IsBackground = true;
            thread.Start();
        }

        private static void Receive()
        {
            while (true)
            {
                SocketData getRoom = new SocketData();
                getRoom.Status = "getRoomPlayer";
                socket.Send(getRoom);
            }
        }

        Player player = new Player();
        static SocketManager socket = new SocketManager();
        Thread thread = new Thread(Receive);
        private void btnRoom1_Click(object sender, EventArgs e)
        {
            
            socket.Close();
            Player player = new Player(1);
            this.Hide();
            FrmPlay room = new FrmPlay();
            room.ShowDialog();
            this.Close();
        }

        private void btnRoom2_Click(object sender, EventArgs e)
        {
            socket.Close();
            Player player = new Player(2);
            this.Hide();
            FrmPlay room = new FrmPlay();
            room.ShowDialog();
            this.Close();
        }
    }
}
