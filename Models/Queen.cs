using System.Collections.Generic;

namespace chess.Models
{
  public class Queen : Piece
  {
    public Queen(Colour colour) : base(colour)
    {
    }

    public override List<Position> ValidMove(Position position)
    {
      var validMoves = new List<Position>();

      // It's basically a bishop and a rook combined.
      validMoves.AddRange(new Bishop(Colour.Black).ValidMove(position));
      validMoves.AddRange(new Rook(Colour.Black).ValidMove(position));

      return validMoves;
    }

    public override string ToString()
    {
      return _colour == Colour.Black ? "Q" : "q";
    }
  }
}