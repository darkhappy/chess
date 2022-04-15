using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a king.
  /// </summary>
  public class Knight : Piece
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Knight" /> class.
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    public Knight(Colour colour) : base(colour)
    {
    }

    /// <summary>
    ///   Generates a list of all possible moves for the piece. The available moves are all moves that are in an L shape.
    /// </summary>
    /// <param name="position">The position to calculate from.</param>
    /// <returns>List containing all possible moves.</returns>
    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      validMoves.Add(new Position(x + 1, y + 2));
      validMoves.Add(new Position(x + 1, y - 2));
      validMoves.Add(new Position(x - 1, y + 2));
      validMoves.Add(new Position(x - 1, y - 2));
      validMoves.Add(new Position(x + 2, y + 1));
      validMoves.Add(new Position(x + 2, y - 1));
      validMoves.Add(new Position(x - 2, y + 1));
      validMoves.Add(new Position(x - 2, y - 1));

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>n</b> for a white knight, <b>N</b> for a black knight.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "N" : "n";
    }

    /// <inheritdoc cref="Piece.CanCollide" />
    /// /
    public override bool CanCollide()
    {
      return false;
    }
  }
}