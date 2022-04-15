using System;
using System.Collections.Generic;
using System.Linq;

namespace chess.Models
{
  /// <summary>
  ///   Represents a chess board and contains all the logic used to manipulate the board.
  /// </summary>
  public class Board
  {
    /// <summary>
    ///   <para>
    ///     Represents the position of a possible en passant capture.
    ///   </para>
    ///   <para>
    ///     This is usually set to null, except when a pawn moves by two, in which case this variable is set to the position
    ///     behind the pawn.
    ///   </para>
    ///   <example>
    ///     If a pawn moves from A2 to A4, this variable is set to A3.
    ///   </example>
    /// </summary>
    private Position? _canBeEnPassant;

    /// <summary>
    ///   Contains all the cells on the board.
    /// </summary>
    private Cell[] _cells;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Board" /> class with an empty board.
    /// </summary>
    public Board()
    {
      _cells = new Cell[64];
      GenerateBoard("................................................................");
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="Board" /> class with a specified board.
    /// </summary>
    /// <param name="board">String that represents the board to generate.</param>
    public Board(string board)
    {
      _cells = new Cell[64];
      GenerateBoard(board);
    }

    /// <summary>
    ///   Generates the board with the specified string.
    /// </summary>
    /// <param name="board">
    ///   String that represents the board to generate.
    /// </param>
    /// <remarks>
    ///   The string must be 64 characters long. Additionally, the characters must be as follows:
    ///   <list type="bullet">
    ///     <item>
    ///       p/P for pawns
    ///     </item>
    ///     <item>
    ///       r/R for rooks
    ///     </item>
    ///     <item>
    ///       n/N for knights
    ///     </item>
    ///     <item>
    ///       b/B for bishops
    ///     </item>
    ///     <item>
    ///       q/Q for queens
    ///     </item>
    ///     <item>
    ///       k/K for kings
    ///     </item>
    ///     <item>
    ///       . for an empty cell
    ///     </item>
    ///   </list>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the string is not 64 characters long.</exception>
    private void GenerateBoard(string board)
    {
      if (board.Length != 64) throw new ArgumentOutOfRangeException(board, "Board must be 64 characters long.");

      var array = board.ToCharArray();
      for (var i = 0; i < array.Length; i++) _cells[i] = new Cell(array[i]);
    }

    /// <summary>
    ///   Returns the current board as a string.
    /// </summary>
    /// <returns>
    ///   String representation of the board.
    /// </returns>
    public override string ToString()
    {
      return _cells.Aggregate("", (current, t) => current + t);
    }

    /// <summary>
    ///   Evaluates if the <c>origin</c> cell can move to the <c>target</c> cell, taking into account collisions.
    /// </summary>
    /// <param name="origin">The cell that is moving.</param>
    /// <param name="target">The target of the <c>origin</c> cell.</param>
    /// <param name="moves">List containing all the moves that the <c>origin</c> cell can do.</param>
    /// <returns>True if the origin cell can move to the target cell, false otherwise.</returns>
    private bool Collision(Position origin, Position target, List<Position> moves)
    {
      if (!_cells[ConvertToIndex(origin)].HasCollision())
        return true;

      var toCheck = PositionsBetween(origin, target, moves);
      return toCheck.All(position => _cells[ConvertToIndex(position)].IsEmpty());
    }

    /// <summary>
    ///   Filters a list of positions to only those that are between the <c>origin</c> and <c>target</c> cells.
    /// </summary>
    /// <param name="origin">The cell that is moving.</param>
    /// <param name="target">The target of the <c>origin</c> cell.</param>
    /// <param name="allPositions">List containing all the moves that the <c>origin</c> cell can do.</param>
    /// <returns>List containing all the positions between the <c>origin</c> and <c>target</c> cells.</returns>
    private static List<Position> PositionsBetween(Position origin, Position target, List<Position> allPositions)
    {
      var positionsBetween = new List<Position>();

      // Verifications
      bool SameRow(Position pos)
      {
        return pos.X == origin.X;
      }

      bool AboveRow(Position pos)
      {
        return pos.Y > origin.Y && pos.Y < target.Y;
      }

      bool BelowRow(Position pos)
      {
        return pos.Y < origin.Y && pos.Y > target.Y;
      }

      bool SameColumn(Position pos)
      {
        return pos.Y == origin.Y;
      }

      bool LeftColumn(Position pos)
      {
        return pos.X < origin.X && pos.X > target.X;
      }

      bool RightColumn(Position pos)
      {
        return pos.X > origin.X && pos.X < target.X;
      }

      if (origin.X == target.X)
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => SameRow(pos) && AboveRow(pos))
            : allPositions.Where(pos => SameRow(pos) && BelowRow(pos))
        );
      else if (origin.Y == target.Y)
        positionsBetween.AddRange(
          origin.X < target.X
            ? allPositions.Where(pos => SameColumn(pos) && RightColumn(pos))
            : allPositions.Where(pos => SameColumn(pos) && LeftColumn(pos))
        );
      else if (origin.X > target.X)
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => AboveRow(pos) && LeftColumn(pos))
            : allPositions.Where(pos => BelowRow(pos) && LeftColumn(pos))
        );
      else if (origin.X < target.X)
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => AboveRow(pos) && RightColumn(pos))
            : allPositions.Where(pos => BelowRow(pos) && RightColumn(pos))
        );

      return positionsBetween;
    }

    /// <summary>
    ///   Convert a position to an index.
    /// </summary>
    /// <param name="position">The position to convert.</param>
    /// <returns>The index of the position.</returns>
    private static int ConvertToIndex(Position position)
    {
      var x = position.X;
      var y = position.Y;
      return y * 8 + x;
    }

    /// <summary>
    ///   Convert an index to a position.
    /// </summary>
    /// <param name="index">The index to convert.</param>
    /// <returns>The position of the index.</returns>
    private static Position ConvertToPosition(int index)
    {
      var x = index % 8;
      var y = index / 8;
      return new Position(x, y);
    }

    /// <summary>
    ///   Evaluates if the <c>origin</c> cell is the same colour as the given parameter.
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <param name="colour">The colour to compare to.</param>
    /// <returns>True if the <c>origin</c> cell is the same colour as the given parameter, false otherwise.</returns>
    public bool SameColour(Position cell, Colour colour)
    {
      return _cells[ConvertToIndex(cell)].Colour == colour;
    }

    /// <summary>
    ///   Changes the cell at the given position to a new piece.
    /// </summary>
    /// <param name="cell">The cell to affect.</param>
    /// <param name="piece">The new piece. See <see cref="GenerateBoard" /> for valid pieces.</param>
    public void ChangeCellTo(Position cell, char piece)
    {
      _cells[ConvertToIndex(cell)] = new Cell(piece);
    }

    /// <summary>
    ///   Evaluates if the given cell is a promotable piece and is on the edge of the board.
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <returns>True if the cell can be promoted, false otherwise.</returns>
    public bool IsPromotable(Position cell)
    {
      if (!_cells[ConvertToIndex(cell)].HasPromotable()) return false;
      return cell.Y == 7 || cell.Y == 0;
    }

    /// <summary>
    ///   Evaluates if the <c>origin</c> cell has a promotable piece.
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <returns>True if the <c>origin</c> cell has a promotable piece, false otherwise.</returns>
    public bool HasPromotable(Position cell)
    {
      return _cells[ConvertToIndex(cell)].HasPromotable();
    }

    /// <summary>
    ///   Generates a list of cells that are attacking the essential piece of the given colour.
    /// </summary>
    /// <param name="colour">The colour of the essential piece to evaluate.</param>
    /// <returns>List containing the indexes of the cells that are attacking the essential piece.</returns>
    public List<Position> GetAssailants(Colour colour)
    {
      // Get the king's position
      var king = GetEssentialPiece(colour);
      return king.OutOfBounds
        ? new List<Position>()
        : GetAttackingPieces(colour, king);
    }

    /// <summary>
    ///   Gets the essential piece of the given colour.
    /// </summary>
    /// <param name="colour"> The colour of the essential piece to get.</param>
    /// <returns>The index of the essential piece.</returns>
    public Position GetEssentialPiece(Colour colour)
    {
      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].HasEssential() && _cells[i].Colour == colour)
          return ConvertToPosition(i);

      return new Position(-1, -1);
    }

    /// <summary>
    ///   Gets the list of cells that are attacking the given position.
    /// </summary>
    /// <param name="colour">
    ///   The colour of the piece being attacked.
    /// </param>
    /// <param name="target">The position that is being attacked.</param>
    /// <returns>List containing the indexes of the cells that are attacking the given position.</returns>
    public List<Position> GetAttackingPieces(Colour colour, Position target)
    {
      // Get all the opposite colour pieces
      var enemyColour = colour == Colour.Black ? Colour.White : Colour.Black;
      var enemies = new List<Position>();
      if (SameColour(target, enemyColour))
        return new List<Position>();

      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].Colour == enemyColour)
          enemies.Add(ConvertToPosition(i));

      var list = enemies.Where(enemy => ValidMove(enemy, target)).ToList();

      // If an enemy king is trying to attack, remove it from the list if performing the move will result in a check
      if (list.Contains(GetEssentialPiece(enemyColour)))
        list.RemoveAll(enemy => _cells[ConvertToIndex(enemy)].HasEssential() && !SelfChecks(enemy, target));

      return list;
    }

    /// <summary>
    ///   Evaluates if the given move is an en passant move.
    ///   <para>
    ///     An en passant move is a move made by any piece that can en passant to <see cref="_canBeEnPassant" />.
    ///   </para>
    /// </summary>
    /// <param name="origin">The cell containing the piece that is moving.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <returns>True if the move is an en passant, false otherwise.</returns>
    private bool EnPassantMove(Position origin, Position target)
    {
      if (!_canBeEnPassant.HasValue) return false;
      if (_canBeEnPassant.Value != target) return false;
      var enPassantee = _cells[ConvertToIndex(new Position(_canBeEnPassant.Value.X, origin.Y))];
      return !enPassantee.IsEmpty() && enPassantee.Colour != _cells[ConvertToIndex(origin)].Colour;
    }

    /// <summary>
    ///   <para>
    ///     Evaluates if the given move is valid.
    ///   </para>
    ///   <para>
    ///     A valid move is a move from a piece to a target cell that is a different colour. It takes into account
    ///     <see cref="Piece.ValidMove" />, as well as
    ///     <see
    ///       cref="Collision(chess.Models.Position,chess.Models.Position,System.Collections.Generic.List{chess.Models.Position})" />
    ///     .
    ///   </para>
    /// </summary>
    /// <param name="origin">The cell containing the moving piece.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <returns> True if the move is valid, false otherwise.</returns>
    public bool ValidMove(Position origin, Position target)
    {
      // Get the cell 
      var cell = _cells[ConvertToIndex(origin)];
      if (cell.IsEmpty()) return false;
      if (cell.Colour == null) return false;
      if (cell.Colour == _cells[ConvertToIndex(target)].Colour) return false;

      // Filter moves
      var moves = cell.ValidMove(origin);
      moves.RemoveAll(pos => pos.OutOfBounds);

      // En Passant, if the move is an en passant we don't need to check for the other filters
      if (cell.CanEnPassant() && EnPassantMove(origin, target))
        return true;

      // Filter moves (well, the pawn's)
      if (cell.CanOnlyAttackDiagonally())
        moves.RemoveAll(pos => pos.X != origin.X && _cells[ConvertToIndex(pos)].IsEmpty());

      if (cell.CanOnlyMoveForward())
        moves.RemoveAll(pos =>
          pos.X == origin.X && !_cells[ConvertToIndex(pos)].IsEmpty() &&
          _cells[ConvertToIndex(pos)].Colour != cell.Colour);

      if (!moves.Contains(target) || moves.Count == 0) return false;

      // Collisions 
      return Collision(origin, target, moves);
    }

    /// <summary>
    ///   Moves the piece at the given origin to the given target.
    /// </summary>
    /// <param name="origin">Position of the piece to move.</param>
    /// <param name="target">Position to move the piece to.</param>
    public void MoveCellTo(Position origin, Position target)
    {
      // Handle castles
      if (CanCastle(origin, target))
      {
        Position castlee;
        Position newTarget;
        if (origin.X - target.X > 0)
        {
          castlee = new Position(0, origin.Y);
          newTarget = new Position(origin.X - 1, origin.Y);
        }
        else
        {
          castlee = new Position(7, origin.Y);
          newTarget = new Position(origin.X + 1, origin.Y);
        }

        SwapCells(castlee, newTarget);
        _cells[ConvertToIndex(newTarget)].Moved();
      }

      if (_canBeEnPassant.HasValue && target == _canBeEnPassant)
        _cells[ConvertToIndex(new Position(target.X, origin.Y))] = new Cell('.');

      // Handle en passant 
      if (_cells[ConvertToIndex(origin)].CanEnPassant() && origin.X == target.X)
      {
        _canBeEnPassant = (target.Y - origin.Y) switch
        {
          2 => new Position(target.X, target.Y - 1),
          -2 => new Position(target.X, target.Y + 1),
          _ => null
        };
      }
      else
        _canBeEnPassant = null;

      // Perform the move
      SwapCells(origin, target);
      _cells[ConvertToIndex(target)].Moved();
    }

    /// <summary>
    ///   Evaluates if any enemy can attack around the essential piece, determined by <see cref="GetEssentialPiece" />
    /// </summary>
    /// <param name="colour">The colour of the essential piece.</param>
    /// <returns>True if any enemy can attack, otherwise false.</returns>
    public bool CanAttackAroundEssential(Colour colour)
    {
      var cell = GetEssentialPiece(colour);
      if (cell.OutOfBounds)
        return false;

      var moves = _cells[ConvertToIndex(cell)].ValidMove(cell);
      moves.RemoveAll(pos => pos.OutOfBounds);
      moves.RemoveAll(pos => !ValidMove(cell, pos) || !SelfChecks(cell, pos));

      return moves.All(pos => GetAttackingPieces(colour, pos).Count != 0);
    }

    /// <summary>
    ///   Moves the first cell to the second cell, overwriting it. The first cell is then removed.
    /// </summary>
    /// <param name="origin">The first cell.</param>
    /// <param name="target">The second cell.</param>
    private void SwapCells(Position origin, Position target)
    {
      _cells[ConvertToIndex(target)] = _cells[ConvertToIndex(origin)];
      _cells[ConvertToIndex(origin)] = new Cell('.');
    }

    /// <summary>
    ///   Evaluates if performing the given move would cause the essential piece to be in check.
    /// </summary>
    /// <param name="origin">The cell containing the moving piece.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <returns>False if the move would cause the essential piece to be in check, true otherwise.</returns>
    public bool SelfChecks(Position origin, Position target)
    {
      var oldBoard = (Cell[]) _cells.Clone();
      var cell = _cells[ConvertToIndex(origin)];
      if (cell.Colour == null)
      {
        _cells = oldBoard;
        return false;
      }

      SwapCells(origin, target);
      var attackers = GetAssailants((Colour) cell.Colour);
      attackers.Remove(target);
      _cells = oldBoard;

      return attackers.Count == 0;
    }

    /// <summary>
    ///   Evaluates if any enemy can move between the two given cells. Note that the target cell (which is usually an enemy) is
    ///   ignored.
    /// </summary>
    /// <param name="origin">The first cell.</param>
    /// <param name="target">The second cell.</param>
    /// <returns>True if an enemy can move between the two, false otherwise.</returns>
    public bool CanBlock(Position origin, Position target)
    {
      // Checks if any enemy piece of the origin can go between the two
      var moves = _cells[ConvertToIndex(origin)].ValidMove(origin);
      var positionsBetween = PositionsBetween(origin, target, moves);
      var enemies = new List<Position>();

      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].Colour == _cells[ConvertToIndex(target)].Colour)
          enemies.Add(ConvertToPosition(i));

      enemies.Remove(target);

      return positionsBetween.Any(pos => enemies.Any(enemy => ValidMove(enemy, pos)));
    }

    /// <summary>
    ///   Evaluates if the move is a capture (i.e. the target cell is occupied by an enemy piece).
    /// </summary>
    /// <param name="origin">The cell containing the moving piece.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <returns>True if the movie is a capture, false otherwise.</returns>
    public bool IsCapture(Position origin, Position target)
    {
      return _cells[ConvertToIndex(origin)].Colour != _cells[ConvertToIndex(target)].Colour &&
             !_cells[ConvertToIndex(target)].IsEmpty();
    }

    /// <summary>
    ///   Evaluates if a castle move can be performed.
    /// </summary>
    /// <param name="origin">The cell containing the moving piece.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <returns>True if the castle can be performed, false otherwise.</returns>
    public bool CanCastle(Position origin, Position target)
    {
      var castler = _cells[ConvertToIndex(origin)];

      // Check if it's the essential piece that is starting the move
      if (!castler.HasEssential()) return false;
      // Check if they can castle
      if (castler.Colour == null)
        return false;
      if (!castler.CanCastle())
        return false;
      if (castler.HasMoved())
        return false;

      // Check if the movement is a castle
      if (!CastlingMove(origin, target))
        return false;

      Position castlee;
      Position passesBy;
      // Get the castlee
      if (origin.X - target.X > 0)
      {
        castlee = new Position(0, origin.Y);
        passesBy = new Position(origin.X - 1, origin.Y);
      }
      else
      {
        castlee = new Position(7, origin.Y);
        passesBy = new Position(origin.X + 1, origin.Y);
      }

      if (!_cells[ConvertToIndex(castlee)].CanCastle())
        return false;
      if (_cells[ConvertToIndex(castlee)].HasMoved())
        return false;

      // Ensure that there are no attackers between these positions
      if (GetAttackingPieces((Colour) castler.Colour, passesBy).Count > 0)
        return false;

      // Also ensure that they are not being attacked 
      if (GetAttackingPieces((Colour) castler.Colour, origin).Count > 0)
        return false;

      // Lastly, check if the castlee can do the move
      return ValidMove(castlee, passesBy);
    }

    /// <summary>
    ///   Evaluates whether the move is a castle. Castling moves are when a piece moves two spaces on the X axis.
    /// </summary>
    /// <param name="origin">The cell containing the moving piece.</param>
    /// <param name="target">The cell that the piece is moving to.</param>
    /// <remarks>This does not check if the origin is a castler.</remarks>
    /// <returns>True if it is a castle, false otherwise.</returns>
    public static bool CastlingMove(Position origin, Position target)
    {
      return Math.Abs(origin.X - target.X) == 2;
    }

    /// <summary>
    ///   Evaluates whether the cell contains an essential piece.
    /// </summary>
    /// <param name="cell">
    ///   The cell to evaluate.
    /// </param>
    /// <returns></returns>
    public bool HasEssential(Position cell)
    {
      return _cells[ConvertToIndex(cell)].HasEssential();
    }

    /// <summary>
    ///   Evaluates whether any cell of a given colour can perform any move.
    /// </summary>
    /// <param name="colour">The colour of the team to evaluate.</param>
    /// <returns>True if at least one cell can perform a move, false otherwise.</returns>
    public bool TeamCanMove(Colour colour)
    {
      var allies = new List<Position>();

      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].Colour == colour)
          allies.Add(ConvertToPosition(i));

      foreach (var ally in allies)
      {
        var movelist = _cells[ConvertToIndex(ally)].ValidMove(ally);
        var cell = _cells[ConvertToIndex(ally)];
        movelist.RemoveAll(pos => pos.OutOfBounds);
        if (cell.CanOnlyAttackDiagonally())
          movelist.RemoveAll(pos => pos.X != ally.X && _cells[ConvertToIndex(pos)].IsEmpty());

        if (cell.CanOnlyMoveForward())
          movelist.RemoveAll(pos => pos.X == ally.X && !_cells[ConvertToIndex(pos)].IsEmpty());

        if (movelist.Any(move => ValidMove(ally, move) && SelfChecks(ally, move))) return true;
      }

      return false;
    }

    /// <summary>
    ///   Verifies if the cell cannot undo their move (ie. go back to the previous state).
    /// </summary>
    /// <param name="cell">The cell to evaluate.</param>
    /// <returns>True if it can undo their move, false otherwise.</returns>
    public bool CantGoBack(Position cell)
    {
      return _cells[ConvertToIndex(cell)].CantGoBack();
    }
  }
}