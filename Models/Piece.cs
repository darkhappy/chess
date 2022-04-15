using System.Collections.Generic;

namespace chess.Models
{
  /// <summary>
  ///   Represents a piece on the board.
  /// </summary>
  public abstract class Piece
  {
    /// <summary>
    ///   Represents the colour of the piece.
    /// </summary>
    protected Colour _colour;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Piece" /> class.
    /// </summary>
    /// <param name="colour">The colour of the piece.</param>
    protected Piece(Colour colour)
    {
      _colour = colour;
    }

    /// <inheritdoc cref="_colour" />
    public Colour Colour => _colour;

    /// <summary>
    ///   Generates a list of all possible moves for the piece.
    /// </summary>
    /// <param name="position">The position where the piece starts.</param>
    /// <returns>List containing all the moves a piece can do.</returns>
    public abstract List<Position> ValidMove(Position position);

    /// <summary>
    ///   Returns the code of the piece. See <see cref="Board.GenerateBoard" /> for more information.
    /// </summary>
    /// <returns>The code of the piece.</returns>
    public new abstract string ToString();

    /// <summary>
    ///   Evaluates if the piece takes into account collisions.
    /// </summary>
    /// <returns>True if the piece takes into account collisions, false otherwise.</returns>
    public virtual bool CanCollide()
    {
      return true;
    }

    /// <summary>
    ///   Evaluates if the piece can be promoted.
    /// </summary>
    /// <returns>True if the piece can be promoted, false otherwise.</returns>
    public virtual bool CanPromote()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece is an essential piece.
    /// </summary>
    /// <returns>True if the piece is an essential piece, false otherwise.</returns>
    public virtual bool IsEssential()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece has moved.
    /// </summary>
    /// <returns>True if the piece has moved, false otherwise.</returns>
    public virtual bool HasMoved()
    {
      return true;
    }

    /// <summary>
    ///   Notifies the piece that it has been moved.
    /// </summary>
    public virtual void Moved()
    {
    }

    /// <summary>
    ///   Evaluates if the piece can only move forward  (ie. it can't attack in front).
    /// </summary>
    /// <returns>True if the piece can only move forward and not attack, false otherwise.</returns>
    public virtual bool CanOnlyMoveForward()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece can only attack in diagonal (ie. it can't move diagonally).
    /// </summary>
    /// <returns>True if the piece can only attack in diagonal and not move, false otherwise.</returns>
    public virtual bool CanOnlyAttackDiagonally()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece can castle.
    /// </summary>
    /// <returns>True if the piece can castle, false otherwise.</returns>
    public virtual bool CanCastle()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece cannot undo it's move (ie. go back to the previous position).
    /// </summary>
    /// <returns>True if the piece cannot undo it's move, false otherwise.</returns>
    public virtual bool CantGoBack()
    {
      return false;
    }

    /// <summary>
    ///   Evaluates if the piece can en passant.
    /// </summary>
    /// <returns>True if the piece can en passant, false otherwise.</returns>
    public virtual bool CanEnPassant()
    {
      return false;
    }
  }
}