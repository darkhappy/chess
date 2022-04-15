using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  /// Represents a pawn.
  /// </summary>
  public class Pawn : StartingPiece
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Pawn"/> class. 
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    public Pawn(Colour colour) : base(colour)
    {
    }

    /// <summary>
    /// Generates a list of moves for the piece. The available moves are one forward, two forward if it is the first move, and one diagonal.
    /// </summary>
    /// <param name="position">The position to calculate from.</param>
    /// <returns>List containing all possible moves.</returns>
    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();
      var x = position.X;
      var y = position.Y;

      if (_colour == Colour.White)
      {
        validMoves.Add(new Position(x, y + 1));
        validMoves.Add(new Position(x - 1, y + 1));
        validMoves.Add(new Position(x + 1, y + 1));
        if (!HasMoved()) validMoves.Add(new Position(x, y + 2));
      }
      else
      {
        validMoves.Add(new Position(x, y - 1));
        validMoves.Add(new Position(x - 1, y - 1));
        validMoves.Add(new Position(x + 1, y - 1));
        if (!HasMoved()) validMoves.Add(new Position(x, y - 2));
      }

      return validMoves;
    }

    /// <inheritdoc cref="Piece.ToString()" />
    /// <returns><b>p</b> for a white pawn, <b>P</b> for a black pawn.</returns>
    public override string ToString()
    {
      return _colour == Colour.Black ? "P" : "p";
    }

    /// <inheritdoc cref="Piece.CanPromote"/>
    public override bool CanPromote()
    {
      return true;
    }

    /// <inheritdoc cref="Piece.CanOnlyAttackDiagonally"/>
    public override bool CanOnlyAttackDiagonally()
    {
      return true;
    }

    /// <inheritdoc cref="Piece.CanOnlyMoveForward"/>
    public override bool CanOnlyMoveForward()
    {
      return true;
    }

    /// <inheritdoc cref="Piece.CantGoBack"/>
    public override bool CantGoBack()
    {
      return true;
    }

    /// <inheritdoc cref="Piece.CanEnPassant"/>
    public override bool CanEnPassant()
    {
      return true;
    }
  }
}