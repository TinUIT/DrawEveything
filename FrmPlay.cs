using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace DrawEveything
{
    public partial class FrmPlay : Form
    {
        public FrmPlay()
        {
            InitializeComponent();
            pgssBarCoolDown.Step = 100;
            pgssBarCoolDown.Maximum = 90000;
            pgssBarCoolDown.Value = 0;
            timer.Interval = 100;
            timer.Enabled = true;

            panelPaint.Enabled = false;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            for (int i = 1; i <= 5; i++)
            {
                cmbWidth.Items.Add(i);
            }
            pic_color.BackColor = Color.Black;

            CheckForIllegalCrossThreadCalls = false;
            
            lbRoom.Text = "Room " + player.getRoom().ToString(); 
            socket.ConnectServer();
            SocketData room = new SocketData();
            room.Room = player.getRoom();
            room.Username = player.getUsername();
            socket.Send(room);

            Thread thread = new Thread(Receive);
            thread.IsBackground=true;
            thread.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pgssBarCoolDown.PerformStep();
        }

        private void Receive()
        {
            while (true)
            {
               receive = (SocketData)socket.Receive();
               switch (receive.Status)
               {
                    case "paint":
                      using (var ms = new MemoryStream(receive.image))
                      {
                         Bitmap btm = new Bitmap(ms);
                         bm = btm;
                         pic.Image = bm;
                      }
                      break;
                    case "chat":
                       AddMessage(receive.Username + ": " + receive.chat);
                       break;
                    case "answer":
                       AddAnswer(receive.Username + ": " + receive.chat);
                        break;
                    case "start":
                        if (receive.start)
                        {
                            start = true;
                            panelPaint.Enabled = true;
                            timer.Start();
                            timer.Tick += new EventHandler(timer1_Tick);
                            pgssBarCoolDown.Value = 0;
                        }
                        break;
                   default:
                        int i = 0;
                        foreach (TextBox tb in textBoxesName)
                        {
                            string s = receive.players[i];
                            if (!String.IsNullOrEmpty(s))
                                tb.Text = receive.players[i];
                            i++;
                        }
                        break;
               }            
            }
        }
        SocketManager socket = new SocketManager();
        SocketData receive;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Player player = new Player();
        List<TextBox> textBoxesName = new List<TextBox>();
        List<TextBox> textBoxesMarked = new List<TextBox>();
        bool start = false;
        #region paint
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);

        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;
        public float width;

        ColorDialog dlg = new ColorDialog();
        Color new_color = Color.Black;       

 
        private void Send()
        {
            Image image = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat);
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                ms.ToArray();

                SocketData paint = new SocketData();
                paint.image = ms.ToArray();
                paint.Status = "paint";
                socket.Send(paint);
            }
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void pctPaint_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void pctPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    Send();
                    py = px;                   
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    Send();
                    py = px;
                }
            }
            pic.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void pctPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            if (paint)
            {
                switch(index)
                {
                    case 3:
                        g.DrawEllipse(p, cX, cY, sX, sY);
  
                        break;
                    case 4:
                        g.DrawRectangle(p, cX, cY, sX, sY);

                        break;
                    case 5:
                        g.DrawLine(p, cX, cY, x, y);

                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*jpg)|*.jpg|(*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Image btm = bm.Clone(new Rectangle(0, 0, pic.Width, pic.Height), bm.PixelFormat);
                btm.Save(sfd.FileName,ImageFormat.Jpeg);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.Image = bm;
            Send();
            index = 0;
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                Point point = set_point(pic, e.Location);
                Fill(bm, point.X, point.Y, new_color);
                Send();
            }
        }

        private void btn_Eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            index = 7;
        }

        private void btn_elipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            switch (index)
            {
                case 3:
                    g.DrawEllipse(p, cX, cY, sX, sY);                   
                    break;
                case 4:
                    g.DrawRectangle(p, cX, cY, sX, sY);      
                    break;
                case 5:
                    g.DrawLine(p, cX, cY, x, y);
                    break;
            }

            Send();
        }

        private void btnTopic1_Click(object sender, EventArgs e)
        {
            SocketData choose = new SocketData();
            choose.chosenTopic = btnTopic1.Text;
            choose.Status = "topic";
            socket.Send(choose);
            btnTopic1.Visible = false;
            btnTopic1.Enabled = false;
            btnTopic2.Visible = false;
            btnTopic2.Enabled = false;
        }

        private void btbTopic2_Click(object sender, EventArgs e)
        {
            SocketData choose = new SocketData();
            choose.chosenTopic = btnTopic2.Text;
            choose.Status = "topic";
            socket.Send(choose);
        }
       
        private void cmbWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            width = float.Parse(cmbWidth.Text);
            p.Width = width;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }

      

        private void btn_color_Click(object sender, EventArgs e)
        {
            dlg.ShowDialog();
            new_color = dlg.Color;
            pic_color.BackColor = dlg.Color;
            p.Color = dlg.Color;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            SendAnswer();
            AddAnswer(player.getUsername() + ":" + tbAnswer.Text);
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_Color, Color new_Color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == old_Color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, new_Color);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SocketData start = new SocketData();
            start.Status = "start";
            start.Room = player.getRoom();
            socket.Send(start);
        }

        private void FrmPlay_Load(object sender, EventArgs e)
        {
            textBoxesName.Add(tb1);
            textBoxesMarked.Add(tb2);
            textBoxesName.Add(tb3);
            textBoxesMarked.Add(tb4);
            textBoxesName.Add(tb5);
            textBoxesMarked.Add(tb6);
            textBoxesName.Add(tb7);
            textBoxesMarked.Add(tb8);
            textBoxesName.Add(tb9);
            textBoxesMarked.Add(tb10);
            textBoxesName.Add(tb11);
            textBoxesMarked.Add(tb12);
            textBoxesName.Add(tb13);
            textBoxesMarked.Add(tb14);
            textBoxesName.Add(tb15);
            textBoxesMarked.Add(tb16);
            textBoxesName.Add(tb17);
            textBoxesMarked.Add(tb18);
            textBoxesName.Add(tb19);
            textBoxesMarked.Add(tb20);
        }

        private void FrmPlay_Activated(object sender, EventArgs e)
        {
            if (start)
            {
                btnTopic1.Visible = true;
                btnTopic1.Enabled = true;
                btnTopic1.Text = receive.topic1;

                btnTopic2.Visible = true;
                btnTopic2.Enabled = true;
                btnTopic2.Text = receive.topic2;
            }
        }

        private void FrmPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketData exit = new SocketData();
        }

        public void Fill(Bitmap bm, int x, int y, Color new_clr)
        {
            Color old_Color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_clr);
            if (old_Color == new_clr) return;

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_Color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_Color, new_clr);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_Color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_Color, new_clr);
                }
            }
        }
        #endregion

        #region Chat&Answer
         private void btn_Send_Click(object sender, EventArgs e)
         {
            SendMessage();
            AddMessage(player.getUsername() + ":" + tbChat.Text);
         }
        void SendMessage()
        {
            if (tbChat.Text != string.Empty)
            {
                SocketData socketData = new SocketData();
                socketData.Status = "chat";
                socketData.chat = tbChat.Text;
                socketData.Username = player.getUsername();
                socket.Send(socketData);
            }
        }

        void SendAnswer()
        {
            if (tbAnswer.Text != string.Empty)
            {
                SocketData socketData = new SocketData();
                socketData.Status = "answer";
                socketData.chat = tbAnswer.Text;
                socketData.Username = player.getUsername();
                socket.Send(socketData);
            }
        }

        void AddMessage(string s)
        {
            lvChat.Items.Add(new ListViewItem() { Text = s });
            tbChat.Clear();
        }

        void AddAnswer(string s)
        {
            lvAnswer.Items.Add(new ListViewItem() { Text = s });
            tbAnswer.Clear();
        }
        #endregion
    }
}
