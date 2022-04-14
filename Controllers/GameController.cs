using System;
using System.Collections.Generic;
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
      if (_selected.OutOfBounds)
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
      _formMatch.DrawTurns();

      // Check if the selected cell has a promotable piece
      if (_match.HasPromotable(target))
        {
            // Check if the target cell can promote
            if (_match.CanPromote(target))
            {
                _toPromote = target;
                _formPromotion = new FormPromotion(this, _match.CurrentPlayer == Colour.White ? Colour.Black : Colour.White);
                _formPromotion.ShowDialog();
                _formMatch.DrawBoard(_match.ExportBoard());
            }
        }

      if (_match.Checkmate())
      {
        if (_match.CurrentPlayer == Colour.Black)
        {
          _main.setWinner(_playerA, _playerB, true);
          _formMatch.VictoryMessage(_playerA);
        }
        else
        {
          _main.setWinner(_playerA, _playerB, false);
          _formMatch.VictoryMessage(_playerB);
        }
      }
      else if (_match.Check())
      {
        _formMatch.CheckMessage(_match.CurrentPlayer);
      }
      else if (_match.ExportHistory().Count >= 50)
      {
        _formMatch.FiftyturnsMessage();
      }
      else if (SameBoard())
      {
        _formMatch.SameboardMessage();
      }
      else if (_match.Stalemate())
      {
        _formMatch.StalemateMessage();
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
      
      List<string> history = _match.ExportHistory();
      int same = 0;
      for(int i = 0; i < history.Count; i++)
      {
        for (int j = i+1; j < history.Count; j++)
        {
          if (history[i] == history[j])
          {
            same++;
          }
        }
      }

      return same >= 3;
    }

    public void Promote(char piece)
    {
      _match.Promote(_toPromote, piece);
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