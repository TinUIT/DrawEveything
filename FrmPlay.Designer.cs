namespace DrawEveything
{
    partial class FrmPlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Send = new System.Windows.Forms.Button();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.lvAnswer = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvChat = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTopic2 = new System.Windows.Forms.Button();
            this.btnTopic1 = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.pic_color = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbWidth = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.tb19 = new System.Windows.Forms.TextBox();
            this.tb18 = new System.Windows.Forms.TextBox();
            this.tb17 = new System.Windows.Forms.TextBox();
            this.tb16 = new System.Windows.Forms.TextBox();
            this.tb15 = new System.Windows.Forms.TextBox();
            this.tb14 = new System.Windows.Forms.TextBox();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbHintAnswer = new System.Windows.Forms.Label();
            this.lbRoom = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgssBarCoolDown = new System.Windows.Forms.ProgressBar();
            this.btn_color = new DrawEveything.RoundButton();
            this.btnRectangle = new DrawEveything.RoundButton();
            this.btn_line = new DrawEveything.RoundButton();
            this.btn_elipse = new DrawEveything.RoundButton();
            this.btn_fill = new DrawEveything.RoundButton();
            this.btn_Eraser = new DrawEveything.RoundButton();
            this.btn_pencil = new DrawEveything.RoundButton();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panelPaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(540, 158);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 39);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Chat";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // tbChat
            // 
            this.tbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChat.Location = new System.Drawing.Point(328, 158);
            this.tbChat.Name = "tbChat";
            this.tbChat.Size = new System.Drawing.Size(204, 39);
            this.tbChat.TabIndex = 4;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(224, 158);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 39);
            this.btnAnswer.TabIndex = 3;
            this.btnAnswer.Text = "Trả lời";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // tbAnswer
            // 
            this.tbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAnswer.Location = new System.Drawing.Point(12, 158);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(204, 39);
            this.tbAnswer.TabIndex = 2;
            // 
            // lvAnswer
            // 
            this.lvAnswer.HideSelection = false;
            this.lvAnswer.Location = new System.Drawing.Point(12, 13);
            this.lvAnswer.Name = "lvAnswer";
            this.lvAnswer.Size = new System.Drawing.Size(287, 139);
            this.lvAnswer.TabIndex = 0;
            this.lvAnswer.UseCompatibleStateImageBehavior = false;
            this.lvAnswer.View = System.Windows.Forms.View.List;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btn_Send);
            this.panel3.Controls.Add(this.tbChat);
            this.panel3.Controls.Add(this.btnAnswer);
            this.panel3.Controls.Add(this.tbAnswer);
            this.panel3.Controls.Add(this.lvChat);
            this.panel3.Controls.Add(this.lvAnswer);
            this.panel3.Location = new System.Drawing.Point(297, 514);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 203);
            this.panel3.TabIndex = 8;
            // 
            // lvChat
            // 
            this.lvChat.HideSelection = false;
            this.lvChat.Location = new System.Drawing.Point(328, 13);
            this.lvChat.Name = "lvChat";
            this.lvChat.Size = new System.Drawing.Size(287, 139);
            this.lvChat.TabIndex = 1;
            this.lvChat.UseCompatibleStateImageBehavior = false;
            this.lvChat.View = System.Windows.Forms.View.List;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 395);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(632, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTopic2);
            this.panel2.Controls.Add(this.btnTopic1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.pic);
            this.panel2.Location = new System.Drawing.Point(247, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 359);
            this.panel2.TabIndex = 7;
            // 
            // btnTopic2
            // 
            this.btnTopic2.BackColor = System.Drawing.Color.White;
            this.btnTopic2.Enabled = false;
            this.btnTopic2.Location = new System.Drawing.Point(437, 231);
            this.btnTopic2.Name = "btnTopic2";
            this.btnTopic2.Size = new System.Drawing.Size(145, 50);
            this.btnTopic2.TabIndex = 3;
            this.btnTopic2.Text = "button2";
            this.btnTopic2.UseVisualStyleBackColor = false;
            this.btnTopic2.Visible = false;
            this.btnTopic2.Click += new System.EventHandler(this.btbTopic2_Click);
            // 
            // btnTopic1
            // 
            this.btnTopic1.BackColor = System.Drawing.Color.White;
            this.btnTopic1.Enabled = false;
            this.btnTopic1.Location = new System.Drawing.Point(121, 231);
            this.btnTopic1.Name = "btnTopic1";
            this.btnTopic1.Size = new System.Drawing.Size(145, 50);
            this.btnTopic1.TabIndex = 2;
            this.btnTopic1.Text = "button1";
            this.btnTopic1.UseVisualStyleBackColor = false;
            this.btnTopic1.Visible = false;
            this.btnTopic1.Click += new System.EventHandler(this.btnTopic1_Click);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(714, 359);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pctPaint_Paint);
            this.pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_MouseClick);
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctPaint_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctPaint_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // panelPaint
            // 
            this.panelPaint.BackColor = System.Drawing.Color.White;
            this.panelPaint.Controls.Add(this.pic_color);
            this.panelPaint.Controls.Add(this.btnClear);
            this.panelPaint.Controls.Add(this.cmbWidth);
            this.panelPaint.Controls.Add(this.btnSave);
            this.panelPaint.Controls.Add(this.btn_color);
            this.panelPaint.Controls.Add(this.btnRectangle);
            this.panelPaint.Controls.Add(this.btn_line);
            this.panelPaint.Controls.Add(this.btn_elipse);
            this.panelPaint.Controls.Add(this.btn_fill);
            this.panelPaint.Controls.Add(this.btn_Eraser);
            this.panelPaint.Controls.Add(this.btn_pencil);
            this.panelPaint.Location = new System.Drawing.Point(12, 133);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(205, 584);
            this.panelPaint.TabIndex = 6;
            // 
            // pic_color
            // 
            this.pic_color.BackColor = System.Drawing.Color.White;
            this.pic_color.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.pic_color.FlatAppearance.BorderSize = 5;
            this.pic_color.Location = new System.Drawing.Point(121, 317);
            this.pic_color.Name = "pic_color";
            this.pic_color.Size = new System.Drawing.Size(52, 43);
            this.pic_color.TabIndex = 10;
            this.pic_color.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Lime;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(58, 423);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 50);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbWidth
            // 
            this.cmbWidth.FormattingEnabled = true;
            this.cmbWidth.Location = new System.Drawing.Point(39, 379);
            this.cmbWidth.Name = "cmbWidth";
            this.cmbWidth.Size = new System.Drawing.Size(125, 28);
            this.cmbWidth.TabIndex = 8;
            this.cmbWidth.SelectedIndexChanged += new System.EventHandler(this.cmbWidth_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(58, 486);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 50);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrawEveything.Properties.Resources.Ảnh1;
            this.pictureBox2.Location = new System.Drawing.Point(577, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(294, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // tb1
            // 
            this.tb1.Enabled = false;
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(975, 84);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(183, 35);
            this.tb1.TabIndex = 12;
            // 
            // tb2
            // 
            this.tb2.Enabled = false;
            this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb2.Location = new System.Drawing.Point(1188, 83);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(64, 35);
            this.tb2.TabIndex = 13;
            // 
            // tb4
            // 
            this.tb4.Enabled = false;
            this.tb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb4.Location = new System.Drawing.Point(1188, 133);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(64, 35);
            this.tb4.TabIndex = 15;
            // 
            // tb3
            // 
            this.tb3.Enabled = false;
            this.tb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb3.Location = new System.Drawing.Point(975, 134);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(183, 35);
            this.tb3.TabIndex = 14;
            // 
            // tb6
            // 
            this.tb6.Enabled = false;
            this.tb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb6.Location = new System.Drawing.Point(1188, 189);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(64, 35);
            this.tb6.TabIndex = 17;
            // 
            // tb5
            // 
            this.tb5.Enabled = false;
            this.tb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb5.Location = new System.Drawing.Point(975, 190);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(183, 35);
            this.tb5.TabIndex = 16;
            // 
            // tb8
            // 
            this.tb8.Enabled = false;
            this.tb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb8.Location = new System.Drawing.Point(1188, 243);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(64, 35);
            this.tb8.TabIndex = 19;
            // 
            // tb7
            // 
            this.tb7.Enabled = false;
            this.tb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb7.Location = new System.Drawing.Point(975, 243);
            this.tb7.Name = "tb7";
            this.tb7.Size = new System.Drawing.Size(183, 35);
            this.tb7.TabIndex = 18;
            // 
            // tb10
            // 
            this.tb10.Enabled = false;
            this.tb10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb10.Location = new System.Drawing.Point(1188, 299);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(64, 35);
            this.tb10.TabIndex = 21;
            // 
            // tb9
            // 
            this.tb9.Enabled = false;
            this.tb9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb9.Location = new System.Drawing.Point(975, 300);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(183, 35);
            this.tb9.TabIndex = 20;
            // 
            // tb20
            // 
            this.tb20.Enabled = false;
            this.tb20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb20.Location = new System.Drawing.Point(1188, 577);
            this.tb20.Name = "tb20";
            this.tb20.Size = new System.Drawing.Size(64, 35);
            this.tb20.TabIndex = 31;
            // 
            // tb19
            // 
            this.tb19.Enabled = false;
            this.tb19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb19.Location = new System.Drawing.Point(975, 578);
            this.tb19.Name = "tb19";
            this.tb19.Size = new System.Drawing.Size(183, 35);
            this.tb19.TabIndex = 30;
            // 
            // tb18
            // 
            this.tb18.Enabled = false;
            this.tb18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb18.Location = new System.Drawing.Point(1188, 521);
            this.tb18.Name = "tb18";
            this.tb18.Size = new System.Drawing.Size(64, 35);
            this.tb18.TabIndex = 29;
            // 
            // tb17
            // 
            this.tb17.Enabled = false;
            this.tb17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb17.Location = new System.Drawing.Point(975, 522);
            this.tb17.Name = "tb17";
            this.tb17.Size = new System.Drawing.Size(183, 35);
            this.tb17.TabIndex = 28;
            // 
            // tb16
            // 
            this.tb16.Enabled = false;
            this.tb16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb16.Location = new System.Drawing.Point(1188, 467);
            this.tb16.Name = "tb16";
            this.tb16.Size = new System.Drawing.Size(64, 35);
            this.tb16.TabIndex = 27;
            // 
            // tb15
            // 
            this.tb15.Enabled = false;
            this.tb15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb15.Location = new System.Drawing.Point(975, 468);
            this.tb15.Name = "tb15";
            this.tb15.Size = new System.Drawing.Size(183, 35);
            this.tb15.TabIndex = 26;
            // 
            // tb14
            // 
            this.tb14.Enabled = false;
            this.tb14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb14.Location = new System.Drawing.Point(1188, 416);
            this.tb14.Name = "tb14";
            this.tb14.Size = new System.Drawing.Size(64, 35);
            this.tb14.TabIndex = 25;
            // 
            // tb13
            // 
            this.tb13.Enabled = false;
            this.tb13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb13.Location = new System.Drawing.Point(975, 417);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(183, 35);
            this.tb13.TabIndex = 24;
            // 
            // tb12
            // 
            this.tb12.Enabled = false;
            this.tb12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb12.Location = new System.Drawing.Point(1188, 361);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(64, 35);
            this.tb12.TabIndex = 23;
            // 
            // tb11
            // 
            this.tb11.Enabled = false;
            this.tb11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb11.Location = new System.Drawing.Point(975, 362);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(183, 35);
            this.tb11.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(968, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 40);
            this.label1.TabIndex = 32;
            this.label1.Text = "Người chơi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(1161, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 40);
            this.label2.TabIndex = 33;
            this.label2.Text = "Điểm";
            // 
            // lbHintAnswer
            // 
            this.lbHintAnswer.AutoSize = true;
            this.lbHintAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHintAnswer.ForeColor = System.Drawing.Color.Yellow;
            this.lbHintAnswer.Location = new System.Drawing.Point(349, 17);
            this.lbHintAnswer.Name = "lbHintAnswer";
            this.lbHintAnswer.Size = new System.Drawing.Size(113, 40);
            this.lbHintAnswer.TabIndex = 34;
            this.lbHintAnswer.Text = "label3";
            this.lbHintAnswer.Visible = false;
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoom.ForeColor = System.Drawing.Color.Yellow;
            this.lbRoom.Location = new System.Drawing.Point(44, 17);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(113, 40);
            this.lbRoom.TabIndex = 35;
            this.lbRoom.Text = "Room";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(51, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(134, 50);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pgssBarCoolDown
            // 
            this.pgssBarCoolDown.Location = new System.Drawing.Point(247, 485);
            this.pgssBarCoolDown.Name = "pgssBarCoolDown";
            this.pgssBarCoolDown.Size = new System.Drawing.Size(714, 23);
            this.pgssBarCoolDown.TabIndex = 36;
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.Blue;
            this.btn_color.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_color.FlatAppearance.BorderSize = 0;
            this.btn_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_color.ForeColor = System.Drawing.Color.White;
            this.btn_color.Image = global::DrawEveything.Properties.Resources.color;
            this.btn_color.Location = new System.Drawing.Point(16, 292);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(80, 80);
            this.btn_color.TabIndex = 6;
            this.btn_color.Text = "Color";
            this.btn_color.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.BackColor = System.Drawing.Color.Blue;
            this.btnRectangle.FlatAppearance.BorderSize = 0;
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectangle.ForeColor = System.Drawing.Color.White;
            this.btnRectangle.Image = global::DrawEveything.Properties.Resources.rectangle;
            this.btnRectangle.Location = new System.Drawing.Point(108, 206);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(80, 80);
            this.btnRectangle.TabIndex = 5;
            this.btnRectangle.Text = "Square";
            this.btnRectangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btn_line
            // 
            this.btn_line.BackColor = System.Drawing.Color.Blue;
            this.btn_line.FlatAppearance.BorderSize = 0;
            this.btn_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_line.ForeColor = System.Drawing.Color.White;
            this.btn_line.Image = global::DrawEveything.Properties.Resources.line;
            this.btn_line.Location = new System.Drawing.Point(16, 206);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(80, 80);
            this.btn_line.TabIndex = 4;
            this.btn_line.Text = "Line";
            this.btn_line.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_line.UseVisualStyleBackColor = false;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_elipse
            // 
            this.btn_elipse.BackColor = System.Drawing.Color.Blue;
            this.btn_elipse.FlatAppearance.BorderSize = 0;
            this.btn_elipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_elipse.ForeColor = System.Drawing.Color.White;
            this.btn_elipse.Image = global::DrawEveything.Properties.Resources.circle;
            this.btn_elipse.Location = new System.Drawing.Point(108, 120);
            this.btn_elipse.Name = "btn_elipse";
            this.btn_elipse.Size = new System.Drawing.Size(80, 80);
            this.btn_elipse.TabIndex = 3;
            this.btn_elipse.Text = "Elipse";
            this.btn_elipse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_elipse.UseVisualStyleBackColor = false;
            this.btn_elipse.Click += new System.EventHandler(this.btn_elipse_Click);
            // 
            // btn_fill
            // 
            this.btn_fill.BackColor = System.Drawing.Color.Blue;
            this.btn_fill.FlatAppearance.BorderSize = 0;
            this.btn_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fill.ForeColor = System.Drawing.Color.White;
            this.btn_fill.Image = global::DrawEveything.Properties.Resources.bucket;
            this.btn_fill.Location = new System.Drawing.Point(16, 120);
            this.btn_fill.Name = "btn_fill";
            this.btn_fill.Size = new System.Drawing.Size(80, 80);
            this.btn_fill.TabIndex = 2;
            this.btn_fill.Text = "Fill";
            this.btn_fill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_fill.UseVisualStyleBackColor = false;
            this.btn_fill.Click += new System.EventHandler(this.btn_fill_Click);
            // 
            // btn_Eraser
            // 
            this.btn_Eraser.BackColor = System.Drawing.Color.Blue;
            this.btn_Eraser.FlatAppearance.BorderSize = 0;
            this.btn_Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eraser.ForeColor = System.Drawing.Color.White;
            this.btn_Eraser.Image = global::DrawEveything.Properties.Resources.eraser;
            this.btn_Eraser.Location = new System.Drawing.Point(108, 34);
            this.btn_Eraser.Name = "btn_Eraser";
            this.btn_Eraser.Size = new System.Drawing.Size(80, 80);
            this.btn_Eraser.TabIndex = 1;
            this.btn_Eraser.Text = "Eraser";
            this.btn_Eraser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Eraser.UseVisualStyleBackColor = false;
            this.btn_Eraser.Click += new System.EventHandler(this.btn_Eraser_Click);
            // 
            // btn_pencil
            // 
            this.btn_pencil.BackColor = System.Drawing.Color.Blue;
            this.btn_pencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_pencil.FlatAppearance.BorderSize = 0;
            this.btn_pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pencil.ForeColor = System.Drawing.Color.White;
            this.btn_pencil.Image = global::DrawEveything.Properties.Resources.pencil;
            this.btn_pencil.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_pencil.Location = new System.Drawing.Point(16, 34);
            this.btn_pencil.Name = "btn_pencil";
            this.btn_pencil.Size = new System.Drawing.Size(80, 80);
            this.btn_pencil.TabIndex = 0;
            this.btn_pencil.Text = "Pencil";
            this.btn_pencil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pencil.UseVisualStyleBackColor = false;
            this.btn_pencil.Click += new System.EventHandler(this.btn_pencil_Click);
            // 
            // FrmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1288, 751);
            this.Controls.Add(this.pgssBarCoolDown);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.lbHintAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb20);
            this.Controls.Add(this.tb19);
            this.Controls.Add(this.tb18);
            this.Controls.Add(this.tb17);
            this.Controls.Add(this.tb16);
            this.Controls.Add(this.tb15);
            this.Controls.Add(this.tb14);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.tb12);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelPaint);
            this.Name = "FrmPlay";
            this.Text = "Play";
            this.Activated += new System.EventHandler(this.FrmPlay_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlay_FormClosing);
            this.Load += new System.EventHandler(this.FrmPlay_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panelPaint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.ListView lvAnswer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvChat;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPaint;
        private RoundButton btn_color;
        private RoundButton btnRectangle;
        private RoundButton btn_line;
        private RoundButton btn_elipse;
        private RoundButton btn_fill;
        private RoundButton btn_Eraser;
        private RoundButton btn_pencil;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.TextBox tb6;
        private System.Windows.Forms.TextBox tb5;
        private System.Windows.Forms.TextBox tb8;
        private System.Windows.Forms.TextBox tb7;
        private System.Windows.Forms.TextBox tb10;
        private System.Windows.Forms.TextBox tb9;
        private System.Windows.Forms.TextBox tb20;
        private System.Windows.Forms.TextBox tb19;
        private System.Windows.Forms.TextBox tb18;
        private System.Windows.Forms.TextBox tb17;
        private System.Windows.Forms.TextBox tb16;
        private System.Windows.Forms.TextBox tb15;
        private System.Windows.Forms.TextBox tb14;
        private System.Windows.Forms.TextBox tb13;
        private System.Windows.Forms.TextBox tb12;
        private System.Windows.Forms.TextBox tb11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWidth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbHintAnswer;
        private System.Windows.Forms.Button btnTopic2;
        private System.Windows.Forms.Button btnTopic1;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button pic_color;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pgssBarCoolDown;
    }
}