using System.Collections.Generic;

namespace chess.Models
{
  public class King : CastlingPiece
  {
    public King(Colour colour) : base(colour)
    {
    }

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

      if (!HasMoved())
      {
        validMoves.Add(new Position(x + 2, y));
        validMoves.Add(new Position(x - 2, y));
      }

      return validMoves;
    }

    public override string ToString()
    {
      return _colour == Colour.Black ? "K" : "k";
    }

    public override bool IsEssential()
    {
      return true;
    }
  }
}