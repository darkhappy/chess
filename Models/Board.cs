using System;
using System.Collections.Generic;
using System.Linq;

namespace chess.Models
{
  public class Board
  {
    private readonly Cell[] _cells;

    public Board()
    {
      _cells = new Cell[64];
      GenerateBoard("................................................................");
    }

    public Board(string board)
    {
      _cells = new Cell[64];
      GenerateBoard(board);
    }

    private void GenerateBoard(string board)
    {
      var array = board.ToCharArray();
      for (var i = 0; i < array.Length; i++) _cells[i] = new Cell(array[i]);
    }

    public override string ToString()
    {
      return _cells.Aggregate("", (current, t) => current + t);
    }

    public bool Collision(Position origin, Position target, List<Position> moves, Position ignore)
    {
      var originCell = _cells[ConvertToIndex(origin)];
      var targetCell = _cells[ConvertToIndex(target)];

      if (!originCell.HasCollision())
        return true;

      var toCheck = PositionsBetween(origin, target, moves);
      toCheck.Remove(ignore);
      return toCheck.All(position => _cells[ConvertToIndex(position)].IsEmpty());
    }

    public bool Collision(Position origin, Position target, List<Position> moves)
    {
      var originCell = _cells[ConvertToIndex(origin)];

      if (!originCell.HasCollision())
        return true;

      var toCheck = PositionsBetween(origin, target, moves);
      return toCheck.Count == 0 || toCheck.All(position => _cells[ConvertToIndex(position)].IsEmpty());
    }

    public List<Position> PositionsBetween(Position origin, Position target, List<Position> allPositions)
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
      {
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => SameRow(pos) && AboveRow(pos))
            : allPositions.Where(pos => SameRow(pos) && BelowRow(pos))
        );
      }
      else if (origin.Y == target.Y)
      {
        positionsBetween.AddRange(
          origin.X < target.X
            ? allPositions.Where(pos => SameColumn(pos) && RightColumn(pos))
            : allPositions.Where(pos => SameColumn(pos) && LeftColumn(pos))
        );
      }
      else if (origin.X > target.X)
      {
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => AboveRow(pos) && LeftColumn(pos))
            : allPositions.Where(pos => BelowRow(pos) && LeftColumn(pos))
        );
      }
      else if (origin.X < target.X)
      {
        positionsBetween.AddRange(
          origin.Y < target.Y
            ? allPositions.Where(pos => AboveRow(pos) && RightColumn(pos))
            : allPositions.Where(pos => BelowRow(pos) && RightColumn(pos))
        );
      }

      return positionsBetween;
    }

    private static int ConvertToIndex(Position position)
    {
      var x = position.X;
      var y = position.Y;
      return y * 8 + x;
    }

    private static Position ConvertToPosition(int index)
    {
      var x = index % 8;
      var y = index / 8;
      return new Position(x, y);
    }

    public bool SameColour(Position origin, Colour colour)
    {
      return _cells[ConvertToIndex(origin)].Colour == colour;
    }

    public bool IsEssentialExposed(Colour colour)
    {
      throw new NotImplementedException();
    }

    public bool HasPromotable(Position target)
    {
      return _cells[ConvertToIndex(target)].HasPromotable();
    }

    public List<int> GetAssailants(Colour colour, Position ignore)
    {
      // Get the king's position
      var king = GetEssentialPiece(colour);
      if (king == -1) return new List<int>();
      return GetAttackingPieces(colour, ConvertToPosition(king), ignore);
    }

    public List<int> GetAssailants(Colour colour)
    {
      // Get the king's position
      var king = GetEssentialPiece(colour);
      if (king == -1) return new List<int>();
      return GetAttackingPieces(colour, ConvertToPosition(king));
    }

    private int GetEssentialPiece(Colour colour)
    {
      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].HasEssential() && _cells[i].Colour == colour)
          return i;

      return -1;
    }

    private List<int> GetAttackingPieces(Colour colour, Position target)
    {
      // Get all the opposite colour pieces
      var enemyColour = colour == Colour.Black ? Colour.White : Colour.Black;
      var enemies = new List<int>();

      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].Colour == enemyColour)
          enemies.Add(i);

      var list = new List<int>();
      foreach (var enemy in enemies)
      {
        var moves = _cells[enemy].ValidMove(ConvertToPosition(enemy));
        if (!moves.Contains(target)) continue;
        foreach (var position in moves.ToList())
          if (position.X < 0 || position.X > 7 || position.Y < 0 || position.Y > 7)
            moves.Remove(position);

        if (Collision(ConvertToPosition(enemy), target, moves)) list.Add(enemy);
      }

      return list;
    }

    private List<int> GetAttackingPieces(Colour colour, Position target, Position ignore)
    {
      // Get all the opposite colour pieces
      var enemyColour = colour == Colour.Black ? Colour.White : Colour.Black;
      var enemies = new List<int>();

      for (var i = 0; i < _cells.Length; i++)
        if (_cells[i].Colour == enemyColour)
          enemies.Add(i);

      var list = new List<int>();
      foreach (var enemy in enemies)
      {
        var moves = _cells[enemy].ValidMove(ConvertToPosition(enemy));
        if (!moves.Contains(target)) continue;
        foreach (var position in moves.ToList())
          if (position.X < 0 || position.X > 7 || position.Y < 0 || position.Y > 7)
            moves.Remove(position);

        if (Collision(ConvertToPosition(enemy), target, moves, ignore)) list.Add(enemy);
      }

      list.Remove(ConvertToIndex(ignore));

      return list;
    }

    public bool ValidMove(Position origin, Position target)
    {
      // Get valid moves
      var cell = _cells[ConvertToIndex(origin)];
      if (cell.IsEmpty()) return false;
      if (cell.Colour == null) return false;
      if (cell.Colour == _cells[ConvertToIndex(target)].Colour) return false;

      var moves = cell.ValidMove(origin);
      if (!moves.Contains(target)) return false;
      moves.RemoveAll(pos => pos.X < 0 || pos.X > 7 || pos.Y < 0 || pos.Y > 7);

      // Check for collisions
      if (!Collision(origin, target, moves)) return false;

      // Check if this move self checks you
      var attackers = cell.HasEssential()
        ? GetAttackingPieces((Colour) cell.Colour, target, origin)
        : GetAssailants((Colour) cell.Colour, origin);

      return attackers.Count == 0;
    }

    public void MoveCellTo(Position origin, Position target)
    {
      _cells[ConvertToIndex(target)] = _cells[ConvertToIndex(origin)];
      _cells[ConvertToIndex(origin)] = new Cell('.');
    }

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
  }
}