using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Match
  {
    private Board _board;
    private Colour _current;
    private List<string> _history;
    private int _turnCount;

    public Match()
    {
      _current = Colour.White;
      _history = new List<string>();
      _turnCount = 0;
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBKQBNR");

    }

    public Colour CurrentPlayer => _current;

    public string ExportBoard()
    {
      return _board.ToString();
    }

    public List<string> ExportHistory()
    {
      return _history;
    }

    public bool ValidTurn(Position origin, Position target)
    {
      return _board.ValidMove(origin, target) && _board.SelfChecks(origin, target);
    }

    public void MakeTurn(Position origin, Position target)
    {
      _board.MoveCellTo(origin, target);
      _current = _current == Colour.White ? Colour.Black : Colour.White;
      _turnCount++;
    }

    public bool ValidSelection(Position cell, bool firstClick)
    {
      if (firstClick)
        return _board.SameColour(cell, _current);
      return !_board.SameColour(cell, _current);
    }

    public bool HasPromotable(Position cell)
    {
      return _board.HasPromotable(cell);
    }

    public bool Check()
    {
      var attackers = _board.GetAssailants(_current);
      return attackers.Count > 0;
    }

    public bool Checkmate()
    {
      throw new NotImplementedException();
    }

    public bool Stalemate()
    {
      throw new NotImplementedException();
    }

    public bool Castle()
    {
      throw new NotImplementedException();
    }

    public List<int> GetAssailants(int cell)
    {
      throw new NotImplementedException();
    }

    public void ChangeBoard(string board)
    {
      _board = new Board(board);
    }
  }
}