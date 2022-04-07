using System;
using System.Collections.Generic;
using System.Linq;

namespace chess.Models
{
  public class Board
  {
    private Cell[] _cells;

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
      for (var i = 0; i < array.Length; i++)
      {
        _cells[i] = new Cell(array[i]);
      }
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
      var targetCell = _cells[ConvertToIndex(target)];

      if (!originCell.HasCollision())
        return true;

      var toCheck = PositionsBetween(origin, target, moves);
      return toCheck.All(position => _cells[ConvertToIndex(position)].IsEmpty());
    }

    public List<Position> PositionsBetween(Position origin, Position target, List<Position> allPositions)
    {
      // In the list of all positions, find the positions between the origin and target
      var positionsBetween =
        allPositions.Where(p => p.X >= origin.X && p.X <= target.X && p.Y >= origin.Y && p.Y <= target.Y);
      var positionsBetweenList = positionsBetween.ToList();
      positionsBetweenList.Remove(origin);
      positionsBetweenList.Remove(target);
      return positionsBetweenList;
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

    public bool SameColour(Position origin, Position target)
    {
      var originIndex = ConvertToIndex(origin);
      var targetIndex = ConvertToIndex(target);

      return _cells[originIndex].Colour == _cells[targetIndex].Colour;
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
      return GetAttackingPieces(colour, ConvertToPosition(king), ignore);
    }

    private int GetEssentialPiece(Colour colour)
    {
      for (var i = 0; i < _cells.Length; i++)
      {
        if (_cells[i].HasEssential())
          return i;
      }

      return -1;
    }

    private List<int> GetAttackingPieces(Colour colour, Position target, Position ignore)
    {
      // Get all the opposite colour pieces
      var enemyColour = colour == Colour.Black ? Colour.White : Colour.Black;
      var enemies = new List<int>();

      for (var i = 0; i < _cells.Length; i++)
      {
        if (_cells[i].Colour == enemyColour)
          enemies.Add(i);
      }

      var list = new List<int>();
      foreach (var enemy in enemies)
      {
        var moves = _cells[enemy].ValidMove(ConvertToPosition(enemy));
        if (!moves.Contains(target)) continue;
        foreach (var position in moves.ToList())
        {
          if (position.X < 0 || position.X > 7 || position.Y < 0 || position.Y > 7)
            moves.Remove(position);
        }

        if (!Collision(ConvertToPosition(enemy), target, moves, ignore)) list.Add(enemy);
      }

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
      foreach (var position in moves.ToList())
      {
        if (position.X < 0 || position.X > 7 || position.Y < 0 || position.Y > 7)
          moves.Remove(position);
      }

      // Check for collisions
      if (!Collision(origin, target, moves)) return false;

      // Check if this move self checks you
      var attackers = GetAssailants((Colour) cell.Colour, origin);
      if (attackers.Count != 0) return false;

      return true;
    }

    public void MoveCellTo(Position origin, Position target)
    {
      _cells[ConvertToIndex(target)] = _cells[ConvertToIndex(origin)];
      _cells[ConvertToIndex(origin)] = new Cell('.');
    }
  }
}