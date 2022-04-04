using System.Collections.Generic;

namespace chess.Models
{
  public class Rook : StartingPiece
  {
    public Rook(Colour colour) : base(colour)
    {
    }

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

    public override string ToString()
    {
      return _colour == Colour.Black ? "R" : "r";
    }
  }
}