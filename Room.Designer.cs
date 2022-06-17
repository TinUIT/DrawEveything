namespace DrawEveything
{
    partial class Room
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
            this.btnRoom1 = new System.Windows.Forms.Button();
            this.btnRoom2 = new System.Windows.Forms.Button();
            this.lbRoom1 = new System.Windows.Forms.Label();
            this.lbRoom2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRoom1
            // 
            this.btnRoom1.BackColor = System.Drawing.Color.Lime;
            this.btnRoom1.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom1.Location = new System.Drawing.Point(146, 137);
            this.btnRoom1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoom1.Name = "btnRoom1";
            this.btnRoom1.Size = new System.Drawing.Size(143, 83);
            this.btnRoom1.TabIndex = 0;
            this.btnRoom1.Text = "Room 1";
            this.btnRoom1.UseVisualStyleBackColor = false;
            this.btnRoom1.Click += new System.EventHandler(this.btnRoom1_Click);
            // 
            // btnRoom2
            // 
            this.btnRoom2.BackColor = System.Drawing.Color.Lime;
            this.btnRoom2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom2.Location = new System.Drawing.Point(411, 137);
            this.btnRoom2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoom2.Name = "btnRoom2";
            this.btnRoom2.Size = new System.Drawing.Size(136, 83);
            this.btnRoom2.TabIndex = 1;
            this.btnRoom2.Text = "Room 2";
            this.btnRoom2.UseVisualStyleBackColor = false;
            this.btnRoom2.Click += new System.EventHandler(this.btnRoom2_Click);
            // 
            // lbRoom1
            // 
            this.lbRoom1.AutoSize = true;
            this.lbRoom1.Location = new System.Drawing.Point(171, 230);
            this.lbRoom1.Name = "lbRoom1";
            this.lbRoom1.Size = new System.Drawing.Size(70, 16);
            this.lbRoom1.TabIndex = 2;
            this.lbRoom1.Text = "Có 0 người";
            // 
            // lbRoom2
            // 
            this.lbRoom2.AutoSize = true;
            this.lbRoom2.Location = new System.Drawing.Point(448, 230);
            this.lbRoom2.Name = "lbRoom2";
            this.lbRoom2.Size = new System.Drawing.Size(70, 16);
            this.lbRoom2.TabIndex = 3;
            this.lbRoom2.Text = "Có 0 người";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrawEveything.Properties.Resources.Ảnh1;
            this.pictureBox2.Location = new System.Drawing.Point(233, 26);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(261, 91);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbRoom2);
            this.Controls.Add(this.lbRoom1);
            this.Controls.Add(this.btnRoom2);
            this.Controls.Add(this.btnRoom1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Room";
            this.Text = "Room";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoom1;
        private System.Windows.Forms.Button btnRoom2;
        private System.Windows.Forms.Label lbRoom1;
        private System.Windows.Forms.Label lbRoom2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
