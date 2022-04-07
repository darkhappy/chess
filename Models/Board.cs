using System;
using System.Collections.Generic;
using System.Linq;

namespace chess.Models
{
  public class Board
  {
    private Cell[] _cell;

    public Board()
    {
      _cell = new Cell[64];
      GenerateBoard("................................................................");
    }

    public Board(string board)
    {
      _cell = new Cell[64];
      GenerateBoard(board);
    }

    private void GenerateBoard(string board)
    {
      var array = board.ToCharArray();
      for (var i = 0; i < array.Length; i++)
      {
        _cell[i] = new Cell(array[i]);
      }
    }

    public override string ToString()
    {
      return _cell.Aggregate("", (current, t) => current + t);
    }

    public bool Collision(Position origin, Position target, List<Position> moves)
    {
      var originCell = _cell[ConvertToIndex(origin)];
      var targetCell = _cell[ConvertToIndex(target)];

      if (!originCell.HasCollision())
        return true;

      var toCheck = PositionsBetween(origin, target, moves);
      return toCheck.All(position => _cell[ConvertToIndex(position)].IsEmpty());
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

    public bool SameColour(Position origin, Position target)
    {
      var originIndex = ConvertToIndex(origin);
      var targetIndex = ConvertToIndex(target);

      return _cell[originIndex].Colour == _cell[targetIndex].Colour;
    }

    public bool IsEssentialExposed(Colour colour)
    {
      throw new NotImplementedException();
    }

    public bool HasPromotable(Position target)
    {
      return _cell[ConvertToIndex(target)].HasPromotable();
    }

    public List<int> GetAssailants(Colour colour)
    {
      throw new NotImplementedException();
    }

    private int GetEssentialPiece(Colour colour)
    {
      throw new NotImplementedException();
    }

    private List<int> GetAttackingPieces(Colour colour, Position target)
    {
      throw new NotImplementedException();
    }

    public bool ValidMove(Position origin, Position target)
    {
      // Get valid moves
      var cell = _cell[ConvertToIndex(origin)];
      var moves = cell.ValidMove(origin);
      if (cell.IsEmpty()) return false;
      if (cell.Colour == _cell[ConvertToIndex(target)].Colour) return false;

      if (!moves.Contains(target)) return false;

      // Check for collisions
      if (!Collision(origin, target, moves)) return false;


      return true;
    }

    public void MoveCellTo(Position origin, Position target)
    {
      _cell[ConvertToIndex(target)] = _cell[ConvertToIndex(origin)];
      _cell[ConvertToIndex(origin)] = new Cell('.');
    }
  }
}