using System.Linq;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class GameController
  {
    private readonly Chess _main;
    private readonly Match _match;
    private readonly Player _playerA;
    private readonly Player _playerB;
    private readonly FormMatch _view;
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
      _view = new FormMatch(this);
      _selected = new Position(-1, -1);
      _playerA = a;
      _playerB = b;
      _view.Show();
    }

    public GameController(Chess main, Player a, Player b)
    {
      _match = new Match();
      _main = main;
      _view = new FormMatch(this);
      _selected = new Position(-1, -1);
      _playerA = a;
      _playerB = b;
      _view.Show();
    }

    public Player PlayerA => _playerA;
    public Player PlayerB => _playerB;

    public void Selection(Position cell)
    {
      if (_selected.OutOfBounds)
      {
        if (!_match.ValidSelection(cell, true)) return;
        _view.DrawBoard(_match.ExportBoard());
        _view.DrawSelection(cell);
        _selected = cell;
      }
      else if (_match.ValidSelection(cell, false))
      {
        Turn(cell);
      }
      else
      {
        _view.DrawBoard(_match.ExportBoard());
        _view.DrawSelection(cell);
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
      _view.DrawBoard(_match.ExportBoard());
      _view.DrawTurns();

      // Check if the selected cell has a promotable piece
      if (_match.HasPromotable(target))
      {
        // Check if the target cell can promote
        if (_match.CanPromote(target))
        {
          _toPromote = target;
          var promotionView =
            new FormPromotion(this, _match.CurrentPlayer == Colour.White ? Colour.Black : Colour.White);
          promotionView.ShowDialog();
          _view.DrawBoard(_match.ExportBoard());
        }
      }

      if (_match.Checkmate())
      {
        if (_match.CurrentPlayer == Colour.Black)
        {
          _main.SetWinner(_playerA, _playerB, true);
          _view.VictoryMessage(_playerA.Name);
        }
        else
        {
          _main.SetWinner(_playerA, _playerB, false);
          _view.VictoryMessage(_playerB.Name);
        }
      }
      else if (_match.Check())
      {
        _view.CheckMessage(_match.CurrentPlayer == Colour.White ? _playerA.Name : _playerB.Name);
      }
      else if (_match.ExportHistory().Count >= 50)
      {
        _view.FiftyTurnsMessage();
      }
      else if (SameBoard())
      {
        _view.SameBoardMessage();
      }
      else if (_match.Stalemate())
      {
        _view.StalemateMessage();
      }
    }

    public string GetBoard()
    {
      return _match.ExportBoard();
    }

    public int HistoryCount()
    {
      return _match.ExportHistory().Count;
    }

    private bool SameBoard()
    {
      var history = _match.ExportHistory();
      return history.GroupBy(x => x).Any(g => g.Count() >= 3);
    }

    public void Promote(char piece)
    {
      _match.Promote(_toPromote, piece);
      _toPromote = new Position(-1, -1);
    }

    public void Resign()
    {
      if (_match.CurrentPlayer == Colour.White)
        _main.SetWinner(_playerA, _playerB, false);
      else
        _main.SetWinner(_playerA, _playerB, true);

      _view.Close();
    }

    public void Draw()
    {
      var resigner = _match.CurrentPlayer == Colour.White ? _playerA : _playerB;
      var opponent = _match.CurrentPlayer == Colour.White ? _playerB : _playerA;
      if (_view.DrawMessage(resigner.Name, opponent.Name))
      {
        _view.Close();
      }
    }
  }
}