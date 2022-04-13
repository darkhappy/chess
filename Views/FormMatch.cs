using chess.Controllers;
using chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using chess.Models;

namespace chess.Views
{
  public partial class FrmMatch : Form
  {
    private GameController _controller;
    private string _board;
    public FrmMatch(GameController controller)
    {
        InitializeComponent();
        _controller = controller;
        _board = _controller.GetBoard();

    }

    private void GridClick(object sender, EventArgs e)
    {
      
      var props = (MouseEventArgs)e;
      var image = (Panel)sender;
      var x = props.X/(image.Height/8);
      var y = Math.Abs(props.Y-(image.Height))/(image.Height/8);

      var pos = new Position(x, y);

      

      _board = _controller.GetBoard();

      _controller.Selection(pos);

    }

    public void DrawSelection(Position pos) {

      Graphics boardGraph = ChessBoard.CreateGraphics();

      var x = pos.X*(ChessBoard.Height/8);

      var y = Math.Abs(pos.Y-7) * (ChessBoard.Height / 8);

      boardGraph.DrawRectangle(new Pen(Color.CadetBlue, 4.0F), x, y, ChessBoard.Height / 8, ChessBoard.Height / 8);

    }

    public void DrawBoard(string board)
    {
      Bitmap imgPiece = null;
      Graphics boardGraph = ChessBoard.CreateGraphics();
      SolidBrush darkCell = new SolidBrush(Color.DarkGray);
      SolidBrush whiteCell = new SolidBrush(Color.White);
      float cellDim = ChessBoard.Height / 8;
      boardGraph.DrawRectangle(new Pen(Color.White), 0, 0, ChessBoard.Height, ChessBoard.Height);
      Size cellSize = new Size(ChessBoard.Height / 8, ChessBoard.Height / 8);
      int indexBoard = 0;

      //boardGraph.FillRectangle(whiteCell, r * cellDim, c * cellDim, cellDim, cellDim);

      for (int c = 0; c < 8; c++)
      {

        for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
        {
          
          boardGraph.FillRectangle(darkCell, r * cellDim, c * cellDim, cellDim, cellDim);

        }
      }

      for (int c = 0; c < 8; c++)
      {

        for (int r = c % 2 == 0 ? 0 : 1; r < 8; r += 2)
        {

          boardGraph.FillRectangle(whiteCell, r * cellDim, c * cellDim, cellDim, cellDim);

        }
      }

      for (int r = 7; r >= 0; r--)
      {
        for (int c = 0; c < 8; c++)
        {
          switch (board[indexBoard++])
          {
            case 'P':
              imgPiece = new Bitmap(Resources.b_pawn);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'p':
              imgPiece = new Bitmap(Resources.w_pawn);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'N':
              imgPiece = new Bitmap(Resources.b_knight);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'n':
              imgPiece = new Bitmap(Resources.w_knight);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'R':
              imgPiece = new Bitmap(Resources.b_rook);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'r':
              imgPiece = new Bitmap(Resources.w_rook);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'B':
              imgPiece = new Bitmap(Resources.b_bishop);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'b':
              imgPiece = new Bitmap(Resources.w_bishop);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'Q':
              imgPiece = new Bitmap(Resources.b_queen);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'q':
              imgPiece = new Bitmap(Resources.w_queen);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'K':
              imgPiece = new Bitmap(Resources.b_king);
              imgPiece = new Bitmap(imgPiece, cellSize);
              break;
            case 'k':
              imgPiece = new Bitmap(Resources.w_king);
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

    private void FormMatch_Load(object sender, EventArgs e)
    {
      grpPlayer1.Text = _controller.PLayerA.Name;
      grpPlayer2.Text = _controller.PLayerB.Name;
      txtScoreA.Text = _controller.PLayerA.Points.ToString();
      txtScoreB.Text = _controller.PLayerB.Points.ToString();
    }

    private void ChessBoard_Paint(object sender, PaintEventArgs e)
    {
      _board = _controller.GetBoard();
      DrawBoard(_board);
    }

    private void BtnResign_Click(object sender, EventArgs e)
    {
      _controller.Resign();
    }

    private void btnDraw_Click(object sender, EventArgs e)
    {
      _controller.DrawMatch();
    }

    public void VictoryMessage()
    {
      this.Enabled = false;
      // Initializes the variables to pass to the MessageBox.Show method.
      string message = "Do you want to play another match?";
      string caption = "Check Mate !";
      MessageBoxButtons buttons = MessageBoxButtons.OK;
      DialogResult result;

      // Displays the MessageBox.
      result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        this.Close();
      }
    }

    
  }
}