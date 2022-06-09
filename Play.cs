using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawEveything
{
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();

            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g1 = Graphics.FromImage(bm);
            g1.Clear(Color.White);
            pic.Image = bm;
            for (int i = 1; i <= 5; i++)
            {
                cmbWidth.Items.Add(i);
            }
            pic_color.BackColor = Color.Black;

            CheckForIllegalCrossThreadCalls = false;

            socket.ConnectServer();
            Thread thread = new Thread(Receive);
            thread.IsBackground=true;
            thread.Start();
        }

        private void Receive()
        {
            while (true)
            {
                receive = (SocketData)socket.Receive();
                isnotReceive = false;
            }
        }
        private void Play_Activated(object sender, EventArgs e)
        {
            if (!isnotReceive)
            {
                isnotReceive = true;
                int x1 = receive.cX;
                int y1 = receive.cY;
                int x2 = receive.sX;
                int y2 = receive.sY;
                if (receive.Status == "paint")
                {
                    p1.Width = receive.width;
                    //p.Color = receive.color;
                    switch (receive.index)
                    {
                        case 1:
                            //label1.Text = receive.cY.ToString();
                            g1.DrawLine(p1, x1, y1, x2, y2);
                            break;
                        case 2:
                            g1.DrawLine(erase, x1, y1, x2, y2);
                            break;
                        case 3:
                            g1.DrawEllipse(p1, x1, y1, x2, y2);
                            break;
                        case 4:
                            g1.DrawRectangle(p1, x1, y1, x2, y2);
                            break;
                        case 5:
                            g1.DrawLine(p1, x1, y1, x2, y2);
                            break;
                        case 6:
                            g1.Clear(Color.White);
                            pic.Image = bm;
                            break;
                        case 7:

                            break;
                    }
                }
                else if (receive.Status == "chat")
                {
                    AddMessage(receive.Username + ": " + receive.chat);
                }
            }
        }
        SocketManager socket = new SocketManager();
        SocketData receive;
        bool isnotReceive = true;
        Player player = new Player();

        #region paint
        Bitmap bm;
        Graphics g,g1;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);

        Pen p1 = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;
        public float width;

        ColorDialog dlg = new ColorDialog();
        Color new_color = Color.Black;       
        
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
                    SocketData pencil = new SocketData(new_color.ToString(), width, px.X, px.Y, py.X, py.Y, 1, "paint");
                    socket.Send(pencil);
                    g.DrawLine(p, px, py);
                    py = px;                   
                }
                if (index == 2)
                {
                    px = e.Location;
                    SocketData eraser = new SocketData(new_color.ToString(), width, px.X, px.Y, py.X, py.Y, 2, "paint");
                    socket.Send(eraser);
                    g.DrawLine(erase, px, py);
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SocketData clear = new SocketData();
            clear.Status = "paint";
            clear.index = 6;
            socket.Send(clear);
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                Point point = set_point(pic, e.Location);
                Fill(bm, point.X, point.Y, new_color);
                SocketData fill = new SocketData();
                fill.Status = "paint";
                fill.index = 7;
                fill.x = point.X;
                fill.y = point.Y;
                fill.color = new_color.ToString();
                socket.Send(fill);
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
                    SocketData elipse = new SocketData(new_color.ToString(), width, cX, cY, sX, sY, 3, "paint");
                    socket.Send(elipse);
                    g.DrawEllipse(p, cX, cY, sX, sY);
                    break;
                case 4:
                    SocketData Rec = new SocketData(new_color.ToString(), width, cX, cY, sX, sY, 4, "paint");
                    socket.Send(Rec);
                    g.DrawRectangle(p, cX, cY, sX, sY);
                    break;
                case 5:
                    SocketData line = new SocketData(new_color.ToString(), width, cX, cY, x, y, 5, "paint");
                    socket.Send(line);
                    g.DrawLine(p, cX, cY, x, y);
                    break;
            }
        }

        private void btnTopic1_Click(object sender, EventArgs e)
        {

        }

        private void btbTopic2_Click(object sender, EventArgs e)
        {

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

        void AddMessage(string s)
        {
            lvChat.Items.Add(new ListViewItem() { Text = s });
            tbChat.Clear();
        }
        #endregion
    }
}
