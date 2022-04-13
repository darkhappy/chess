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
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQKBNR");

      //test boards :
      //_board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQKBNR");
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
      if (!_board.ValidMove(origin, target))
        return false;
      if (!_board.SelfChecks(origin, target))
        return false;

      if (!_board.HasEssential(origin))
        return true;

      if (!Board.CastlingMove(origin, target))
        return true;

      return _board.CanCastle(origin, target);
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

    public bool CanPromote(Position cell)
    {
      return _board.IsInPromotableCell(cell, _current);
    }

    public bool Check()
    {
      var attackers = _board.GetAssailants(_current);
      return attackers.Count > 0;
    }

    public bool Checkmate()
    {
      var attackers = _board.GetAssailants(_current);
      if (attackers.Count == 0)
        return false;

      // Check if the king can move out of check
      if (!_board.CanAttackAroundEssential(_current))
        return false;

      if (attackers.Count != 1) return true;

      var ally = _current == Colour.White ? Colour.Black : Colour.White;
      if (_board.GetAttackingPieces(ally, attackers[0]).Count != 0)
        return false;

      if (_board.CanBlock(attackers[0], _board.GetEssentialPiece(_current)))
        return false;

      return true;
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