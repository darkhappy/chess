using System;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class GameController
  {
    private int _fiftyTurns;
    private Chess _main;
    private Match _match;
    private Player _playerA;
    private Player _playerB;
    private Position _selected;
    private FrmMatch _formMatch;

    public GameController(Player a, Player b)
    {
      _match = new Match();
      _formMatch = new FrmMatch(this);
      _selected = new Position(-1, -1);
      _playerA = a;
      _playerB = b;
      _formMatch.Show();
    }

    public void Selection(Position cell)
    {
      if (_selected.X == -1)
      {
        if (_match.ValidSelection(cell, true))
        {
          _formMatch.DrawBoard(_match.ExportBoard());
          _formMatch.DrawSelection(cell);
          _selected = cell;
        }
      }
      else if (_match.ValidSelection(cell, false))
      {
        this.Turn(cell);

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
      if (_match.ValidTurn(_selected, target)) {
        _match.MakeTurn(_selected, target);
        _selected = new Position(-1, -1);
        _formMatch.DrawBoard(_match.ExportBoard());

        if (_match.Checkmate())
        {
          _formMatch.VictoryMessage();
        }
      }
    }

    public string GetBoard()
    {
      return _match.ExportBoard();
    }

    public Player PLayerA => _playerA;
    public Player PLayerB => _playerB;

    private void Stalemate()
    {
      throw new NotImplementedException();
    }

    private void Rules()
    {
      throw new NotImplementedException();
    }

    private void Castle()
    {
      throw new NotImplementedException();
    }
    public void Resign()
    {
      //update winner player
      _formMatch.Close();
    }

    public void DrawMatch()
    {
      _formMatch.Close();
    }
  }
}