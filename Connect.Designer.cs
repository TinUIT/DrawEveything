namespace DrawEveything
{
    partial class Connect
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
            this.btConnect = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.Label();
            this.btnCreate_Server = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btConnect.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btConnect.FlatAppearance.BorderSize = 2;
            this.btConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConnect.Location = new System.Drawing.Point(254, 257);
            this.btConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(118, 49);
            this.btConnect.TabIndex = 18;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(329, 176);
            this.tbIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(255, 26);
            this.tbIP.TabIndex = 17;
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(238, 175);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(45, 25);
            this.IP.TabIndex = 16;
            this.IP.Text = "IP :";
            // 
            // btnCreate_Server
            // 
            this.btnCreate_Server.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreate_Server.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnCreate_Server.FlatAppearance.BorderSize = 2;
            this.btnCreate_Server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate_Server.Location = new System.Drawing.Point(475, 257);
            this.btnCreate_Server.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate_Server.Name = "btnCreate_Server";
            this.btnCreate_Server.Size = new System.Drawing.Size(149, 49);
            this.btnCreate_Server.TabIndex = 19;
            this.btnCreate_Server.Text = "Create Server";
            this.btnCreate_Server.UseVisualStyleBackColor = false;
            this.btnCreate_Server.Click += new System.EventHandler(this.btnCreate_Server_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreate_Server);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.IP);
            this.Name = "Connect";
            this.Text = "Connect";
            this.Shown += new System.EventHandler(this.Connect_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Button btnCreate_Server;
    }
}

