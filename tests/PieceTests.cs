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
    public void CanMoveDiagonally()
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, 2)));
    }

    /// <summary>
    ///   Asserts that the bishop can move diagonally.
    /// </summary>
    [Test]
    public void CanMoveDiagonally2()
    {
      var moves = _bishop.ValidMove(new Position(3, 3));
      Assert.That(moves, Has.Member(new Position(4, 2)));
    }
    
    /// <summary>
    ///   Asserts that the bishop cannot move horizontally.
    /// </summary>
    [Test]
    public void CannotMoveHorizontally()
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(2, 0)));
    }

    /// <summary>
    ///   Asserts that the bishop cannot move vertically.
    /// </summary>
    [Test]
    public void CannotMoveVertically()
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(0, 2)));
    }
    
    [Test]
    public void CannotMoveUpLeft()
    {
      var moves = _bishop.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(-1, 2)));
    }
  }

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
    public void CanMoveHorizontally()
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, 0)));
    }

    [Test]
    public void CanMoveHorizontally2()
    {
      var moves = _rook.ValidMove(new Position(7, 7));
      Assert.That(moves, Has.Member(new Position(0, 7)));
    }


    [Test]
    public void CanMoveVertically()
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(0, 2)));
    }
    
    [Test]
    public void CanMoveVertically2()
    {
      var moves = _rook.ValidMove(new Position(7, 7));
      Assert.That(moves, Has.Member(new Position(7, 0)));
    }

    [Test]
    public void CannotMoveDiagonally()
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(2, 2)));
    }
    
    [Test]
    public void CannotMoveUpLeft()
    {
      var moves = _rook.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(-1, 2)));
    }
  }

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
    public void CanMoveUpLeft()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(-1, 2)));
    }
    
    [Test]
    public void CanMoveUpRight()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(1, 2)));
    }
    
    [Test]
    public void CanMoveDownLeft()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(-1, -2)));
    }
    
    [Test]
    public void CanMoveDownRight()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(1, -2)));
    }
    
    [Test]
    public void CanMoveRightUp()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, 1)));
    }
    
    [Test]
    public void CanMoveRightDown()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, -1)));
    }
    
    [Test]
    public void CanMoveLeftUp()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(-2, 1)));
    }
    
    [Test]
    public void CanMoveLeftDown()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(-2, -1)));
    }    
    
    [Test]
    public void CannotMoveVertically()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(0, 2)));
    }
    
    [Test]
    public void CannotMoveHorizontally()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(2, 0)));
    }
    
    [Test]
    public void CannotMoveDiagonally()
    {
      var moves = _knight.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(2, 2)));
    }
  }

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
    public void CanMoveHorizontally()
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, 0)));
    }
    
    [Test]
    public void CanMoveHorizontally2()
    {
      var moves = _queen.ValidMove(new Position(7, 7));
      Assert.That(moves, Has.Member(new Position(0, 7)));
    }
    
    [Test]
    public void CanMoveVertically()
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(0, 2)));
    }
    
    [Test]
    public void CanMoveVertically2()
    {
      var moves = _queen.ValidMove(new Position(7, 7));
      Assert.That(moves, Has.Member(new Position(7, 0)));
    }
    
    [Test]
    public void CanMoveDiagonally()
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.Member(new Position(2, 2)));
    }
    
    [Test]
    public void CanMoveDiagonally2()
    {
      var moves = _queen.ValidMove(new Position(3, 3));
      Assert.That(moves, Has.Member(new Position(4, 2)));
    }
    
    [Test]
    public void CannotMoveUpLeft()
    {
      var moves = _queen.ValidMove(new Position(0, 0));
      Assert.That(moves, Has.No.Member(new Position(-1, 2)));
    }
  }
}