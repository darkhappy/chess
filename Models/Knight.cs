using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Knight : Piece
  {
    public Knight(Colour colour) : base(colour)
    {
    }

    public override bool CanCollide()
    {
      throw new NotImplementedException();
    }

    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      validMoves.Add(new Position(x + 1, y + 2));
      validMoves.Add(new Position(x + 1, y - 2));
      validMoves.Add(new Position(x - 1, y + 2));
      validMoves.Add(new Position(x - 1, y - 2));
      validMoves.Add(new Position(x + 2, y + 1));
      validMoves.Add(new Position(x + 2, y - 1));
      validMoves.Add(new Position(x - 2, y + 1));
      validMoves.Add(new Position(x - 2, y - 1));

      return validMoves;
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }
  }
}