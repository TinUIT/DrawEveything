﻿using DrawEveything;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawEverything
{
    public partial class Guide : Form
    {
        public Guide()
        {
            InitializeComponent();
        }

        private void guide_Load(object sender, EventArgs e)
        {
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartGame startGame = new StartGame();
            startGame.ShowDialog();
            this.Close();
        }
    }
}