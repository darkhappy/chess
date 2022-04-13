namespace chess.Models
{
  public abstract class CastlingPiece : StartingPiece
  {
    protected CastlingPiece(Colour colour) : base(colour)
    {
    }

    public override bool CanCastle()
    {
      return true;
    }
  }

}