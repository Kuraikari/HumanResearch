﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HumanResearch
{
    public partial class Form1 : Form
    {
        public Thread messageread;
        public AI ai = new AI();

        public Form1()
        {
            InitializeComponent();
        }

        public void readMessages()
        {
            foreach (var line in txtAllMessages.Lines)
            {

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ai.interpretPhrase(txtMyMessage.Text.ToLower());
        }
    }
}
