using System.Collections.Generic;

namespace chess.Models
{
  public class Cell
  {
    private Piece? _piece;

    /// <summary>
    /// Create a new cell with a piece within.
    /// </summary>
    /// <param name="piece">The piece in the cell</param>
    /// <remarks>
    /// The piece parameter can be set to null.
    /// </remarks>
    public Cell(char piece)
    {
      var colour = char.IsLower(piece) ? Models.Colour.White : Models.Colour.Black;
      _piece = char.ToLower(piece) switch
      {
        'p' => new Pawn(colour),
        'r' => new Rook(colour),
        'n' => new Knight(colour),
        'b' => new Bishop(colour),
        'q' => new Queen(colour),
        'k' => new King(colour),
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
    /// <returns>Whether the case is empty or not</returns>
    public bool IsEmpty()
    {
      return _piece == null;
    }

    /// <summary>
    /// Check if the piece in the cell can collide
    /// </summary>
    /// <returns>Whether the piece can collide or not</returns>
    public bool HasCollision()
    {
      return _piece != null && _piece.CanCollide();
    }

    /// <summary>
    /// Check if the piece in the cell can promote
    /// </summary>
    /// <returns>Whether the cell contains a promotable piece or not</returns>
    public bool HasPromotable()
    {
      return _piece != null && _piece.CanPromote();
    }

    /// <summary>
    /// Check if the piece in the cell has moved
    /// </summary>
    /// <returns>Whether the piece has moved or not</returns>
    public bool HasMoved()
    {
      return _piece != null && _piece.HasMoved();
    }

    /// <summary>
    /// Check if the piece in the cell is an essential one
    /// </summary>
    /// <returns>Whether the piece is essential or not</returns>
    public bool HasEssential()
    {
      return _piece != null && _piece.IsEssential();
    }

    /// <summary>
    /// Return all possible move for the piece within the cell
    /// </summary>
    /// <param name="origin">Piece position on the board</param>
    /// <returns>A list of valid move for a piece without considering collisions</returns>
    public List<Position> ValidMove(Position origin)
    {
      return _piece == null ? new List<Position>() : _piece.ValidMove(origin);
    }

    /// <summary>
    /// Convert the cell into a string
    /// </summary>
    /// <returns>String corresponding to the piece within the cell</returns>
    public override string ToString()
    {
      return _piece == null ? "." : _piece.ToString();
    }

    /// <summary>
    /// Sets the piece in the cell as having moved
    /// </summary>
    public void Moved()
    {
      _piece?.Moved();
    }

    /// <summary>
    /// Check if the piece in the cell can only attack diagonally.
    /// </summary>
    /// <returns>Wheter the piece can attack diagonally or not</returns>
    public bool CanOnlyAttackDiagonally()
    {
      return _piece != null && _piece.CanOnlyAttackDiagonally();
    }

    /// <summary>
    /// Check if the piece in the cell can only move forward
    /// </summary>
    /// <returns>Wheter the piece can only move forward or not</returns>
    public bool CanOnlyMoveForward()
    {
      return _piece != null && _piece.CanOnlyMoveForward();
    }

    /// <summary>
    /// Check if the piece in the cell can castle
    /// </summary>
    /// <returns>Wheter the piece can castle or not</returns>
    public bool CanCastle()
    {
      return _piece != null && _piece.CanCastle();
    }

    public bool CantGoBack()
    {
      return _piece != null && _piece.CantGoBack();
    }
  }
}