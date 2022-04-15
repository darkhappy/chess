using System;
using System.Drawing;
using System.Windows.Forms;
using chess.Controllers;
using chess.Models;
using chess.Properties;

namespace chess.Views
{
  public partial class FormMatch : Form
  {
    private readonly GameController _controller;
    private string _board;

    /// <summary>
    ///   Initializes the FormMatch when called with new
    /// </summary>
    /// <param name="controller">The cell containing the moving piece.</param>
    /// <returns>Returns a new instance of FormMatch</returns>
    public FormMatch(GameController controller)
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
      var props = (MouseEventArgs) e;
      var image = (Panel) sender;
      var x = props.X / (image.Height / 8);
      var y = Math.Abs(props.Y - image.Height) / (image.Height / 8);

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
      var boardGraph = ChessBoard.CreateGraphics();
      var x = pos.X * (ChessBoard.Height / 8);
      var y = Math.Abs(pos.Y - 7) * (ChessBoard.Height / 8);

      boardGraph.DrawRectangle(new Pen(Color.CadetBlue, 4.0F), x, y, ChessBoard.Height / 8, ChessBoard.Height / 8);
    }

    /// <summary>
    ///   Draws the graphics of the given string board
    /// </summary>
    /// <param name="board">Represents the board as a 64 char string</param>
    public void DrawBoard(string board)
    {
      Bitmap? imgPiece = null;
      var boardGraph = ChessBoard.CreateGraphics();
      var darkCell = new SolidBrush(Color.DarkGray);
      var whiteCell = new SolidBrush(Color.White);

      var cellDim = ChessBoard.Height / 8;
      boardGraph.DrawRectangle(new Pen(Color.White), 0, 0, ChessBoard.Height, ChessBoard.Height);
      var cellSize = new Size(ChessBoard.Height / 8, ChessBoard.Height / 8);
      var indexBoard = 0;

      for (var r = 7; r >= 0; r--)
      {
        for (var c = 0; c < 8; c++)
        {
          boardGraph.FillRectangle((c + r) % 2 == 1 ? darkCell : whiteCell, c * cellDim, r * cellDim, cellDim, cellDim);

          imgPiece = board[indexBoard++] switch
          {
            'P' => new Bitmap(Resources.b_pawn),
            'p' => new Bitmap(Resources.w_pawn),
            'N' => new Bitmap(Resources.b_knight),
            'n' => new Bitmap(Resources.w_knight),
            'R' => new Bitmap(Resources.b_rook),
            'r' => new Bitmap(Resources.w_rook),
            'B' => new Bitmap(Resources.b_bishop),
            'b' => new Bitmap(Resources.w_bishop),
            'Q' => new Bitmap(Resources.b_queen),
            'q' => new Bitmap(Resources.w_queen),
            'K' => new Bitmap(Resources.b_king),
            'k' => new Bitmap(Resources.w_king),
            _ => null
          };

          if (imgPiece == null) continue;

          imgPiece = new Bitmap(imgPiece, cellSize);
          boardGraph.DrawImage(imgPiece, c * cellDim, r * cellDim);
        }
      }
    }

    /// <summary>
    ///   Loads the first view of the match
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
    ///   Loads the board from the match and calls DrawBoard
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void ChessBoard_Paint(object sender, PaintEventArgs e)
    {
      _board = _controller.GetBoard();
      DrawBoard(_board);
    }

    /// <summary>
    ///   Calls Resign from GameController
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void BtnResign_Click(object sender, EventArgs e)
    {
      _controller.Resign();
    }

    /// <summary>
    ///   Calls the DrawMatch from GameController
    /// </summary>
    /// <param name="sender">Reprensent the form itself</param>
    /// <param name="e">Represents the events we have to listen to</param>
    private void btnDraw_Click(object sender, EventArgs e)
    {
      _controller.Draw();
    }

    /// <summary>
    ///   Message pops when a player wants to call a draw match
    /// </summary>
    /// <param name="currentColor">The colour of the player that calls the draw</param>
    /// <returns>bool</returns>
    public bool DrawMessage(string resigner, string opponent)
    {
      const string caption = "Draw !";
      var message = resigner + " want to make a draw. \n\n" + opponent + " do you agree?";

      var dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
      return dialogResult == DialogResult.Yes;
    }

    /// <summary>
    ///   Meesage pops when a player is in check
    /// </summary>
    /// <param name="currentColor">Colour of the player that is in check</param>
    public void CheckMessage(string player)
    {
      var message = "Player: " + player + " is in check";
      const string caption = "Check !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK) Close();
    }

    /// <summary>
    ///   Message posp when a player wins doing a checkmate
    /// </summary>
    /// <param name="winner">The winer of the match</param>
    public void VictoryMessage(string winner)
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      var message = "Player : " + winner + " is the winner !";
      const string caption = "Check Mate !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK) Close();
    }

    /// <summary>
    ///   Message pops when the same board is made 3 times
    /// </summary>
    public void SameBoardMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You made the same board 3 times, it leads you to a draw !";
      const string caption = "Draw !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK) Close();
    }

    /// <summary>
    ///   Message pops when nothing happens after 50 turn
    /// </summary>
    public void FiftyTurnsMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You made 50 turns without any changes !";
      const string caption = "Draw !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;


      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK) Close();
    }

    /// <summary>
    ///   Message pops when there is a stalemate
    /// </summary>
    public void StalemateMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You are in a stalemate !";
      const string caption = "Stalemate !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK) Close();
    }

    /// <summary>
    ///   Draws the number of the turns in the formMatch
    /// </summary>
    public void DrawTurns()
    {
      txtTurns.Text = _controller.HistoryCount().ToString();
    }
  }
}