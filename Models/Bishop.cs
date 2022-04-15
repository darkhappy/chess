using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  /// Represents a bishop.
  /// </summary>
  public class Bishop : Piece
  {
    /// <summary>
    /// initializes a new instance of the Bishop class.
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    public Bishop(Colour colour) : base(colour)
    {
    }

    /// <summary>
    ///   Generates a list of moves for the piece. The available moves are all the positions on the same diagonal as the piece.
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
        validMoves.Add(new Position(x - i, y + i));
        validMoves.Add(new Position(x + i, y + i));
        validMoves.Add(new Position(x - i, y - i));
        validMoves.Add(new Position(x + i, y - i));
      }

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>b</b> for a white bishop, <b>B</b> for a black bishop.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "B" : "b";
    }
  }
}