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
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }
  }
}