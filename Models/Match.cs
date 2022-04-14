using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a chess match.
  /// </summary>
  public class Match
  {
    /// <summary>
    ///   Represents the history of the match.
    /// </summary>
    /// <remarks>If a capture or a move that isn't undoable is performed, this history is cleared.</remarks>
    private readonly List<string> _history;

    /// <summary>
    ///   Represents the board of the match.
    /// </summary>
    private Board _board;

    /// <summary>
    ///   Represents which colour is currently playing.
    /// </summary>
    private Colour _current;

    /// <summary>
    ///   Initializes a new instance of the <see cref="T:chess.Models.Match" /> class with the starting
    ///   <see cref="Models.Board" />.
    /// </summary>
    public Match()
    {
      _current = Colour.White;
      _history = new List<string>();
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQKBNR");
      //test boards :
      //_board = new Board("rnbqkbnrpppp.pp...........B.p..p....P......P....PPP.PPPPRN.QKBNR"); //no idea
      //_board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBQKBNR"); //En passant
      //_board = new Board("........PPP..........................................ppp........"); //Promotion
      //_board = new Board(".......K.....q..................................p..............k"); //Promotion + Math / Promotion + Pat
      //_board = new Board("r.b.k.n..pp.p..........P........p..qp...P.P......P..K...RNB..Br."); //Echec
      //_board = new Board("r...k..r................................................R...K..R"); //Castle
    }

    /// <inheritdoc cref="_current" />
    public Colour CurrentPlayer => _current;

    /// <summary>
    ///   Exports the current <see cref="Board" /> to a string.
    /// </summary>
    /// <value>A string representation of the chess board.</value>
    public string Board => _board.ToString();

    /// <inheritdoc cref="_history" />
    public List<string> History => _history;

    /// <summary>
    ///   Evaluates if a move is valid.
    /// </summary>
    /// <seealso cref="Models.Board.ValidMove(Position, Position)" />
    /// <seealso cref="Models.Board.SelfChecks(Position, Position)" />
    /// <seealso cref="Models.Board.CanCastle(Position, Position)" />
    /// <param name="origin">The origin of the move.</param>
    /// <param name="target">The target of the move.</param>
    /// <returns>True if the piece can move there without any issues, false otherwise.</returns>
    public bool ValidTurn(Position origin, Position target)
    {
      // Basic verification
      if (!_board.ValidMove(origin, target))
        return false;
      if (!_board.SelfChecks(origin, target))
        return false;

      // If the origin piece is a king, handle castles
      if (!_board.HasEssential(origin))
        return true;

      if (!Models.Board.CastlingMove(origin, target))
        return true;

      return _board.CanCastle(origin, target);
    }

    /// <summary>
    ///   Performs a move on the <see cref="Board" />.
    /// </summary>
    /// <param name="origin">The origin of the move.</param>
    /// <param name="target">The target of the move.</param>
    public void MakeTurn(Position origin, Position target)
    {
      _current = _current == Colour.White ? Colour.Black : Colour.White;

      // Handle history
      if (_board.CantGoBack(origin) || _board.IsCapture(origin, target)) _history.Clear();

      _board.MoveCellTo(origin, target);
      _history.Add(Board);
    }

    /// <summary>
    ///   <para>
    ///     Evaluates if the selection is valid.
    ///   </para>
    ///   <para>
    ///     On the first move, the selection is valid if the piece is of the current player. On the second move, the selection
    ///     is valid if the piece is of the enemy colour, or if it is empty.
    ///   </para>
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <param name="firstClick">Whether this is the first or second click.</param>
    /// <returns></returns>
    public bool ValidSelection(Position cell, bool firstClick)
    {
      if (firstClick)
        return _board.SameColour(cell, _current);
      return !_board.SameColour(cell, _current);
    }

    /// <summary>
    ///   Promotes a cell to a new cell.
    /// </summary>
    /// <param name="cell">The cell to promote.</param>
    /// <param name="cPiece">The new piece.</param>
    public void Promote(Position cell, char cPiece)
    {
      if (_current == Colour.White)
        cPiece = char.ToUpper(cPiece);

      _board.ChangeCellTo(cell, cPiece);
    }

    /// <summary>
    ///   Evaluates if the cell has a promotable piece.
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <returns>True if the piece is promotable, false otherwise.</returns>
    public bool HasPromotable(Position cell)
    {
      return _board.HasPromotable(cell);
    }

    /// <summary>
    ///   Evaluates if the cell can be promoted.
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <returns>True if the piece can be promoted, false otherwise.</returns>
    public bool CanPromote(Position cell)
    {
      return _board.IsPromotable(cell);
    }

    /// <summary>
    ///   Evaluates if the current colour is in check.
    /// </summary>
    /// <returns>True if the current colour is in check, false otherwise.</returns>
    public bool Check()
    {
      var attackers = _board.GetAssailants(_current);
      return attackers.Count > 0;
    }

    /// <summary>
    ///   <para>
    ///     Evaluates if the current colour is in checkmate.
    ///   </para>
    ///   <para>
    ///     A checkmate is a king that is being attacked and cannot move out the way. No other pieces can move between the king
    ///     and the attacker, and no other piece can move to the attacker.
    ///   </para>
    /// </summary>
    /// <returns>True if the current colour is in checkmate, false otherwise.</returns>
    public bool Checkmate()
    {
      var attackers = _board.GetAssailants(_current);
      if (attackers.Count == 0)
        return false;

      // Check if the king can move out of check
      if (!_board.CanAttackAroundEssential(_current))
        return false;

      // If there are more than one attacker, then we don't need to check the other cases, as there is no way to block or attack two pieces.
      if (attackers.Count != 1) return true;

      var ally = _current == Colour.White ? Colour.Black : Colour.White;
      if (_board.GetAttackingPieces(ally, attackers[0]).Count != 0)
        return false;

      if (_board.CanBlock(attackers[0], _board.GetEssentialPiece(_current)))
        return false;

      return true;
    }

    /// <summary>
    ///   <para>
    ///     Evaluates if the current colour is in stalemate.
    ///   </para>
    ///   <para>
    ///     It's considered stalemate if the current colour is not in check and there are no legal moves.
    ///   </para>
    /// </summary>
    /// <returns></returns>
    public bool Stalemate()
    {
      return !Check() && !_board.TeamCanMove(_current);
    }

    /// <summary>
    ///   For testing purposes, this changes the board to a new board.
    /// </summary>
    /// <param name="board">The new board.</param>
    public void ChangeBoard(string board)
    {
      _board = new Board(board);
    }
  }
}