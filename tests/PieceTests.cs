using chess.Models;
using NUnit.Framework;

namespace tests
{
  /// <summary>
  ///   Tests bishop movement.
  /// </summary>
  [TestFixture]
  public class BishopTests
  {
    /// <summary>
    ///   Initializes the bishop for each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
      _bishop = new Bishop(Colour.White);
    }

    private Bishop _bishop;

    /// <summary>
    ///   Asserts that the bishop can move diagonally.
    /// </summary>
    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CanMoveDiagonally(int x, int y)
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    /// <summary>
    ///   Asserts that the bishop cannot move horizontally.
    /// </summary>
    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CannotMoveHorizontally(int x, int y)
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    /// <summary>
    ///   Asserts that the bishop cannot move vertically.
    /// </summary>
    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CannotMoveVertically(int x, int y)
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    public void CannotMoveUpLeft()
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(-1, 2)));
    }
  }

  /// <summary>
  ///   Tests rook movement.
  /// </summary>
  [TestFixture]
  public class RookTests
  {
    [SetUp]
    public void Setup()
    {
      _rook = new Rook(Colour.White);
    }

    private Rook _rook;

    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CanMoveHorizontally(int x, int y)
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CanMoveVertically(int x, int y)
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CannotMoveDiagonally(int x, int y)
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }
  }

  /// <summary>
  ///   Tests knight movement.
  /// </summary>
  [TestFixture]
  public class KnightTests
  {
    [SetUp]
    public void Setup()
    {
      _knight = new Knight(Colour.White);
    }

    private Knight _knight;

    [Test]
    [TestCase(-1, 2)]
    [TestCase(1, 2)]
    [TestCase(2, 1)]
    [TestCase(2, -1)]
    [TestCase(1, -2)]
    [TestCase(-1, -2)]
    [TestCase(-2, -1)]
    [TestCase(-2, 1)]
    public void CanMoveInL(int x, int y)
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CannotMoveHorizontally(int x, int y)
    {
    }

    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CannotMoveVertically(int x, int y)
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CannotMoveDiagonally(int x, int y)
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }
  }

  /// <summary>
  ///   Tests queen movement.
  /// </summary>
  [TestFixture]
  public class QueenTests
  {
    [SetUp]
    public void Setup()
    {
      _queen = new Queen(Colour.White);
    }

    private Queen _queen;

    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CanMoveHorizontally(int x, int y)
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CanMoveVertically(int x, int y)
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CanMoveDiagonally(int x, int y)
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    public void CannotMoveUpLeft()
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(-1, 2)));
    }
  }

  /// <summary>
  ///   Tests king movement.
  /// </summary>
  [TestFixture]
  public class KingTests
  {
    [SetUp]
    public void Setup()
    {
      _king = new King(Colour.White);
    }

    private King _king;

    [Test]
    [TestCase(1, 1)]
    [TestCase(1, 0)]
    [TestCase(1, -1)]
    [TestCase(0, 1)]
    [TestCase(0, -1)]
    [TestCase(-1, 1)]
    [TestCase(-1, 0)]
    [TestCase(-1, -1)]
    public void CanMoveByOne(int x, int y)
    {
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(2, 0)]
    [TestCase(-2, 0)]
    public void CanMoveHorizontallyByTwo(int x, int y)
    {
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(2, 0)]
    [TestCase(-2, 0)]
    public void CannotMoveHorizontallyByTwoIfMoved(int x, int y)
    {
      _king.Moved();
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }


    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CannotMoveHorizontally(int x, int y)
    {
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CannotMoveVertically(int x, int y)
    {
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CannotMoveDiagonally(int x, int y)
    {
      var moves = _king.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }
  }

  [TestFixture]
  public class PawnTests
  {
    [SetUp]
    public void Setup()
    {
      _pawn = new Pawn(Colour.White);
    }

    private Pawn _pawn;

    [Test]
    public void CanMoveForward()
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(0, 1)));
    }

    [Test]
    public void CanMoveForwardByTwo()
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(0, 2)));
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(-1, 1)]
    public void CanMoveForwardDiagonally(int x, int y)
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    public void CannotMoveForwardByTwoIfMoved()
    {
      _pawn.Moved();
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(0, 2)));
    }

    [Test]
    [TestCase(4, 0)]
    [TestCase(-4, 0)]
    public void CannotMoveHorizontally(int x, int y)
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(0, 4)]
    [TestCase(0, -4)]
    public void CannotMoveVertically(int x, int y)
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }

    [Test]
    [TestCase(4, 4)]
    [TestCase(-4, 4)]
    [TestCase(4, -4)]
    [TestCase(-4, -4)]
    public void CannotMoveDiagonally(int x, int y)
    {
      var moves = _pawn.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(x, y)));
    }
  }
}