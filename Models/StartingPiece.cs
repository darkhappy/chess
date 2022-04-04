namespace chess.Models
{
  public abstract class StartingPiece : Piece
  {
    private bool _hasMoved;

    protected StartingPiece(Colour colour) : base(colour)
    {
      _hasMoved = false;
    }

    public override bool HasMoved()
    {
      return _hasMoved;
    }

    public override void Moved()
    {
      _hasMoved = true;
    }
  }
}