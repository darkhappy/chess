namespace chess.Models
{
  /// <summary>
  ///   Represents a chess <see cref="Piece" /> that needs to know if it has moved or not.
  /// </summary>
  public abstract class StartingPiece : Piece
  {
    /// <summary>
    ///   Represents whether a piece has moved or not.
    /// </summary>
    private bool _hasMoved;

    /// <summary>
    ///   Initializes a new instance of the <see cref="StartingPiece" /> class.
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    /// <seealso cref="Piece(Colour)" />
    protected StartingPiece(Colour colour) : base(colour)
    {
      _hasMoved = false;
    }

    /// <inheritdoc cref="Piece.HasMoved()" />
    public override bool HasMoved()
    {
      return _hasMoved;
    }

    /// <inheritdoc cref="Piece.Moved()" />
    public override void Moved()
    {
      _hasMoved = true;
    }
  }
}