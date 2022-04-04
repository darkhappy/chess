using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Cell
  {
    private Piece? _piece;

    /// <summary>
    /// Create a new cell
    /// </summary>
    public Cell()
    {
    }

    /// <summary>
    /// Create a new cell with a piece within
    /// </summary>
    /// <param name="piece"></param>
    public Cell(Piece piece)
    {
      _piece = piece;
    }

    /// <summary>
    /// Return the piece color in the cell
    /// </summary>
    public Colour Colour
    {
      get => _piece.Colour;
    }

    /// <summary>
    /// Get or set a piece in the cell
    /// </summary>
    public Piece Piece
    {
      get => _piece;
      set => _piece = value;
    }

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
      return _piece.CanCollide();
    }

    /// <summary>
    /// Check if the piece in the cell can promote
    /// </summary>
    /// <returns></returns>
    public bool HasPromotable()
    {
      return _piece.CanPromote();
    }

    /// <summary>
    /// Check if the piece in the cell is an essential one
    /// </summary>
    /// <returns></returns>
    public bool HasEssential()
    {
      return _piece.IsEssential();
    }

    /// <summary>
    /// Return all possible move for the piece within the cell
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public List<Position> ValidMove(Position origin)
    {
      return _piece.ValidMove(origin);
    }
  }
}