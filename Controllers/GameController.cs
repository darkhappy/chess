using System.Linq;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  /// <summary>
  /// Represent the game controller of the chess game
  /// </summary>
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

    /// <summary>
    /// Initialize the PlayerController with its controller and the two players
    /// </summary>
    /// <param name="main">Chess controlller</param>
    /// <param name="a">Player A</param>
    /// <param name="b">Player B</param>
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

    /// <summary>
    /// Getter of PlayerA
    /// </summary>
    public Player PlayerA => _playerA;

    /// <summary>
    /// Getter of PlayerB
    /// </summary>
    public Player PlayerB => _playerB;

    /// <summary>
    /// Make all the actions when selecting a cell
    /// </summary>
    /// <param name="cell">The selected cell</param>
    public void Selection(Position cell)
    {
      if (_selected.OutOfBounds)
      {
        if (!_match.ValidSelection(cell, true)) return;
        _view.DrawBoard(_match.Board);
        _view.DrawSelection(cell);
        _selected = cell;
      }
      else if (_match.ValidSelection(cell, false))
      {
        Turn(cell);
      }
      else
      {
        _view.DrawBoard(_match.Board);
        _view.DrawSelection(cell);
        _selected = cell;
      }
    }

    /// <summary>
    /// Make all actions for the second selection
    /// </summary>
    /// <param name="target">The cell you want to make your move on</param>
    private void Turn(Position target)
    {
      // Verify if the match is valid
      if (!_match.ValidTurn(_selected, target)) return;

      // Make the turn
      _match.MakeTurn(_selected, target);
      _selected = new Position(-1, -1);
      _view.DrawBoard(_match.Board);
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
          _view.DrawBoard(_match.Board);
        }
      }

      //Check if the move provoked a check situation
      if (_match.Check())
      {
        //Check if the situation is a checkmate
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
        else 
        {
          _view.CheckMessage(_match.CurrentPlayer == Colour.White ? _playerA.Name : _playerB.Name);
        }
      }
      //Check if the move provoked a stalemate
      else if (_match.Stalemate())
      {
        _view.StalemateMessage();
      }
      //Check if it has been fifty turns without anything happening
      else if (_match.History.Count >= 50)
      {
        _view.FiftyTurnsMessage();
      }
      //Check if the same bord has been repeted 3 times
      else if (SameBoard())
      {
        _view.SameBoardMessage();
      }
    }

    /// <summary>
    /// Get the current board in a string form
    /// </summary>
    /// <returns>The bord in string</returns>
    public string GetBoard()
    {
      return _match.Board;
    }

    /// <summary>
    /// Get the number of turns without anything happening 
    /// </summary>
    /// <returns>The number of turn saved in the history</returns>
    public int HistoryCount()
    {
      return _match.History.Count;
    }

    /// <summary>
    /// Check if the same bord appeared 3 times
    /// </summary>
    /// <returns>Whether the same bord appeared 3 times or not </returns>
    private bool SameBoard()
    {
      var history = _match.History;
      return history.GroupBy(x => x).Any(g => g.Count() >= 3);
    }

    /// <summary>
    /// Handle the promotion of a piece
    /// </summary>
    /// <param name="piece">The char representing the promotion piece</param>
    public void Promote(char piece)
    {
      _match.Promote(_toPromote, piece);
      _toPromote = new Position(-1, -1);
    }

    /// <summary>
    /// handle the resign of the players
    /// </summary>
    public void Resign()
    {
      if (_match.CurrentPlayer == Colour.White)
        _main.SetWinner(_playerA, _playerB, false);
      else
        _main.SetWinner(_playerA, _playerB, true);

      _view.Close();
    }

    /// <summary>
    /// Handle the draw case
    /// </summary>
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