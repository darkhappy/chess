namespace chess.Models
{
  /// <summary>
  ///   Represents a chess <see cref="Piece" /> that can perform castling.
  /// </summary>
  public abstract class CastlingPiece : StartingPiece
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="CastlingPiece" /> class.
    /// </summary>
    /// <param name="colour"> The colour of the piece. </param>
    /// <seealso cref="Piece(Colour)" />
    protected CastlingPiece(Colour colour) : base(colour)
    {
    }

    /// <inheritdoc cref="Piece.CanCastle()" />
    public override bool CanCastle()
    {
      return true;
    }
  }
}