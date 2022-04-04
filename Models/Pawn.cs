using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Pawn : StartingPiece
  {
    public Pawn(Colour colour) : base(colour)
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

    public override bool CanPromote()
    {
      throw new NotImplementedException();
    }
  }
}