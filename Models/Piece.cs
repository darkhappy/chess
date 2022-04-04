using System.Collections.Generic;

namespace chess.Models
{
  public abstract class Piece
  {
    protected Colour _colour;

    protected Piece(Colour colour)
    {
      _colour = colour;
    }

    public Colour Colour => _colour;

    public abstract List<Position> ValidMove(Position position);

    public new abstract string ToString();

    public virtual bool CanCollide()
    {
      return true;
    }

    public virtual bool CanPromote()
    {
      return false;
    }

    public virtual bool IsEssential()
    {
      return false;
    }

    public virtual bool HasMoved()
    {
      return true;
    }

    public virtual void Moved()
    {
    }
  }
}