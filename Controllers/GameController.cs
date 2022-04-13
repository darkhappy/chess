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
    private int _fiftyTurns;
    private Position _selected;

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
      _fiftyTurns = 0;
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

    private void Turn(Position target) { 
      if (_match.ValidTurn(_selected, target)) {
        _match.MakeTurn(_selected, target);
        _selected = new Position(-1, -1);
        _formMatch.DrawBoard(_match.ExportBoard());
        ++_fiftyTurns;
        _formMatch.DrawTurns();

        if (_match.Checkmate())
        {

          if (_match.CurrentPlayer == Colour.White)
            _main.setWinner(_playerA, _playerB, true);
          else
            _main.setWinner(_playerA, _playerB, false);
        }
        else if (_fiftyTurns >= 50 || this.SameBoard())
        {
          this.DrawMatch();
        }
      }
    }
    

    public string GetBoard()
    {
      return _match.ExportBoard();
    }
    public bool SameBoard()
    {
      
      List<string> history = _match.ExportHistory();
      int same = 0;
      for(int i = 0; i < history.Count; i++)
      {
        for (int j = i; j < history.Count; j++)
        {
          if (history[i] == history[j+1])
          {
            ++same;
          }
        }
      }

      return same >= 3;
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

    public bool Check()
    {
      return _match.Check();
    }

    public int Turns => _fiftyTurns;
  }
}