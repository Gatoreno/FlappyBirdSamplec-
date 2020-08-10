﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyWFApp
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 4;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappy.Top += gravity; //make de the flappy fall baby

            //this move the pipes
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreLabel.Text = "Score : "+score.ToString();

            if (pipeBottom.Left < -50 )
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -75)
            {
                pipeTop.Left = 800;
                score++;
            }

            if (
                flappy.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappy.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappy.Bounds.IntersectsWith(ground.Bounds) ||
                flappy.Top < -25
                )
            {
                endGameAlv();
            }

            if (score > 5)
            {
                pipeSpeed = 6;
            }
            if (score > 10)
            {
                pipeSpeed = 7;
            }
            if (score > 15)
            {
                pipeSpeed = 8;
            }
            
        }

        private void keyDownPressed(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -9;
            }

        }

        private void keyUpPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 9;
            }
        }

        private void endGameAlv()
        {
            gameTimer.Stop();
            scoreLabel.Text = "GAME OVER!!!";
        }
    }
}
