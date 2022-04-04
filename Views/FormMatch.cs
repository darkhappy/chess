using chess.Controllers;
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
    public FormMatch()
    {
      InitializeComponent();
      
    }
    public void GridClick(object sender, System.EventArgs e)
    {

    }

    private void DrawBoard(string board)
    {

    }

    private void ChessBoard_Paint(object sender, PaintEventArgs e)
    {
      Graphics boardGraph = ChessBoard.CreateGraphics();
      SolidBrush darkCell = new SolidBrush(Color.DarkGray);
      float cellDim = ChessBoard.Height / 8;
      boardGraph.DrawRectangle(new Pen(Color.White), 0, 0, ChessBoard.Height, ChessBoard.Height);
      
      for (int c = 0; c < 8; c++)
        for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
          boardGraph.FillRectangle(darkCell, r * cellDim, c * cellDim, cellDim, cellDim);
    }
  }
}