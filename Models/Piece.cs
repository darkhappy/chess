using System;

namespace chess.Models
{
  public abstract class Piece
  {
    private Colour _colour;

    protected Piece(Colour colour)
    {
      throw new System.NotImplementedException();
    }

    public abstract bool ValidMove(int x1, int y1, int x2, int y2);
    public new abstract string ToString();

    public virtual bool CanCollide()
    {
      throw new System.NotImplementedException();
    }

    public virtual bool CanPromote()
    {
      throw new System.NotImplementedException();
    }

    public virtual bool IsEssential()
    {
      throw new System.NotImplementedException();
    }

    public virtual bool HasMoved()
    {
      throw new System.NotImplementedException();
    }
  }
}