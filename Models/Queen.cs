using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a queen.
  /// </summary>
  public class Queen : Piece
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Queen" /> class.
    /// </summary>
    /// <param name="colour"></param>
    public Queen(Colour colour) : base(colour)
    {
    }

    /// <summary>
    ///   Generates a list of moves for the piece. The available moves are all the positions on the same X or Y axis as the
    ///   piece, or the positions on the same diagonal as the piece.
    /// </summary>
    /// <param name="position">The position to evaluate from.</param>
    /// <returns>A list of positions the piece can move to.</returns>
    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      for (var i = 1; i < 8; i++)
      {
        validMoves.Add(new Position(x - i, y + i));
        validMoves.Add(new Position(x + i, y + i));
        validMoves.Add(new Position(x - i, y - i));
        validMoves.Add(new Position(x + i, y - i));
        validMoves.Add(new Position(x, y + i));
        validMoves.Add(new Position(x, y - i));
        validMoves.Add(new Position(x + i, y));
        validMoves.Add(new Position(x - i, y));
      }

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>q</b> if the piece is white, <b>Q</b> if the piece is black.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "Q" : "q";
    }
  }
}