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

    FormMatch _formMatch;

    public GameController(Player a, Player b)
    {
      _match = new Match();
      _formMatch = new FormMatch(this);
      _selected = new Position(-1, -1);
      _formMatch.Show();
    }

    public void Selection(Position cell)
    {
      if (_selected.X == -1)
      {
        if (_match.ValidSelection(cell, true))
        {
          _formMatch.DrawSelection(cell);
          _selected = cell;
        }
      }
      else if (_match.ValidSelection(cell, false))
      {
        //this.Turn(cell);

      }
      else
      {
        _formMatch.DrawSelection(cell);
        _selected = cell;
      }

    }

    private void Turn(Position target)
    {
      throw new NotImplementedException();
    }

    public string GetBoard()
    {
      return _match.ExportBoard();
    }

    private void Stalemate()
    {
      throw new NotImplementedException();
    }

    private void Checkmate()
    {
      throw new NotImplementedException();
    }

    private void Check()
    {
      throw new NotImplementedException();
    }

    private void Rules()
    {
      throw new NotImplementedException();
    }

    public void Resign()
    {
      throw new NotImplementedException();
    }

    private void Castle()
    {
      throw new NotImplementedException();
    }
  }
}