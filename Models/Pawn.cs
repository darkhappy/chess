using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Pawn : StartingPiece
  {
    public Pawn(Colour colour) : base(colour)
    {
    }

    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      if (_colour == Colour.White)
      {
        validMoves.Add(new Position(x, y + 1));
        validMoves.Add(new Position(x - 1, y + 1));
        validMoves.Add(new Position(x + 1, y + 1));
        if (!HasMoved())
        {
          validMoves.Add(new Position(x, y + 2));
        }
      }
      else
      {
        validMoves.Add(new Position(x, y - 1));
        validMoves.Add(new Position(x - 1, y - 1));
        validMoves.Add(new Position(x + 1, y - 1));
        if (!HasMoved())
        {
          validMoves.Add(new Position(x, y - 2));
        }
      }

      return validMoves;
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }

    public override bool CanPromote()
    {
      throw new NotImplementedException();
    }
  }
}