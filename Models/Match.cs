using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Match
  {
    private Board _board;
    private Colour _current;
    private List<string> _history;

    public Match()
    {
      _current = Colour.White;
      _history = new List<string>();
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQK..R");
      //_board = new Board("rnbqk..rppp.pppp................................PP..P..PRNBQK..R");

      /*
      _board = new Board(
        "........" +
        "........" +
        "........" +
        "........" +
        "........" +
        "........" +
        "........" +
        "........");
      */
      //test boards :
      //_board = new Board("........PPP..........................................ppp........");
      //_board = new Board(".......K.....q..................................p..............k");
      //_board = new Board("rnbqkbnr.ppp...p............p.p....PP....P......P....PP.RNBQKBNR");
      //_board = new Board("r.b.k.n..pp.p..........P........p..qp...P.P......P..K...RNB..Br.");
    

    //_board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQKBNR");

          //test boards :
          //_board = new Board("........PPP..........................................ppp........");
          //_board = new Board(".......K.....q..................................p..............k");
          //_board = new Board("rnbqkbnr.ppp...p............p.p....PP....P......P....PP.RNBQKBNR");
          //_board = new Board("r.b.k.n..pp.p..........P........p..qp...P.P......P..K...RNB..Br.");
          // Casstle tests
          //  _board = new Board("r...k..r........................................................");
          //_board = new Board("r...k..r................................................R...K..R");
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
      _current = _current == Colour.White ? Colour.Black : Colour.White;

      if (_board.CantGoBack(origin) || _board.IsCapture(origin, target))
      {
        _history.Clear();
      }

      _board.MoveCellTo(origin, target);
      _history.Add(ExportBoard());
    }

    public bool ValidSelection(Position cell, bool firstClick)
    {
      if (firstClick)
        return _board.SameColour(cell, _current);
      return !_board.SameColour(cell, _current);
    }

    public void Promote(Position cell, string piece)
    {
      if (_current == Colour.White)
        piece = piece.ToUpper();

      _board.ChangeCellTo(cell, piece[0]);
    }

    public bool HasPromotable(Position cell)
    {
      return _board.HasPromotable(cell);
    }

    public bool CanPromote(Position cell)
    {
      return _board.IsPromotable(cell);
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
      return !this.Check() && !_board.TeamCanMove(_current);
    }

    public bool Castle()
    {
      throw new NotImplementedException();
    }

    public void ChangeBoard(string board)
    {
      _board = new Board(board);
    }
  }
}