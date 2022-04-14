using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class GameController
  {
    private FrmMatch _formMatch;
    private FormPromotion _formPromotion;
    private Chess _main;
    private Match _match;
    private Player _playerA;
    private Player _playerB;
    private Position _selected;
    private Position _toPromote;

    /// <summary>
    /// For testing purposes.
    /// </summary>
    /// <param name="a">Player A</param>
    /// <param name="b">Player B</param>
    public GameController(Player a, Player b)
    {
      _match = new Match();
      _formMatch = new FrmMatch(this);
      _selected = new Position(-1, -1);
      _playerA = a;
      _playerB = b;
      _formMatch.Show();
    }

    public GameController(Chess main, Player a, Player b)
    {
      _match = new Match();
      _main = main;
      _formMatch = new FrmMatch(this);
      _selected = new Position(-1, -1);
      _playerA = a;
      _playerB = b;
      _formMatch.Show();
    }

    public Player PlayerA => _playerA;
    public Player PlayerB => _playerB;

    public void Selection(Position cell)
    {
      if (_selected.X == -1)
      {
        if (!_match.ValidSelection(cell, true)) return;
        _formMatch.DrawBoard(_match.ExportBoard());
        _formMatch.DrawSelection(cell);
        _selected = cell;
      }
      else if (_match.ValidSelection(cell, false))
      {
        Turn(cell);
      }
      else
      {
        _formMatch.DrawBoard(_match.ExportBoard());
        _formMatch.DrawSelection(cell);
        _selected = cell;
      }
    }

    private void Turn(Position target)
    {
      // Verify if the match is valid
      if (!_match.ValidTurn(_selected, target)) return;

      // Make the turn
      _match.MakeTurn(_selected, target);
      _selected = new Position(-1, -1);
      _formMatch.DrawBoard(_match.ExportBoard());

      // Check if the selected cell has a promotable piece
      if (_match.HasPromotable(target))
      {
        // Check if the target cell can promote
        if (_match.CanPromote(target))
        {
          _toPromote = target;
          _formPromotion = new FormPromotion(this);
          _formPromotion.ShowDialog();
          _formMatch.DrawBoard(_match.ExportBoard());
        }
      }

      // Check for check
      if (_match.Check())
        // Check for checkmate
        if (_match.Checkmate())
        {
          _formMatch.VictoryMessage();
          _main.setWinner(_playerA, _playerB, _match.CurrentPlayer == Colour.White);
        }
        else
        {
          // Show that they are in check
        }
      else
      {
        // Check for stalemates (50 turns without a significant move, 3 of the same board, no one can move)
      }
    }

    public string GetBoard()
    {
      return _match.ExportBoard();
    }

    public void Promote(string piece)
    {
      switch (piece)
      {
        case "Queen":
          _match.Promote(_toPromote, "q");
          break;
        case "Bishop":
          _match.Promote(_toPromote, "b");
          break;
        case "Knight":
          _match.Promote(_toPromote, "n");
          break;
        case "Rook":
          _match.Promote(_toPromote, "r");
          break;
      }

      _toPromote = new Position(-1, -1);
    }

    public void Resign()
    {
      if (_match.CurrentPlayer == Colour.White)
        _main.setWinner(_playerA, _playerB, false);
      else
        _main.setWinner(_playerA, _playerB, true);

      _formMatch.Close();
    }

    public void DrawMatch()
    {
      if (_formMatch.DrawMessage(_match.CurrentPlayer))
      {
        _formMatch.Close();
      }
    }
  }
}