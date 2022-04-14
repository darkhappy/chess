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
      bool SameRow(Position pos) => pos.X == origin.X;
      bool AboveRow(Position pos) => pos.Y > origin.Y && pos.Y < target.Y;
      bool BelowRow(Position pos) => pos.Y < origin.Y && pos.Y > target.Y;
      bool SameColumn(Position pos) => pos.Y == origin.Y;
      bool LeftColumn(Position pos) => pos.X < origin.X && pos.X > target.X;
      bool RightColumn(Position pos) => pos.X > origin.X && pos.X < target.X;

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
    /// <param name="origin">The cell to evaluate.</param>
    /// <param name="colour">The colour to compare to.</param>
    /// <returns>True if the <c>origin</c> cell is the same colour as the given parameter, false otherwise.</returns>
    public bool SameColour(Position origin, Colour colour)
    {
      return _cells[ConvertToIndex(origin)].Colour == colour;
    }

    public void ChangeCellTo(Position cell, char piece)
    {
      _cells[ConvertToIndex(cell)] = new Cell(piece);
    }

    public bool IsPromotable(Position target)
    {
      List<Position> promotablePositions = new List<Position>();

      for(int i = 0; i <= 7; i++)
      {
        promotablePositions.Add(new Position(i, 7));
        promotablePositions.Add(new Position(i, 0));
      }

      return promotablePositions.Contains(target);    
    }

    /// <summary>
    ///   Evaluates if the <c>origin</c> cell has a promotable piece.
    /// </summary>
    /// <param name="target">The cell to evaluate.</param>
    /// <returns>True if the <c>origin</c> cell has a promotable piece, false otherwise.</returns>
    public bool HasPromotable(Position target)
    {
      return _cells[ConvertToIndex(target)].HasPromotable();
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
      return king == new Position(-1, -1)
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

      var list = enemies.Where(enemy => ValidMove(enemy, target) && SelfChecks(enemy, target)).ToList();

      return list;
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
      // Get valid moves
      var cell = _cells[ConvertToIndex(origin)];
      if (cell.IsEmpty()) return false;
      if (cell.Colour == null) return false;
      if (cell.Colour == _cells[ConvertToIndex(target)].Colour) return false;

      var moves = cell.ValidMove(origin);
      moves.RemoveAll(pos => pos.X < 0 || pos.X > 7 || pos.Y < 0 || pos.Y > 7);
      if (cell.CanOnlyAttackDiagonally())
        moves.RemoveAll(pos => pos.X != origin.X && _cells[ConvertToIndex(pos)].IsEmpty());

      if (cell.CanOnlyMoveForward())
        moves.RemoveAll(pos => pos.X == origin.X && !_cells[ConvertToIndex(pos)].IsEmpty());

      if (!moves.Contains(target) || moves.Count == 0) return false;

      // Check for collisions
      return Collision(origin, target, moves);
    }

    /// <summary>
    ///   Moves the piece at the given origin to the given target.
    /// </summary>
    /// <param name="origin">Position of the piece to move.</param>
    /// <param name="target">Position to move the piece to.</param>
    public void MoveCellTo(Position origin, Position target)
    {
      if (CanCastle(origin, target))
      {
        // Handle castles
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

      SwapCells(origin, target);
      _cells[ConvertToIndex(target)].Moved();
    }

    /// <summary>
    ///   Converts the board to a 2D array.
    /// </summary>
    /// <returns> 2D array representing the board.</returns>
    public Cell[][] ConvertTo2D()
    {
      var array = _cells;
      var result = new Cell[8][];
      for (var i = 0; i < result.Length; i++)
        result[i] = new Cell[8];

      for (var i = 0; i < array.Length; i++)
      {
        var x = i % 8;
        var y = i / 8;
        result[y][x] = array[i];
      }

      return result;
    }

    public bool CanAttackAroundEssential(Colour colour)
    {
      var cell = GetEssentialPiece(colour);
      if (cell == new Position(-1, -1)) return false;
      var moves = _cells[ConvertToIndex(cell)].ValidMove(cell);
      moves.RemoveAll(pos => pos.X < 0 || pos.X > 7 || pos.Y < 0 || pos.Y > 7);
      moves.RemoveAll(pos => _cells[ConvertToIndex(pos)].Colour != _cells[ConvertToIndex(cell)].Colour);
      return moves.Any(pos => GetAttackingPieces(colour, cell).Count > 0);
    }

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
      // TODO: Scuffed. Needs to be fixed.
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

    public bool CanCastle(Position origin, Position target)
    {
      var castler = _cells[ConvertToIndex(origin)];

      // Check if it's the essential piece that is starting the move
      if (!castler.HasEssential()) return false;
      // Check if they can castle
      if (castler.Colour == null) return false;
      if (!castler.CanCastle()) return false;
      if (castler.HasMoved()) return false;

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

      if (!_cells[ConvertToIndex(castlee)].CanCastle()) return false;
      if (_cells[ConvertToIndex(castlee)].HasMoved()) return false;

      // Ensure that there are no attackers between these positions
      if (GetAttackingPieces((Colour) castler.Colour, passesBy).Count > 0)
        return false;

      // Also ensure that they are not being attacked 
      if (GetAttackingPieces((Colour) castler.Colour, origin).Count > 0)
        return false;

      // Lastly, check if the castlee can do the move
      if (!ValidMove(castlee, passesBy))
        return false;


      return true;
    }

    public static bool CastlingMove(Position origin, Position target)
    {
      return Math.Abs(origin.X - target.X) == 2;
    }

    public bool HasEssential(Position cell)
    {
      return _cells[ConvertToIndex(cell)].HasEssential();
    }
  }
}