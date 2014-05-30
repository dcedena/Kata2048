using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kata2048_Classes;

namespace Kata2048_Design
{
    public partial class FormBoard : Form
    {
        private GameBoard board = null;
        public FormBoard()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ClearBoard();
            board = new GameBoard(new int[,] { { 2, 4, 0, 0 }, 
                                               { 0, 4, 0, 2 }, 
                                               { 0, 0, 2, 0 }, 
                                               { 0, 2, 0, 0 } });
            DrawBoard();   
        }

        private void ClearBoard()
        {
            flowLayoutPanel1.Controls.Clear();
            board = null;
            toolStripStatusLabel1.Text = "";
            PrintScore();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void DrawBoard()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int r = 0; r < board.numRows; r++)
            {
                for (int c = 0; c < board.numColumns; c++)
                {
                    int val = board.listaCeldas[r, c];
                    ucCell cell = new ucCell(val);

                    flowLayoutPanel1.Controls.Add(cell);
                }
            }
        }

        private void pbTop_Click(object sender, EventArgs e)
        {
            movement(GameBoard.MovementType.TOP);
        }

        private void pbRight_Click(object sender, EventArgs e)
        {
            movement(GameBoard.MovementType.RIGHT);
        }

        private void pbBottom_Click(object sender, EventArgs e)
        {
            movement(GameBoard.MovementType.BOTTOM);
        }

        private void pbLeft_Click(object sender, EventArgs e)
        {
            movement(GameBoard.MovementType.LEFT);
        }

        private void movement(GameBoard.MovementType movement)
        {
            bool isMoved = false;
            switch (movement)
            {
                case GameBoard.MovementType.TOP:
                    isMoved = board.MoveToTop();
                    break;
                case GameBoard.MovementType.RIGHT:
                    isMoved = board.MoveToRight();
                    break;
                case GameBoard.MovementType.BOTTOM:
                    isMoved = board.MoveToBottom();
                    break;
                case GameBoard.MovementType.LEFT:
                    isMoved = board.MoveToLeft();
                    break;
            }

            // Set the values to the controls
            DrawBoard();
            PrintScore();

            bool hasWin = board.HasWin();
            bool isGameOver = board.IsGameOver();
            
            // Indicate if there is some movement.
            WriteMessageInStatusBar(isMoved, hasWin, isGameOver);
        }

        private void PrintScore()
        {
            toolStripStatusLabel2.Text = "Score = " + (board != null ? board.Score.ToString() : "0");
        }

        private void WriteMessageInStatusBar(bool isMoved, bool hasWin, bool isGameOver)
        {
            if(hasWin)
            {
                toolStripStatusLabel1.ForeColor = (isMoved ? Color.Green : Color.Red);
                toolStripStatusLabel1.Text = "### YOU WIN ###";
            }
            else
            {
                toolStripStatusLabel1.ForeColor = (isMoved ? Color.Green : Color.Red);
                toolStripStatusLabel1.Text = (isMoved ? "MOVED" : "NOT MOVED"); 
    
                if(isGameOver)
                {
                    toolStripStatusLabel1.Text += "--- GAME OVER ---";
                }
            }
        }
    }
}