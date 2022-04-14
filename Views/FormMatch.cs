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

    /// <summary>
    ///   Initializes the FormMatch when called with new
    /// </summary>
    /// <param name="controller">The cell containing the moving piece.</param>
    /// <returns>Returns a new instance of FormMatch</returns>
    public FrmMatch(GameController controller)
    {
      InitializeComponent();
      _controller = controller;
      _board = _controller.GetBoard();

    }

    /// <summary>
    ///   Method called when the board panel is clcked by the player
    /// </summary>
    /// <param name="sender">Represents the panel clicked</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void GridClick(object sender, EventArgs e)
    {

      var props = (MouseEventArgs)e;
      var image = (Panel)sender;
      var x = props.X / (image.Height / 8);
      var y = Math.Abs(props.Y - (image.Height)) / (image.Height / 8);

      var pos = new Position(x, y);

      _board = _controller.GetBoard();

      _controller.Selection(pos);

    }

    /// <summary>
    ///   Methode called when the area clicked is a valid selection by the player
    /// </summary>
    /// <param name="pos">Reprensents de position as a 2 dimentional table that starts by the bottom-left(starts with 0, 0)</param>
    public void DrawSelection(Position pos)
    {

      Graphics boardGraph = ChessBoard.CreateGraphics();

      var x = pos.X * (ChessBoard.Height / 8);

      var y = Math.Abs(pos.Y - 7) * (ChessBoard.Height / 8);

      boardGraph.DrawRectangle(new Pen(Color.CadetBlue, 4.0F), x, y, ChessBoard.Height / 8, ChessBoard.Height / 8);

    }

    /// <summary>
    /// Draws the graphics of the given string board
    /// </summary>
    /// <param name="board">Represents the board as a 64 char string</param>
    public void DrawBoard(string board)
    {
      Bitmap imgPiece = null;
      Graphics boardGraph = ChessBoard.CreateGraphics();
      SolidBrush darkCell = new SolidBrush(Color.DarkGray);
      SolidBrush whiteCell = new SolidBrush(Color.White);

      char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
      TextBox txt = new TextBox();

      float cellDim = ChessBoard.Height / 8;
      boardGraph.DrawRectangle(new Pen(Color.White), 0, 0, ChessBoard.Height, ChessBoard.Height);
      Size cellSize = new Size(ChessBoard.Height / 8, ChessBoard.Height / 8);
      int indexBoard = 0;

      for (int r = 7; r >= 0; r--)
      {
        for (int c = 0; c < 8; c++)
        {
          if ((c + r) % 2 == 1)
            boardGraph.FillRectangle(darkCell, c * cellDim, r * cellDim, cellDim, cellDim);
          else
            boardGraph.FillRectangle(whiteCell, c * cellDim, r * cellDim, cellDim, cellDim);

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
            boardGraph.DrawImage(imgPiece, c * cellDim, r * cellDim);
          }
        }
      }
    }

    /// <summary>
    /// Loads the first view of the match
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void FormMatch_Load(object sender, EventArgs e)
    {
      grpPlayer1.Text = _controller.PlayerA.Name;
      grpPlayer2.Text = _controller.PlayerB.Name;
      txtScoreA.Text = _controller.PlayerA.Points.ToString();
      txtScoreB.Text = _controller.PlayerB.Points.ToString();
      txtTurns.Text = _controller.HistoryCount().ToString();
    }

    /// <summary>
    /// Loads the board from the match and calls DrawBoard
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void ChessBoard_Paint(object sender, PaintEventArgs e)
    {
      _board = _controller.GetBoard();
      DrawBoard(_board);
    }

    /// <summary>
    /// Calls Resign from GameController
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void BtnResign_Click(object sender, EventArgs e)
    {
      _controller.Resign();
    }

    /// <summary>
    /// Calls the DrawMatch from GameController
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void btnDraw_Click(object sender, EventArgs e)
    {
      _controller.DrawMatch();
    }

    /// <summary>
    /// Message pops when a player wants to call a draw match
    /// </summary>
    /// <param name="currentColor">The colour of the player that calls the draw</param>
    /// <returns>bool</returns>
    public bool DrawMessage(Colour currentColor)
    {
      string caption = "Draw !";
      string message;

      if (currentColor == Colour.White)
        message = _controller.PlayerA.Name + " want to make a draw. \n\n" + _controller.PlayerB.Name + " do you agree?";
      else
        message = _controller.PlayerB.Name + " want to make a draw. \n\n" + _controller.PlayerA.Name + " do you agree?";

      DialogResult dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

      return dialogResult == DialogResult.Yes;
    }

    /// <summary>
    /// Meesage pops when a player is in check
    /// </summary>
    /// <param name="currentColor">Colour of the player that is in check</param>
    public void CheckMessage(Colour currentColor)
    {
      string caption = "Check !";
      string message;

      if (currentColor == Colour.White)
        message = _controller.PlayerA.Name + " is in check.";
      else
        message = _controller.PlayerB.Name + " is in check.";

      DialogResult dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.OK);

    }

    /// <summary>
    /// Message posp when a player wins doing a checkmate
    /// </summary>
    /// <param name="winner">The winer of the match</param>
    public void VictoryMessage(Player winner)
    {

      // Initializes the variables to pass to the MessageBox.Show method.
      string message = "PLayer : " + winner.Name + " is the winner !";
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

    /// <summary>
    /// Message pops when the same board is made 3 times
    /// </summary>
    public void SameboardMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      string message = "You made the same board 3 times, it leads you to a draw !";
      string caption = "Draw !";
      MessageBoxButtons buttons = MessageBoxButtons.OK;
      DialogResult result;

      // Displays the MessageBox.
      result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        this.Close();
      }
    }

    /// <summary>
    /// Message pops when nothing happens after 50 turn
    /// </summary>
    public void FiftyturnsMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      string message = "You made 50 turns without any changes !";
      string caption = "Draw !";
      MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      MessageBox.Show(message, caption, buttons);
      
    }

    /// <summary>
    /// Message pops when there is a stalemate
    /// </summary>
    public void StalemateMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      string message = "You are in a stalemate !";
      string caption = "Stalemate !";
      MessageBoxButtons buttons = MessageBoxButtons.OK;
      DialogResult result;

      // Displays the MessageBox.
      result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        this.Close();
      }
    }

    /// <summary>
    /// Draws the number of the turns in the formMatch
    /// </summary>
    public void DrawTurns()
    {
      txtTurns.Text = _controller.HistoryCount().ToString();
    }
  }
}