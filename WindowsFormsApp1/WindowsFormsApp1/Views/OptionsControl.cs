﻿using System;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public partial class OptionsControl :  UserControl, IControl
    {
        private Game game;
        public OptionsControl()
        {
            InitializeComponent();
        }
        
        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            game.Options.s.Stop();
            game.Options.s.Volume = 0;
            game.Options.s.Play();
            trackBarValue.Text = game.Options.s.Volume.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            game.ChangeStage(GameStage.NotStarted);
        }
    }
}