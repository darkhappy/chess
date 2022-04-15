using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a rook.
  /// </summary>
  public class Rook : CastlingPiece
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Rook" /> class.
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    public Rook(Colour colour) : base(colour)
    {
    }

    /// <summary>
    ///   Generates a list of moves for the piece. The available moves are all the positions on the same X or Y axis as the
    ///   piece.
    /// </summary>
    /// <param name="position">The position to calculate from.</param>
    /// <returns>List containing all possible moves.</returns>
    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      for (var i = 1; i < 8; i++)
      {
        validMoves.Add(new Position(x, y + i));
        validMoves.Add(new Position(x, y - i));
        validMoves.Add(new Position(x + i, y));
        validMoves.Add(new Position(x - i, y));
      }

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>r</b> for a white rook, <b>R</b> for a black rook.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "R" : "r";
    }
  }
}