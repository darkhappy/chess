using System.Collections.Generic;

namespace chess.Models
{
  public class Cell
  {
    private Piece? _piece;

    /// <summary>
    /// Create a new cell with a piece within
    /// </summary>
    /// <param name="piece"></param>
    public Cell(char piece)
    {
      _piece = piece switch
      {
        'p' => new Pawn(Models.Colour.White),
        'P' => new Pawn(Models.Colour.Black),
        'r' => new Rook(Models.Colour.White),
        'R' => new Rook(Models.Colour.Black),
        'n' => new Knight(Models.Colour.White),
        'N' => new Knight(Models.Colour.Black),
        'b' => new Bishop(Models.Colour.White),
        'B' => new Bishop(Models.Colour.Black),
        'q' => new Queen(Models.Colour.White),
        'Q' => new Queen(Models.Colour.Black),
        'k' => new King(Models.Colour.White),
        'K' => new King(Models.Colour.Black),
        _ => null
      };
    }

    /// <summary>
    /// Return the piece color in the cell
    /// </summary>
    public Colour? Colour => _piece?.Colour;

    /// <summary>
    /// Check if the cell is empty
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
      return _piece == null;
    }

    /// <summary>
    /// Check if the piece in the cell can collide
    /// </summary>
    /// <returns></returns>
    public bool HasCollision()
    {
      return _piece != null && _piece.CanCollide();
    }

    /// <summary>
    /// Check if the piece in the cell can promote
    /// </summary>
    /// <returns></returns>
    public bool HasPromotable()
    {
      return _piece != null && _piece.CanPromote();
    }

    /// <summary>
    /// Check if the piece in the cell is an essential one
    /// </summary>
    /// <returns></returns>
    public bool HasEssential()
    {
      return _piece != null && _piece.IsEssential();
    }

    /// <summary>
    /// Return all possible move for the piece within the cell
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public List<Position> ValidMove(Position origin)
    {
      return _piece == null ? new List<Position>() : _piece.ValidMove(origin);
    }

    public override string ToString()
    {
      return _piece == null ? "." : _piece.ToString();
    }

    public void Moved()
    {
      if (_piece != null)
      {
        _piece.Moved();
      }
    }

    public bool CanOnlyAttackDiagonally()
    {
      return _piece != null && _piece.CanOnlyAttackDiagonally();
    }

    public bool CanOnlyMoveForward()
    {
      return _piece != null && _piece.CanOnlyMoveForward();
    }
  }
}