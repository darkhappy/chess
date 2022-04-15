using System;

namespace chess.Models
{
  /// <summary>
  ///   Represents a position on the chess board.
  /// </summary>
  public struct Position
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Position" /> struct using the specified coordinates.
    /// </summary>
    /// <param name="x">The position on the X axis.</param>
    /// <param name="y">The position on the Y axis.</param>
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="Position" /> struct using a string representation of the position.
    /// </summary>
    /// <param name="position">String representation of the position.</param>
    /// <remarks>A position ranges from a-h on the X axis, and 1-8 on the Y axis.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if a letter or number is out of bounds.</exception>
    public Position(string position)
    {
      var x = position[0];
      var y = position[1];
      X = x switch
      {
        'a' => 0,
        'b' => 1,
        'c' => 2,
        'd' => 3,
        'e' => 4,
        'f' => 5,
        'g' => 6,
        'h' => 7,
        _ => throw new ArgumentOutOfRangeException(position, "Invalid x coordinate")
      };
      Y = int.Parse(y.ToString()) - 1;

      if (Y > 8 || Y < 0) throw new ArgumentOutOfRangeException(position, "Invalid y coordinate");
    }

    /// <summary>
    ///   Represents the position on the X axis.
    /// </summary>
    public int X { get; }

    /// <summary>
    ///   Represents the position on the Y axis.
    /// </summary>
    public int Y { get; }

    /// <summary>
    ///   Compares if two positions are equal.
    /// </summary>
    /// <param name="other">The second position to compare to.</param>
    /// <returns>True if they are equal, otherwise false.</returns>
    private bool Equals(Position other)
    {
      return X == other.X && Y == other.Y;
    }

    /// <summary>
    ///   Compares if two positions are equal.
    /// </summary>
    /// <param name="obj">The second position to compare to.</param>
    /// <returns>True if they are equal, otherwise false.</returns>
    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      return obj.GetType() == GetType() && Equals((Position) obj);
    }

    /// <summary>
    ///   Returns the hash code for this instance.
    /// </summary>
    /// <returns>The hash code for this instance.</returns>
    public override int GetHashCode()
    {
      unchecked
      {
        return (X * 397) ^ Y;
      }
    }

    /// <summary>
    ///   Compares if two positions are equal.
    /// </summary>
    /// <param name="left">The first position to compare to.</param>
    /// <param name="right">The second position to compare to.</param>
    /// <returns>True if they are equal, otherwise false.</returns>
    public static bool operator ==(Position? left, Position? right)
    {
      return Equals(left, right);
    }

    /// <summary>
    ///   Compares if two positions are different.
    /// </summary>
    /// <param name="left">The first position to compare to.</param>
    /// <param name="right">The second position to compare to.</param>
    /// <returns>True if they are different, otherwise false.</returns>
    public static bool operator !=(Position? left, Position? right)
    {
      return !Equals(left, right);
    }

    /// <summary>
    ///   Verifies if the position is not in the board (X or Y that is above 7 or below 0).
    /// </summary>
    public bool OutOfBounds => X < 0 || X > 7 || Y < 0 || Y > 7;
  }
}