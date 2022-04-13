using System;

namespace chess.Models
{
  public struct Position
  {
    private int _x;
    private int _y;

    public Position(int x, int y)
    {
      _x = x;
      _y = y;
    }

    public Position(string position)
    {
      var x = position[0];
      var y = position[1];
      _x = x switch
      {
        'a' => 0,
        'b' => 1,
        'c' => 2,
        'd' => 3,
        'e' => 4,
        'f' => 5,
        'g' => 6,
        'h' => 7,
        _ => throw new Exception("Invalid x coordinate")
      };
      _y = int.Parse(y.ToString()) - 1;
    }

    public int X
    {
      get => _x;
      set
      {
        if (value >= 8 || value < 0) throw new ArgumentOutOfRangeException();
        _x = value;
      }
    }

    public int Y
    {
      get => _y;
      set
      {
        if (value >= 8 || value < 0) throw new ArgumentOutOfRangeException();
        _y = value;
      }
    }

    private bool Equals(Position other)
    {
      return _x == other._x && _y == other._y;
    }

    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((Position) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (_x * 397) ^ _y;
      }
    }

    public static bool operator ==(Position? left, Position? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Position? left, Position? right)
    {
      return !Equals(left, right);
    }
  }
}