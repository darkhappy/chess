using chess.Controllers;
using chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormMatch : Form
  {
    private GameController _controller;
    private string _board;
    public FormMatch()//GameController controller
    {
      InitializeComponent();
        //_controller = controller;
        //_board = _controller.GetBoard();

    }
    public void GridClick(object sender, System.EventArgs e)
    {

    }

    public void DrawBoard(string board)
    {
      Bitmap imgPiece = null;
      Graphics boardGraph = ChessBoard.CreateGraphics();
      SolidBrush darkCell = new SolidBrush(Color.DarkGray);
      float cellDim = ChessBoard.Height / 8;
      boardGraph.DrawRectangle(new Pen(Color.White), 0, 0, ChessBoard.Height, ChessBoard.Height);
      Size cellSize = new Size(ChessBoard.Height / 8, ChessBoard.Height / 8);
      for (int c = 0; c < 8; c++)
        for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
          boardGraph.FillRectangle(darkCell, r * cellDim, c * cellDim, cellDim, cellDim);
      for (int r = 0; r < 8; r++)
      {
        for (int c = 0; c < 8; c++)
        {
          switch (board[r*8 + c])
          {
            case 'P':
              imgPiece = new Bitmap(Resources._00);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'p':
              imgPiece = new Bitmap(Resources._10);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'R':
              imgPiece = new Bitmap(Resources._03);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'r':
              imgPiece = new Bitmap(Resources._13);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'N':
              imgPiece = new Bitmap(Resources._01);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'n':
              imgPiece = new Bitmap(Resources._11);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'B':
              imgPiece = new Bitmap(Resources._02);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'b':
              imgPiece = new Bitmap(Resources._12);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'Q':
              imgPiece = new Bitmap(Resources._04);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'q':
              imgPiece = new Bitmap(Resources._14);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'K':
              imgPiece = new Bitmap(Resources._05);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'k':
              imgPiece = new Bitmap(Resources._15);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case '.':
              imgPiece = null;
              break;
          }
          if (imgPiece != null)
          {
            boardGraph.DrawImage(imgPiece, c*cellDim, r*cellDim);
          }
        }
      }
    }

    private void ChessBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard("rnbqkbnrpppppppp................................PPPPPPPPPPPPPPPP");
    }
  }
}