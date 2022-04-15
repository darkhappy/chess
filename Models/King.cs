using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a king.
  /// </summary>
  public class King : CastlingPiece
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="King" /> class.
    /// </summary>
    /// <param name="colour"></param>
    public King(Colour colour) : base(colour)
    {
    }

    /// <summary>
    ///   Generates a list of the moves for this piece. The available moves are all the positions adjacent to the current
    ///   position. If the king has not moved, it will also add castling moves (ie. two cells to the left or right).
    /// </summary>
    /// <param name="position">The position to calculate from.</param>
    /// <returns>List containing all possible moves.</returns>
    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      validMoves.Add(new Position(x + 1, y));
      validMoves.Add(new Position(x - 1, y));
      validMoves.Add(new Position(x, y + 1));
      validMoves.Add(new Position(x, y - 1));
      validMoves.Add(new Position(x + 1, y + 1));
      validMoves.Add(new Position(x - 1, y - 1));
      validMoves.Add(new Position(x - 1, y + 1));
      validMoves.Add(new Position(x + 1, y - 1));

      if (HasMoved()) return validMoves;

      validMoves.Add(new Position(x + 2, y));
      validMoves.Add(new Position(x - 2, y));

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>k</b> for a white king, <b>K</b> for a black king.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "K" : "k";
    }

    /// <inheritdoc cref="Piece.IsEssential()" />
    public override bool IsEssential()
    {
      return true;
    }
  }
}