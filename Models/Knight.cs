using System;

namespace chess.Models
{
  public class Knight : Piece
  {
    public Knight(Colour colour) : base(colour)
    {
      throw new NotImplementedException();
    }
    
    public override bool CanCollide()
    {
      throw new NotImplementedException();
    }

    public override bool ValidMove(int x1, int y1, int x2, int y2)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }
  }
}