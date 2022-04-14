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

    public void DrawBoard(string board)
    {
      Bitmap imgPiece = null;
      Graphics boardGraph = ChessBoard.CreateGraphics();
      SolidBrush darkCell = new SolidBrush(Color.DarkGray);
      SolidBrush whiteCell = new SolidBrush(Color.White);

      char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
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

    private void FormMatch_Load(object sender, EventArgs e)
    {
      grpPlayer1.Text = _controller.PlayerA.Name;
      grpPlayer2.Text = _controller.PlayerB.Name;
      txtScoreA.Text = _controller.PlayerA.Points.ToString();
      txtScoreB.Text = _controller.PlayerB.Points.ToString();
      txtTurns.Text = _controller.HistoryCount().ToString();
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
      _controller.Draw();
    }

    public bool DrawMessage(string resigner, string opponent)
    {
      const string caption = "Draw !";
      var message = resigner + " want to make a draw. \n\n" + opponent + " do you agree?";

      var dialogResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
      return dialogResult == DialogResult.Yes;
    }

    public void CheckMessage(string player)
    {
      var message = "Player: " + player + " is in check";
      const string caption = "Check !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        Close();
      }
    }

    public void VictoryMessage(string winner)
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      var message = "Player : " + winner + " is the winner !";
      const string caption = "Check Mate !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        Close();
      }
    }

    public void SameBoardMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You made the same board 3 times, it leads you to a draw !";
      const string caption = "Draw !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        Close();
      }
    }

    public void FiftyTurnsMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You made 50 turns without any changes !";
      const string caption = "Draw !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;


      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        Close();
      }
    }

    public void StalemateMessage()
    {
      // Initializes the variables to pass to the MessageBox.Show method.
      const string message = "You are in a stalemate !";
      const string caption = "Stalemate !";
      const MessageBoxButtons buttons = MessageBoxButtons.OK;

      // Displays the MessageBox.
      var result = MessageBox.Show(message, caption, buttons);
      if (result == DialogResult.OK)
      {
        Close();
      }
    }

    public void DrawTurns()
    {
      txtTurns.Text = _controller.HistoryCount().ToString();
    }
  }
}