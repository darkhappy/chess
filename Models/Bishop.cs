using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Bishop : Piece
  {
    public Bishop(Colour colour) : base(colour)
    {
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