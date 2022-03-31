namespace chess.Models
{
  public abstract class StartingPiece : Piece
  {
    private bool _hasMoved;

    protected StartingPiece(Colour colour) : base(colour)
    {
      throw new System.NotImplementedException();
    }

    public override bool HasMoved()
    {
      throw new System.NotImplementedException();
    }
  }
}